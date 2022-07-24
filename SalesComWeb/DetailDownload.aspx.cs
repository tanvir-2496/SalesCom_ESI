using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using ClosedXML.Excel;
using System.IO;


public partial class DetailDownload : System.Web.UI.Page
{

    protected void pager_PreRender(object sender, EventArgs e)
    {
        if (ddlCommissionCycle.SelectedIndex > 0)
        {
            BindData(Int32.Parse(ddlCommissionCycle.SelectedValue), string.Empty);
        }
        else if (!string.IsNullOrEmpty(this.txtReportName.Text))
        {
            BindData(0, this.txtReportName.Text.Trim());
        }
        else
        {
            BindData(0, string.Empty);
        }
    }


    [System.Web.Services.WebMethod]
    public static List<string> GetReportName()
    {
        return CommissionReportDAL.Get_Detail_Report_Name_List(0);
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            if (!Permissions.DetailReportDownloadView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            Common.PopulatePeriodType(ddlPeridType);
            Common.AddSelectOne(ddlPeridType);
            this.ddlYear.DataSource = Common.GenrateYear();
            this.ddlYear.DataBind();
        }

    }

    private void BindData(Int32 commissionCycleId, string reportName)
    {
        List<DetailDownloadList> list;
        if (commissionCycleId > 0)
        {
            list = ReportViewDAL.GetDetailDownloadList(commissionCycleId, string.Empty);
            this.txtReportName.Text = string.Empty;
        }
        else if (!string.IsNullOrEmpty(reportName))
        {
            list = ReportViewDAL.GetDetailDownloadList(0, reportName);
        }
        else
        {
            list = new List<DetailDownloadList>();
            this.txtReportName.Text = string.Empty;
        }
        lv.DataSource = list;
        lv.DataBind();

        lblResults.Text = String.Format("Total results: {0}", list.Count);
        pager.Visible = list.Count > pager.PageSize;
    }

   
    protected void lv_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        string arg = e.CommandArgument.ToString();
        int MasterID = Convert.ToInt32(arg);
        
        Export export = new Export();

        DataTable dt = CommissionDetailExportDAL.DetailsDataDownload(MasterID);

        try
        {
            Common.ToCSV(dt, String.Format("Detail_Report_Wise_{0}", System.DateTime.Now.ToString("ddMMyyy-HHmmss")));
        }
        catch (Exception ex)
        {
            this.lblResults.Text = ex.Message;
        }
    }
    public static string ValidateColumnData(string input)
    {
        try
        {
            if (input == null)
                return string.Empty;

            bool isQuote = false;
            bool isComma = false;
            int len = input.Length;
            for (int i = 0; i < len && (isComma == false || isQuote == false); i++)
            {
                char ch = input[i];
                if (ch == '"')
                    isQuote = true;
                else if (ch == ',')
                    isComma = true;
            }

            if (isQuote)
                input = input.Replace("\"", "\"\"");

            if (isComma)
                return "\"" + input + "\"";
            else
                return input;
        }
        catch
        {
            throw new Exception(string.Format("Data Parsing Error: Column Data : {0}", input));
        }
    }

    protected void ddlCommissionCycle_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlCommissionCycle.SelectedIndex > 0)
        {
            pager.SetPageProperties(0, pager.MaximumRows, false);
            BindData(Int32.Parse(ddlCommissionCycle.SelectedValue), string.Empty);
        }
        else
        {
            BindData(0, string.Empty);
        }
    }

    protected void ddlPeridType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPeridType.SelectedIndex > 0)
        {
            Common.PopulateCommissionCycleByYear(ddlCommissionCycle, int.Parse(ddlPeridType.SelectedValue), int.Parse(ddlYear.SelectedValue));
            Common.AddSelectOne(ddlCommissionCycle);
        }
        else
        {
            ddlCommissionCycle.Items.Clear();
        }
        BindData(0, string.Empty);
    }
    protected void lv_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        //LinkButton _lbtnDetailsAmount = (LinkButton)e.Item.FindControl("lbtnDetailsAmount");
        //PostBackTrigger ti = new PostBackTrigger();
        //ti.ControlID = _lbtnDetailsAmount.ClientID;
        //upCycle.Triggers.Add(ti);
        //ScriptManager.GetCurrent(Page).RegisterPostBackControl(_lbtnDetailsAmount);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(this.txtReportName.Text))
        {
            this.ddlPeridType.SelectedIndex = 0;
            ddlCommissionCycle.Items.Clear();
            pager.SetPageProperties(0, pager.MaximumRows, false);
            BindData(0, this.txtReportName.Text.Trim());
        }

    }

    //protected void btnDownloadReport_Click(object sender, EventArgs e)
    //{
    //    string arg = btnDownloadReport.Text;
    //    int MasterID = Convert.ToInt32(arg);

    //    Export export = new Export();

    //    DataTable dt = CommissionDetailExportDAL.DetailsDataDownload(MasterID);

    //    try
    //    {
    //        Common.ExportToExcel(dt, String.Format("Detail_Report_Wise_{0}", System.DateTime.Now.ToString("ddMMyyy-HHmmss")));

    //    }
    //    catch (Exception ex)
    //    {
    //        this.lblResults.Text = ex.Message;
    //    }
    //}
}
