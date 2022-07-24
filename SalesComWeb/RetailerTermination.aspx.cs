using System;
using System.Data;
using System.Data.OracleClient;
using System.Web;
using System.Web.Services;

public partial class PendingApproval : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            if (!Permissions.RetailerTermination)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Session["retailer_code"] = this.txtRetaileCode.Text;
        HttpContext.Current.Session["comment"] = this.txtComment.Text;
        string title = "Terminate - Channel";
        string text = String.Format("Are you sure you want to terminate channel : {0}?", this.txtRetaileCode.Text);
        MessageBox messageBox = new MessageBox(text, title, MessageBox.MessageBoxIcons.Question, MessageBox.MessageBoxButtons.OKCancel, MessageBox.MessageBoxStyle.StyleA);
        messageBox.SuccessEvent.Add("OkClick");
        messageBox.FailedEvent.Add("CancalClick");
        this.lblMsg.Text = messageBox.Show(this);
    }

    [WebMethod]
    public static string OkClick(object sender, EventArgs e)
    {
        using (OracleConnection conn = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Dmsphase4ConnectionString"].ConnectionString))
        {

            string retailer = (string)HttpContext.Current.Session["retailer_code"];
            string comment = (string)HttpContext.Current.Session["comment"];

            conn.Open();
            string sqlCheckRetailer = String.Format("select count(*) from retailer where code = '{0}'", retailer);
            string sqlCheckStatus = String.Format("select code, enabled, substr(terminationby, 1, instr(terminationby, '_')-1) as terminationby, to_char(terminationdate, 'DD-MON-YY') terminationdate from retailer where code = '{0}' and terminationstatus = 'Y'", retailer);
            string sqlUpdateStatus = String.Format("update retailer set enabled = 'N', TERMINATIONSTATUS = 'Y', TERMINATIONDATE = sysdate , REMARKS = '{0}' , TERMINATIONBY = '{1}_{2}' where CODE = '{3}'", comment, LoginInfo.Current.UserName, LoginInfo.Current.UserId, retailer);

            using (OracleCommand cmd = new OracleCommand(sqlCheckRetailer, conn))
            {
                cmd.CommandType = CommandType.Text;
                int result = Convert.ToInt16(cmd.ExecuteScalar());

                if (result == 0)
                {
                    return String.Format("Retailer \"{0}\" does not exists", retailer);
                }
            }

            using (OracleCommand cmd = new OracleCommand(sqlCheckStatus, conn))
            {
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    return String.Format("Retailer \"{0}\" already has been terminated on {1} by {2}.", retailer, dr["TERMINATIONDATE"], dr["TERMINATIONBY"]);
                }
            }

            using (OracleCommand cmd = new OracleCommand(sqlUpdateStatus, conn))
            {
                cmd.CommandType = CommandType.Text;
                if (cmd.ExecuteNonQuery() > 0)
                    return String.Format("Retailer \"{0}\" is terminated successfully by {1}.", retailer, LoginInfo.Current.UserName);
            }

        }
        return "something went wrong!";
    }


    [WebMethod]
    public static string CancalClick(object sender, EventArgs e)
    {
        return "You have clicked Cancal button.";
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable(); ;
        using (OracleConnection conn = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Dmsphase4ConnectionString"].ConnectionString))
        {
            conn.Open();
            string sqlTerminationList = String.Format("select code, terminationstatus, terminationdate, terminationby from retailer where trunc(terminationdate) between trunc(sysdate - 30) and trunc(sysdate) and terminationstatus = 'Y'");

            using (OracleCommand cmd = new OracleCommand(sqlTerminationList, conn))
            {
                cmd.CommandType = CommandType.Text;

                using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
        }

        try
        {
            Common.ExportToExcel(dt, String.Format("Termination_List_From_{0}_to_{1}", System.DateTime.Now.AddDays(-30).ToString("ddMMyyy"), System.DateTime.Now.ToString("ddMMyyy")));
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}