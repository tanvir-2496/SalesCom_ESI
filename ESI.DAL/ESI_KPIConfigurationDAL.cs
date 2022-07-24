using ESI.Entity;
using ESI.Entity.ViewModel;
using SalesCom.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ESI.DAL
{
    public class ESI_KPIConfigurationDAL
    {
        public static SuccessMessage SaveKpiConfigurationData(List<KPIViewModel> MainKPI, List<SubKPIViewModel> SubKPI, List<ConditionViewModel> Condition, int sChannelId, int year, int quarter, int month, int reportType, int userId, string userName)
        {
            SuccessMessage ReturnMessage = dataValidation(MainKPI, SubKPI, Condition);
            if (ReturnMessage.Type == (int)Message.MessageType.Fail)
            {
                return ReturnMessage;
            }
            ESI_DBTransaction transaction = new ESI_DBTransaction();
            transaction.Begin();
            int createdBy = userId;
            string message = "Something went wrong!!";
            bool isValid = false;
            try
            {
                int ReportCycleId = SaveReportCycle(sChannelId, year, quarter, month, reportType, createdBy, transaction);

                if (ReportCycleId > 0)
                {
                    isValid = true;
                    int lastConditionId = 0;
                    if (month > 0)
                    {
                        QuarterMonthCycleEnt monthCycle = getQuarterMonthCycle(year, quarter, month);
                        if (monthCycle.QUARTER_MONTH_CYCLE_ID > 0)
                        {
                            isValid = true;
                            int monthCycleId = monthCycle.QUARTER_MONTH_CYCLE_ID;
                            int result = SaveIncentivePayout(MainKPI, ReportCycleId, monthCycleId, transaction);
                            if (result > 0)
                            {
                                List<ConditionViewModel> conditions = SaveKPIConfiguration(MainKPI, SubKPI, Condition, sChannelId, year, quarter, ReportCycleId, month, createdBy, transaction);
                                if (conditions.Count > 0)
                                {
                                    isValid = true;
                                    lastConditionId = SaveConditionConfiguration(conditions, month, transaction);
                                }
                            }
                            else
                            {
                                isValid = false;
                                ReturnMessage.Message = "Technical Problem: [IncentivePayout]!!";
                                ReturnMessage.Type = (int)Message.MessageType.Fail;
                            }
                        }
                        else
                        {
                            isValid = false;
                            ReturnMessage.Message = "Please Select Current Quarter!!";
                            ReturnMessage.Type = (int)Message.MessageType.Fail;
                        }
                    }
                    else 
                    {
                        int [] threeMonths = new int[3]  { 0,1,2};
                        
                        for (int i = 0; i < threeMonths.Count(); i++)
                        {
                            int MonthNo = i + 1;
                            QuarterMonthCycleEnt monthCycle = getQuarterMonthCycle(year, quarter, MonthNo);
                            if (monthCycle.QUARTER_MONTH_CYCLE_ID > 0)
                            {
                                isValid = true;
                                int monthCycleId = monthCycle.QUARTER_MONTH_CYCLE_ID;
                                int result = SaveIncentivePayout(MainKPI, ReportCycleId, monthCycleId, transaction);
                                if (result > 0)
                                {
                                    List<ConditionViewModel> conditions = SaveKPIConfiguration(MainKPI, SubKPI, Condition, sChannelId, year, quarter, ReportCycleId, MonthNo, createdBy, transaction);
                                    if (conditions.Count > 0)
                                    {
                                        isValid = true;
                                        lastConditionId = SaveConditionConfiguration(conditions, MonthNo, transaction);
                                    }
                                }
                                else
                                {
                                    isValid = false;
                                    ReturnMessage.Message = "Technical Problem: [IncentivePayout]!!";
                                    ReturnMessage.Type = (int)Message.MessageType.Fail;
                                }
                            }
                            else
                            {
                                isValid = false;
                                ReturnMessage.Message = "Please Select Current Quarter!!";
                                ReturnMessage.Type = (int)Message.MessageType.Fail;
                            }
                        }
                    }
                    
                    if (isValid)
                    {
                        message = SaveApprovalStatus(sChannelId, createdBy, userName, ReportCycleId, transaction);
                        if (message == "1")
                        {
                            isValid = true;
                        }
                    }
                }
                else
                {
                    if (ReportCycleId == -1) 
                    {
                        isValid = false;
                        ReturnMessage.Message = "KPI already configured!!";
                        ReturnMessage.Type = (int)Message.MessageType.Fail;
                    }
                    else if (ReportCycleId == -2)
                    {
                        isValid = false;
                        ReturnMessage.Message = "Arrear Report must have same Original Report type report!!";
                        ReturnMessage.Type = (int)Message.MessageType.Fail;
                    }
                    else
                    {
                        isValid = false;
                        ReturnMessage.Message = "Error occured while KPI configuration!!";
                        ReturnMessage.Type = (int)Message.MessageType.Fail;
                    }
                    
                }

                if (isValid)
                {
                    transaction.Commit();
                    ReturnMessage.Message = "KPI Configured Successfully!!";
                    ReturnMessage.Type = (int)Message.MessageType.Success;
                }
                else
                {
                    transaction.RollBack();
                    ReturnMessage.Type = (int)Message.MessageType.Fail;
                }
            }
            catch (Exception ex)
            {
                transaction.RollBack();
                ReturnMessage.Type = (int)Message.MessageType.Fail;
            }

            return ReturnMessage;
        }

        public static string SaveItem(List<KPIFromData> dataFromItem, IList<KPIToData> dataToItem, string KPIItem, int CreateBy)
        {
            int FromSalesGroup = Convert.ToInt32(dataFromItem[0].FromSalesGroup);
            int FromYear = Convert.ToInt32(dataFromItem[0].FromYear);
            int FromQuarter = Convert.ToInt32(dataFromItem[0].FromQuarter);
            int FromMonth = Convert.ToInt32(dataFromItem[0].FromMonth);
            string Channel = dataFromItem[0].FromReportName.ToString();

            int ToReportType = Convert.ToInt32(dataToItem[0].ToReportType);
            int ToSalesGroup = Convert.ToInt32(dataToItem[0].ToSalesGroup);
            int ToSalesChannel = Convert.ToInt32(dataToItem[0].ToSalesChannelName);
            int ToQuarter = Convert.ToInt32(dataToItem[0].ToQuarter);
            int ToYear = Convert.ToInt32(dataToItem[0].ToYear);
            int ToMonth = Convert.ToInt32(dataToItem[0].ToMonth);

            string KPIList = KPIItem.ToString();

            //OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "");

            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_KPI_REPLICATE");

            procedure.AddInputParameter("pFromSalesGroupId", FromSalesGroup, OracleType.Number);//pFromSalesGroupId NUMBER,        
            procedure.AddInputParameter("pFromYear", FromYear, OracleType.Number);//pFromYear NUMBER,
            procedure.AddInputParameter("pFromQuarter", FromQuarter, OracleType.Number);//pFromQuarter NUMBER,
            procedure.AddInputParameter("pFromSalesChannelId", Channel, OracleType.VarChar);//pFromSalesChannelId VARCHAR2,
            procedure.AddInputParameter("pFromMonth", FromMonth, OracleType.Number);//pFromMonth NUMBER,  

            procedure.AddInputParameter("pToReportType", ToReportType, OracleType.Number);//pToReportType NUMBER,
            procedure.AddInputParameter("pToSalesGroupId", ToSalesGroup, OracleType.Number);//pToSalesGroupId NUMBER,
            procedure.AddInputParameter("pToSalesChannelId", ToSalesChannel, OracleType.Number);//pToSalesChannelId NUMBER,
            procedure.AddInputParameter("pToYear", ToYear, OracleType.Number);//pToYear NUMBER,
            procedure.AddInputParameter("pToQuarter", ToQuarter, OracleType.Number);//pToQuarter NUMBER,            
            procedure.AddInputParameter("pToMonth", ToMonth, OracleType.Number);//pToMonth NUMBER,
            procedure.AddInputParameter("pKPIList", KPIList, OracleType.VarChar);//pKPIList VARCHAR2,
            procedure.AddInputParameter("pCreatedBy", CreateBy, OracleType.Number);//pCreatedBy NUMBER,


            try
            {
                procedure.ExecuteNonQuery();
                int errorCode = procedure.ErrorCode;
                if (errorCode == 10) {
                    return "SUCCESSFUL";
                }
                else if (errorCode == 1)
                {
                    return "1";
                }
                else if (errorCode == 2)
                {
                    return "2";
                }
                else {
                    return "3";
                }

                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        public static int SaveReportCycle(int sChannelId, int year, int quarter, int month, int reportType, int createdBy, ESI_DBTransaction transaction)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_INSERT_REPORTCYCLE");
            procedure.AddOutputParameter("PO_RETURNVALUE", OracleType.Number);
            procedure.AddInputParameter("pYear", year, OracleType.Number);
            procedure.AddInputParameter("pQuarter", quarter, OracleType.Number);
            procedure.AddInputParameter("pMonth", month, OracleType.Number);
            procedure.AddInputParameter("pReportType", reportType, OracleType.Number);
            procedure.AddInputParameter("pSalesChannelId", sChannelId, OracleType.Number);
            procedure.AddInputParameter("pMatureDate", DateTime.Now, OracleType.DateTime);
            procedure.AddInputParameter("pCreatedBy", createdBy, OracleType.Number);
            procedure.AddInputParameter("pCreatedDate", DateTime.Now, OracleType.DateTime);

            try
            {
                procedure.ExecuteNonQuery(transaction);
                if (procedure.ErrorCode == 0)
                {
                    return procedure.ReturnValue;
                }
                return procedure.ErrorCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<ConditionViewModel> SaveKPIConfiguration(List<KPIViewModel> MainKPI, List<SubKPIViewModel> SubKPI, List<ConditionViewModel> Condition, int sChannelId, int year, int quarter, int reportCycleId, int month, int createdBy, ESI_DBTransaction transaction)
        {

            List<ConditionViewModel> MainKPIMapCondition = SaveMainKPI(MainKPI, SubKPI, Condition, sChannelId, year, quarter, reportCycleId, month, createdBy, transaction);
            List<ConditionViewModel> SubKPIMapCondition = SaveSubKPI(MainKPI, SubKPI, MainKPIMapCondition, sChannelId, year, quarter, reportCycleId, month, createdBy, transaction);
            return SubKPIMapCondition;
        }
        public static List<ConditionViewModel> SaveMainKPI(List<KPIViewModel> MainKPI, List<SubKPIViewModel> SubKPI, List<ConditionViewModel> Condition, int sChannelId, int year, int quarter, int reportCycleId, int month, int createdBy, ESI_DBTransaction transaction)
        {
            foreach (var kpi in MainKPI)
            {

                var hasSubKPI = SubKPI.FirstOrDefault(m => m.Kpi_id == kpi.Kpi_id);

                int isLastLevel = 1;
                int parentKpiId = 0;
                if (hasSubKPI != null)
                {
                    isLastLevel = 0;
                }

                ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_INSERT_KPICONFIGURATION");
                procedure.AddOutputParameter("PO_RETURNVALUE", OracleType.Number);
                procedure.AddInputParameter("pKpiConfigId", 0, OracleType.Number);
                procedure.AddInputParameter("pYear", year, OracleType.Number);
                procedure.AddInputParameter("pQuarter", quarter, OracleType.Number);
                procedure.AddInputParameter("pMonth", month, OracleType.Number);

                procedure.AddInputParameter("pSalesChannelId", sChannelId, OracleType.Number);
                procedure.AddInputParameter("pKpiId", kpi.Kpi_id, OracleType.Number);
                procedure.AddInputParameter("pParentKpiId", parentKpiId, OracleType.Number);
                procedure.AddInputParameter("pReportCycle", reportCycleId, OracleType.Number);
                procedure.AddInputParameter("pIsLastLevel", isLastLevel, OracleType.Number);
                procedure.AddInputParameter("pIncentivePayout", kpi.Incentive_Payout, OracleType.VarChar);
                procedure.AddInputParameter("pWeightage", kpi.Weightage, OracleType.Number);
                procedure.AddInputParameter("pCreatedBy", createdBy, OracleType.Number);
                procedure.AddInputParameter("pCreatedDate", DateTime.Now, OracleType.DateTime);
                procedure.AddInputParameter("pSTATUS", 2, OracleType.Number);
                try
                {
                    procedure.ExecuteNonQuery(transaction);
                    if (procedure.ErrorCode == 0)
                    {
                        Condition.Where(m => m.Kpi_id == kpi.Kpi_id).ToList().ForEach(x => x.Kpi_Configuration_Id = procedure.ReturnValue);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return Condition;
        }
        public static List<ConditionViewModel> SaveSubKPI(List<KPIViewModel> MainKPI, List<SubKPIViewModel> SubKPI, List<ConditionViewModel> Condition, int sChannelId, int year, int quarter, int reportCycleId, int month, int createdBy, ESI_DBTransaction transaction)
        {
            foreach (var subKpi in SubKPI)
            {
                int isLastLevel = 1;
                int parentKpiId = subKpi.Kpi_id;

                ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_INSERT_KPICONFIGURATION");
                procedure.AddOutputParameter("PO_RETURNVALUE", OracleType.Number);
                procedure.AddInputParameter("pKpiConfigId", 0, OracleType.Number);
                procedure.AddInputParameter("pYear", year, OracleType.Number);
                procedure.AddInputParameter("pQuarter", quarter, OracleType.Number);
                procedure.AddInputParameter("pMonth", month, OracleType.Number);

                procedure.AddInputParameter("pSalesChannelId", sChannelId, OracleType.Number);
                procedure.AddInputParameter("pKpiId", subKpi.SubKpi_id, OracleType.Number);
                procedure.AddInputParameter("pParentKpiId", parentKpiId, OracleType.Number);
                procedure.AddInputParameter("pReportCycle", reportCycleId, OracleType.Number);
                procedure.AddInputParameter("pIsLastLevel", isLastLevel, OracleType.Number);
                procedure.AddInputParameter("pIncentivePayout", null, OracleType.Number);
                procedure.AddInputParameter("pWeightage", subKpi.Weightage, OracleType.Number);
                procedure.AddInputParameter("pCreatedBy", createdBy, OracleType.Number);
                procedure.AddInputParameter("pCreatedDate", DateTime.Now, OracleType.DateTime);
                procedure.AddInputParameter("pSTATUS", 2, OracleType.Number);

                try
                {
                    procedure.ExecuteNonQuery(transaction);
                    if (procedure.ErrorCode == 0)
                    {
                        Condition.Where(m => m.SubKpi_id == subKpi.SubKpi_id).ToList().ForEach(x => x.Kpi_Configuration_Id = procedure.ReturnValue);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return Condition;
        }
        public static int SaveIncentivePayout(List<KPIViewModel> MainKPI, int reportCycleId, int monthCycleId, ESI_DBTransaction transaction)
        {
            int result = 0;
            foreach (var kpi in MainKPI)
            {
                if (kpi.Incentive_Payout_Json != null)
                {
                    JArray Payout_Json = JArray.Parse(kpi.Incentive_Payout_Json);
                    List<IncentivePayoutViewModel> incentiveList = Payout_Json.ToObject<List<IncentivePayoutViewModel>>().ToList();
                    foreach (var iPayout in incentiveList)
                    {
                        iPayout.IAtActual = iPayout.IAtActual == "True" ? "Y" : "N";
                        iPayout.IIsLinear = iPayout.IIsLinear == "True" ? "Y" : "N";

                        ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_INSERT_INCENTIVE_PAYOUT");
                        procedure.AddOutputParameter("PO_RETURNVALUE", OracleType.Number);
                        procedure.AddInputParameter("pREPORT_CYCLE_ID", reportCycleId, OracleType.Number);
                        procedure.AddInputParameter("pQUARTER_MONTH_CYCLE_ID", monthCycleId, OracleType.Number);
                        procedure.AddInputParameter("pKPI_ID", kpi.Kpi_id, OracleType.Number);
                        procedure.AddInputParameter("pRELATION_OPARETION", iPayout.IOperator, OracleType.VarChar);
                        procedure.AddInputParameter("pTHRESHOLD_PARCENT", iPayout.IThreshold, OracleType.Number);
                        procedure.AddInputParameter("pEQUEVALENT_PARCENT", iPayout.IAmount, OracleType.Number);
                        procedure.AddInputParameter("pIS_AT_ACTUAL", iPayout.IAtActual, OracleType.VarChar);
                        procedure.AddInputParameter("pLINEAR_PARCENT", iPayout.IRatioAmount, OracleType.Number);
                        procedure.AddInputParameter("pIS_LINEAR", iPayout.IIsLinear, OracleType.VarChar);
                        procedure.AddInputParameter("pCREATE_DATE", DateTime.Now, OracleType.DateTime);
                        procedure.AddInputParameter("pCONDITION_ORDER", iPayout.IOrder + 1, OracleType.Number);
                        try
                        {
                            procedure.ExecuteNonQuery(transaction);
                            if (procedure.ErrorCode == 0)
                            {
                                result = procedure.ReturnValue;
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
                else
                {
                    return result = 0;
                }
            }
            return result;
        }
        public static int SaveAndUpdateIncentivePayout(List<KPIViewModel> MainKPI, int reportCycleId, int monthCycleId, ESI_DBTransaction transaction)
        {
            int result = 0;
            foreach (var kpi in MainKPI)
            {
                if (kpi.Incentive_Payout_Json != null)
                {
                    // var Payout_Json = JsonConvert.DeserializeObject(kpi.Incentive_Payout_Json);
                    string Incentive_Payout_Json = kpi.Incentive_Payout_Json;
                    string newIncentive = Incentive_Payout_Json.Replace('\'', '"');
                    string newIncentive2 = newIncentive.Replace('T', 't');
                    // var m = JsonConvert.SerializeObject(Incentive_Payout_Json);
                    JArray Payout_Json = JArray.Parse(newIncentive2);
                    List<IncentivePayoutViewModel> incentiveList = Payout_Json.ToObject<List<IncentivePayoutViewModel>>().ToList();
                    List<Incentive_PayoutEnt> incentive = ESI_KPIDAL.GetIncentivePayout(monthCycleId, reportCycleId, kpi.Kpi_id);
                    foreach (var oldIncentive in incentive)
                    {
                        var HaveToUpdate = incentiveList.Find(m => m.IIncentiveID == oldIncentive.ESI_KPI_INCENTIVE_PAYOUT);
                        if (HaveToUpdate != null)
                        {
                            if (HaveToUpdate.IIncentiveID > 0)
                            {
                                continue;
                            }
                        }
                        int deletedId = deleteIncentive(oldIncentive.ESI_KPI_INCENTIVE_PAYOUT,transaction);
                    }
                    foreach (var iPayout in incentiveList)
                    {
                        iPayout.IAtActual = iPayout.IAtActual == "True" ? "Y" : "N";
                        iPayout.IIsLinear = iPayout.IIsLinear == "True" ? "Y" : "N";

                        if (iPayout.IIncentiveID > 0)
                        {
                            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_UPDATE_INCENTIVE_PAYOUT");
                            procedure.AddOutputParameter("PO_RETURNVALUE", OracleType.Number);
                            procedure.AddInputParameter("pESI_KPI_INCENTIVE_PAYOUT", iPayout.IIncentiveID, OracleType.Number);
                            procedure.AddInputParameter("pREPORT_CYCLE_ID", reportCycleId, OracleType.Number);
                            procedure.AddInputParameter("pQUARTER_MONTH_CYCLE_ID", monthCycleId, OracleType.Number);
                            procedure.AddInputParameter("pKPI_ID", kpi.Kpi_id, OracleType.Number);
                            procedure.AddInputParameter("pRELATION_OPARETION", iPayout.IOperator, OracleType.VarChar);
                            procedure.AddInputParameter("pTHRESHOLD_PARCENT", iPayout.IThreshold, OracleType.Number);
                            procedure.AddInputParameter("pEQUEVALENT_PARCENT", iPayout.IAmount, OracleType.Number);
                            procedure.AddInputParameter("pIS_AT_ACTUAL", iPayout.IAtActual, OracleType.VarChar);
                            procedure.AddInputParameter("pLINEAR_PARCENT", iPayout.IRatioAmount, OracleType.Number);
                            procedure.AddInputParameter("pIS_LINEAR", iPayout.IIsLinear, OracleType.VarChar);
                            procedure.AddInputParameter("pCREATE_DATE", DateTime.Now, OracleType.DateTime);
                            procedure.AddInputParameter("pCONDITION_ORDER", iPayout.IOrder, OracleType.Number);
                            try
                            {
                                procedure.ExecuteNonQuery(transaction);
                                if (procedure.ErrorCode == 0)
                                {
                                    result = procedure.ReturnValue;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        else
                        {
                            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_INSERT_INCENTIVE_PAYOUT");
                            procedure.AddOutputParameter("PO_RETURNVALUE", OracleType.Number);
                            procedure.AddInputParameter("pREPORT_CYCLE_ID", reportCycleId, OracleType.Number);
                            procedure.AddInputParameter("pQUARTER_MONTH_CYCLE_ID", monthCycleId, OracleType.Number);
                            procedure.AddInputParameter("pKPI_ID", kpi.Kpi_id, OracleType.Number);
                            procedure.AddInputParameter("pRELATION_OPARETION", iPayout.IOperator, OracleType.VarChar);
                            procedure.AddInputParameter("pTHRESHOLD_PARCENT", iPayout.IThreshold, OracleType.Number);
                            procedure.AddInputParameter("pEQUEVALENT_PARCENT", iPayout.IAmount, OracleType.Number);
                            procedure.AddInputParameter("pIS_AT_ACTUAL", iPayout.IAtActual, OracleType.VarChar);
                            procedure.AddInputParameter("pLINEAR_PARCENT", iPayout.IRatioAmount, OracleType.Number);
                            procedure.AddInputParameter("pIS_LINEAR", iPayout.IIsLinear, OracleType.VarChar);
                            procedure.AddInputParameter("pCREATE_DATE", DateTime.Now, OracleType.DateTime);
                            procedure.AddInputParameter("pCONDITION_ORDER", iPayout.IOrder + 1, OracleType.Number);
                            try
                            {
                                procedure.ExecuteNonQuery(transaction);
                                if (procedure.ErrorCode == 0)
                                {
                                    result = procedure.ReturnValue;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                }
                else
                {
                    return result = 0;
                }
            }
            return result;
        }

        public static int deleteIncentive(int reportCycleId, ESI_DBTransaction transaction)
        {
            int result = 0;
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_DELETE_INCENTIVE_PAYOUT");
            procedure.AddOutputParameter("PO_RETURNVALUE", OracleType.Number);
            procedure.AddInputParameter("pESI_KPI_INCENTIVE_PAYOUT", reportCycleId, OracleType.Number);

            try
            {
                procedure.ExecuteNonQuery(transaction);
                if (procedure.ErrorCode == 0)
                {
                    result = procedure.ReturnValue;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static QuarterMonthCycleEnt getQuarterMonthCycle(int year, int quarter, int month)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GET_QUARTER_MONTH_CYCLE");
            procedure.AddInputParameter("R_MONTH", month, OracleType.Number);
            procedure.AddInputParameter("R_QUARTER", quarter, OracleType.Number);
            procedure.AddInputParameter("R_YEAR", year, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                return new QuarterMonthCycleEnt(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveConditionConfiguration(List<ConditionViewModel> Condition, int CreatedBy, ESI_DBTransaction transaction)
        {
            int lastReturnValue = 0;
            foreach (var condition in Condition)
            {
                ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_INSERT_KPICONDITIONCONFIG");
                procedure.AddOutputParameter("PO_RETURNVALUE", OracleType.Number);
                procedure.AddInputParameter("pKpiConditionConfigId", 0, OracleType.Number);
                procedure.AddInputParameter("pKpiConfigurationId", condition.Kpi_Configuration_Id, OracleType.Number);
                procedure.AddInputParameter("pConditionId", condition.Condition_id, OracleType.Number);

                procedure.AddInputParameter("pCreatedBy", CreatedBy, OracleType.Number);
                procedure.AddInputParameter("pCreatedDate", DateTime.Now, OracleType.DateTime);
                procedure.AddInputParameter("pSTATUS", 1, OracleType.Number);
                try
                {
                    procedure.ExecuteNonQuery(transaction);
                    if (procedure.ErrorCode == 0)
                    {
                        lastReturnValue = procedure.ReturnValue;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return lastReturnValue;
        }
        public static string SaveApprovalStatus(int sChannelId, int CreatedBy, string userName, int reportCycleId, ESI_DBTransaction transaction)
        {
            SalesGroupEnt salesChannel = GetSalesGroupBySalesChannelId(sChannelId);
            ApprovalFlowViewModel approvalFlow = GetApprovalFlowByTypeAndOrder(1, salesChannel.Sales_Group_Name);
            string message = "";
            if (approvalFlow.ApprovalFlowId > 0)
            {
                ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_INSERT_APPROVALSTATUS");
                procedure.AddOutputParameter("PO_RETURNVALUE", OracleType.Number);
                procedure.AddInputParameter("iAPPROVAL_STATUS_ID", 0, OracleType.Number);
                procedure.AddInputParameter("iFLOW_ID", approvalFlow.ApprovalFlowId, OracleType.Number);
                procedure.AddInputParameter("iLEVEL_ID", approvalFlow.ApprovalLevelId, OracleType.Number);
                procedure.AddInputParameter("iREPORT_CYCLE_ID", reportCycleId, OracleType.Number);
                procedure.AddInputParameter("iSTATUS", 0, OracleType.Number);
                procedure.AddInputParameter("iLAST_APPROVER_ID", "", OracleType.VarChar);
                procedure.AddInputParameter("iCOMMENTS", "", OracleType.VarChar);
                procedure.AddInputParameter("iAPPROVAL_TYPE", 5, OracleType.Number);
                procedure.AddInputParameter("iCreatedBy", CreatedBy, OracleType.Number);
                procedure.AddInputParameter("iCreatedDate", DateTime.Now, OracleType.DateTime);

                try
                {
                    procedure.ExecuteNonQuery(transaction);
                    if (procedure.ErrorCode == 0)
                    {
                       // SaveApprovalStatusLog(sChannelId, CreatedBy, userName, procedure.ReturnValue, approvalFlow.ApprovalFlowId, approvalFlow.ApprovalLevelId, transaction);
                    }
                    else
                    {
                        //message = "Approval Flow not Setup properly!!";
                    }
                    message = "1";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return message;
        }
        public static int SaveApprovalStatusLog(int sChannelId, int CreatedBy, string userName, int ApprovalStatusId, int ApprovalFlowId, int ApprovalLevelId, ESI_DBTransaction transaction)
        {
            int ReturnValue = 0;
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_INSERT_APPROVALSTATUSLOG");
            procedure.AddOutputParameter("PO_RETURNVALUE", OracleType.Number);
            procedure.AddInputParameter("iAPPROVAL_STATUS_LOG_ID", 0, OracleType.Number);
            procedure.AddInputParameter("iAPPROVAL_STATUS_ID", ApprovalStatusId, OracleType.Number);
            procedure.AddInputParameter("iSTATUS", 2, OracleType.Number);
            procedure.AddInputParameter("iCOMMENTS", "", OracleType.VarChar);
            procedure.AddInputParameter("iAPPROVAL_TYPE", 1, OracleType.Number);

            procedure.AddInputParameter("iFLOW_ID", ApprovalFlowId, OracleType.Number);
            procedure.AddInputParameter("iLEVEL_ID", ApprovalLevelId, OracleType.Number);

            procedure.AddInputParameter("iCreatedBy", CreatedBy, OracleType.Number);
            procedure.AddInputParameter("iCreatedByName", userName, OracleType.VarChar);
            //iCreatedByName
            procedure.AddInputParameter("iCreatedDate", DateTime.Now, OracleType.DateTime);

            try
            {
                procedure.ExecuteNonQuery(transaction);
                if (procedure.ErrorCode == 0)
                {
                    ReturnValue = procedure.ReturnValue;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ReturnValue;
        }
        public static SalesGroupEnt GetSalesGroupBySalesChannelId(int salesChannel)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETSALESGROUPBYSCHANNELID");
            procedure.AddInputParameter("gSALES_CHANNEL_ID", salesChannel, OracleType.Number);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                return new SalesGroupEnt(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static ApprovalFlowViewModel GetApprovalFlowByTypeAndOrder(int order, string Type)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETFLOWBYATYPENORDER");
            procedure.AddInputParameter("gAPPROVALTYPE", Type, OracleType.VarChar);
            procedure.AddInputParameter("gORDERID", order, OracleType.Number);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                if (dt.Rows.Count > 0)
                {
                    return new ApprovalFlowViewModel(dt.Rows[0]);
                }
                return new ApprovalFlowViewModel();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Update KPI Configuration
        public static string UpdateApprovalStatus(int sChannelId, int updatedBy, string userName, int reportCycleId, ESI_DBTransaction transaction)
        {
            SalesGroupEnt salesChannel = GetSalesGroupBySalesChannelId(sChannelId);
            ApprovalFlowViewModel approvalFlow = GetApprovalFlowByTypeAndOrder(1, salesChannel.Sales_Group_Name);
            string message = "";
            if (approvalFlow.ApprovalFlowId > 0)
            {
                int reportApprovalStatusID = 0;
                int userApprovalType = 0;
                try
                {
                    ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GET_APPROVALSTATUS");//ESI_UPDATE_APPROVAL

                    procedure.AddOutputParameter("PO_RETURNVALUE", OracleType.Number);
                    procedure.AddOutputParameter("PO_RETURNVALUE1", OracleType.Number);
                    procedure.AddInputParameter("P_REPORT_CYCLE_ID", reportCycleId, OracleType.Number);                    
                    procedure.AddInputParameter("P_FLOW_ID", approvalFlow.ApprovalFlowId, OracleType.Number);
                    procedure.AddInputParameter("P_UpdatedBy", updatedBy, OracleType.Number);

                    

                    procedure.ExecuteNonQuery(transaction);

                    reportApprovalStatusID = procedure.ReturnValue;
                    userApprovalType = procedure.ReturnValue1;

                }
                catch (Exception ex)
                {
                    throw ex;
                }

                try
                {
                    if (userApprovalType == 1)
                    {
                        ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_UPDATE_APPROVALSTATUS");//ESI_UPDATE_APPROVAL
                        procedure.AddOutputParameter("PO_RETURNVALUE", OracleType.Number);
                        procedure.AddInputParameter("iREPORT_CYCLE_ID", reportCycleId, OracleType.Number);
                        procedure.AddInputParameter("iFLOW_ID", approvalFlow.ApprovalFlowId, OracleType.Number);
                        procedure.AddInputParameter("iLEVEL_ID", approvalFlow.ApprovalLevelId, OracleType.Number);
                        procedure.AddInputParameter("iSTATUS", 0, OracleType.Number);

                        procedure.AddInputParameter("iUpdatedBy", updatedBy, OracleType.Number);
                        procedure.AddInputParameter("iUpdatedDate", DateTime.Now, OracleType.DateTime);


                        procedure.ExecuteNonQuery(transaction);
                        if (procedure.ErrorCode == 0)
                        {
                            SaveApprovalStatusLog(sChannelId, updatedBy, userName, procedure.ReturnValue, approvalFlow.ApprovalFlowId, approvalFlow.ApprovalLevelId, transaction);
                        }
                        else
                        {
                            //message = "Approval Flow not Setup properly!!";
                        }
                        message = "1";
                    }
                    else if (userApprovalType == 2)
                    {
                        SaveApprovalStatusLog(sChannelId, updatedBy, userName, reportApprovalStatusID, approvalFlow.ApprovalFlowId, approvalFlow.ApprovalLevelId, transaction);
                        message = "1";
                    }
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return message;
        }
        public static ReportCycleEnt GetReportCycleById(int reportCycleId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETREPORTCYCLE");
            procedure.AddInputParameter("p_REPORT_CYCLE_ID", reportCycleId, OracleType.Number);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                if (dt.Rows.Count > 0)
                {
                    return new ReportCycleEnt(dt.Rows[0]);
                }
                return new ReportCycleEnt();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Pervious Status Change
        public static int UpdatePreviousKPIConfiguration(int monthId, int UpdatedBy, int ReportCycleId, ESI_DBTransaction transaction)
        {
            int ReturnValue = 0;
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_UPDATE_KPICONFIGURATION");
            procedure.AddInputParameter("pREPORT_CYCLE_ID", ReportCycleId, OracleType.Number);
            procedure.AddInputParameter("pMonth", monthId, OracleType.Number);

            procedure.AddInputParameter("pUpdatedBy", UpdatedBy, OracleType.Number);
            procedure.AddInputParameter("pUpdatedDate", DateTime.Now, OracleType.DateTime);

            try
            {
                procedure.ExecuteNonQuery(transaction);
                if (procedure.ErrorCode == 0)
                {
                    ReturnValue = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ReturnValue;
        }
        public static SuccessMessage UpdateKpiConfigurationData(List<KPIViewModel> MainKPI, List<SubKPIViewModel> SubKPI, List<ConditionViewModel> Condition, int ReportCycleId, int Month, int UserId, string userName)
        {
            SuccessMessage ReturnMessage = dataValidation(MainKPI, SubKPI, Condition);
            if (ReturnMessage.Type == (int)Message.MessageType.Fail)
            {
                return ReturnMessage;
            }
            ESI_DBTransaction transaction = new ESI_DBTransaction();
            transaction.Begin();
            int createdBy = UserId;
            int updatedBy = UserId;
           // int QuarterMonth = 3;
            string message = "Something went wrong!!";
            bool isValid = false;
            try
            {
                ReportCycleEnt ReportCycle = GetReportCycleById(ReportCycleId);
                //Update Previous Month KPI Configuration Status
                int returnValue = 0;
                //for (int i = Month; i <= QuarterMonth; i++)
                //{
                //    returnValue = UpdatePreviousKPIConfiguration(i, updatedBy, ReportCycleId, transaction);
                //}
               
                 returnValue = UpdatePreviousKPIConfiguration(Month, updatedBy, ReportCycleId, transaction);
               
                //-------------------------------Save New-----------------------------
                if (returnValue > 0)
                {
                    isValid = true;
                    int lastConditionId = 0;
                    //for (int MonthNo = Month; MonthNo <= QuarterMonth; MonthNo++)
                    //{
                        var MonthNo = Month;
                        ReportCycleEnt reportCycleTable = ESI_ReportDAL.GetReportCycleById(ReportCycleId);
                        QuarterMonthCycleEnt monthCycle = getQuarterMonthCycle(reportCycleTable.YEAR, reportCycleTable.QUARTER, MonthNo);
                        if (monthCycle.QUARTER_MONTH_CYCLE_ID > 0)
                        {
                            isValid = true;
                            int monthCycleId = monthCycle.QUARTER_MONTH_CYCLE_ID;
                            int result = SaveAndUpdateIncentivePayout(MainKPI, ReportCycleId, monthCycleId, transaction);
                            if (result > 0)
                            {
                                List<ConditionViewModel> conditions = SaveKPIConfiguration(MainKPI, SubKPI, Condition, ReportCycle.SALES_CHANNEL_ID, ReportCycle.YEAR, ReportCycle.QUARTER, ReportCycleId, MonthNo, createdBy, transaction);
                                if (conditions.Count > 0)
                                {
                                    isValid = true;
                                    lastConditionId = SaveConditionConfiguration(conditions, MonthNo, transaction);
                                }
                            }
                            else
                            {
                                isValid = false;
                                ReturnMessage.Message = "Technical Problem: [IncentivePayout]!!";
                                ReturnMessage.Type = (int)Message.MessageType.Fail;
                            }
                        }
                    //}

                    message = UpdateApprovalStatus(ReportCycle.SALES_CHANNEL_ID, createdBy, userName, ReportCycleId, transaction);
                    if (message == "1")
                    {
                        isValid = true;
                    }
                    else
                    {
                        ReturnMessage.Message = message;
                        ReturnMessage.Type = (int)Message.MessageType.Fail;
                    }
                }
                else
                {
                    isValid = false;
                    ReturnMessage.Message = "Something went wrong!!";
                    ReturnMessage.Type = (int)Message.MessageType.Fail;
                }

                if (isValid)
                {
                    transaction.Commit();
                    ReturnMessage.Message = "KPI Updated Successfully!!";
                    ReturnMessage.Type = (int)Message.MessageType.Success;
                }
                else
                {
                    transaction.RollBack();
                    ReturnMessage.Message = message;
                    ReturnMessage.Type = (int)Message.MessageType.Fail;
                }
            }
            catch (Exception)
            {
                transaction.RollBack();
                ReturnMessage.Message = message;
                ReturnMessage.Type = (int)Message.MessageType.Fail;
            }

            return ReturnMessage;
        }
        public static SuccessMessage dataValidation(List<KPIViewModel> MainKPI, List<SubKPIViewModel> SubKPI, List<ConditionViewModel> Condition)
        {
            decimal KPIWeightage = 0;
            var sameKPI = MainKPI.GroupBy(m => m.Kpi_id).Any(a => a.Count() > 1);
            if (sameKPI)
            {
                return new SuccessMessage() { Message = "Duplicate KPI Detected!!", Type = (int)Message.MessageType.Fail };
            }

            foreach (var item in SubKPI)
            {
                if (Condition.Where(x => x.SubKpi_id == item.SubKpi_id).GroupBy(m => m.Condition_id).Any(a => a.Count() > 1))
                {
                    return new SuccessMessage() { Message = "Duplicate Sub KPI Condition Detected!!", Type = (int)Message.MessageType.Fail };
                }
            }
            foreach (var kpi in MainKPI)
            {
                KPIWeightage += kpi.Weightage;
                if (SubKPI.Where(x => x.Kpi_id == kpi.Kpi_id).GroupBy(m => m.SubKpi_id).Any(a => a.Count() > 1))
                {
                    return new SuccessMessage() { Message = "Duplicate SubKPI Detected!!", Type = (int)Message.MessageType.Fail };
                }
                if (Condition.Where(x => x.Kpi_id == kpi.Kpi_id).GroupBy(m => m.Condition_id).Any(a => a.Count() > 1))
                {
                    return new SuccessMessage() { Message = "Duplicate Condition Detected!!", Type = (int)Message.MessageType.Fail };
                }
                if (kpi.Incentive_Payout.Length < 0)
                {
                    return new SuccessMessage() { Message = "Incentive payout must not be empty!!", Type = (int)Message.MessageType.Fail };
                }
                if (kpi.Weightage < 0)
                {
                    return new SuccessMessage() { Message = "KPI weightage must not be empty!!", Type = (int)Message.MessageType.Fail }; 
                }

                if (SubKPI.Where(x => x.Kpi_id == kpi.Kpi_id).Any() && SubKPI.Where(x => x.Kpi_id == kpi.Kpi_id).Select(y=>y.Weightage).Sum() != kpi.Weightage)
                {
                    return new SuccessMessage() { Message = "Sub KPI total weightage is not equal to KPI weightage!!", Type = (int)Message.MessageType.Fail };
                }
               
                foreach (var skpi in SubKPI)
                {
                    //int subKpiWeightate = 0;
                    if (skpi.Kpi_id < 1 || skpi.SubKpi_id < 1)
                    {
                        return new SuccessMessage() { Message = "Data is Invalid!! Please Contact with technical team!!", Type = (int)Message.MessageType.Fail };
                    }

                    if (skpi.Kpi_id == kpi.Kpi_id)
                    {
                        decimal subKpiWeightate = 0;
                        subKpiWeightate += skpi.Weightage;
                        if (kpi.Weightage < subKpiWeightate)
                        {
                            return new SuccessMessage() { Message = "Sub KPI weightage is not valid!!", Type = (int)Message.MessageType.Fail };
                        }
                    }

                }
            }
            if (KPIWeightage > 100)
            {
                return new SuccessMessage() { Message = "KPI weightage can't be more then 100% !!", Type = (int)Message.MessageType.Fail }; 
            }
            foreach (var con in Condition)
            {
                if (con.Kpi_id < 1 || con.Condition_id < 1)
                {
                    return new SuccessMessage() { Message = "Condition Data is Invalid!! Please Contact with technical team!!", Type = (int)Message.MessageType.Fail };
                }
            }
            return new SuccessMessage() { Message = "Validation Successfull!!", Type = (int)Message.MessageType.Success };
            // SubKPI.GroupBy(p => p.Kpi_id).Sum(m=>m.;
        }

    }
}
