using System;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for MsgUtility
/// </summary>
public class MsgUtility
{

    public static void msg(string editMode, int ErrorCode, string PageCaption, Page PageName, Label lblMsg)
    {

        msg(editMode, ErrorCode, PageCaption, PageName, lblMsg, "..");
    }

    public static void msg(int ErrorCode, string PageCaption, Page PageName, Label lblMsg)
    {
        msg(ErrorCode, PageCaption, PageName, lblMsg, "..");
    }

    public static void msg(int ErrorCode, string PageCaption, Page PageName, Label lblMsg, string ArchiveMsg)
    {
        if (ErrorCode >= 0)
        {
            //LoginInfo.Current.Archive.Insert(0, string.Format(" {1} - <b>{2}</b> is added.<span class=\"timeEvent\">{0}</span>", DateTime.Now.ToString("hh:mm tt"), PageCaption, ArchiveMsg));
            lblMsg.ForeColor = System.Drawing.Color.DarkGreen;
            lblMsg.Font.Bold = true;
            lblMsg.Text = PageCaption + Resources.ErrorMsg.SuccessfullyAdded;
            ScriptManager.RegisterStartupScript(PageName, PageName.GetType(), "refresh", "parent.refreshWindow();", true);
        }
        else
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = Resources.ErrorMsg.UnsuccessfullyUpdated + PageCaption + "<br>" + ErrorMsgDictionary.getErrorMsg(ErrorCode);
        }
    }

    public static void msg(string editMode,int ErrorCode, string PageCaption,Page PageName,Label lblMsg,string ArchiveMsg)
    {

        if (editMode == "HearderAdd") {
            ScriptManager.RegisterStartupScript(PageName, PageName.GetType(), "refresh", "parent.refreshWindow();", true);
            ScriptManager.RegisterStartupScript(PageName, PageName.GetType(), "close", "parent.tb_remove();", true);
        }

        if (editMode == "edit")
        {

            if (ErrorCode >= 0)
            {
                LoginInfo.Current.Archive.Insert(0,string.Format(" {1} - <b>{2}</b> is modified.<span class=\"timeEvent\">{0}</span>",DateTime.Now.ToString("hh:mm tt"), PageCaption, ArchiveMsg));
                ScriptManager.RegisterStartupScript(PageName, PageName.GetType(), "refresh", "parent.refreshWindow();", true);
                ScriptManager.RegisterStartupScript(PageName, PageName.GetType(), "close", "parent.tb_remove();", true);
            }
            else
            {
                lblMsg.Font.Bold = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = Resources.ErrorMsg.UnsuccessfullyUpdated + PageCaption + "<br>" + ErrorMsgDictionary.getErrorMsg(ErrorCode);
            }
        }
        else if (editMode == "add")
        {
            if (ErrorCode >= 0)
            {
                LoginInfo.Current.Archive.Insert(0, string.Format(" {1} - <b>{2}</b> is added.<span class=\"timeEvent\">{0}</span>", DateTime.Now.ToString("hh:mm tt"), PageCaption, ArchiveMsg));
                lblMsg.ForeColor = System.Drawing.Color.DarkGreen;
                lblMsg.Font.Bold = true;
                lblMsg.Text = PageCaption + Resources.ErrorMsg.SuccessfullyAdded;
                ScriptManager.RegisterStartupScript(PageName, PageName.GetType(), "refresh", "parent.refreshWindow();", true);

            }
            else
            {
                lblMsg.Font.Bold = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = Resources.ErrorMsg.UnsuccessfullyAdded + PageCaption + "<BR>" + ErrorMsgDictionary.getErrorMsg(ErrorCode);
            }
        }
        else if (editMode == "update")
        {
            if (ErrorCode >= 0)
            {
                LoginInfo.Current.Archive.Insert(0, string.Format(" {1} - <b>{2}</b> is added.<span class=\"timeEvent\">{0}</span>", DateTime.Now.ToString("hh:mm tt"), PageCaption, ArchiveMsg));
                lblMsg.ForeColor = System.Drawing.Color.DarkGreen;
                lblMsg.Font.Bold = true;
                lblMsg.Text = PageCaption + Resources.ErrorMsg.SuccessfullyUpdated;
                ScriptManager.RegisterStartupScript(PageName, PageName.GetType(), "refresh", "refreshWindow();", true);
            }
            else
            {
                lblMsg.Font.Bold = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = Resources.ErrorMsg.UnsuccessfullyAdded + PageCaption + "<BR>" + ErrorMsgDictionary.getErrorMsg(ErrorCode);
            }
        }
        else if (editMode == "upload")
        {
            if (ErrorCode >= 0)
            {
                LoginInfo.Current.Archive.Insert(0, string.Format(" {1} - <b>{2}</b> is added.<span class=\"timeEvent\">{0}</span>", DateTime.Now.ToString("hh:mm tt"), PageCaption, ArchiveMsg));
                lblMsg.ForeColor = System.Drawing.Color.DarkGreen;
                lblMsg.Font.Bold = true;
                lblMsg.Text = PageCaption + Resources.ErrorMsg.SuccessfullyUploaded;
            }
            else
            {
                lblMsg.Font.Bold = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = Resources.ErrorMsg.UnsuccessfullyAdded + PageCaption + "<BR>" + ErrorMsgDictionary.getErrorMsg(ErrorCode);
            }
        }
        else if (editMode == "Delete")
        {

            if (ErrorCode >= 0)
            {
                LoginInfo.Current.Archive.Insert(0, string.Format(" {1} - <b>{2}</b> is deleted.<span class=\"timeEvent\">{0}</span>", DateTime.Now.ToString("hh:mm tt"), PageCaption, ArchiveMsg));
                ScriptManager.RegisterStartupScript(PageName, PageName.GetType(), "refresh", "parent.refreshWindow();", true);
                ScriptManager.RegisterStartupScript(PageName, PageName.GetType(), "close", "parent.tb_remove();", true);
            }
            else
            {
                lblMsg.Font.Bold = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = Resources.ErrorMsg.UnsuccessfullyDeleted + PageCaption + "<br>" + ErrorMsgDictionary.getErrorMsg(ErrorCode);
            }
        }
        else 
        {
            if (ErrorCode == 0)
            {
                ScriptManager.RegisterStartupScript(PageName, PageName.GetType(), "refresh", "parent.refreshWindow();", true);
                ScriptManager.RegisterStartupScript(PageName, PageName.GetType(), "close", "parent.tb_remove();", true);
            }
            else
            {
                lblMsg.Font.Bold = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = Resources.ErrorMsg.UnsuccessfullyDeleted + PageCaption  + "<BR>" + ErrorMsgDictionary.getErrorMsg(ErrorCode);
            }
        }
    }
    public static void msgCommon(Page PageName,Label lblMsg,string strMsg)
    {
                lblMsg.Font.Bold = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = strMsg;
    }

    public static void msgSuccess(Page PageName, Label lblMsg, string strMsg)
    {
        lblMsg.Font.Bold = true;
        lblMsg.ForeColor = System.Drawing.Color.Green;
        lblMsg.Text = strMsg;
    }
    public static void showNotPermittedMsg(Page PageName)
    {
        PageName.Response.Write(string.Format("<h2>{0}</h2><a type='button' href='/default.aspx'>Back to Home</a>", Resources.CommonMsg.NotPermitted));
        PageName.Response.End();
    }
    public static void loginMessageView(Page PageName, string recordType, string logintype, string recordtime)
    {
        LoginInfo.Current.Archive.Insert(0, string.Format(" {0} - <b>{1}</b> at </br> {2} ", recordType, logintype, recordtime));
        ScriptManager.RegisterStartupScript(PageName, PageName.GetType(), "refresh", "parent.refreshWindow();", true);
    }
}
