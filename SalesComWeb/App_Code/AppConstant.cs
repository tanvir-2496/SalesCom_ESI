using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Configuration;

/// <summary>
/// Summary description for AppConstant
/// </summary>
public  class AppConstant
{
    public AppConstant()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    private string _ShopTypeID = "ShopTypeID";

    public static string ConnectionString
    {

        get { return System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; }
         }
    public static string DMSConnectionString
    {

        get { return System.Configuration.ConfigurationManager.ConnectionStrings["DMSConnectionString"].ConnectionString; }
    }
    public static int ShopTypeID
    {

        get { return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["ShopTypeID"].Trim()); }
    }

    public static decimal VatAmount
    {

        get { return Convert.ToDecimal(System.Configuration.ConfigurationManager.AppSettings["VatAmount"].Trim()); }
    }


   
}
