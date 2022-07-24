using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetupActivity : System.Web.UI.Page
{
    protected Int32 ReportId
    {
        get { return (Int32)ViewState["ReportId"]; }
        set { ViewState["ReportId"] = value; }
    }

    protected string ReportName
    {
        get { return ViewState["ReportName"].ToString(); }
        set { ViewState["ReportName"] = value; }
    }

    protected string CommissionCycle
    {
        get { return ViewState["CommissionCycle"].ToString(); }
        set { ViewState["CommissionCycle"] = value; }
    }

    protected int CycleId
    {
        get { return (int)ViewState["CycleId"]; }
        set { ViewState["CycleId"] = value; }
    }

    protected Int32 Result
    {
        get { return (Int32)ViewState["Result"]; }
        set { ViewState["Result"] = value; }
    }

    protected DateTime ReportFormDate
    {
        get { return (DateTime)ViewState["ReportFormDate"]; }
        set { ViewState["ReportFormDate"] = value; }
    }

    protected DateTime ReportToDate
    {
        get { return (DateTime)ViewState["ReportToDate"]; }
        set { ViewState["ReportToDate"] = value; }
    }
    protected DateTime MaturDate
    {
        get { return (DateTime)ViewState["MaturDate"]; }
        set { ViewState["MaturDate"] = value; }
    }
    protected string LateReason
    {
        get { return ViewState["LateReason"].ToString(); }
        set { ViewState["LateReason"] = value; }
    }



    protected void pager_PreRender(object sender, EventArgs e)
    {
        if (ddlCommissionCycle.SelectedIndex > 0)
        {
            BindData(Int32.Parse(ddlCommissionCycle.SelectedValue), true);
        }
        else if (ddlProvisionCycle.SelectedIndex > 0)
        {
            BindData(Int32.Parse(ddlProvisionCycle.SelectedValue), false);
        }
        else
        {
            BindData(0, false);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!Permissions.ReportPreExeConfigView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            lblReportName.InnerText = String.Empty;
            Common.PopulatePeriodType(ddlPeridType);
            Common.AddSelectOne(ddlPeridType);
            this.ddlYear.DataSource = Common.GenrateYear();
            this.ddlYear.DataBind();
        }
    }

    private void BindData(Int32 publishCycleId, bool isPublish)
    {
        List<ReportPreExeConfigEnt> list;

        if (publishCycleId == 0)
        {
            list = new List<ReportPreExeConfigEnt>();
        }
        else
        {
            if (isPublish)
            {
                list = ReportPreExeConfigDAL.GetReportPreExeConfig(publishCycleId, 0, 0, 0);
            }
            else
            {
                list = ReportPreExeConfigDAL.GetReportPreExeConfig(0, 0, 0, Int32.Parse(this.ddlProvisionCycle.SelectedValue));
            }
        }

        lv.DataSource = list;
        lv.DataBind();
        lblResults.Text = String.Format("Total results: {0}", list.Count);
        pager.Visible = list.Count > pager.PageSize;
    }

    protected void ddlCommissionCycle_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlCommissionCycle.SelectedIndex > 0)
        {
            pager.SetPageProperties(0, pager.MaximumRows, false);
            ddlProvisionCycle.SelectedIndex = 0;
            BindData(Int32.Parse(ddlCommissionCycle.SelectedValue), true);
        }
        else
        {
            BindData(0, false);
        }

        ClearLeadCycles();
    }

    protected void ddlPeridType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPeridType.SelectedIndex > 0)
        {
            //Common.PopulateCommissionCycleId(ddlCommissionCycle, int.Parse(ddlPeridType.SelectedValue));
            Common.PopulateCommissionCycleByYear(ddlCommissionCycle, int.Parse(ddlPeridType.SelectedValue), int.Parse(ddlYear.SelectedValue));
            Common.AddSelectOne(ddlCommissionCycle);
            //Common.PopulateCommissionCycleId(ddlProvisionCycle, int.Parse(ddlPeridType.SelectedValue));
            Common.PopulateCommissionCycleByYear(ddlProvisionCycle, int.Parse(ddlPeridType.SelectedValue), int.Parse(ddlYear.SelectedValue));
            Common.AddSelectOne(ddlProvisionCycle);
        }
        else
        {
            ddlCommissionCycle.Items.Clear();
            ddlProvisionCycle.Items.Clear();
        }

        BindData(0, false);
        ClearLeadCycles();


    }

    private void ClearLeadCycles()
    {
        this.lvReportCycle.DataSource = null;
        this.lvReportCycle.DataBind();
        this.dvLeadCycelPage.Visible = false;
        this.dvLeadCycleDetails.Visible = false;
        this.lblReportName.Visible = false;
        this.lblReportName.InnerText = String.Empty;
        this.lblResult.Text = String.Empty;
    }

    protected void btnLoad_Click(object sender, EventArgs e)
    {
        if (!Permissions.ReportPreExeConfigModify)
        {
            lblResult.Text = "You don't have permission to load/modify";
            return;
        }

        Button btnLoad = sender as Button;
        string[] param = btnLoad.CommandArgument.ToString().Split(new char[] { ',' });
        this.lblReportName.InnerText = String.Empty;
        this.lblResult.Text = String.Empty;

        if (param.Length == 8)
        {
            this.lvReportCycle.EditIndex = -1;
            dpLeadCycles.SetPageProperties(0, pager.MaximumRows, false);
            this.ReportName = param[0];
            this.ReportId = Convert.ToInt32(param[1]);
            this.CycleId = Convert.ToInt32(param[2]);
            this.ReportFormDate = String.IsNullOrEmpty(param[3]) ? default(DateTime) : DateTime.Parse(param[3]);
            this.ReportToDate = String.IsNullOrEmpty(param[4]) ? default(DateTime) : DateTime.Parse(param[4]);
            this.CommissionCycle = param[5];
            this.MaturDate = String.IsNullOrEmpty(param[6]) ? default(DateTime) : DateTime.Parse(param[6]);
            this.LateReason = param[7];
            LoadLeadCycles();
        }
    }

    private void LoadLeadCycles()
    {
        this.dvLeadCycleDetails.Visible = true;
        this.dvLeadCycelPage.Visible = true;
        this.lblReportName.Visible = true;
        this.lblReportName.InnerText = String.Format("Report Name: {0}; Base Cycle : {1}", ReportName, CommissionCycle);
        List<ReportPreExeConfigEnt> list = ReportPreExeConfigDAL.GetReportPreExeConfig(0, ReportId, CycleId, 0);
        this.lvReportCycle.DataSource = list;
        this.lvReportCycle.DataBind();
        this.lblLeadCycleResult.Text = String.Format("Total results: {0}", list.Count);
        this.dpLeadCycles.Visible = list.Count > dpLeadCycles.PageSize;
    }

    protected void dpLeadCycles_PreRender(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(this.lblReportName.InnerText))
        {
            LoadLeadCycles();
        }
    }

    protected void lvReportCycle_ItemEditing(object sender, ListViewEditEventArgs e)
    {
        this.lblResult.Text = String.Empty;
        lvReportCycle.EditIndex = e.NewEditIndex;
        LoadLeadCycles();
    }

    protected void lvReportCycle_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (lvReportCycle.EditIndex >= 0)
        {
            SetEditItem(e);
        }
    }

    private void SetEditItem(ListViewItemEventArgs e)
    {
        ListViewDataItem dataItem = (ListViewDataItem)e.Item;

        if (dataItem.DisplayIndex == lvReportCycle.EditIndex)
        {
            ReportPreExeConfigEnt rowItem = (ReportPreExeConfigEnt)dataItem.DataItem;

            DropDownList provisionCycleId = (DropDownList)dataItem.FindControl("ddlProvisionCycle");
            DropDownList publishCycleId = (DropDownList)dataItem.FindControl("ddlPublishCycle");

            TextBox provisionFromDate = (TextBox)dataItem.FindControl("txtProvisionFromDate");
            if (String.IsNullOrEmpty(provisionFromDate.Text))
            {
                provisionFromDate.Text = ReportFormDate.FirstDayOfNextMonth().ToString("dd-MMM-yyyy");
            }

            TextBox provisionToDate = (TextBox)dataItem.FindControl("txtProvisionToDate");
            if (String.IsNullOrEmpty(provisionToDate.Text))
            {
                provisionToDate.Text = ReportToDate.LastDayOfProvisionMonthMonth().ToString("dd-MMM-yyyy");
            }

            TextBox reportFromDate = (TextBox)dataItem.FindControl("txtReportFromDate");
            if (String.IsNullOrEmpty(reportFromDate.Text))
            {
                reportFromDate.Text = provisionFromDate.Text;
            }

            TextBox reportToDate = (TextBox)dataItem.FindControl("txtReportToDate");

            if (String.IsNullOrEmpty(reportToDate.Text))
            {
                reportToDate.Text = ReportToDate.LastDayOfNextMonth().ToString("dd-MMM-yyyy");
            }

            if (ddlPeridType.SelectedIndex > 0)
            {
                Common.PopulateCommissionCycleId(provisionCycleId, int.Parse(ddlPeridType.SelectedValue));
                Common.AddSelectOne(provisionCycleId);

                Common.PopulateCommissionCycleId(publishCycleId, int.Parse(ddlPeridType.SelectedValue));
                Common.AddSelectOne(publishCycleId);

                provisionCycleId.SelectedValue = rowItem.ProvisionCycleId.ToString() == String.Empty ? "0" : rowItem.ProvisionCycleId.ToString();
                publishCycleId.SelectedValue = rowItem.PublishCycleId.ToString() == String.Empty ? "0" : rowItem.PublishCycleId.ToString();
            }
        }
    }

    protected void lvReportCycle_ItemCanceling(object sender, ListViewCancelEventArgs e)
    {
        this.lvReportCycle.EditIndex = -1;
        LoadLeadCycles();
    }

    protected void lvReportCycle_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        this.lvReportCycle.EditIndex = -1;
    }

    protected void lvReportCycle_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "Update")
        {
            Result = UpdateDataSource(e);

        }
    }

    private static int UpdateDataSource(ListViewCommandEventArgs e)
    {
        ReportPreExeConfigEnt reportPreExeConfig = new ReportPreExeConfigEnt();

        Int32 ReportCycleId = Convert.ToInt32(e.CommandArgument);

        TextBox ProvisionFromDate = (TextBox)e.Item.FindControl("txtProvisionFromDate");
        TextBox ProvisionToDate = (TextBox)e.Item.FindControl("txtProvisionToDate");
        TextBox ReportFromDate = (TextBox)e.Item.FindControl("txtReportFromDate");
        TextBox ReportToDate = (TextBox)e.Item.FindControl("txtReportToDate");
        TextBox MatureDate = (TextBox)e.Item.FindControl("txtMatureDate");
        TextBox LateReason = (TextBox)e.Item.FindControl("txtLateReason");

        DropDownList ddlProvisionCycleId = (DropDownList)e.Item.FindControl("ddlProvisionCycle");
        DropDownList ddPublishCycleId = (DropDownList)e.Item.FindControl("ddlPublishCycle");
        CheckBox status = (CheckBox)e.Item.FindControl("chkStatus");

        reportPreExeConfig.CycleReportId = ReportCycleId;
        reportPreExeConfig.ProvisionCycleId = Int32.Parse(ddlProvisionCycleId.SelectedValue);
        reportPreExeConfig.PublishCycleId = Int32.Parse(ddPublishCycleId.SelectedValue);
        reportPreExeConfig.Status = status.Checked == true ? (Int16)1 : (Int16)0;
        reportPreExeConfig.ProvisionFromDate = ProvisionFromDate.Text == String.Empty ? default(DateTime) : DateTime.Parse(ProvisionFromDate.Text);
        reportPreExeConfig.ProvisionToDate = ProvisionToDate.Text == String.Empty ? default(DateTime) : DateTime.Parse(ProvisionToDate.Text);
        reportPreExeConfig.ReportFromDate = ReportFromDate.Text == String.Empty ? default(DateTime) : DateTime.Parse(ReportFromDate.Text);
        reportPreExeConfig.ReportToDate = ReportToDate.Text == String.Empty ? default(DateTime) : DateTime.Parse(ReportToDate.Text);
        reportPreExeConfig.MatureDate = MatureDate.Text == String.Empty ? default(DateTime) : DateTime.Parse(MatureDate.Text);
        reportPreExeConfig.LateReason = LateReason.Text == String.Empty ? null : LateReason.Text;

        return ReportPreExeConfigDAL.UpdateDataSource(reportPreExeConfig, "U");

    }

    protected void lvReportCycle_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
        MsgUtility.msg("update", Result, "Report " + ReportName + "'s" + " Commission Cycle ", this, lblResult, "");
        if (Result >= 0)
        {
            this.lvReportCycle.EditIndex = -1;
            LoadLeadCycles();
        }
    }

    protected void ddlProvisionCycle_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlProvisionCycle.SelectedIndex > 0)
        {
            pager.SetPageProperties(0, pager.MaximumRows, false);
            ddlCommissionCycle.SelectedIndex = 0;
            BindData(Int32.Parse(ddlProvisionCycle.SelectedValue), false);
        }
        else
        {
            BindData(0, false);
        }

        ClearLeadCycles();
    }
    public string CheckMatureDate(string matureDate)
    {
        DateTime result = new DateTime();
        List<ReportPreExeConfigEnt> list = ReportPreExeConfigDAL.GetReportPreExeConfig(0, ReportId, 0, 0);
        if (!string.IsNullOrEmpty(matureDate))
        {
            result = Convert.ToDateTime(matureDate);
        }
        else
        {
            if (list.Count == 1)
            {
                foreach (var item in list)
                {
                    result = item.MatureDate;
                }
            }
            else
            {
                list.RemoveAt(list.Count - 1);
                foreach (var item in list)
                {
                    result = item.ComMatureDate;
                }
            }

        }
        return result.ToString("dd-MMM-yy");
    }

}