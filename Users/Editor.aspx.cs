﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_Editor : System.Web.UI.Page
{
    String connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            populateGroup(ddl1, ddl2, ddl3, ddl4);
        }

    }

    protected void populateGroup(DropDownList ddl1, DropDownList ddl2, DropDownList ddl3, DropDownList ddl4)
    {
        ddl1.AppendDataBoundItems = true;
        ddl1.Items.Clear();
        ddl2.AppendDataBoundItems = true;
        ddl2.Items.Clear();
        ddl3.AppendDataBoundItems = true;
        ddl3.Items.Clear();
        ddl1.Items.Add(new ListItem("-Categoria-", "-1"));
        ddl2.Items.Add(new ListItem("-Sottocategoria-", "-1"));
        ddl3.Items.Add(new ListItem("-Argomento-", "-1"));
        ddl4.Items.Add(new ListItem("-Sezione-", "-1"));
        String querySubcat = "SELECT Id, Nome FROM Categoria";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand();
        command.CommandType = CommandType.Text;
        command.CommandText = querySubcat;
        command.Connection = conn;

        conn.Open();
        ddl1.DataSource = command.ExecuteReader();
        ddl1.DataTextField = "Nome";
        ddl1.DataValueField = "Id";
        ddl1.DataBind();
        conn.Close();
    }

    protected void InsertSection(object sender, EventArgs e)
    {
        String query = "SELECT TOP 1 Posizione FROM Sezione WHERE IdArgomento=@idA ORDER BY Posizione DESC";
        String insertQuery = "INSERT INTO Sezione (Nome,HtmlCode, IdArgomento, Posizione) VALUES (@nome, @code, @id, @pos)";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand();
        int idArg = int.Parse(ddl3.SelectedItem.Value);
        command.CommandType = CommandType.Text;
        command.CommandText = query;
        command.Connection = conn;
        command.Parameters.Add("@idA", SqlDbType.Int);
        command.Parameters["@idA"].Value = idArg;
        conn.Open();
        SqlDataReader reader = command.ExecuteReader();
        int pos = 0;
        if (reader.Read())
        {
            pos = (int)reader["Posizione"] + 1;
        }
        conn.Close();
        SqlCommand insert = new SqlCommand();
        insert.CommandType = CommandType.Text;
        insert.CommandText = insertQuery;
        insert.Connection = conn;
        insert.Parameters.Add("@nome", SqlDbType.VarChar);
        insert.Parameters["@nome"].Value = tb1.Text;
        insert.Parameters.Add("@code", SqlDbType.VarChar);
        insert.Parameters["@code"].Value = CKEditor1.Text;
        insert.Parameters.Add("@id", SqlDbType.Int);
        insert.Parameters["@id"].Value = idArg;
        insert.Parameters.Add("@pos", SqlDbType.Int);
        insert.Parameters["@pos"].Value = pos;
        conn.Open();
        insert.ExecuteNonQuery();
        CKEditor1.Text = "";
        populateGroup(ddl1, ddl2, ddl3, ddl4);
    }

    protected void populateSubcatParam(object sender, EventArgs e)
    {
        ddl2.AppendDataBoundItems = true;
        ddl2.Items.Clear();
        ddl3.AppendDataBoundItems = true;
        ddl3.Items.Clear();
        ddl4.AppendDataBoundItems = true;
        ddl4.Items.Clear();

        String querySubcat = "SELECT Id, Nome FROM Sottocategoria WHERE IdCategoria = @id";
        String queryArgument = "SELECT Id, Nome FROM Argomento WHERE IdSottocategoria = @idS";
        String querySection = "SELECT Id, Nome, Posizione FROM Sezione WHERE IdArgomento = @idA ORDER BY Posizione ";
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
            conn.Close();

            if (ddl2.SelectedItem != null)
            {
                if (int.Parse(ddl2.SelectedItem.Value) > 0)
                {
                    conn.Open();
                    SqlCommand command2 = new SqlCommand();
                    command2.Parameters.Add("@idS", SqlDbType.Int);
                    command2.Parameters["@idS"].Value = ddl2.SelectedItem.Value;
                    command2.CommandType = CommandType.Text;
                    command2.CommandText = queryArgument;
                    command2.Connection = conn;
                    ddl3.DataSource = command2.ExecuteReader();
                    ddl3.DataTextField = "Nome";
                    ddl3.DataValueField = "Id";
                    ddl3.DataBind();
                    conn.Close();

                    if (ddl3.SelectedItem != null)
                    {
                        if (int.Parse(ddl3.SelectedItem.Value) > 0)
                        {
                            conn.Open();
                            SqlCommand command3 = new SqlCommand();
                            command3.Parameters.Add("@idA", SqlDbType.Int);
                            command3.Parameters["@idA"].Value = ddl3.SelectedItem.Value;
                            command3.CommandType = CommandType.Text;
                            command3.CommandText = querySection;
                            command3.Connection = conn;
                            ddl4.DataSource = command3.ExecuteReader();
                            ddl4.DataTextField = "Nome";
                            ddl4.DataValueField = "Id";
                            ddl4.DataBind();
                            conn.Close();
                        }
                    }
                }
            }
        }
        else
        {
            ddl2.Items.Add(new ListItem("-Sottocategoria-", "-1"));
            ddl3.Items.Add(new ListItem("-Argomento-", "-1"));
            ddl4.Items.Add(new ListItem("-Sezione-", "-1"));

        }

    }

    protected void populateArgumentParam(object sender, EventArgs e)
    {
        ddl3.AppendDataBoundItems = true;
        ddl3.Items.Clear();
        ddl4.AppendDataBoundItems = true;
        ddl4.Items.Clear();

        String queryArgument = "SELECT Id, Nome FROM Argomento WHERE IdSottocategoria = @id";
        String querySection = "SELECT Id, Nome, Posizione FROM Sezione WHERE IdArgomento = @idA ORDER BY Posizione";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand();
        command.Parameters.Add("@id", SqlDbType.Int);
        command.Parameters["@id"].Value = ddl2.SelectedItem.Value;
        command.CommandType = CommandType.Text;
        command.CommandText = queryArgument;
        command.Connection = conn;

        if (ddl2.SelectedItem != null)
        {
            if (int.Parse(ddl2.SelectedItem.Value) > 0)
            {
                conn.Open();
                ddl3.DataSource = command.ExecuteReader();
                ddl3.DataTextField = "Nome";
                ddl3.DataValueField = "Id";
                ddl3.DataBind();
                conn.Close();

                if (ddl3.SelectedItem != null)
                {
                    if (int.Parse(ddl3.SelectedItem.Value) > 0)
                    {
                        conn.Open();
                        SqlCommand command2 = new SqlCommand();
                        command2.Parameters.Add("@idA", SqlDbType.Int);
                        command2.Parameters["@idA"].Value = ddl3.SelectedItem.Value;
                        command2.CommandType = CommandType.Text;
                        command2.CommandText = querySection;
                        command2.Connection = conn;
                        ddl4.DataSource = command2.ExecuteReader();
                        ddl4.DataTextField = "Nome";
                        ddl4.DataValueField = "Id";
                        ddl4.DataBind();
                        conn.Close();
                    }
                }
            }
        }
        else
        {
            ddl3.Items.Add(new ListItem("-Argomento-", "-1"));
            ddl4.Items.Add(new ListItem("-Sezione-", "-1"));
        }


    }

    protected void populateSectionParam(object sender, EventArgs e)
    {
        ddl4.AppendDataBoundItems = true;
        ddl4.Items.Clear();
        String querySection = "SELECT Id, Nome, Posizione FROM Sezione WHERE IdArgomento = @idA ORDER BY Posizione";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand();
        command.Parameters.Add("@idA", SqlDbType.Int);
        command.Parameters["@idA"].Value = ddl3.SelectedItem.Value;
        command.CommandType = CommandType.Text;
        command.CommandText = querySection;
        command.Connection = conn;

        if (int.Parse(ddl3.SelectedItem.Value) > 0)
        {
            conn.Open();
            ddl4.DataSource = command.ExecuteReader();
            ddl4.DataTextField = "Nome";
            ddl4.DataValueField = "Id";
            ddl4.DataBind();
            conn.Close();
        }
        else
        {
            ddl4.Items.Add(new ListItem("-Sezione-", "-1"));
        }
    }


    protected void cb_CheckedChanged(object sender, EventArgs e)
    {

        if (cb.Checked == true)
        {
            lbl.ForeColor = System.Drawing.Color.Gray;
            tb2.Enabled = false;
        }
        else
        {
            lbl.ForeColor = System.Drawing.Color.Black;
            tb2.Enabled = true;
        }
    }
}