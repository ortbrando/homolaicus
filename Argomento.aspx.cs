using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{    
    String connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ToString();
    public int id;
    public string aux;
    string idArg;
    int idCat;
    string nomeArg;
    string nomeCat;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Nickname"] == null)
        {
            btnComment.Enabled = false;
            tbComment.Enabled = false;
            lblConfirm.Visible = true;
            lblConfirm.Text = "Effetta l'accesso per commentare";
        }

        try
        {
            bindBreadcrumb();
            this.Title = nomeArg;
            menu_ItemDataBound();
            articleRepeaterBind();
            bindComments();
            
            HtmlMeta tag = new HtmlMeta();
            tag.Attributes.Add("property", "og:description");
            tag.Content = "Contenuto di proprietà di www.homolaicus.com relativo alla categoria " + nomeCat;
            Page.Header.Controls.Add(tag);

            HtmlMeta tag2 = new HtmlMeta();
            tag2.Attributes.Add("property", "og:image");
            tag2.Content = "http://www.sfondi-desktop.eu/images/wallpapers/Immagine-di-un-Gatto-562056.jpeg";
            Page.Header.Controls.Add(tag2);
             
        }
        catch{}
        

    }

    protected void bindBreadcrumb()
    {
    
        idArg = Request.QueryString["Arg"];
        int idSub = getSub(); 
        if (idSub == -1 || idArg == null)
        {
            Response.Redirect("Homepage.aspx");
        }
        string q1 = "SELECT * FROM Argomento WHERE Id = @cont ";
        string q2 = "SELECT * FROM Sottocategoria WHERE Id = @cont2";
        string q3 = "SELECT * FROM Categoria WHERE Id = @cont3";
        SqlConnection conn = new SqlConnection(connectionString);
        conn.Open();
        SqlCommand c1 = new SqlCommand(q1, conn);
        c1.Parameters.Add("@cont", SqlDbType.Int);
        c1.Parameters["@cont"].Value = idArg;
        SqlCommand c2 = new SqlCommand(q2, conn);
        c2.Parameters.Add("@cont2", SqlDbType.Int);
        c2.Parameters["@cont2"].Value = idSub;

        SqlDataReader r1 = c1.ExecuteReader();
        r1.Read();
        nomeArg = (string)r1["Nome"];
        arg.Text = nomeArg;
        r1.Close();

        SqlDataReader r2 = c2.ExecuteReader();
        r2.Read();
        sub.Text = (string)r2["Nome"];


        SqlCommand c3 = new SqlCommand(q3, conn);
        c3.Parameters.Add("@cont3", SqlDbType.Int);
        idCat = (int)r2["IdCategoria"];
        c3.Parameters["@cont3"].Value = idCat;

        r2.Close();

        SqlDataReader r3 = c3.ExecuteReader();
        r3.Read();
        nomeCat = (string)r3["Nome"];
        cat.Text = nomeCat;
        r3.Close();
        conn.Close();  
    }

    protected int getSub()
    {
        
        try
        {
            DbController controller = new DbController(connectionString);
            SqlDataReader reader = controller.Read("SELECT IdSottocategoria FROM Argomento WHERE Id = @cont", new QueryParameter[] { new QueryParameter("cont", idArg, SqlDbType.Int)});
            reader.Read();
            return (int)reader["IdSottocategoria"];
        }
        catch { return -1; }

    }


    protected String getContent()
    {
        string s = "";
        String query = "SELECT * FROM Sezione WHERE IdArgomento = @cont ORDER BY Posizione ASC";

        try
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add("@cont", SqlDbType.Int);
            command.Parameters["@cont"].Value = idArg;
            SqlDataReader r = command.ExecuteReader();
            while (r.Read())
            {
                s += "<p><h1>" + r["Nome"] + "</h1></p>" + r["HtmlCode"] + "\n";
            }
        }
        catch { return null; }

        return s;

    }

    protected void savePDF(object sender, EventArgs args)
    {
        /*
        System.Web.HttpResponse Response = System.Web.HttpContext.Current.Response;
        try
        {
            // create an API client instance
            pdfcrowd.Client client = new pdfcrowd.Client("Panchh", "39b635bb2f4badc8b5d6b96a5399a264");

            // convert a web page and write the generated PDF to a memory stream
            MemoryStream Stream = new MemoryStream();
            client.convertHtml(getContent(), Stream);

            // set HTTP response headers
            Response.Clear();
            Response.AddHeader("Content-Type", "application/pdf");
            Response.AddHeader("Cache-Control", "max-age=0");
            Response.AddHeader("Accept-Ranges", "none");
            Response.AddHeader("Content-Disposition", "attachment; filename=Homolaicus-"+nomeArg+".pdf");

            // send the generated PDF
            Stream.WriteTo(Response.OutputStream);
            Stream.Close();
            Response.Flush();
            Response.End();
        }
        catch (pdfcrowd.Error why)
        {
            Response.Write(why.ToString());
        }
         */
        
    }


    protected void menu_ItemDataBound()
    {
        String query = "SELECT Nome FROM Sezione WHERE IdArgomento = @cont ORDER BY Posizione ASC";

        try
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add("@cont", SqlDbType.Int);
            command.Parameters["@cont"].Value = idArg;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            menu.DataSource = dt;
            menu.DataBind();
        }
        catch { }
    }

    protected void articleRepeaterBind()
    {
        String query = "SELECT * FROM Sezione WHERE IdArgomento = @cont ORDER BY Posizione ASC";

        try
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add("@cont", SqlDbType.Int);
            command.Parameters["@cont"].Value = idArg;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            articleRepeater.DataSource = dt;
            articleRepeater.DataBind();
            mobileRepeater.DataSource = dt;
            mobileRepeater.DataBind();
        }
        catch { }
    }

    protected void cat_Click(object sender, EventArgs e)
    {
        Response.Redirect("Categoria.aspx?Cat=" + idCat);
    }

    protected void btnComment_Click(object sender, EventArgs e)
    {
        String query = "INSERT INTO Commento (Testo, Data, IdArg, NicknameUtente) VALUES (@testo, @data, @arg, @nick)";
        
        if (!String.IsNullOrWhiteSpace(tbComment.Text))
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add("@testo", SqlDbType.VarChar);
                command.Parameters["@testo"].Value = tbComment.Text;
                command.Parameters.Add("@data", SqlDbType.DateTime);
                command.Parameters["@data"].Value = DateTime.Now;
                command.Parameters.Add("@arg", SqlDbType.Int);
                command.Parameters["@arg"].Value = idArg;
                command.Parameters.Add("@nick", SqlDbType.VarChar);
                command.Parameters["@nick"].Value = Session["Nickname"].ToString();

                if (command.ExecuteNonQuery() > 0)
                {
                    lblConfirm.Visible = true;
                    lblConfirm.ForeColor = System.Drawing.Color.Green;
                    lblConfirm.Text = "Commento inserito correttamente!";
                    tbComment.Text = "";
                    Response.Redirect(Request.RawUrl);
                }
            }
            catch { }
            finally
            {
                conn.Close();
            }
        }
        else
        {
            lblConfirm.Visible = true;
            lblConfirm.ForeColor = System.Drawing.Color.Red;
            lblConfirm.Text = "Inserisci un commento valido"; 
        }
        
    }

    protected void bindComments()
    {
        String query = "SELECT * FROM Commento INNER JOIN Utente ON Commento.NicknameUtente = Utente.Nickname WHERE IdArg = @cont ORDER BY Data DESC";

        try
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.Add("@cont", SqlDbType.Int);
            command.Parameters["@cont"].Value = idArg;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            repeaterComments.DataSource = dt;
            repeaterComments.DataBind();
            mobileRepeaterComments.DataSource = dt;
            mobileRepeaterComments.DataBind();
        }
        catch { }

    }
}