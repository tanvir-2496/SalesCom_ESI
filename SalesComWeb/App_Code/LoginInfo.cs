using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for LoginInfo
/// </summary>
public class LoginInfo
{
    public int UserId { get; set; }

    public string Login { get; set; }

    public string UserName
    {
        get;
        set;
    }


    public bool IsSuperUser
    {
        get;
        set;
    }



    public int CenterId
    {
        get;
        set;
    }

    public string CenterName
    {
        get;
        set;
    }

    public int CenterType
    {
        get;
        set;
    }


    public List<string> Archive
    {
        get;
        set;
    }

    public static LoginInfo Current
    {
        get
        {
            string path = HttpContext.Current.Request.Url.AbsolutePath;

            if (HttpContext.Current.Session["LoginInfo"] == null)
            {
                //if (HttpContext.Current.Response.IsRequestBeingRedirected)
                //{
                    HttpContext.Current.Response.Redirect(string.Format("logout.aspx?returnurl={0}", path));
                //}
                //HttpContext.Current.Response.Redirect(string.Format("logout.aspx?returnurl={0}", path), false);
                //HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            return HttpContext.Current.Session["LoginInfo"] as LoginInfo;
        }

    }

}
