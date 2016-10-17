using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Categoria : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ToString();
    string idCat;
    string nome;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            
            idCat = Request.QueryString["Cat"];
            if (idCat == null)
            {
                Response.Redirect("Homepage.aspx");
            }
            nome = Request.QueryString["Nome"];
            String query = "SELECT * FROM Sottocategoria WHERE IdCategoria = @cont";

            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add("@cont", SqlDbType.VarChar);
                command.Parameters["@cont"].Value = idCat;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                repeater.DataSource = dt;
                repeater.DataBind();
            }
            catch { }
        }

        
    }

    protected void repeater_ItemDataBound1(object sender, RepeaterItemEventArgs e)
    {
        String query = "SELECT * FROM Argomento WHERE IdSottocategoria = @cont";

        try
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add("@cont", SqlDbType.VarChar);
            string idSottocategoria = (e.Item.FindControl("hidden") as HiddenField).Value;
            command.Parameters["@cont"].Value = idSottocategoria;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Repeater r = e.Item.FindControl("child") as Repeater;
            r.DataSource = dt;
            r.DataBind();

        }
        catch { }
    }

    protected void openArgument(object sender, EventArgs e)
    {
        String s = ((LinkButton)sender).CommandArgument;       
        Response.Redirect("Argomento.aspx?Arg=" + s);
        
    }
    protected void searchButton_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrWhiteSpace(searchTb.Text))
        {
            Response.Redirect("RicercaArticoli.aspx?search=" + searchTb.Text);
        }
        else
        {
            searchButton.Enabled = false;
        }

    }
}