using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class WebUserControl : System.Web.UI.UserControl
{
    public String TargetTbx = "";

  protected override void OnPreRender(EventArgs e) {
  base.OnPreRender(e);
  if (!Page.ClientScript.IsClientScriptBlockRegistered(Page.GetType(), "CommonBehaviour")) 
  {
    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "CommonBehaviour", String.Empty);
    ((HtmlHead)Page.Header).Controls.Add(new LiteralControl("<script type='text/javascript' src='" + Page.ResolveUrl("UserControl/datetimePicker/file_js/zapatec.js") + "'><" + "/script>\n"));

    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "CommonBehaviour", String.Empty);
    ((HtmlHead)Page.Header).Controls.Add(new LiteralControl("<script type='text/javascript' src='" + Page.ResolveUrl("UserControl/datetimePicker/file_js/calendar.js") + "'><" + "/script>\n"));

    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "CommonBehaviour", String.Empty);
    ((HtmlHead)Page.Header).Controls.Add(new LiteralControl("<script type='text/javascript' src='" + Page.ResolveUrl("UserControl/datetimePicker/file_js/calendar-en.js") + "'><" + "/script>\n"));
  
    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "CommonBehaviour", String.Empty);
    ((HtmlHead)Page.Header).Controls.Add(new LiteralControl("<link href='UserControl/datetimePicker/themes/aqua.css' rel='stylesheet' type='text/css'/> \n"));
       
     // Page.RegisterStartupScript("MyKey", "<script type=\"text/javascript\">" + "var cal = new Zapatec.Calendar.setup({ inputField:\"" + TargetTbx + "\",ifFormat:\"%d-%m-%Y\",button:\"button1\",showsTime:false});" + "</script>\n");
  }

}
    protected void Page_Load(object sender, EventArgs e)
    {
    }
}