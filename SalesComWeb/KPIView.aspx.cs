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
using System.Drawing;

public partial class KPIView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            if (!Permissions.ESIKPIView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
        }
    }

    [WebMethod]
    public static KPIUpdateViewModel GetKPIWithCondition(int reportCycleId, int month)
    {
        try
        {
            //int sGroupID = SessionData.getUserSalesGroup().SALES_GROUP_ID;
            var salesGroup = SalesGroupDAL.GetSalesGroupByReportCycleId(reportCycleId);
            var kpi = new KPIUpdateViewModel();
            if (salesGroup.SALES_GROUP_ID > 0)
            {
                kpi = ESI_KPIDAL.GetKPIWithConditionByReportCycleIdAndMonth(reportCycleId, month, salesGroup.SALES_GROUP_ID);
            }

            //   var kpi = ESI_KPIDAL.GetKPIWithConditionByReportCycleIdAndMonth(reportCycleId, month, sGroupID);
            return kpi;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
    }
   
}