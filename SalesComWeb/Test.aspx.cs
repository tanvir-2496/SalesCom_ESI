using System;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("<div class=\"eventHeader\">");
        Response.Write("Last Updated Events </br>");
        Response.Write("</div>");


        if (LoginInfo.Current.Archive.Count > 10)
        {
            LoginInfo.Current.Archive.RemoveRange(10, LoginInfo.Current.Archive.Count - 10);
        }

        foreach (string s in LoginInfo.Current.Archive)
        {


            Response.Write("<div class=\"eventList\">");
            Response.Write(s + "<br>");
            Response.Write("</div>");
        }
        Response.End();
        
    }
}
