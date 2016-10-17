using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Conferma : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        string code = Request.QueryString["value"];
        if (!(code == null))
        {
            if (!code.Equals("0"))
            {
                string nick = checkCode(code);
                if (!nick.Equals(""))
                {
                    resetCode(nick);
                    lblConfirm.Text = "Account attivato con successo!";
                    Session["Nickname"] = nick;
                }
                else
                {
                    lblConfirm.ForeColor = System.Drawing.Color.Red;
                    lblConfirm.Text = "Errore nel processo di conferma dell'account";
                }
            }
            else
            {
                lblConfirm.ForeColor = System.Drawing.Color.Red;
                lblConfirm.Text = "Errore nel processo di conferma dell'account";
            }
        }
        else
        {
            lblConfirm.ForeColor = System.Drawing.Color.Red;
            lblConfirm.Text = "Errore nel processo di conferma dell'account";
        }
        
        
    }

    protected string checkCode(string code)
    {
        string query = "SELECT Nickname FROM Utente WHERE CodiceTemporaneo = @Codice ";

        try
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add("@Codice", SqlDbType.NChar);
            command.Parameters["@Codice"].Value = code;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                return reader["Nickname"].ToString();
            }
            
        }
        catch (Exception e1)
        {
            return "";
        }
        return "";
    }

    protected void resetCode(string nickname)
    {
        string query = "UPDATE Utente SET CodiceTemporaneo = 0000000000 WHERE Nickname = @Nickname";

        try
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add("@Nickname", SqlDbType.VarChar);
            command.Parameters["@Nickname"].Value = nickname;
            command.ExecuteNonQuery();
        }
        catch (Exception e2)
        {
            
        }
    }
}