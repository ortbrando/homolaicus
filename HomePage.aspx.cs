using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomePage : System.Web.UI.Page
{
    String connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        populateSingle(catDdl, "Categoria");
    }

    protected void populateSingle(DropDownList ddl, String table)
    {
        if (table == "Categoria" || table == "Sottocategoria" || table == "Argomento")
        {
            ddl.AppendDataBoundItems = true;
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("-" + table + "-", "-1"));
            String querySubcat = "SELECT Id, Nome FROM " + table;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = querySubcat;
            command.Connection = conn;

            conn.Open();
            ddl.DataSource = command.ExecuteReader();
            ddl.DataTextField = "Nome";
            ddl.DataValueField = "Id";
            ddl.DataBind();
            conn.Close();
        }
        else
        {
        }
    }

    protected void PayPalBtn_Click(object sender, EventArgs e)
    {
        string business = "galarico@homolaicus.com";
        string itemName = "Homolaicus";
        string currencyCode = "EUR";

        StringBuilder ppHref = new StringBuilder();

        ppHref.Append("https://www.paypal.com/cgi-bin/webscr?cmd=_xclick");
        ppHref.Append("&business=" + business);
        ppHref.Append("&item_name=" + itemName);
        ppHref.Append("&currency_code=" + currencyCode);
        
        Response.Redirect(ppHref.ToString(), true);

    }

    protected void contact_Click(object sender, EventArgs e)
    {

        if (!nameTb.Text.Equals("") && !surnameTb.Text.Equals("") && !emailTb.Text.Equals("") && !txtMessage.Text.Equals(""))
        {
            string cat = "Nessuna";
            if (catDdl.SelectedItem != null)
            {
                cat = catDdl.SelectedItem.Text;
            }
            SmtpClient smtpClient = new SmtpClient("smtp.aruba.it", 25);

            smtpClient.Credentials = new System.Net.NetworkCredential("newsletter@homolaicus.com", "Fct20142014");
            smtpClient.UseDefaultCredentials = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage mail = new MailMessage();
            mail.Body = "Nome: " + nameTb.Text + "\nCognome: " + surnameTb.Text + "\nTelefono: " + phoneTb.Text + "\nE-Mail: " +
                emailTb.Text + "\nWebsite: " + websiteTb.Text + "\nSezione: " + cat + "\nMessaggio: " + txtMessage.Text;
            mail.Subject = "Contatto da Homolaicus.com";
            //Setting From , To and CC
            mail.From = new MailAddress("newsletter@homolaicus.com", "" + nameTb.Text + " " + surnameTb.Text);
            mail.To.Add(new MailAddress("info@homolaicus.com"));
            mail.CC.Add(new MailAddress("brando.mordenti@gmail.com"));

            smtpClient.Send(mail);

        }
    }

    protected void bindRecents()
    {
        String query = "SELECT TOP 3 Argomento FROM Libro ORDER BY Numero DESC";

        try
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            recentsRepeater.DataSource = dt;
            recentsRepeater.DataBind();
        }
        catch { }
    }
}