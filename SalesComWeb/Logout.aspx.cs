using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {       
        try 
        {
            if (Session["loginRecord"] != null)
            {
                Session["loginRecord"] = null;
            }

            LoginInfo _LoginInfo = (LoginInfo)Session["LoginInfo"];
            //SAVE_INSERTAPPLICATIONACCESSLOG(_LoginInfo.UserId, "LOGOUT");
        }
        catch(Exception ex)
        {

        }

        Session.Abandon();
        FormsAuthentication.SignOut();       
        if (Request.QueryString["passChange"] == null && Request.QueryString["returnurl"] != null)
        {
            Response.Redirect(string.Format("login.aspx?returnurl={0}", Request.QueryString["returnurl"]));
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }
    public static void SAVE_INSERTAPPLICATIONACCESSLOG(int userID, string action)
    {
        string strProcedureName = "INSERTAPPLICATIONLOGININFO";
        using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["SalesComConnectionString"].ToString()))
        using (OracleCommand command = new OracleCommand())
        {
            command.Connection = connection;
            command.CommandText = strProcedureName;
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("P_USER_ID", userID);
            command.Parameters.AddWithValue("P_APPLICATION_NAME", "SALESCOM");
            command.Parameters.AddWithValue("P_MODULE_NAME", "LOGIN");
            command.Parameters.AddWithValue("P_ACTIVITY_NAME", "LOGIN");
            command.Parameters.AddWithValue("P_ACTION_TYPE", action);


            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception ex)
            {
                // lblMsg.Text = ex.Message + "(INSERTAPPLICATIONACCESSLOG)";
            }

        }
    }
}
