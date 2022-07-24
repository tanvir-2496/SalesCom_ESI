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

            this.ddlYear.DataSource = Common.GenrateYear();
            this.ddlYear.DataBind();
            {
                ddlMonth.SelectedValue = "0";
                ddlMonth.Enabled = true;
                int reportType = Convert.ToInt32(ddlReportType.SelectedValue);
                if (reportType == 1)
                {
                    ddlMonth.Enabled = false;
                }
            }
        }
      
    }
    [WebMethod]
    public static SuccessMessage SaveKpiConfigurationData(List<KPIViewModel> MainKPI, List<SubKPIViewModel> SubKPI, List<ConditionViewModel> Condition, int sChannelId, int year, int quarter, int month, int reportType)
    {
        int usrId = LoginInfo.Current.UserId;
        SuccessMessage kpiConfiguration = ESI_KPIConfigurationDAL.SaveKpiConfigurationData(MainKPI, SubKPI, Condition, sChannelId, year, quarter, month, reportType, usrId, LoginInfo.Current.UserName);
        return kpiConfiguration;
    }

    #region cascade dropdown

    [WebMethod]
    public static List<TargetListEntClone> GETSalesKPI(string reportId, string monthid)
    {
        int reportCycleId = Int32.Parse(reportId);
        int month = Int32.Parse(monthid);

        var TargetList = TargetDAL.GetTargetStatus_Clone(reportCycleId, month);
        return TargetList;
    }

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
        if (SGroupID< 1)
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
}