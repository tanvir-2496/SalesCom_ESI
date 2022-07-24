using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DetailSetUpAdd : System.Web.UI.Page
{
    private static Action SaveData;

    public string editMode
    {
        get
        {
            return ViewState["editMode"].ToString();
        }
        set
        {
            ViewState["editMode"] = value;
        }
    }
    protected int Id
    {
        get
        {
            return (int)ViewState["Id"];
        }
        set
        {
            ViewState["Id"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.DetailReportAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            editMode = "add";
            Id = -1;

            Common.PopulatePeriodType(ddlPeridType);
            Common.AddSelectOne(ddlPeridType);

            this.ddlYear.DataSource = Common.GenrateYear();
            this.ddlYear.DataBind();


            try
            {
                if (!string.IsNullOrEmpty(Request["Id"]))
                {
                    Id = int.Parse(Request["Id"]);
                    ReportMaster CampaignInfo = CampaignDenoDriveDAL.GetDailySetupById(Id);

                    hdnOperationId.Value = Id.ToString();
                    txtReportName.Text = CampaignInfo.ReportName;

                    //hdnTableData.Value = BindTableData(Id);
                    tbodyTable.InnerHtml = BindTableData(Id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (!string.IsNullOrEmpty(Request["mode"]))
            {
                editMode = Request["mode"];
                hdnEditMode.Value = editMode;
            }

           
        }
    }


    public string BindTableData(int getId)
    {
        int rowSL = 0;
        string tableName = "";
        string levelName = "";

        string actionLink = "<button type='button' class='btn' style='background-color: ff9933; margin-left: 5px;height: 18px !important;width: 42px;'  onclick='RemoveTableName(this)'><a class='fa fa-trash' style='font-size: 10px;font-style: normal !important;'>Delete</a></button></div>";
        string tableRow = "";

        IList<ReportDetail> results = CampaignDenoDriveDAL.GetDetailSetupItemData(getId);

        for (int i = 0; i < results.Count; i++)
        {
            rowSL = i;
            tableName = results[i].TableName;
            levelName = results[i].LevelName;
          
      
            tableRow = tableRow + "<tr class='dummy_row_line_item' id='deno_" + (rowSL + 1) + "'>";
            tableRow = tableRow + "<td class='dummy_sl_no' style='display: none'> <span>" + (rowSL + 1) + " </span></td>";

            tableRow = tableRow + "<td class='dummy_item_tableStart'><input type='hidden' name='TableInfo[" + (rowSL) + "].tableStart' value='" + tableName + "'> <span>" + tableName + "</span></td>";
            tableRow = tableRow + "<td class='dummy_item_levelStart'><input type='hidden' name='TableInfo[" + (rowSL) + "].levelStart' value='" + levelName + "'> <span>" + levelName + "</span></td>";


            tableRow = tableRow + "<td class='dummy_model_link'>" + actionLink + "</td>";
            tableRow = tableRow + "</tr>";
        }


        hdnRowId.Value = rowSL.ToString();

        return tableRow;
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            double CampaignDuration = ((DateTime.Now.Date - DateTime.Now.Date).TotalDays) + 1;
            if (DateTime.Now.Date <= DateTime.Now.Date)
            {
                if (DateTime.Now.Date >= DateTime.Now.Date)
                {
                    if (CampaignDuration <= 30)
                    {
                        int ErrorCode = 0;// SaveData(true);
                        MsgUtility.msg(editMode, ErrorCode, "Commission Detail Setup Information", this, lblMsg, "");
                        if (editMode == "add")
                        {
                            if (ErrorCode >= 0)
                            {
                                ClearData();
                            }
                        }
                    }
                    else
                        MsgUtility.msgCommon(this, lblMsg, " Max campaign duration is 30 days.");
                }
                else
                    MsgUtility.msgCommon(this, lblMsg, "Campaign start date must be minimum today and onwards.");
            }
            else
                MsgUtility.msgCommon(this, lblMsg, "Start date must be grater or equal from end date.");
        }
        catch (Exception EX)
        {
            MsgUtility.msgCommon(this, lblMsg, "Error Occured!!!" + EX.Message);
        }


    }



    private void ClearData()
    {
        editMode = "add";
        Id = -1;
        txtReportName.Text = String.Empty;
    }


    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        int ErrorCode = 0;
        if (editMode == "add")
        {
            MsgUtility.msg(editMode, ErrorCode, "Detail data ", this, lblMsg, "Detail SetUp");
        }
        else
        {
            MsgUtility.msg("update", ErrorCode, "Detail data ", this, lblMsg, "Detail SetUp");

        }


    }

    [WebMethod]
    public static IList<Modality> GetModalityValue(string currentData)
    {
        try
        {
            IList<Modality> obj = new List<Modality>();
            int getId = Convert.ToInt32(currentData);
            obj = CampaignDenoDriveDAL.GetModalityValue(getId);
            return obj;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    [WebMethod]
    public static bool GetIsTableExist(string table_name)
    {
        try
        {

            int value = CampaignDenoDriveDAL.GetIsTableExist(table_name);
            if (value == 1)
            {
                return true;
            }
            else {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    public static string SaveMasterDetailData(List<ReportMaster> masterItem, IList<ReportDetail> detailItem)
    {
        DetailSetUpAdd obj = new DetailSetUpAdd();
        var isSuccess = obj.SaveDataMethod(masterItem, detailItem);
        return isSuccess;
    }

    [WebMethod]
    public static string IsReportNameValid(string GetName)
    {
        try
        {
            string reportName = GetName;
            string getResult = CampaignDenoDriveDAL.CheckReportNameValid(reportName);
            return getResult;
        }
        catch(Exception ex) {
            return ex.Message.ToString();
        }
    }



    public string SaveDataMethod(List<ReportMaster> masterItem, IList<ReportDetail> detailItem)
    {
        try
        {
            ReportMaster MasterInfo = new ReportMaster();

            MasterInfo.ReportName = masterItem[0].ReportName;
            MasterInfo.Id = masterItem[0].Id;
            MasterInfo.Mode = masterItem[0].Mode;
            MasterInfo.CyCleId = masterItem[0].CyCleId;
          
               int CreateBy = LoginInfo.Current.UserId;
               string getResult = CampaignDenoDriveDAL.SaveReportMasterDetailItemData(MasterInfo, CreateBy, detailItem);

               return getResult;
        }
        catch (Exception EX)
        {
            return EX.Message.ToString();
        }

    }

    [System.Web.Services.WebMethod]
    public static List<string> GetReportName(string month)
    {
        int yearMonth = 0;
       
        if (month != "") {
            yearMonth = Int16.Parse(month);
        }


        return CommissionReportDAL.Get_Report_Name_By_YearMonth(yearMonth);


        //if (year != "" && month !="")
        //{
        //    month = month.Substring(0, 3);
        //    year = year.Substring(year.Length - 2);
        //    yearMonth = month + "_" + year;
        //}
       
    }


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

    private void BindData(Int32 commissionCycleId, string reportName)
    {
        List<ReportViewWithTotal> list;
        if (commissionCycleId > 0)
        {
            list = ReportViewDAL.GetItemList(commissionCycleId, string.Empty);
            this.txtReportName.Text = string.Empty;
        }
        else if (!string.IsNullOrEmpty(reportName))
        {
            list = ReportViewDAL.GetItemList(0, reportName);
        }
        else
        {
            list = new List<ReportViewWithTotal>();
            this.txtReportName.Text = string.Empty;
        }
     
    }
    protected void ddlCommissionCycle_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlCommissionCycle.SelectedIndex > 0)
        {
           
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

    

}