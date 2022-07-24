using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for Permissions
/// </summary>
public class Permissions
{

    //public static bool Manage_Shop              { get { return LoadFromSession(8) && LoginInfo.Current.CenterType == AppConstant.ShopTypeID ; } }
    //group 26 

    public static bool ActivityView { get { return LoadFromSession(800001); } }
    public static bool ActivityAdd { get { return LoadFromSession(800002); } }
    public static bool ActivityModify { get { return LoadFromSession(800003); } }
    public static bool ActivityDelete { get { return LoadFromSession(800004); } }

    public static bool SIMValidationRuleView { get { return LoadFromSession(800005); } }
    public static bool SIMValidationRuleAdd { get { return LoadFromSession(800006); } }
    public static bool SIMValidationRuleModify { get { return LoadFromSession(800007); } }
    public static bool SIMValidationRuleDelete { get { return LoadFromSession(800008); } }

    public static bool EventTypeView { get { return LoadFromSession(800009); } }
    public static bool EventTypeAdd { get { return LoadFromSession(800010); } }
    public static bool EventTypeModify { get { return LoadFromSession(800011); } }
    public static bool EventTypeDelete { get { return LoadFromSession(800012); } }

    public static bool EventView { get { return LoadFromSession(800013); } }
    public static bool EventAdd { get { return LoadFromSession(800014); } }
    public static bool EventModify { get { return LoadFromSession(800015); } }
    public static bool EventDelete { get { return LoadFromSession(800016); } }

    public static bool CommissionCycleView { get { return LoadFromSession(800017); } }
    public static bool CommissionCycleAdd { get { return LoadFromSession(800018); } }
    public static bool CommissionCycleModify { get { return LoadFromSession(800019); } }
    public static bool CommissionCycleDelete { get { return LoadFromSession(800020); } }

    public static bool CommissionReportView { get { return LoadFromSession(800021); } }
    public static bool CommissionReportAdd { get { return LoadFromSession(800022); } }
    public static bool CommissionReportModify { get { return LoadFromSession(800023); } }
    public static bool CommissionReportDelete { get { return LoadFromSession(800024); } }

    public static bool EventRuleView { get { return LoadFromSession(800025); } }
    public static bool EventRuleAdd { get { return LoadFromSession(800026); } }
    public static bool EventRuleModify { get { return LoadFromSession(800027); } }
    public static bool EventRuleDelete { get { return LoadFromSession(800028); } }

    public static bool PeriodTypeView { get { return LoadFromSession(800029); } }
    public static bool PeriodTypeAdd { get { return LoadFromSession(800030); } }
    public static bool PeriodTypeModify { get { return LoadFromSession(800031); } }
    public static bool PeriodTypeDelete { get { return LoadFromSession(800032); } }

    public static bool PeriodView { get { return LoadFromSession(800033); } }
    public static bool PeriodAdd { get { return LoadFromSession(800034); } }
    public static bool PeriodModify { get { return LoadFromSession(800035); } }
    public static bool PeriodDelete { get { return LoadFromSession(800036); } }

    public static bool ChannelTypeView { get { return LoadFromSession(800037); } }
    public static bool ChannelTypeAdd { get { return LoadFromSession(800038); } }
    public static bool ChannelTypeModify { get { return LoadFromSession(800039); } }
    public static bool ChannelTypeDelete { get { return LoadFromSession(800040); } }

    public static bool ChannelView { get { return LoadFromSession(800041); } }
    public static bool ChannelAdd { get { return LoadFromSession(800042); } }
    public static bool ChannelModify { get { return LoadFromSession(800043); } }
    public static bool ChannelDelete { get { return LoadFromSession(800044); } }

    public static bool SegmentTypeView { get { return LoadFromSession(800045); } }
    public static bool SegmentTypeAdd { get { return LoadFromSession(800046); } }
    public static bool SegmentTypeModify { get { return LoadFromSession(800047); } }
    public static bool SegmentTypeDelete { get { return LoadFromSession(800048); } }

    public static bool SegmentView { get { return LoadFromSession(800049); } }
    public static bool SegmentAdd { get { return LoadFromSession(800050); } }
    public static bool SegmentModify { get { return LoadFromSession(800051); } }
    public static bool SegmentDelete { get { return LoadFromSession(800052); } }

    public static bool CommsiionReportSegmentsView { get { return LoadFromSession(800053); } }
    public static bool CommsiionReportSegmentsAdd { get { return LoadFromSession(800054); } }
    public static bool CommsiionReportSegmentsModify { get { return LoadFromSession(800055); } }
    public static bool CommsiionReportSegmentsDelete { get { return LoadFromSession(800056); } }

    public static bool SAFImportExcelView { get { return LoadFromSession(800057); } }
    public static bool SAFImportExcelAdd { get { return LoadFromSession(800058); } }
    public static bool SAFImportExcelModify { get { return LoadFromSession(800059); } }
    public static bool SAFImportExcelDelete { get { return LoadFromSession(800060); } }

    public static bool ImportCommissionTargetView { get { return LoadFromSession(800061); } }
    public static bool ImportCommissionTargetAdd { get { return LoadFromSession(800062); } }
    public static bool ImportCommissionTargetModify { get { return LoadFromSession(800063); } }
    public static bool ImportCommissionTargetDelete { get { return LoadFromSession(800064); } }

    public static bool ModalityReportContentView { get { return LoadFromSession(800065); } }
    public static bool ModalityReportContentAdd { get { return LoadFromSession(800066); } }
    public static bool ModalityReportContentModify { get { return LoadFromSession(800067); } }
    public static bool ModalityReportContentDelete { get { return LoadFromSession(800068); } }

    public static bool ExcludedProductsView { get { return LoadFromSession(800069); } }
    public static bool ExcludedProductsAdd { get { return LoadFromSession(800070); } }
    public static bool ExcludedProductsModify { get { return LoadFromSession(800071); } }
    public static bool ExcludedProductsDelete { get { return LoadFromSession(800072); } }

    public static bool ChannelWithdrawalView { get { return LoadFromSession(800073); } }
    public static bool ChannelWithdrawalAdd { get { return LoadFromSession(800074); } }
    public static bool ChannelWithdrawalModify { get { return LoadFromSession(800075); } }
    public static bool ChannelWithdrawalDelete { get { return LoadFromSession(800076); } }

    public static bool ApprovalFlowView { get { return LoadFromSession(800077); } }
    public static bool ApprovalFlowAdd { get { return LoadFromSession(800078); } }
    public static bool ApprovalFlowModify { get { return LoadFromSession(800079); } }
    public static bool ApprovalFlowDelete { get { return LoadFromSession(800080); } }

    public static bool ApprovalLevelView { get { return LoadFromSession(800081); } }
    public static bool ApprovalLevelAdd { get { return LoadFromSession(800082); } }
    public static bool ApprovalLevelModify { get { return LoadFromSession(800083); } }
    public static bool ApprovalLevelDelete { get { return LoadFromSession(800084); } }

    public static bool LevelUserView { get { return LoadFromSession(800085); } }
    public static bool LevelUserAdd { get { return LoadFromSession(800086); } }
    public static bool LevelUserModify { get { return LoadFromSession(800087); } }
    public static bool LevelUserDelete { get { return LoadFromSession(800088); } }

    public static bool PendingApprovalView { get { return LoadFromSession(800089); } }
    public static bool PendingApprovalAdd { get { return LoadFromSession(800090); } }
    public static bool PendingApprovalModify { get { return LoadFromSession(800091); } }
    public static bool PendingApprovalDelete { get { return LoadFromSession(800092); } }

    public static bool PendingApprovalViewView { get { return LoadFromSession(800093); } }
    public static bool PendingApprovalViewAdd { get { return LoadFromSession(800094); } }
    public static bool PendingApprovalViewModify { get { return LoadFromSession(800095); } }
    public static bool PendingApprovalViewDelete { get { return LoadFromSession(800096); } }

    public static bool ReportViewView { get { return LoadFromSession(800097); } }
    public static bool ReportViewAdd { get { return LoadFromSession(800098); } }
    public static bool ReportViewModify { get { return LoadFromSession(800099); } }
    public static bool ReportViewDelete { get { return LoadFromSession(800100); } }

    public static bool PendingApprovalSummaryView { get { return LoadFromSession(800101); } }
    public static bool PendingApprovalSummaryAdd { get { return LoadFromSession(800102); } }
    public static bool PendingApprovalSummaryModify { get { return LoadFromSession(800103); } }
    public static bool PendingApprovalSummaryDelete { get { return LoadFromSession(800104); } }

    public static bool ChannelEventBatchView { get { return LoadFromSession(800105); } }
    public static bool ChannelEventBatchAdd { get { return LoadFromSession(800106); } }
    public static bool ChannelEventBatchModify { get { return LoadFromSession(800107); } }
    public static bool ChannelEventBatchDelete { get { return LoadFromSession(800108); } }

    public static bool CommissionReportConciseView { get { return LoadFromSession(800109); } }
    public static bool CommissionReportConciseAdd { get { return LoadFromSession(800110); } }
    public static bool CommissionReportConciseModify { get { return LoadFromSession(800111); } }
    public static bool CommissionReportConciseDelete { get { return LoadFromSession(800112); } }

    public static bool CommissionReportCopyView { get { return LoadFromSession(800113); } }
    public static bool CommissionReportCopyAdd { get { return LoadFromSession(800114); } }
    public static bool CommissionReportCopyModify { get { return LoadFromSession(800115); } }
    public static bool CommissionReportCopyDelete { get { return LoadFromSession(800116); } }

    public static bool ReportPreExeConfigView { get { return LoadFromSession(800117); } }
    public static bool ReportPreExeConfigAdd { get { return LoadFromSession(800118); } }
    public static bool ReportPreExeConfigModify { get { return LoadFromSession(800119); } }
    public static bool ReportPreExeConfigDelete { get { return LoadFromSession(800120); } }

    public static bool InitiateClaimApprovalView { get { return LoadFromSession(800121); } }
    public static bool InitiateClaimApprovalUpload { get { return LoadFromSession(800122); } }
    public static bool InitiateClaimApprovalModify { get { return LoadFromSession(800123); } }
    public static bool InitiateClaimApprovalDelete { get { return LoadFromSession(800124); } }

    public static bool AdhocReportView { get { return LoadFromSession(800125); } }
    public static bool AdhocReportAdd { get { return LoadFromSession(800126); } }
    public static bool AdhocReportModify { get { return LoadFromSession(800127); } }
    public static bool AdhocReportDelete { get { return LoadFromSession(800128); } }

    public static bool AdhocPendingApprovalView { get { return LoadFromSession(800129); } }
    public static bool AdhocPendingApprovalAdd { get { return LoadFromSession(800130); } }
    public static bool AdhocPendingApprovalModify { get { return LoadFromSession(800131); } }
    public static bool AdhocPendingApprovalDelete { get { return LoadFromSession(800132); } }

    public static bool AdhocReportViewView { get { return LoadFromSession(800133); } }
    public static bool AdhocReportViewAdd { get { return LoadFromSession(800134); } }
    public static bool AdhocReportViewModify { get { return LoadFromSession(800135); } }
    public static bool AdhocReportViewDelete { get { return LoadFromSession(800136); } }
    public static bool CdpReport { get { return LoadFromSession(800160); } }

    public static bool AdhocSummaryReportView { get { return LoadFromSession(800137); } }
    public static bool AdhocPendingApprovalViewView { get { return LoadFromSession(800138); } }

    public static bool ReportApprovalView { get { return LoadFromSession(800139); } }
    public static bool ReportApprovalAdd { get { return LoadFromSession(800140); } }
    public static bool ReportApprovalModify { get { return LoadFromSession(800141); } }
    public static bool ReportApprovalDelete { get { return LoadFromSession(800142); } }
    public static bool ReportApprovalAct { get { return LoadFromSession(800143); } }

    public static bool ClaimApprovalView { get { return LoadFromSession(800144); } }
    public static bool ClaimApprovalOperation { get { return LoadFromSession(800145); } }

    public static bool InitiateDisburseApprovalView { get { return LoadFromSession(800146); } }
    public static bool InitiateDisburseApprovalUpload { get { return LoadFromSession(800147); } }
    public static bool InitiateDisburseApprovalModify { get { return LoadFromSession(800148); } }
    public static bool InitiateDisburseApprovalDelete { get { return LoadFromSession(800149); } }

    public static bool DisburseApprovalProcessView { get { return LoadFromSession(800150); } }
    public static bool DisburseApprovalProcessDownload { get { return LoadFromSession(800151); } }
    public static bool DisburseApprovalProcessApproval { get { return LoadFromSession(800152); } }

    public static bool DisburseReportView { get { return LoadFromSession(800153); } }
    public static bool DisburseReportDownload { get { return LoadFromSession(800154); } }

    public static bool ReportCycleMappingView { get { return LoadFromSession(800154); } }
    public static bool ReportCycleMappingAdd { get { return LoadFromSession(800155); } }
    public static bool ReportCycleMappingEdit { get { return LoadFromSession(800156); } }

    public static bool RetailerTermination { get { return LoadFromSession(800157); } }
    public static bool RetailerTerminationList { get { return LoadFromSession(800158); } }

    public static bool PosUploadReportDownload { get { return LoadFromSession(800159); } }

    
    public static bool HeadWiseWithheldList { get { return LoadFromSession(800160); } }
    
    public static bool ReportWiseWithheldList { get { return LoadFromSession(800161); } }

    public static bool RedisburseInitiation { get { return LoadFromSession(800162); } }

    public static bool RedisburseApprovalProcessView { get { return LoadFromSession(800163); } }
    public static bool RedisburseApprovalProcessAction { get { return LoadFromSession(800164); } }


	// ESI Page Permission
    public static bool ESIKpiConfigure { get { return LoadFromSession(800161); } }
    public static bool ESISetupKpiAdd { get { return LoadFromSession(800162); } }
    public static bool ESISetupSubKpiAdd { get { return LoadFromSession(800163); } }
    public static bool ESISetupConditionAdd { get { return LoadFromSession(800164); } }

    public static bool ESITargetUpload { get { return LoadFromSession(800169); } }
    public static bool ESISetupChannelMapping { get { return LoadFromSession(800178); } }
    public static bool ESISetupManualData { get { return LoadFromSession(800179); } }

    public static bool ESIOwnDashboard { get { return LoadFromSession(800175); } }
    public static bool ESIHierarchyWiseDashboard { get { return LoadFromSession(800176); } }

    public static bool ESIKPIApproval { get { return LoadFromSession(800167); } }
    public static bool ESIKPIView { get { return LoadFromSession(800166); } }
    public static bool ESIKPIUpdate { get { return LoadFromSession(800165); } }
    public static bool ESIKpiApprovalAct { get { return LoadFromSession(800168); } }

    public static bool ESITargetApproval { get { return LoadFromSession(800170); } }
    public static bool ESITargetApprovalAct { get { return LoadFromSession(800172); } }
    public static bool ESITargetView { get { return LoadFromSession(800171); } }

    public static bool ESIReportApproval { get { return LoadFromSession(800173); } }
    public static bool ESIReportApprovalAct { get { return LoadFromSession(800177); } }

    public static bool ESIKPIReportView { get { return LoadFromSession(800174); } }

    //For Daily Deno Campaign list view, add, update, stop
    public static bool DailyCampaignView { get { return LoadFromSession(800180); } }
    public static bool DailyCampaignAdd { get { return LoadFromSession(800181); } }
    public static bool DailyCampaignUpdate { get { return LoadFromSession(800182); } }

    //For Campaign Deno Drive list view, add, update, stop
    public static bool CampaignDenoView { get { return LoadFromSession(800183); } }
    public static bool CampaignDenoAdd { get { return LoadFromSession(800184); } }
    public static bool CampaignDenoTarget { get { return LoadFromSession(800185); } }
    public static bool CampaignDenoApprovalList { get { return LoadFromSession(800186); } }
    public static bool CampaignDenoDetailView { get { return LoadFromSession(800187); } }
    public static bool CampaignDenoApproveAct { get { return LoadFromSession(800188); } }


    public static bool DetailReportView { get { return LoadFromSession(800189); } }
    public static bool DetailReportAdd { get { return LoadFromSession(800190); } }
    public static bool DetailReportDownloadView { get { return LoadFromSession(800191); } }


//800183	Deno Drive Campaign list
//800184	Deno Drive Campaign Add
//800185	Deno Drive Target Upload
//800186	Deno Drive Approval List
//800187	Deno Drive Campaign Detail View 
//800188	Deno Drive Campaign Approve or Reject






    public static bool IsAccessible(string PageName)
    {
        return true;

        //PageName = PageName.Split('/').Last().Split('.').First()+".aspx";

        //switch (PageName.ToLower())
        //{
        //    case "usergroup.aspx":
        //    case "usergroupadd.aspx":
        //        return User_Setup;


        //    case "userinfo.aspx":
        //    case "userinfoadd.aspx":
        //        return User_Setup || Manage_Shop;



        //    case "roleinfo.aspx":
        //    case "roleinfoadd.aspx":
        //    case "setroleright.aspx":
        //        return Role_Setup;



        //    case "rolegroup.aspx":
        //    case "rolegroupadd.aspx":
        //        return Role_Group;


        //    case "channel.aspx":
        //    case "channeladd.aspx":
        //        return Channel_Setup;



        //    case "center.aspx":
        //    case "centeradd.aspx":
        //        return Center_Setup;


        //    case "addusertocenter.aspx":
        //    case "setteller.aspx":
        //    case "userteller.aspx":
        //    case "teller.aspx":
        //    case "telleradd.aspx":
        //        return Manage_Shop;

        //    case "default.aspx":
        //    case ".aspx":
        //        return true;

        //    default:
        //        return LoginInfo.Current.IsSuperUser;


        // }
    }

    private static bool LoadFromSession(int rightId)
    {
        List<POS.DAL.RoleRight> permissions = HttpContext.Current.Session["Permissions"] as List<POS.DAL.RoleRight>;
        //if (LoginInfo.Current.IsSuperUser)
        //{
        //    return true;
        //}
        permissions = POS.BLL.RoleRightBLL.getRoleRightByUserId(LoginInfo.Current.UserId);
        if (HttpContext.Current.Session["Permissions"] == null)
        {
            HttpContext.Current.Session["Permissions"] = "1";

        }

        return permissions.Count(p => p.RIGHTID == rightId) >= 1;
        //return true;
    }

}
