using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CdpDetailReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            // BindData();

            PopulateCDPReportList(this.ddlReportname);
            ddlReportname.Items.Insert(0, new ListItem("---Select----", "-1"));
        }
    }

    public void PopulateCDPReportList(ListControl control)
    {
        control.DataSource = CdpReportDAL.Get_CDP_Report_List();
        control.DataTextField = "report_name";
        control.DataValueField = "cdp_report_info_id";
        control.DataBind();
    }



    private void BindData(DateTime startDate, DateTime endDate, int rName, string rType)
    {
        List<CdpReportEntity> list = new List<CdpReportEntity>();
        list = CdpReportDAL.GetCdpReport(startDate, endDate, rName, rType);
        lv.DataSource = list;
        lv.DataBind();
        lblResults.Text = String.Format("Total results: {0}", list.Count);
        pager.Visible = list.Count > pager.PageSize;

    }


    protected void pager_PreRender(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            DateTime fDate = DateTime.Parse(txtFromDate.Text);
            DateTime tDate = DateTime.Parse(txtToDate.Text);
            int rName = Convert.ToInt32(ddlReportname.SelectedValue);
            string rType = Convert.ToString(ddlReportType.SelectedValue);
            BindData(fDate, tDate, rName, rType);
        }

    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        DateTime fDate = DateTime.Parse(txtFromDate.Text);
        DateTime tDate = DateTime.Parse(txtToDate.Text);
        int rName = Convert.ToInt32(ddlReportname.SelectedValue);
        string rType = Convert.ToString(ddlReportType.SelectedValue);
        BindData(fDate, tDate, rName, rType);
    }

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        DateTime fDate = DateTime.Parse(txtFromDate.Text);
        DateTime tDate = DateTime.Parse(txtToDate.Text);
        int rName = Convert.ToInt32(ddlReportname.SelectedValue);
        string rType = Convert.ToString(ddlReportType.SelectedValue);
        // Export export = new Export();
        DataTable dt_excel = CdpReportDAL.ReportData(fDate, tDate, rName, rType);
        try
        {
            Common.ExportToExcel(dt_excel, String.Format("Sales_Incentive_{0}_{1}", "", System.DateTime.Now.ToString("ddMMyyy-HHmmss")));
        }
        catch (Exception ex)
        {
            this.lblResults.Text = ex.Message;
        }


    }
}