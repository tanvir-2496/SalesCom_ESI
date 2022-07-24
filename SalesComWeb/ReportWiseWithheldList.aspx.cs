using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportWiseWithheldList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDummyRow();
        }
    }

    private void BindDummyRow()
    {
        DataTable dummy = new DataTable();
        dummy.Columns.Add("row_number");
        dummy.Columns.Add("reportname");
        dummy.Columns.Add("report_duration");
        dummy.Columns.Add("claim_amt");
        dummy.Columns.Add("withheld_amt");
        dummy.Columns.Add("disburse_amt");
        dummy.Columns.Add("approvallevelname");
        dummy.Columns.Add("current_redisburse_number");
        dummy.Columns.Add("current_redisbure_amount");
        dummy.Rows.Add();
        gvWithheldList.DataSource = dummy;
        gvWithheldList.DataBind();
    }

    [System.Web.Services.WebMethod(Description = "Get Period Type")]
    public static List<PeriodTypeEnt> GetPeriodType()
    {
        return PeriodTypeDAL.GetItemList(0);
    }

    [System.Web.Services.WebMethod(Description = "Get Year")]
    public static List<int> GetYear()
    {
        return Common.GenrateYear(); 
    }

    [System.Web.Services.WebMethod(Description = "Get Commission Cycle by Year")]
    public static List<ReportCycleEnt> GetCommissionCycleByYear(int periodTypeId, int year)
    {
        return CommissionCycleDAL.GetCommissionCycleByYear(periodTypeId, year);
    }

    [System.Web.Services.WebMethod(Description = "Get report wise withheld list")]
    public static List<ReportWiseWithheldListEnt> BindData(int cycleId, int pageIndex)
    {
        return ReportWiseWithheldListDAL.Get_Report_Wise_Withheld_List(cycleId, pageIndex);
    }

}