using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ESI.Entity.ViewModel;
using ESI.DAL;
using ESI.Entity;

public partial class KPIUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            if (!Permissions.ESIKPIUpdate)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
        }
    }

    [WebMethod]
    public static List<KPIEnt> GETKPIBYReportCycleId(string ReportCycleId)
    {
        if (ReportCycleId == null)
        {
            return new List<KPIEnt>();
        }
        int reportCycleId = Convert.ToInt32(ReportCycleId);
        var salesGroup = SalesGroupDAL.GetSalesGroupByReportCycleId(reportCycleId);
       
        int SGroupID = Convert.ToInt32(salesGroup.SALES_GROUP_ID);
        if (SGroupID < 1)
        {
            SGroupID = 0;
        }
        var kpi = ESI_KPIDAL.GetItemList(SGroupID);
        return kpi;
    }
    [WebMethod]
    public static SuccessMessage UpdateKpiConfigurationData(List<KPIViewModel> MainKPI, List<SubKPIViewModel> SubKPI, List<ConditionViewModel> Condition, int ReportCycleId, int Month)
    {
        int usrId = LoginInfo.Current.UserId;
        var kpiConfiguration = ESI_KPIConfigurationDAL.UpdateKpiConfigurationData(MainKPI, SubKPI, Condition, ReportCycleId, Month, usrId, LoginInfo.Current.UserName);
        return kpiConfiguration;
    }
    [WebMethod]
    public static KPIUpdateViewModel GetKPIWithCondition(int reportCycleId, int month)
    {
       // int sGroupID = SessionData.getUserSalesGroup().SALES_GROUP_ID;
        var salesGroup = SalesGroupDAL.GetSalesGroupByReportCycleId(reportCycleId);
        var kpi = new KPIUpdateViewModel();
        if (salesGroup.SALES_GROUP_ID > 0)
        {
            kpi = ESI_KPIDAL.GetKPIWithConditionByReportCycleIdAndMonth(reportCycleId, month, salesGroup.SALES_GROUP_ID);
        }
      
        return kpi;
    }
   
}