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

public partial class SetupKpiTarget : System.Web.UI.Page
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

        string reportname = ddlReportName.SelectedItem.Text;
        this.ddlMonth.Items.Clear();
        this.ddlMonth.DataBind();

        if (reportname.Contains("_M1_"))
        {
            ddlMonth.Items.Insert(0, new ListItem("M1", "1"));
        }
        else if (reportname.Contains("_M1_"))
        {
            ddlMonth.Items.Insert(0, new ListItem("M2", "2"));
        }
        else if (reportname.Contains("_M1_"))
        {
            ddlMonth.Items.Insert(0, new ListItem("M3", "3"));
        }
        else
        {
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
    //protected void ddlReportName_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    var reportCycleId = Convert.ToInt32(ddlReportName.SelectedValue == "" ? "1" : ddlReportName.SelectedValue);
    //    MonthDropDown();
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "CallAfterLoad", "CallAfterLoad();", true);
    //}

    protected void ddlReportName_SelectedIndexChanged(object sender, EventArgs e)
    {
        var reportCycleId = Convert.ToInt32(ddlReportName.SelectedValue == "" ? "1" : ddlReportName.SelectedValue);

        this.ddlKPI.Items.Clear();
        this.ddlKPI.DataBind();
        this.ddlKPI.Items.Insert(0, new ListItem("Select KPI", "0"));

        this.ddlSubKPI.Items.Clear();
        this.ddlSubKPI.DataBind();
        this.ddlSubKPI.Items.Insert(0, new ListItem("Select Sub KPI", "0"));

        Common.PopulateKPIData(ddlKPI, reportCycleId);
        MonthDropDown();
        

    }

    protected void ddl_KPI_IndexChanged(object sender, EventArgs e)
    {
        var reportCycleId = Convert.ToInt32(ddlReportName.SelectedValue == "" ? "1" : ddlReportName.SelectedValue);
        var parentKPI = Convert.ToInt32(ddlKPI.SelectedValue == "" ? "1" : ddlKPI.SelectedValue);
        Common.PopulateSubKPIData(ddlSubKPI, reportCycleId, parentKPI);
        Common.PopulateCondition(ddlCondition, reportCycleId, parentKPI);
    }

    protected void ddl_SubKPI_IndexChanged(object sender, EventArgs e)
    {
        var reportCycleId = Convert.ToInt32(ddlReportName.SelectedValue == "" ? "1" : ddlReportName.SelectedValue);
        var parentKPI = Convert.ToInt32(ddlSubKPI.SelectedValue == "" ? "1" : ddlSubKPI.SelectedValue);
        Common.PopulateCondition(ddlCondition, reportCycleId, parentKPI);
    }

    #region Clone Section
    protected void ddl_Clone_SubKPI_IndexChanged(object sender, EventArgs e)
    {
        var reportCycleId = Convert.ToInt32(ddlCloneReportName.SelectedValue == "" ? "1" : ddlCloneReportName.SelectedValue);
        var parentKPI = Convert.ToInt32(ddlCloneSubKPI.SelectedValue == "" ? "1" : ddlCloneSubKPI.SelectedValue);
        Common.PopulateCondition(ddlCloneCondition, reportCycleId, parentKPI);
    }

    protected void ddl_Clone_KPI_IndexChanged(object sender, EventArgs e)
    {
        var reportCycleId = Convert.ToInt32(ddlCloneReportName.SelectedValue == "" ? "1" : ddlCloneReportName.SelectedValue);
        var parentKPI = Convert.ToInt32(ddlCloneKPI.SelectedValue == "" ? "1" : ddlCloneKPI.SelectedValue);
        Common.PopulateSubKPI(ddlCloneSubKPI, reportCycleId, parentKPI);
        Common.PopulateCondition(ddlCloneCondition, reportCycleId, parentKPI);
    }

    protected void ddlCloneReportName_SelectedIndexChanged(object sender, EventArgs e)
    {
        var reportCycleId = Convert.ToInt32(ddlCloneReportName.SelectedValue == "" ? "1" : ddlCloneReportName.SelectedValue);

        this.ddlCloneKPI.Items.Clear();
        this.ddlCloneKPI.DataBind();
        this.ddlCloneKPI.Items.Insert(0, new ListItem("Select KPI", "0"));

        this.ddlCloneSubKPI.Items.Clear();
        this.ddlCloneSubKPI.DataBind();
        this.ddlCloneSubKPI.Items.Insert(0, new ListItem("Select Sub KPI", "0"));

        Common.PopulateKPI(ddlCloneKPI, reportCycleId);
        CloneMonthDropDown();


    }

    protected void CloneClearAllDropdown()
    {
        this.ddlCloneReportName.Items.Clear();
        this.ddlCloneReportName.DataBind();

        this.ddlCloneMonth.Items.Clear();
        this.ddlCloneMonth.DataBind();

    }
    protected void ddlCloneSalesGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        CloneClearAllDropdown();
        string salesGroup = ddlCloneSalesGroup.SelectedItem.Text;
        if (Convert.ToInt32(ddlCloneSalesGroup.SelectedItem.Value) == 0)
        {
            return;
        }
        var year = Convert.ToInt32(ddlCloneYear.SelectedValue == "" ? DateTime.Now.Year.ToString() : ddlCloneYear.SelectedValue);
        var quarter = Convert.ToInt32(ddlCloneQuarter.SelectedValue == "0" ? "1" : ddlCloneQuarter.SelectedValue);
        Common.PopulateTargetReportId(ddlCloneReportName, 0, year, quarter, salesGroup);
    }


    protected void ddl_Clone_Year_IndexChanged(object sender, EventArgs e)
    {
        CloneClearAllDropdown();
        string salesGroup = ddlCloneSalesGroup.SelectedItem.Text;
        if (Convert.ToInt32(ddlCloneSalesGroup.SelectedItem.Value) == 0)
        {
            return;
        }
        var year = Convert.ToInt32(ddlCloneYear.SelectedValue == "" ? DateTime.Now.Year.ToString() : ddlCloneYear.SelectedValue);
        var quarter = Convert.ToInt32(ddlCloneQuarter.SelectedValue == "0" ? "1" : ddlCloneQuarter.SelectedValue);
        Common.PopulateTargetReportId(ddlCloneReportName, 0, year, quarter, salesGroup);
    }
    protected void ddl_Clone_Quarter_IndexChanged(object sender, EventArgs e)
    {
        CloneClearAllDropdown();
        string salesGroup = ddlCloneSalesGroup.SelectedItem.Text;
        if (Convert.ToInt32(ddlCloneSalesGroup.SelectedItem.Value) == 0)
        {
            return;
        }
        var year = Convert.ToInt32(ddlCloneYear.SelectedValue == "" ? DateTime.Now.Year.ToString() : ddlCloneYear.SelectedValue);
        var quarter = Convert.ToInt32(ddlCloneQuarter.SelectedValue == "0" ? "1" : ddlCloneQuarter.SelectedValue);
        Common.PopulateTargetReportId(ddlCloneReportName, 0, year, quarter, salesGroup);
    }

    public void CloneMonthDropDown()
    {

        string reportname = ddlCloneReportName.SelectedItem.Text;
        this.ddlCloneMonth.Items.Clear();
        this.ddlCloneMonth.DataBind();

        if (reportname.Contains("_M1_"))
        {
            ddlCloneMonth.Items.Insert(0, new ListItem("M1", "1"));
        }
        else if (reportname.Contains("_M1_"))
        {
            ddlCloneMonth.Items.Insert(0, new ListItem("M2", "2"));
        }
        else if (reportname.Contains("_M1_"))
        {
            ddlCloneMonth.Items.Insert(0, new ListItem("M3", "3"));
        }
        else
        {
            ddlCloneMonth.Items.Insert(0, new ListItem("Quarterly", "0"));
            //ddlCloneMonth.Items.Insert(1, new ListItem("M1", "1"));
            //ddlCloneMonth.Items.Insert(2, new ListItem("M2", "2"));
            //ddlCloneMonth.Items.Insert(3, new ListItem("M3", "3"));
        }
    }
    #endregion

    

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
    public static string SaveReplicateData(List<KPITargetFromData> dataFromItem, IList<KPITargetToData> dataToItem)
    {

        try
        {
            int CreateBy = LoginInfo.Current.UserId;
            var isSuccess = TargetDAL.SaveItem(dataFromItem, dataToItem, CreateBy);
            return isSuccess;
        }

        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    [WebMethod]
    public static List<TargetListEntClone> GetSalesApprovedKPI(string reportId, string monthid)
    {
        int reportCycleId = Int32.Parse(reportId);
        int month = Int32.Parse(monthid);

        var TargetList = TargetDAL.GetTargetStatus_Approved(reportCycleId, month);
        return TargetList;
    }
}