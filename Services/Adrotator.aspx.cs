using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Adrotator : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["LocalDb"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (CheckTable())
            {
                bindData();
                FirstInsert.Visible = false;
            } else {
                lblRotator.Text = "Ancora non sono stati inseriti banner pubblicitari, per cominciare prova ad inserirne uno.";
                FirstInsert.Visible = true;
            }
            

            if (CheckHitTable())
                bindTable();
            else lblClicks.Text = "Ancora non sono presenti statistiche pubblicitarie.";
        }  
    }

    protected void bindTable()
    {

        String query = "SELECT ID, NavigateUrl, Hits FROM Ads INNER JOIN AdHits ON ID = AdID ORDER BY Hits DESC";

        try
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            statsRepeater.DataSource = dt;
            statsRepeater.DataBind();
        }
        catch { }
    }

    private bool CheckHitTable()
    {
        String query = "SELECT * FROM AdHits";

        try
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return true;
            else return false;
        }
        catch (Exception e1)
        {
            return false;
        }
        finally { }
    }

    private bool CheckTable()
    {
        String query = "SELECT * FROM Ads";

        try
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return true;
            else return false;
        }
        catch (Exception e1)
        {
            return false;
        }
        finally { }
    }

    private bool CheckUrl(string url)
    {
        String query = "SELECT * FROM Ads WHERE NavigateUrl = @url";

        try
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add("@url", SqlDbType.NVarChar);
            command.Parameters["@url"].Value = String.Concat("~/Adsclicked.aspx?url=", url);
            SqlDataReader reader = command.ExecuteReader();
            if (!reader.Read())
                return true;
            else return false;
        }
        catch (Exception e1)
        {
            return false;
        }
        finally { }
    }

    private void bindData()
    {
        try
        {
            string strQuery = "SELECT ID,ImageUrl, NavigateUrl,AlternateText,Keyword,Impressions,Width,Height FROM Ads";
            SqlCommand cmd = new SqlCommand(strQuery);
            GridView1.DataSource = GetData(cmd);
            GridView1.DataBind();

            if (GridView1.HeaderRow != null)
            {
                GridView1.UseAccessibleHeader = true;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        } catch(Exception e){}
    }

    private DataTable GetData(SqlCommand cmd)
    {
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(connectionString);
        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        con.Open();
        sda.SelectCommand = cmd;
        sda.Fill(dt);
        return dt;
    }

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        bindData();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

    protected void AddNewCustomer(object sender, EventArgs e)
    {
        try
        {
            string ImageUrl = ((TextBox)GridView1.FooterRow.FindControl("txtImageUrl")).Text;
            string NavigateUrl = ((TextBox)GridView1.FooterRow.FindControl("txtNavigateUrl")).Text;
            string AlternateText = ((TextBox)GridView1.FooterRow.FindControl("txtAlternateText")).Text;
            string Keyword = ((TextBox)GridView1.FooterRow.FindControl("txtKeyword")).Text;
            string Impressions = ((TextBox)GridView1.FooterRow.FindControl("txtImpressions")).Text;
            string Width = ((TextBox)GridView1.FooterRow.FindControl("txtWidth")).Text;
            string Height = ((TextBox)GridView1.FooterRow.FindControl("txtHeight")).Text;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Ads " +
            "values(@ImageUrl, @NavigateUrl, @AlternateText, @Keyword, @Impressions, @Width, @Height);" +
            "SELECT ID,ImageUrl, NavigateUrl,AlternateText,Keyword,Impressions,Width,Height FROM Ads";
            cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = ImageUrl;
            cmd.Parameters.Add("@NavigateUrl", SqlDbType.NVarChar).Value = String.Concat("~/Adsclicked.aspx?url=", NavigateUrl.ToString());
            cmd.Parameters.Add("@AlternateText", SqlDbType.NVarChar).Value = AlternateText;
            cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = Keyword;
            cmd.Parameters.Add("@Impressions", SqlDbType.Int).Value = int.Parse(Impressions);
            cmd.Parameters.Add("@Width", SqlDbType.Int).Value = int.Parse(Width);
            cmd.Parameters.Add("@Height", SqlDbType.Int).Value = int.Parse(Height);
            GridView1.DataSource = GetData(cmd);
            GridView1.DataBind();
        }
        catch (Exception ex) { }
    }

    protected void DeleteCustomer(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkRemove = (LinkButton)sender;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM AdHits WHERE AdID=@ID; DELETE FROM Ads WHERE ID=@ID;" +
            "SELECT ID,ImageUrl, NavigateUrl,AlternateText,Keyword,Impressions,Width,Height FROM Ads";
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value
                = int.Parse(lnkRemove.CommandArgument);
            GridView1.DataSource = GetData(cmd);
            GridView1.DataBind();
            bindTable();
            if (!CheckTable())
            {
                lblRotator.Text = "Ancora non sono stati inseriti banner pubblicitari, per cominciare prova ad inserirne uno.";
                FirstInsert.Visible = true;
            }
            if (!CheckHitTable())
                lblClicks.Text = "Ancora non sono presenti statistiche pubblicitarie.";
        }
        catch (Exception ex) { }

    }

    protected void EditCustomer(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bindData();
    }

    protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bindData();
    }

    protected void UpdateCustomer(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string ID = ((Label)GridView1.Rows[e.RowIndex]
                            .FindControl("lblID")).Text;
            string ImageUrl = ((TextBox)GridView1.Rows[e.RowIndex]
                                .FindControl("txtImageUrl")).Text;
            string NavigateUrl = ((TextBox)GridView1.Rows[e.RowIndex]
                                .FindControl("txtNavigateUrl")).Text;
            string AlternateText = ((TextBox)GridView1.Rows[e.RowIndex]
                                .FindControl("txtAlternateText")).Text;
            string Keyword = ((TextBox)GridView1.Rows[e.RowIndex]
                                .FindControl("txtKeyword")).Text;
            string Impressions = ((TextBox)GridView1.Rows[e.RowIndex]
                                .FindControl("txtImpressions")).Text;
            string Width = ((TextBox)GridView1.Rows[e.RowIndex]
                                .FindControl("txtWidth")).Text;
            string Height = ((TextBox)GridView1.Rows[e.RowIndex]
                                .FindControl("txtHeight")).Text;


            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Ads SET ImageUrl=@ImageUrl," +
             "NavigateUrl=@NavigateUrl, AlternateText=@AlternateText, Keyword=@Keyword, Impressions=@Impressions, Width=@Width, Height=@Height WHERE ID=@ID;" +
             "SELECT ID,ImageUrl, NavigateUrl,AlternateText,Keyword,Impressions,Width,Height FROM Ads";
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(ID);
            cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = ImageUrl;
            cmd.Parameters.Add("@NavigateUrl", SqlDbType.NVarChar).Value = String.Concat("~/Adsclicked.aspx?url=", NavigateUrl.ToString());
            cmd.Parameters.Add("@AlternateText", SqlDbType.NVarChar).Value = AlternateText;
            cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = Keyword;
            cmd.Parameters.Add("@Impressions", SqlDbType.Int).Value = int.Parse(Impressions);
            cmd.Parameters.Add("@Width", SqlDbType.Int).Value = int.Parse(Width);
            cmd.Parameters.Add("@Height", SqlDbType.Int).Value = int.Parse(Height);
            GridView1.EditIndex = -1;
            GridView1.DataSource = GetData(cmd);
            GridView1.DataBind();
        }
        catch (Exception exe) { }
    }

    protected void first_insert_Click(object sender, EventArgs e)
    {
        try
        {
            string ImageUrl = txbImageUrlF.Text;
            string NavigateUrl = txbNavigateUrlF.Text;
            string AlternateText = txbAlternateTextF.Text;
            string Keyword = txbKeywordF.Text;
            string Impressions = txbImpressionsF.Text;
            string Width = txbWeightF.Text;
            string Height = txbHeightF.Text;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Ads " +
            "values(@ImageUrl, @NavigateUrl, @AlternateText, @Keyword, @Impressions, @Width, @Height);" +
            "SELECT ID,ImageUrl, NavigateUrl,AlternateText,Keyword,Impressions,Width,Height FROM Ads";
            cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = ImageUrl;
            cmd.Parameters.Add("@NavigateUrl", SqlDbType.NVarChar).Value = String.Concat("~/Adsclicked.aspx?url=", NavigateUrl.ToString());
            cmd.Parameters.Add("@AlternateText", SqlDbType.NVarChar).Value = AlternateText;
            cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = Keyword;
            cmd.Parameters.Add("@Impressions", SqlDbType.Int).Value = int.Parse(Impressions);
            cmd.Parameters.Add("@Width", SqlDbType.Int).Value = int.Parse(Width);
            cmd.Parameters.Add("@Height", SqlDbType.Int).Value = int.Parse(Height);
            FirstInsert.Visible = false;
            lblRotator.Text = "";
            clear_txb();
            GridView1.DataSource = GetData(cmd);
            GridView1.DataBind();
        }
        catch (Exception ex) { }
    }

    protected void clear_txb()
    {
        txbImageUrlF.Text="";
        txbNavigateUrlF.Text = "";
        txbAlternateTextF.Text = "";
        txbKeywordF.Text = "";
        txbImpressionsF.Text = "";
        txbWeightF.Text = "";
        txbHeightF.Text = "";
    }
}