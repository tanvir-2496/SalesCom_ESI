using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

public partial class PendingApprovalSummaryView : System.Web.UI.Page
{
    protected int CycleId
    {
        get { return (int)ViewState["CycleId"]; }
        set { ViewState["CycleId"] = value; }
    }

    protected void pager_PreRender(object sender, EventArgs e)
    {
        BindData();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.PendingApprovalSummaryView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            CycleId = int.Parse(Request["CycleId"]);
        }
    }

    private void BindData()
    {
        List<PendingApprovalSummaryViewEnt> list = PendingApprovalSummaryViewDAL.GetItemList(CycleId);
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
    protected void lv_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "ExportSummary")
        {
            DataTable dt_excel = CommissionDetailExportDAL.GetItemList(0, e.CommandArgument.ToString(), CycleId);
            try
            {
                Common.ExportToExcel(dt_excel, String.Format("Detail_{0}", System.DateTime.Now.ToString("ddMMyyy-HHmmss")));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        if (e.CommandName.StartsWith("ExportDetails"))
        {
            string[] argument = e.CommandArgument.ToString().Split('|');

            DataTable dt_excel = CommissionDetailExportDAL.GetItemListByChannelIdCycleId(Convert.ToInt32(argument[0]), argument[1], CycleId);

            try
            {
                Common.ExportToExcel(dt_excel, String.Format("Detail_Channel_{0}", System.DateTime.Now.ToString("ddMMyyy-HHmmss")));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }

    protected void lbCompact_Click(object sender, EventArgs e)
    {
        DataTable dt_excel = CommissionDetailExportDAL.GetDistributorList(0, CycleId);

        try
        {
            Common.ExportToExcel(dt_excel, String.Format("Distributor_{0}", System.DateTime.Now.ToString("ddMMyyy-HHmmss")));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lbSummary_Click(object sender, EventArgs e)
    {
        DataTable dt_excel = CommissionDetailExportDAL.GetItemList(0, String.Empty, CycleId);

        try
        {
            Common.ExportToExcel(dt_excel, String.Format("Detail_{0}", System.DateTime.Now.ToString("ddMMyyy-HHmmss")));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lbDetails_Click(object sender, EventArgs e)
    {
        DataTable dt_excel = CommissionDetailExportDAL.DetailsReportWise(0, CycleId);

        try
        {
            Common.ExportToExcel(dt_excel, String.Format("Report_Wise_{0}", System.DateTime.Now.ToString("ddMMyyy-HHmmss")));
        }
        catch (Exception ex)
        {
            this.lblResults.Text = ex.Message;
        }
    }
}