using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Services_AdminPanel : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["USER_ID"] != null)
        {
            user.Text = Session["USER_ID"].ToString();
        }
        else Response.Redirect("Login.aspx");
    }
    protected void logoutBut_Click(object sender, EventArgs e)
    {
        Session["USER_ID"] = null;
        Response.Redirect("~/Homepage.aspx");
    }
}
