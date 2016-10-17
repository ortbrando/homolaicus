using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Libri : System.Web.UI.Page
{
    String connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        bindTable();
    }

    protected void bindTable(){

        String query = "SELECT * FROM Libro ORDER BY Numero DESC";

        try
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            booksRepeater.DataSource = dt;
            booksRepeater.DataBind();
        }
        catch { }
    }
    protected void searchButton_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrWhiteSpace(searchTb.Text))
        {
            Response.Redirect("RicercaLibri.aspx?search=" + searchTb.Text);
        }
        else
        {
            searchButton.Enabled = false;
        }
    }
}