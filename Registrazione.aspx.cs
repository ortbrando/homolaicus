using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registrazione : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ToString();
    string temp = "";
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Registrati_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrWhiteSpace(Username.Text))
        {
            lblError.Text = "Inserisci un Username valido";
        }
        else if (String.IsNullOrWhiteSpace(Email.Text))
        {
            lblError.Text = "Inserisci una Email valida";
        }
        else if (Password.Text.Length < 8)
        {
            lblError.Text = "Inserisci una Password di almeno 8 caratteri";
        } 
        else if (!Password.Text.Equals(CheckPassword.Text))
        {
            lblError.Text = "Le Password non coincidono";
        }
        else
        {
            if (checkUsernameEmail() == 2)
            {
                try
                {
                    string queryInsert = "INSERT INTO Utente VALUES (@Username, @Email, @Redatore, @Immagine, @Codice, @Password)";
                    SqlConnection conn = new SqlConnection(connectionString);
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand(queryInsert, conn);
                    command.Parameters.Add("@Username", SqlDbType.VarChar);
                    command.Parameters["@Username"].Value = Username.Text;
                    command.Parameters.Add("@Email", SqlDbType.VarChar);
                    command.Parameters["@Email"].Value = Email.Text;
                    command.Parameters.Add("@Redatore", SqlDbType.Bit);
                    command.Parameters["@Redatore"].Value = 0;
                    command.Parameters.Add("@Immagine", SqlDbType.VarChar);
                    command.Parameters["@Immagine"].Value = "http://yourownroom.com/images/userDefault.jpg";
                    command.Parameters.Add("@Codice", SqlDbType.NChar);
                    temp = RNGCharacterMask();
                    command.Parameters["@Codice"].Value = temp;
                    command.Parameters.Add("@Password", SqlDbType.NChar);
                    command.Parameters["@Password"].Value = md5(Password.Text);
                    command.ExecuteNonQuery();
                    confirmMail(temp);
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Per attivare il tuo account, controlla la mail di conferma che ti abbiamo inviato.";
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.ToString();
                }
            }
        }
    }

    protected void confirmMail(string code)
    {
        SmtpClient smtpClient = new SmtpClient("smtp.aruba.it", 25);
        smtpClient.Credentials = new System.Net.NetworkCredential("newsletter@homolaicus.com", "Fct20142014");
        smtpClient.UseDefaultCredentials = true;
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        MailMessage mail = new MailMessage();
        mail.Body = "Grazie per esserti registrato a homolaicus.com ! \n\n Il tuo profilo non è ancora attivo, ma puoi attivarlo cliccando sul link sottostante: \n\n" + "www.homolaicus.com/nuovo/Conferma.aspx?value=" + code;
        mail.Subject = "Conferma la registrazione homolaicus.com ";
        //Setting From , To and CC
        mail.From = new MailAddress("newsletter@homolaicus.com");
        mail.To.Add(new MailAddress(Email.Text));
        smtpClient.Send(mail);
    }

    /*  0 -> Username Exists
        1 -> Email Exists
        2 -> OK
     */
    protected int checkUsernameEmail()
    {
        string queryCheck = "IF EXISTS(SELECT Nickname FROM Utente WHERE Nickname = @Username) BEGIN SELECT -1 END ELSE IF EXISTS(SELECT Nickname FROM Utente WHERE Email = @Email) BEGIN SELECT -2 END ELSE BEGIN SELECT -3 END ";

        try
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand(queryCheck, conn);
            command.Parameters.Add("@Username", SqlDbType.VarChar);
            command.Parameters["@Username"].Value = Username.Text;
            command.Parameters.Add("@Email", SqlDbType.VarChar);
            command.Parameters["@Email"].Value = Email.Text;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int i = (int)reader[0];
                if (i == -1)
                {
                    lblError.Text = "Username non disponibile";
                    return 0;
                }
                else if (i == -2)
                {
                    lblError.Text = "Email già utilizzata da un altro utente";
                    return 1;
                }
                else if (i == -3)
                {
                    return 2;
                }
            }
        }
        catch (Exception e1)
        { lblError.Text = e1.ToString(); }
        return 3;

    }

    private string RNGCharacterMask()
    {
        int maxSize = 10;
        char[] chars = new char[62];
        string a;
        a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        chars = a.ToCharArray();
        int size = maxSize;
        byte[] data = new byte[1];
        RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
        crypto.GetNonZeroBytes(data);
        size = maxSize;
        data = new byte[size];
        crypto.GetNonZeroBytes(data);
        StringBuilder result = new StringBuilder(size);
        foreach (byte b in data)
        { result.Append(chars[b % (chars.Length - 1)]); }
        return result.ToString();
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