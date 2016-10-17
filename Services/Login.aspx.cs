using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_ID"] != null)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }

    protected void login(object sender, EventArgs e)
    {
        string hash = md5(InputPassword.Text);
        string connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ToString();
        String query = "SELECT Password FROM Admins WHERE Username = @indirizzo";

        try
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add("@indirizzo", SqlDbType.VarChar);
            command.Parameters["@indirizzo"].Value = InputEmail.Text;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["Password"].ToString() == hash)
                {
                    Session["USER_ID"] = InputEmail.Text;
                    Response.Redirect("Dashboard.aspx");
                }

            }
            lblError.Text = "Username o password errati";

        }
        catch (Exception e1)
        { e1.ToString(); }
    }

    private string md5(string sPassword)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] bs = System.Text.Encoding.UTF8.GetBytes(sPassword);
        bs = x.ComputeHash(bs);
        System.Text.StringBuilder s = new System.Text.StringBuilder();
        foreach (byte b in bs)
        {
            s.Append(b.ToString("x2").ToLower());
        }
        return s.ToString();
    }
  
}