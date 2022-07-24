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
        get
        {
            return (int)ViewState["CycleId"];
        }
        set
        {
            ViewState["CycleId"] = value;
        }
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
        List<PendingApprovalSummaryViewEnt> list = PendingApprovalSummaryViewDAL.GetProvisionSummaryView(CycleId);

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
        if (e.CommandName == "ExportAll")
        {
            string[] arg = e.CommandArgument.ToString().Split('|');

            Int64 ChannelId = Convert.ToInt64(arg[0]);
            int CycleID = Convert.ToInt32(arg[1]);
            DataTable dt_excel = CommissionDetailExportDAL.GetAllProvision(ChannelId, CycleID);

            try
            {
                Common.ExportToExcel(dt_excel, String.Format("Provision_Detail_{0}", System.DateTime.Now.ToString("ddMMyyy-HHmmss")));
            }
            catch
            {
                Exception ex;
            }

        }

        if (e.CommandName.StartsWith("ExportDetail"))
        {
            string[] arg = e.CommandArgument.ToString().Split('|');

            Int64 ChannelId = Convert.ToInt64(arg[0]);
            int CycleID = Convert.ToInt32(arg[1]);
            int AmountTypeID = 0;

            DataTable dt_excel = CommissionDetailExportDAL.GenerateProvisionReport(ChannelId, AmountTypeID, CycleID);

            try
            {
                Common.ExportToExcel(dt_excel, String.Format("Provision_Distributor_{0}", System.DateTime.Now.ToString("ddMMyyy-HHmmss")));
            }
            catch
            {
                Exception ex;
            }

        }

    }
    protected void linkAllPreview_Click(object sender, EventArgs e)
    {
        DataTable dt_excel = CommissionDetailExportDAL.GetAllProvision(0, CycleId);

        try
        {
            Common.ExportToExcel(dt_excel, String.Format("Provision_Detail_{0}", System.DateTime.Now.ToString("ddMMyyy-HHmmss")));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void linkAllDisTributor_Click(object sender, EventArgs e)
    {
        DataTable dt_excel = CommissionDetailExportDAL.GetDistributorListProvision(0, CycleId);
        try
        {
            Common.ExportToExcel(dt_excel, String.Format("Provision_Distributor_{0}", System.DateTime.Now.ToString("ddMMyyy-HHmmss")));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void linkDetailBrackdown_Click(object sender, EventArgs e)
    {
        //DataTable dt_excel = CommissionDetailExportDAL.GenerateProvisionReport(0, 0, CycleId);
        DataTable dt_excel = CommissionDetailExportDAL.DetailsProvisionReport(0, CycleId);
        


        try
        {
            Common.ExportToExcel(dt_excel, String.Format("Provision_Brackdown_{0}", System.DateTime.Now.ToString("ddMMyyy-HHmmss")));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}