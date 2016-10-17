using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Services_Gestione : System.Web.UI.Page
{
    String connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            populateGroup(ddl1, ddl2, false, null);
            populateGroup(ddl3, ddl4, true, ddl5);
            populateSingle(ddl6, "Categoria");
            populateGroup(ddl7, ddl8, false, null);
            populateGroup(ddlEliminaCat, ddlEliminaSub, true, ddlEliminaArg);
            populateGroup(ddlEliminaCat1, ddlEliminaSub1, false, null);
            populateGroup(ddlEliminaCat2, ddlEliminaSub2, true, ddlEliminaArg2);
        }
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
            lbl1.Text = "Error";
        }
    }

    protected void populateGroup(DropDownList ddl, DropDownList ddlFollow, bool arg, DropDownList ddlArg)
    {
        ddl.AppendDataBoundItems = true;
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("-Categoria-", "-1"));
        ddlFollow.Items.Add(new ListItem("-Sottocategoria-", "-1"));
        if (arg)
        {
            ddlArg.Items.Add(new ListItem("-Argomento-", "-1"));
        }
        String querySubcat = "SELECT Id, Nome FROM Categoria";
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

    protected void editSubcat(object sender, EventArgs e)
    {
        String query = "UPDATE Sottocategoria SET Nome = @name WHERE Id=@id";
        SqlConnection conn = new SqlConnection(connectionString);

        try
        {
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add("@name", SqlDbType.VarChar);
            command.Parameters["@name"].Value = tb1.Text;
            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = ddl2.SelectedItem.Value;
            if (command.ExecuteNonQuery() > 0)
            {
                lbl1.ForeColor = System.Drawing.Color.Green;
                lbl1.Text = "Sottocategoria modificata correttamente!";
                ddl1.Items.Clear();
                ddl2.Items.Clear();
                populateGroup(ddl1, ddl2, false, null);
            }
        }
        catch { }
        finally
        {
            conn.Close();
        }
    }

    protected void editArgument(object sender, EventArgs e)
    {
        String query = "UPDATE Argomento SET Nome = @name WHERE Id=@id";
        SqlConnection conn = new SqlConnection(connectionString);

        try
        {
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add("@name", SqlDbType.VarChar);
            command.Parameters["@name"].Value = tb2.Text;
            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = ddl5.SelectedItem.Value;
            if (command.ExecuteNonQuery() > 0)
            {
                lbl2.ForeColor = System.Drawing.Color.Green;
                lbl2.Text = "Argomento modificato correttamente!";
                ddl3.Items.Clear();
                ddl4.Items.Clear();
                ddl5.Items.Clear();
                populateGroup(ddl3, ddl4, true, ddl5);
            }
        }
        catch { }
        finally
        {
            conn.Close();
        }

    }

    protected void addSubcat(object sender, EventArgs e)
    {
        String query = "INSERT INTO Sottocategoria (Nome, IdCategoria) VALUES (@name , @id)";
        SqlConnection conn = new SqlConnection(connectionString);

        try
        {
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add("@name", SqlDbType.VarChar);
            command.Parameters["@name"].Value = tb3.Text;
            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = ddl6.SelectedItem.Value;
            if (command.ExecuteNonQuery() > 0)
            {
                lbl3.ForeColor = System.Drawing.Color.Green;
                lbl3.Text = "Sottocategoria aggiunta correttamente!";
                ddl6.Items.Clear();
                tb3.Text = "";
                populateSingle(ddl6, "Categoria");
            }
        }
        catch { }
        finally
        {
            conn.Close();
        }
    }

    protected void addArgument(object sender, EventArgs e)
    {
        String query = "INSERT INTO Argomento (Nome, IdSottocategoria, Data) VALUES (@name , @id, @date)";
        SqlConnection conn = new SqlConnection(connectionString);

        try
        {
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add("@name", SqlDbType.VarChar);
            command.Parameters["@name"].Value = tb4.Text;
            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = ddl8.SelectedItem.Value;
            command.Parameters.Add("@date", SqlDbType.Date);
            command.Parameters["@date"].Value = DateTime.Now;
            if (command.ExecuteNonQuery() > 0)
            {
                lbl4.ForeColor = System.Drawing.Color.Green;
                lbl4.Text = "Argomento aggiunto correttamente!";
                ddl7.Items.Clear();
                ddl8.Items.Clear();
                tb4.Text = "";
                populateGroup(ddl7, ddl8, false, null);
            }
        }
        catch { }
        finally
        {
            conn.Close();
        }
    }

    protected void populateSubcatParam(object sender, EventArgs e)
    {
        ddl4.AppendDataBoundItems = true;
        ddl4.Items.Clear();
        ddl5.AppendDataBoundItems = true;
        ddl5.Items.Clear();
        String querySubcat = "SELECT Id, Nome FROM Sottocategoria WHERE IdCategoria = @id";
        String queryArgument = "SELECT Id, Nome FROM Argomento WHERE IdSottocategoria = @idS";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand();
        command.Parameters.Add("@id", SqlDbType.Int);
        command.Parameters["@id"].Value = ddl3.SelectedItem.Value;
        command.CommandType = CommandType.Text;
        command.CommandText = querySubcat;
        command.Connection = conn;


        if (int.Parse(ddl3.SelectedItem.Value) > 0)
        {
            conn.Open();
            ddl4.DataSource = command.ExecuteReader();
            ddl4.DataTextField = "Nome";
            ddl4.DataValueField = "Id";
            ddl4.DataBind();
            conn.Close();

            if (ddl4.SelectedItem != null)
            {
                if (int.Parse(ddl3.SelectedItem.Value) > 0 && int.Parse(ddl4.SelectedItem.Value) > 0)
                {
                    conn.Open();
                    SqlCommand command2 = new SqlCommand();
                    command2.Parameters.Add("@idS", SqlDbType.Int);
                    command2.Parameters["@idS"].Value = ddl4.SelectedItem.Value;
                    command2.CommandType = CommandType.Text;
                    command2.CommandText = queryArgument;
                    command2.Connection = conn;
                    ddl5.DataSource = command2.ExecuteReader();
                    ddl5.DataTextField = "Nome";
                    ddl5.DataValueField = "Id";
                    ddl5.DataBind();
                }
            }
        }
        else
        {
            ddl4.Items.Add(new ListItem("-Sottocategoria-", "-1"));
            ddl5.Items.Add(new ListItem("-Argomento-", "-1"));
        }
    }

    protected void populateArgumentParam(object sender, EventArgs e)
    {
        ddl5.AppendDataBoundItems = true;
        ddl5.Items.Clear();
        String querySubcat = "SELECT Id, Nome FROM Argomento WHERE IdSottocategoria = @id";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand();
        command.Parameters.Add("@id", SqlDbType.Int);
        command.Parameters["@id"].Value = ddl4.SelectedItem.Value;
        command.CommandType = CommandType.Text;
        command.CommandText = querySubcat;
        command.Connection = conn;

        if (int.Parse(ddl4.SelectedItem.Value) > 0)
        {
            conn.Open();
            ddl5.DataSource = command.ExecuteReader();
            ddl5.DataTextField = "Nome";
            ddl5.DataValueField = "Id";
            ddl5.DataBind();
        }
        else
        {
            ddl5.Items.Add(new ListItem("-Argomento-", "-1"));
        }
    }

    protected void populateSubcatParam1(object sender, EventArgs e)
    {
        ddl2.AppendDataBoundItems = true;
        ddl2.Items.Clear();
        String querySubcat = "SELECT Id, Nome FROM Sottocategoria WHERE IdCategoria = @id";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand();
        command.Parameters.Add("@id", SqlDbType.Int);
        command.Parameters["@id"].Value = ddl1.SelectedItem.Value;
        command.CommandType = CommandType.Text;
        command.CommandText = querySubcat;
        command.Connection = conn;

        if (int.Parse(ddl1.SelectedItem.Value) > 0)
        {
            conn.Open();
            ddl2.DataSource = command.ExecuteReader();
            ddl2.DataTextField = "Nome";
            ddl2.DataValueField = "Id";
            ddl2.DataBind();
        }
        else
        {
            ddl2.Items.Add(new ListItem("-Sottocategoria-", "-1"));
        }
    }

    protected void populateSubcatParam2(object sender, EventArgs e)
    {
        ddl8.AppendDataBoundItems = true;
        ddl8.Items.Clear();
        String querySubcat = "SELECT Id, Nome FROM Sottocategoria WHERE IdCategoria = @id";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand();
        command.Parameters.Add("@id", SqlDbType.Int);
        command.Parameters["@id"].Value = ddl7.SelectedItem.Value;
        command.CommandType = CommandType.Text;
        command.CommandText = querySubcat;
        command.Connection = conn;

        if (int.Parse(ddl7.SelectedItem.Value) > 0)
        {
            conn.Open();
            ddl8.DataSource = command.ExecuteReader();
            ddl8.DataTextField = "Nome";
            ddl8.DataValueField = "Id";
            ddl8.DataBind();
        }
        else
        {
            ddl8.Items.Add(new ListItem("-Sottocategoria-", "-1"));
        }
    }

    protected void UploadButton_Click(object sender, EventArgs e)
    {
       
        if (FileUploadControl.HasFile)
        {
            try
            {
                 using (WebClient client = new WebClient())
        {
            string filename = Path.GetFileName(FileUploadControl.FileName);
            client.Credentials = new NetworkCredential("5007264@aruba.it", "6eu3eyym14");
            client.UploadFile("ftp://informaticami.com/public/", "STOR", filename);
        }
                //FileUploadControl.PostedFile.SaveAs(Server.MapPath("~/homolaicus/images/") + filename);
                StatusLabel.Text = "Upload status: File uploaded!";
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }
    }
    protected void ddlEliminaCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlEliminaSub.AppendDataBoundItems = true;
        ddlEliminaSub.Items.Clear();
        ddlEliminaArg.AppendDataBoundItems = true;
        ddlEliminaArg.Items.Clear();
        String querySubcat = "SELECT Id, Nome FROM Sottocategoria WHERE IdCategoria = @id";
        String queryArgument = "SELECT Id, Nome FROM Argomento WHERE IdSottocategoria = @idS";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand();
        command.Parameters.Add("@id", SqlDbType.Int);
        command.Parameters["@id"].Value = ddlEliminaCat.SelectedItem.Value;
        command.CommandType = CommandType.Text;
        command.CommandText = querySubcat;
        command.Connection = conn;


        if (int.Parse(ddlEliminaCat.SelectedItem.Value) > 0)
        {
            conn.Open();
            ddlEliminaSub.DataSource = command.ExecuteReader();
            ddlEliminaSub.DataTextField = "Nome";
            ddlEliminaSub.DataValueField = "Id";
            ddlEliminaSub.DataBind();
            conn.Close();

            if (ddlEliminaSub.SelectedItem != null)
            {
                if (int.Parse(ddlEliminaCat.SelectedItem.Value) > 0 && int.Parse(ddlEliminaSub.SelectedItem.Value) > 0)
                {
                    conn.Open();
                    SqlCommand command2 = new SqlCommand();
                    command2.Parameters.Add("@idS", SqlDbType.Int);
                    command2.Parameters["@idS"].Value = ddlEliminaSub.SelectedItem.Value;
                    command2.CommandType = CommandType.Text;
                    command2.CommandText = queryArgument;
                    command2.Connection = conn;
                    ddlEliminaArg.DataSource = command2.ExecuteReader();
                    ddlEliminaArg.DataTextField = "Nome";
                    ddlEliminaArg.DataValueField = "Id";
                    ddlEliminaArg.DataBind();
                }
            }
        }
        else
        {
            ddlEliminaSub.Items.Add(new ListItem("-Sottocategoria-", "-1"));
            ddlEliminaArg.Items.Add(new ListItem("-Argomento-", "-1"));
        }
    }
    protected void ddlEliminaSub_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlEliminaArg.AppendDataBoundItems = true;
        ddlEliminaArg.Items.Clear();
        String querySubcat = "SELECT Id, Nome FROM Argomento WHERE IdSottocategoria = @id";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand();
        command.Parameters.Add("@id", SqlDbType.Int);
        command.Parameters["@id"].Value = ddlEliminaSub.SelectedItem.Value;
        command.CommandType = CommandType.Text;
        command.CommandText = querySubcat;
        command.Connection = conn;

        if (int.Parse(ddlEliminaSub.SelectedItem.Value) > 0)
        {
            conn.Open();
            ddlEliminaArg.DataSource = command.ExecuteReader();
            ddlEliminaArg.DataTextField = "Nome";
            ddlEliminaArg.DataValueField = "Id";
            ddlEliminaArg.DataBind();
        }
        else
        {
            ddlEliminaArg.Items.Add(new ListItem("-Argomento-", "-1"));
        }

    }
    protected void ddlEliminaCat1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlEliminaSub1.AppendDataBoundItems = true;
        ddlEliminaSub1.Items.Clear();
        String querySubcat = "SELECT Id, Nome FROM Sottocategoria WHERE IdCategoria = @id";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand();
        command.Parameters.Add("@id", SqlDbType.Int);
        command.Parameters["@id"].Value = ddlEliminaCat1.SelectedItem.Value;
        command.CommandType = CommandType.Text;
        command.CommandText = querySubcat;
        command.Connection = conn;

        if (int.Parse(ddlEliminaCat1.SelectedItem.Value) > 0)
        {
            conn.Open();
            ddlEliminaSub1.DataSource = command.ExecuteReader();
            ddlEliminaSub1.DataTextField = "Nome";
            ddlEliminaSub1.DataValueField = "Id";
            ddlEliminaSub1.DataBind();
        }
        else
        {
            ddlEliminaSub1.Items.Add(new ListItem("-Sottocategoria-", "-1"));
        }
    }

    protected void ddlEliminaCat2_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlEliminaSub2.AppendDataBoundItems = true;
        ddlEliminaSub2.Items.Clear();
        ddlEliminaArg2.AppendDataBoundItems = true;
        ddlEliminaArg2.Items.Clear();
        String querySubcat = "SELECT Id, Nome FROM Sottocategoria WHERE IdCategoria = @id";
        String queryArgument = "SELECT Id, Nome FROM Argomento WHERE IdSottocategoria = @idS";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand();
        command.Parameters.Add("@id", SqlDbType.Int);
        command.Parameters["@id"].Value = ddlEliminaCat2.SelectedItem.Value;
        command.CommandType = CommandType.Text;
        command.CommandText = querySubcat;
        command.Connection = conn;


        if (int.Parse(ddlEliminaCat2.SelectedItem.Value) > 0)
        {
            conn.Open();
            ddlEliminaSub2.DataSource = command.ExecuteReader();
            ddlEliminaSub2.DataTextField = "Nome";
            ddlEliminaSub2.DataValueField = "Id";
            ddlEliminaSub2.DataBind();
            conn.Close();

            if (ddlEliminaSub2.SelectedItem != null)
            {
                if (int.Parse(ddlEliminaCat2.SelectedItem.Value) > 0 && int.Parse(ddlEliminaSub2.SelectedItem.Value) > 0)
                {
                    conn.Open();
                    SqlCommand command2 = new SqlCommand();
                    command2.Parameters.Add("@idS", SqlDbType.Int);
                    command2.Parameters["@idS"].Value = ddlEliminaSub2.SelectedItem.Value;
                    command2.CommandType = CommandType.Text;
                    command2.CommandText = queryArgument;
                    command2.Connection = conn;
                    ddlEliminaArg2.DataSource = command2.ExecuteReader();
                    ddlEliminaArg2.DataTextField = "Nome";
                    ddlEliminaArg2.DataValueField = "Id";
                    ddlEliminaArg2.DataBind();
                }
            }
        }
        else
        {
            ddlEliminaSub2.Items.Add(new ListItem("-Sottocategoria-", "-1"));
            ddlEliminaArg2.Items.Add(new ListItem("-Argomento-", "-1"));
        }
    }

    protected void ddlEliminaSub2_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlEliminaArg2.AppendDataBoundItems = true;
        ddlEliminaArg2.Items.Clear();
        String querySubcat = "SELECT Id, Nome FROM Argomento WHERE IdSottocategoria = @id";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand();
        command.Parameters.Add("@id", SqlDbType.Int);
        command.Parameters["@id"].Value = ddlEliminaSub2.SelectedItem.Value;
        command.CommandType = CommandType.Text;
        command.CommandText = querySubcat;
        command.Connection = conn;

        if (int.Parse(ddlEliminaSub2.SelectedItem.Value) > 0)
        {
            conn.Open();
            ddlEliminaArg2.DataSource = command.ExecuteReader();
            ddlEliminaArg2.DataTextField = "Nome";
            ddlEliminaArg2.DataValueField = "Id";
            ddlEliminaArg2.DataBind();
        }
        else
        {
            ddlEliminaArg2.Items.Add(new ListItem("-Argomento-", "-1"));
        }
    }
    protected void btnEliminaSub_Click(object sender, EventArgs e)
    {

    }
    protected void btnEliminaArg_Click(object sender, EventArgs e)
    {

    }
    protected void btnEliminaSez_Click(object sender, EventArgs e)
    {

    }
}