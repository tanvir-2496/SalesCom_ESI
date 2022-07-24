using System;
using System.Globalization;
using System.Threading;
using System.Web.UI;
using System.Configuration;
using System.Reflection;
using System.Web;

public partial class MasterPages_default : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {


        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "init", "initialize();setWindowSize();", true);
        if (!IsPostBack)
        {
            if (!Permissions.IsAccessible(Page.AppRelativeVirtualPath))
            {
                Response.Flush();
                Response.End();
            }
        }
        
        lblConnectionType.Text = ConfigurationManager.ConnectionStrings["SalesComConnectionString"].ToString().Contains("SALCOMDB") ? "Live Database" : "Test Database";

        lblSlnPath.Text = string.Format("New Development Sln: {0} </br>SLN Path {1}", HttpRuntime.AppDomainAppPath.Contains("23-May-17") ? "Yes" : "No", HttpRuntime.AppDomainAppPath);

    }
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
      
    }
    private void HideItem(DevExpress.Web.ASPxMenu.MenuItem item)
    {
        if (!item.HasChildren && item.NavigateUrl.Trim().Length == 0)
        {
            item.Visible = false;
        }
    }

    protected void ASPxMenu2_PreRender(object sender, EventArgs e)
    {
        foreach (DevExpress.Web.ASPxMenu.MenuItem item in ASPxMenu1.Items)
        {
            HideItem(item);

        }


    }
    
}
