using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;


public partial class CampaignDenoDriveSetup : System.Web.UI.Page
{
    //protected Int32 ReportId
    //{
    //    get { return (Int32)ViewState["CampaignID"]; }
    //    set { ViewState["CampaignID"] = value; }
    //}
    protected void pager_PreRender(object sender, EventArgs e)
    {
        BindData();
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!Permissions.CampaignDenoView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
        }
    }

    private void BindData()
    {
        List<DenoCampaignEnt> list = DenoCampaignDAL.GetItemList(0);

        lv.DataSource = list;
        lv.DataBind();
        lblResults.Text = String.Format("Total results: {0}", list.Count);
        pager.Visible = list.Count > pager.PageSize;


    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        BindData();
        pager.SetPageProperties(0, pager.MaximumRows, false);
    }

    protected void btnStop_Click(object sender, EventArgs e)
    {
        this.lblMessage.Text = String.Empty;
        Button btnLoad = sender as Button;
        string campaignId = btnLoad.CommandArgument.ToString();

        try
        {
            if (!Permissions.CampaignDenoAdd)
            {
                this.lblMessage.ForeColor = Color.Red;
                this.lblMessage.Text = "User dont have campaign update permission.";
            }
            else if (campaignId != null)
            {
                int ErrorCode = StopCampaign(Convert.ToInt32(campaignId));
                BindData();
                pager.SetPageProperties(0, pager.MaximumRows, false);
            }
            else
            {
                this.lblMessage.ForeColor = Color.Red;
                this.lblMessage.Text = "Campaign id not valid.";
            }

        }
        catch (Exception ex)
        {
            this.lblMessage.ForeColor = Color.Red;
            this.lblMessage.Text = ex.Message;
        }

    }

    protected void lv_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        this.lblMessage.Text = String.Empty;
        if (e.CommandName == "DownloadTarget")
        {
            string arg = e.CommandArgument.ToString();

            Export export = new Export();

            try
            {
                if (arg != null)
                {
                    int CampaignID = Convert.ToInt32(arg);
                    DataTable dt_excel = DenoCampaignDAL.DownloadCampaignTarget(CampaignID);
                    Common.ExportToExcelinXLSXformat(dt_excel, String.Format("Campaign_Target_{0}_{1}", "", System.DateTime.Now.ToString("ddMMyyy-HHmmss")));
                }
                else
                {
                    this.lblMessage.ForeColor = Color.Red;
                    this.lblMessage.Text = "Campaign id not valid.";
                }


            }
            catch (Exception ex)
            {
                this.lblMessage.ForeColor = Color.Red;
                this.lblMessage.Text = "Error Occured!!! " + ex.Message;
            }
        }
    }
    protected void lv_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Button lbtn = e.Item.FindControl("btnStop") as Button;
            if (lbtn != null)
            {
                ListViewDataItem dataitem = e.Item as ListViewDataItem;
                string isActive = Convert.ToString(DataBinder.Eval(dataitem.DataItem, "IsActive"));
                DateTime endDate = Convert.ToDateTime(DataBinder.Eval(dataitem.DataItem, "ExtendEndDate"));
                if (isActive == "N" && DateTime.Now.Date <= endDate && Permissions.CampaignDenoAdd)
                {
                    lbtn.Visible = true;
                }
                else
                {
                    lbtn.Visible = false;
                }
            }
        }

        LinkButton dwonloadTarget = (LinkButton)e.Item.FindControl("lbtnDownloadTarget");
        PostBackTrigger ti = new PostBackTrigger();
        ti.ControlID = dwonloadTarget.ClientID;
        ScriptManager.GetCurrent(Page).RegisterPostBackControl(dwonloadTarget);
    }

    public static bool CheckCampaignDate(string CampaignDate)
    {
        if (Convert.ToDateTime(CampaignDate) < DateTime.Now.Date)
        {
            return false;
        }
        return true;
    }

    public static bool CheckCampaignStop(string IsStop)
    {
        if (IsStop == "N")
        {
            return true;
        }
        return false;
    }

    private int StopCampaign(int campaignId)
    {
        try
        {
            int update_by = LoginInfo.Current.UserId;

            int ErrorCode = DenoCampaignDAL.InactiveCampaign(campaignId, update_by);

            return ErrorCode;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {


        List<DenoCampaignEnt> list = DenoCampaignDAL.GetItemList(0);
        list = list.Where(t => t.CampaignName.ToLower().Contains(search_textbox.Text.Trim().ToString().ToLower())).ToList();
        lv.DataSource = list;
        lv.DataBind();
        lblResults.Text = String.Format("Total results: {0}", list.Count);
        pager.Visible = list.Count > pager.PageSize;


    }


}