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
using POS.DAL;
using System.Collections.Generic;
namespace POS.BLL
{
    public class UtilityBLL
    {

        public static string GetConnectionStringOracle()
        {
            
           return "Data Source=11g_apps01; User ID=CFDB; Password=test123;";
            //return ConfigurationSettings.AppSettings["GetPOSConnectionString"].ToString();
        }


    }
}

