﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Classe che gestisce le iterazioni con il database
/// </summary>
public class QueryParameter
{
    public string Name;
    public object Value;
    public SqlDbType Type;

    public QueryParameter(string name, object value, SqlDbType type)
    {
        this.Name = name;
        this.Value = value;
        this.Type = type;
    }
}

public class DbController
{
    private SqlConnection _conn;
    /// <summary>
    /// Inizializza il DbController con la stringa di connessione al database
    /// </summary>
    /// <param name="connectionString"></param>
    public DbController(string connectionString)
    {
        _conn = new SqlConnection(connectionString);
        _conn.Open();
    }
    private SqlCommand GetCommand(string query, QueryParameter[] queryParams)
    {
        SqlCommand command = new SqlCommand(query, _conn);
        foreach (QueryParameter qp in queryParams)
        {
            command.Parameters.Add("@" + qp.Name, qp.Type);
            command.Parameters["@" + qp.Name].Value = qp.Value;
        }
        return command;
    }
    /// <summary>
    /// Esegue la query con i parametri e ritorna un SqlReader
    /// </summary>
    /// <param name="query"></param>
    /// <param name="queryParams"></param>
    /// <returns></returns>
    public SqlDataReader Read(string query, QueryParameter[] queryParams)
    {
        SqlCommand command = GetCommand(query, queryParams);
        SqlDataReader reader = command.ExecuteReader();
        command.Dispose(); //forse da problemi
        return reader;
    }
    /// <summary>
    /// Esegue la query, con i parametri e ritorna un SqlDataTable
    /// </summary>
    /// <param name="query"></param>
    /// <param name="queryParams"></param>
    /// <returns></returns>
    public DataTable ReadTable(string query, QueryParameter[] queryParams)
    {
        SqlCommand command = GetCommand(query, queryParams);
        DataTable datatable = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        adapter.Fill(datatable);
        command.Dispose();
        return datatable;
    }
    /// <summary>
    /// Metodo per scrivere su db (Insert,update,delete) tramite corretta query,
    /// con i parametri specificati 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="queryParams"></param>
    public void Write(string query, QueryParameter[] queryParams)//insert, update, delete, ecc..
    {
            SqlCommand command = GetCommand(query, queryParams);
            command.ExecuteNonQuery();
            command.Dispose();
    }

    /// <summary>
    /// Chiude la connessione con il database
    /// </summary>
    public void Close()
    {
        _conn.Close();
    }
}