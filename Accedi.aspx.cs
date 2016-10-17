using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Accedi : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAccedi_Click(object sender, EventArgs e)
    {
        string hash = md5(tbPassword.Text);
        String query = "SELECT * FROM Utente WHERE Nickname = @Nickname";

        try
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add("@Nickname", SqlDbType.VarChar);
            command.Parameters["@Nickname"].Value = tbNickname.Text;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["Password"].ToString().Equals(hash))
                {
                    Session["Nickname"] = tbNickname.Text;
                    Session["Redatore"] = reader.GetBoolean(2);
                    Response.Redirect("Homepage.aspx");
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