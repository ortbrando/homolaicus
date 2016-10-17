using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ricerca : System.Web.UI.Page
{
    String connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ToString();
    string input;

    protected void Page_Load(object sender, EventArgs e)
    {
        input =  Request.QueryString["search"];
        if (String.IsNullOrWhiteSpace(input))
        {
            Response.Redirect("Libri.aspx");
        }
        textInput.Text = input;
        bindResults();
    }

    protected void bindResults()
    {
        String query = "SELECT * FROM Libro WHERE Indice LIKE '%'+ @cont + '%'";

        try
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add("@cont", SqlDbType.VarChar);
            command.Parameters["@cont"].Value = input;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            resultRepeater.DataSource = dt;
            resultRepeater.DataBind();
        }
        catch { }
    }
}