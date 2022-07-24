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
using System.Resources;
using System.Reflection;

/// <summary>
/// Summary description for ErrorMsgDictionary
/// </summary>
public class ErrorMsgDictionary
{
    private static int DALErrorCode = -10000000; // the value must be same POS.DAL.Utility

    public static string getErrorMsg(int ErrorCode)
    {
        //value for our return value
        //string resourceValue = string.Empty;

        // specify your resource file name 


        string resourceFile = "~/OracleErrorCodes.aspx";
        // get the path of your file
   
        ErrorCode -= DALErrorCode;
      

        string Key = "E" + ErrorCode.ToString();

        object val = HttpContext.GetLocalResourceObject(resourceFile, Key);
        if (val != null)
        {
            return val.ToString();
        }
        return "Invalid Operation!"+ErrorCode.ToString();
    }
}
