<%@ Application Language="C#" %>


<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        POS.DAL.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        //RegisterRoutes(System.Web.Routing.RouteTable.Routes);
        SalesCom.DAL.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["SalesComConnectionString"].ToString();
        //Microsoft.AspNet.FriendlyUrls.RouteCollectionExtensions.EnableFriendlyUrls(System.Web.Routing.RouteTable.Routes);
    }

    //public static void RegisterRoutes(System.Web.Routing.RouteCollection routes)
    //{
    //    routes.MapPageRoute("",
    //        "regular_and_ad-hoc_report",
    //        "~/ReportView.aspx");
    //}

    //internal protected void Application_BeginRequest(object sender, EventArgs e)
    //{
    //    // Get objects.
    //    HttpContext context = base.Context;
    //    HttpResponse response = context.Response;
        
    //    //HttpApplication app = sender as HttpApplication;
    //    //System.Web.Routing.RouteCollection rt = System.Web.Routing.RouteTable.Routes;
    //    if (SiteMap.CurrentNode != null)
    //    {
    //        string t = SiteMap.CurrentNode.Title;
    //        //rt.MapPageRoute("", t.ToString(), "~/" + SiteMap.CurrentNode.ToString(), true);
    //        Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Resolve(SiteMap.CurrentNode.ToString());
             
    //    }
    //    // Complete.
    //    //base.CompleteRequest();
    //}

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown
    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs
    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started
    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
    }
    
    
       
</script>
