using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Users_UserHomepage : System.Web.UI.MasterPage
{
    String connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlMeta tag = new HtmlMeta();
        tag.Name = "title";
        tag.Content = "This is the Title";
        Page.Header.Controls.Add(tag);

        HtmlMeta tag2 = new HtmlMeta();
        tag.Name = "description";
        tag.Content = "This is a short summary of the page.";
        Page.Header.Controls.Add(tag2);

        if (Session["Nickname"] != null)
        {
            if (Session["Redatore"] != null)
            {
                if (bool.Parse(Session["Redatore"].ToString()))
                {
                    btnEditor.Visible = true;
                    btnGestione.Visible = true;
                }
            }
            btnAccedi.Visible = false;
            lblUser.Visible = true;
            btnLogout.Visible = true;
            lblUser.Text = Session["Nickname"].ToString();
        }
        else
        {
            btnAccedi.Visible = true;
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session["Nickname"] = null;
        Session["Redatore"] = null;
        Response.Redirect("~/Homepage.aspx");
    }

    protected void Item_Click(object sender, EventArgs e)
    {

        String s = ((LinkButton)sender).Text;
        String query = "SELECT * FROM Categoria WHERE Nome = @cont";

        try
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add("@cont", SqlDbType.VarChar);
            command.Parameters["@cont"].Value = s;
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int i = (int)reader["Id"];
            string n = (String)reader["Nome"];
            Response.Redirect("~/Categoria.aspx?Cat=" + i);
        }
        catch { }
    }
    protected void btnEditor_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Users/Editor.aspx");
    }
    protected void btnGestione_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Users/Gestione.aspx");
    }
    protected void btnAccedi_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Accedi.aspx");
    }
}
