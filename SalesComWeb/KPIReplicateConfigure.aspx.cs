using ESI.DAL;
using ESI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using ESI.Entity.ViewModel;

public partial class SetupKpiConfigure : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {

            if (!Permissions.ESIKpiConfigure)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            var userId = LoginInfo.Current.UserId;
            Common.PopulateSalesGroup(ddlSalesGroup, userId);
            Common.PopulateSalesGroup(ddlCloneSalesGroup, userId);

            this.ddlYear.DataSource = Common.GenrateYear();
            this.ddlYear.DataBind();

            this.ddlCloneYear.DataSource = Common.GenrateYear();
            this.ddlCloneYear.DataBind();
            {
                ddlCloneMonth.SelectedValue = "0";
                ddlCloneMonth.Enabled = true;
                int reportCloneType = Convert.ToInt32(ddlCloneReportType.SelectedValue);
                if (reportCloneType == 1)
                {
                    ddlCloneMonth.Enabled = false;
                }
            }
            ClearAllDropdown();
        }

    }
    protected void ClearAllDropdown()
    {
        this.ddlReportName.Items.Clear();
        this.ddlReportName.DataBind();

        this.ddlMonth.Items.Clear();
        this.ddlMonth.DataBind();

    }

    public void MonthDropDown()
    {
        //ddlCloneMonth.Enabled = true;
        string reportname = ddlReportName.SelectedItem.Text;
        this.ddlMonth.Items.Clear();
        this.ddlMonth.DataBind();

        if (reportname.Contains("_M1_"))
        {
            ddlMonth.Items.Insert(0, new ListItem("M1", "1"));
        }
        else if (reportname.Contains("_M2_"))
        {
            ddlMonth.Items.Insert(0, new ListItem("M2", "2"));
        }
        else if (reportname.Contains("_M3_"))
        {
            ddlMonth.Items.Insert(0, new ListItem("M3", "3"));
        }
        else
        {
            //ddlCloneMonth.Enabled = false;
            ddlMonth.Items.Insert(0, new ListItem("Quarterly", "0"));
            //ddlMonth.Items.Insert(1, new ListItem("M1", "1"));
            //ddlMonth.Items.Insert(2, new ListItem("M2", "2"));
            //ddlMonth.Items.Insert(3, new ListItem("M3", "3"));
        }
    }

    protected void ddlSalesGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearAllDropdown();
        string salesGroup = ddlSalesGroup.SelectedItem.Text;
        if (Convert.ToInt32(ddlSalesGroup.SelectedItem.Value) == 0)
        {
            return;
        }
        var year = Convert.ToInt32(ddlYear.SelectedValue == "" ? DateTime.Now.Year.ToString() : ddlYear.SelectedValue);
        var quarter = Convert.ToInt32(ddlQuarter.SelectedValue == "0" ? "1" : ddlQuarter.SelectedValue);
        Common.PopulateTargetReportId(ddlReportName, 0, year, quarter, salesGroup);
    }

    protected void ddlCloneSalesGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        string asdasda = ddlCloneSalesGroup.SelectedItem.Value;
        int salesGroup = Convert.ToInt32(ddlCloneSalesGroup.SelectedItem.Value);
        if (Convert.ToInt32(ddlCloneSalesGroup.SelectedItem.Value) == 0)
        {
            return;
        }
        Common.PopulateSalesChannel(ddlCloneSalesChannelName, salesGroup);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "CallAfterLoad", "CallAfterLoad();", true);
    }


    protected void ddl_Year_IndexChanged(object sender, EventArgs e)
    {
        ClearAllDropdown();
        string salesGroup = ddlSalesGroup.SelectedItem.Text;
        if (Convert.ToInt32(ddlSalesGroup.SelectedItem.Value) == 0)
        {
            return;
        }
        var year = Convert.ToInt32(ddlYear.SelectedValue == "" ? DateTime.Now.Year.ToString() : ddlYear.SelectedValue);
        var quarter = Convert.ToInt32(ddlQuarter.SelectedValue == "0" ? "1" : ddlQuarter.SelectedValue);
        Common.PopulateTargetReportId(ddlReportName, 0, year, quarter, salesGroup);
    }
    protected void ddl_Quarter_IndexChanged(object sender, EventArgs e)
    {
        ClearAllDropdown();
        string salesGroup = ddlSalesGroup.SelectedItem.Text;
        if (Convert.ToInt32(ddlSalesGroup.SelectedItem.Value) == 0)
        {
            return;
        }
        var year = Convert.ToInt32(ddlYear.SelectedValue == "" ? DateTime.Now.Year.ToString() : ddlYear.SelectedValue);
        var quarter = Convert.ToInt32(ddlQuarter.SelectedValue == "0" ? "1" : ddlQuarter.SelectedValue);
        Common.PopulateTargetReportId(ddlReportName, 0, year, quarter, salesGroup);
    }
    protected void ddlReportName_SelectedIndexChanged(object sender, EventArgs e)
    {
        var reportCycleId = Convert.ToInt32(ddlReportName.SelectedValue == "" ? "1" : ddlReportName.SelectedValue);
       MonthDropDown();
       ScriptManager.RegisterStartupScript(this, this.GetType(), "CallAfterLoad", "CallAfterLoad();", true);
    }

    //

    [WebMethod]
    public static SuccessMessage SaveKpiConfigurationData(List<KPIViewModel> MainKPI, List<SubKPIViewModel> SubKPI, List<ConditionViewModel> Condition, int sChannelId, int year, int quarter, int month, int reportType)
    {
        int usrId = LoginInfo.Current.UserId;
        SuccessMessage kpiConfiguration = ESI_KPIConfigurationDAL.SaveKpiConfigurationData(MainKPI, SubKPI, Condition, sChannelId, year, quarter, month, reportType, usrId, LoginInfo.Current.UserName);
        return kpiConfiguration;
    }

    #region cascade dropdown


    [WebMethod]
    public static List<SalesChannelEnt> GETSalesChannelByGROUPID(string SalesGroupId)
    {
        int SGroupID = Convert.ToInt32(SalesGroupId);
        if (SGroupID < 1)
        {
            SGroupID = 0;
        }
        var SalesGroup = ESI_SalesChannelDAL.GetItemList(SGroupID);
        return SalesGroup;
    }

    [WebMethod]
    public static List<KPIEnt> GETKPIBYGROUPID(string SalesGroupId)
    {
        int SGroupID = Convert.ToInt32(SalesGroupId);
        if (SGroupID < 1)
        {
            SGroupID = 0;
        }
        var kpi = ESI_KPIDAL.GetItemList(SGroupID);
        return kpi;
    }
    [WebMethod]
    public static List<KPIEnt> GETKPIBySubKpiId(string KPIId)
    {
        int kpiId = Convert.ToInt32(KPIId);
        var kpi = ESI_KPIDAL.GetSubKpiByKpiId(kpiId);
        return kpi;
    }
    [WebMethod]
    public static List<ConditionEnt> GETConditionByKpiId(string KPIId)
    {
        int kpiId = Convert.ToInt32(KPIId);
        var conditions = ESI_KPIDAL.GetConditionByKpiId(kpiId);
        return conditions;
    }
    #endregion


    [WebMethod]
    public static string SaveReplicateData(List<KPIFromData> dataFromItem, IList<KPIToData> dataToItem, string KPIItem)
    {
        try {
            int CreateBy = LoginInfo.Current.UserId;
            var isSuccess = ESI_KPIConfigurationDAL.SaveItem(dataFromItem, dataToItem, KPIItem, CreateBy);

            if (isSuccess == "SUCCESSFUL" || isSuccess == "SUCC")
            {
                return isSuccess;
            }else
                {
                    if (isSuccess == "1") 
                    {
                        return "KPI already configured!!";
                    }
                    else if (isSuccess == "2") 
                    {
                        return "Arrear Report must have same Original Report type report!!";
                    }
                    else
                    {
                       return "Error occured while KPI configuration!!";
                    }
                    
                }
        }
       
        catch(Exception ex){
            return ex.Message;
        }
        
    }



}