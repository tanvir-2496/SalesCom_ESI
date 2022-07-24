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
        }
        if (string.IsNullOrEmpty(HttpContext.Current.Session["SalesChannel"].ToString()))
        {
            Server.TransferRequest(Request.Url.AbsolutePath, false);
            return;
        }
    }
    [WebMethod]
    public static SuccessMessage SaveKpiConfigurationData(List<KPIViewModel> MainKPI, List<SubKPIViewModel> SubKPI, List<ConditionViewModel> Condition, int sChannelId, int year, int quarter, int thresholdType)
    {
        int usrId = LoginInfo.Current.UserId;
        SuccessMessage kpiConfiguration = ESI_KPIConfigurationDAL2.SaveKpiConfigurationData(MainKPI, SubKPI, Condition, sChannelId, year, quarter, thresholdType, usrId, LoginInfo.Current.UserName);
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