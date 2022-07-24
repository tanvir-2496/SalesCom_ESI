using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomHttpModule
/// </summary>
public class CustomHttpModule : IHttpModule
{
    public CustomHttpModule()
    {
    }

    public void Dispose()
    {
        // need to delete throw new NotImplementedException();
        
    }

    public void Init(HttpApplication app)
    {
        app.AcquireRequestState += new EventHandler(app_AcquireRequestState);
        app.PostAcquireRequestState += new EventHandler(app_PostAcquireRequestState);
        
    }

    private void app_PostAcquireRequestState(object sender, EventArgs e)
    {
        HttpApplication httpApp = sender as HttpApplication;
        HttpContext ctx = HttpContext.Current;
        ctx.Response.Write("Executing PostAcquireRequestState");
    }

    private void app_AcquireRequestState(object sender, EventArgs e)
    {
        HttpApplication httpApp = sender as HttpApplication;
        HttpContext ctx = HttpContext.Current;
        ctx.Response.Write("Executing AcquireRequestState");
    }
}