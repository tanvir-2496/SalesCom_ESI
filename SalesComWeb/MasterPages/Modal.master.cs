using System;
using System.Globalization;
using System.Threading;
using System.Web.UI;
public partial class MasterPages_Modal : System.Web.UI.MasterPage
{
      
    protected void Page_Load(object sender, EventArgs e)
    {
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "init", "initialize();fnAdjustParentHeight();", true);
    }
}
