using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Adsclicked : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        string url = HttpContext.Current.Request.Url.PathAndQuery;
        url = string.Concat("~", url);
        int id = GetAdId(url);
        CountClick(id, url);
    }

    protected int GetAdId(string url)
    {
        String query = "SELECT ID FROM Ads WHERE NavigateUrl = @url";

        try
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add("@url", SqlDbType.NVarChar);
            command.Parameters["@url"].Value = url;
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader["ID"] != null)
                return (int)reader["ID"];

        }
        catch (Exception e1)
        {
            return 0;
        }
        finally { }
        return 0;

    }

    protected void CountClick(int id, string url)
    {
        string query = " IF exists (Select AdID FROM AdHits where AdID = @id) UPDATE ADHits SET Hits = Hits+1 where AdID = @id ELSE INSERT INTO ADHits values (@id,1)";

        try
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = id;
            command.ExecuteNonQuery();

            url = url.Replace("~/Adsclicked.aspx?url=", "http://");
            Response.Redirect(url);
            
        }
        catch (Exception e1)
        {
        }
    }
    
}