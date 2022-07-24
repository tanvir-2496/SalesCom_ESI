using ESI.Entity;
using ESI.Entity.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.DAL
{
    public class ESI_KPIDAL
    {
        public static List<KPIEnt> GetItemList(int SalesGroupId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETKPIBYGROUPID");
            procedure.AddInputParameter("P_SALES_GROUP_ID", SalesGroupId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<KPIEnt> results = new List<KPIEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new KPIEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static DataTable GetItemListActiveInactive(int salesGroupId, int searchType, string searchName)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETLISTACTIVEINACTIVE");
            procedure.AddInputParameter("P_SALES_GROUP_ID", salesGroupId, OracleType.Number);
            procedure.AddInputParameter("P_SEARCH_TYPE", searchType, OracleType.Number);
            procedure.AddInputParameter("P_SEARCH_NAME", searchName, OracleType.VarChar);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                return dt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static int SaveKPISubKPIConditionStatus(int searchType, int id, int is_Active)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_UPDATEKPICONDITION");

            procedure.AddInputParameter("pOptionType", searchType, OracleType.Number);
            procedure.AddInputParameter("pID", id, OracleType.Number);
            procedure.AddInputParameter("pIsActive", is_Active, OracleType.Number);

            try
            {
                procedure.ExecuteNonQuery();
                if (procedure.ReturnMessage == "SUCCESSFUL")
                {
                    return procedure.ErrorCode;
                }
                return procedure.ErrorCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<KPIEnt> GetSubKpiByKpiId(int kpiId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETSUBKPIVIEWBYKPIID");
            procedure.AddInputParameter("P_KPI_ID", kpiId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<KPIEnt> results = new List<KPIEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new KPIEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static List<ConditionEnt> GetConditionByKpiId(int kpiId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETCONDITIONVIEWBYKPIID");
            procedure.AddInputParameter("C_KPI_ID", kpiId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ConditionEnt> results = new List<ConditionEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ConditionEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static List<KPIConfigurationEnt> GetKPIConfig(int ReportCycleId, int month)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETKPICONFIGByCIDnM");//greater than
            procedure.AddInputParameter("R_REPORTCYCLEID", ReportCycleId, OracleType.Number);
            procedure.AddInputParameter("R_MONTH", month, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<KPIConfigurationEnt> results = new List<KPIConfigurationEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new KPIConfigurationEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static List<ConditionConfigEnt> GetConditionConfig(int kpiConfigId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETCONDITIONCONFIG");
            procedure.AddInputParameter("R_KPICONFIGID", kpiConfigId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ConditionConfigEnt> results = new List<ConditionConfigEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ConditionConfigEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static KPIUpdateViewModel KPIUpdateDropdownData(int sGroupId)
        {
            List<KPIEnt> kpis = GetItemList(sGroupId);
            List<KPIViewModel> subKpis = new List<KPIViewModel>();
            List<ConditionViewModel> kpiConditions = new List<ConditionViewModel>();
            foreach (var kpi in kpis)
            {
                var subkpis = GetSubKpiByKpiId(kpi.Kpi_id);
                foreach (var sub in subkpis)
                {
                    subKpis.Add(new KPIViewModel()
                    {
                        Kpi_id = sub.Kpi_id,
                        ParentKpiId = kpi.Kpi_id,
                        Kpi_Name = sub.Kpi_Name,
                        Remarks = sub.Remarks,
                    });
                }

                var kCondition = GetConditionByKpiId(kpi.Kpi_id);

                foreach (var con in kCondition)
                {
                    kpiConditions.Add(new ConditionViewModel()
                    {
                        Kpi_id = kpi.Kpi_id,
                        Condition_Name = con.Condition_Name,
                        Condition_id = con.Condition_id,
                        Remarks = con.Remarks,
                    });
                }
            }
            foreach (var subKpi in subKpis)
            {
                var kCondition = GetConditionByKpiId(subKpi.Kpi_id);

                foreach (var con in kCondition)
                {
                    kpiConditions.Add(new ConditionViewModel()
                    {
                        SubKpi_id = subKpi.Kpi_id,
                        Condition_Name = con.Condition_Name,
                        Condition_id = con.Condition_id,
                        Remarks = con.Remarks,
                    });
                }
            }

            return new KPIUpdateViewModel() { KPIDropdown = kpis, SubKPIDropdown = subKpis, ConditionDropdown = kpiConditions };
        }

        public static KPIUpdateViewModel GetKPIWithConditionByReportCycleIdAndMonth(int reportCycleId, int month, int sGroupId)
        {
            KPIUpdateViewModel kpiConfig = new KPIUpdateViewModel();
            List<KPIConfigurationEnt> kpiConfigList = GetKPIConfig(reportCycleId, month);
            List<KPIConfigurationEnt> mainKPIs = new List<KPIConfigurationEnt>();
            List<KPIConfigurationEnt> subKPIs = new List<KPIConfigurationEnt>();
            List<ConditionConfigEnt> conditions = new List<ConditionConfigEnt>();

            KPIUpdateViewModel dropdown = KPIUpdateDropdownData(sGroupId);
            kpiConfig.KPIDropdown = dropdown.KPIDropdown;
            kpiConfig.SubKPIDropdown = dropdown.SubKPIDropdown;
            kpiConfig.ConditionDropdown = dropdown.ConditionDropdown;

            foreach (var kpi in kpiConfigList)
            {
                List<ConditionConfigEnt> c = GetConditionConfig(kpi.KPI_CONFIG_ID);
                if (c.Count > 0)
                {
                    conditions.AddRange(c);
                }
                if (kpi.PARENT_KPI_ID > 0)
                {
                    subKPIs.Add(new KPIConfigurationEnt()
                    {
                        KPI_ID = kpi.KPI_ID,
                        KPI_CONFIG_ID = kpi.KPI_CONFIG_ID,
                        INCENTIVE_PAYOUT = kpi.INCENTIVE_PAYOUT,
                        KPI_NAME = kpi.KPI_NAME,
                        QUARTER = kpi.QUARTER,
                        MONTH = kpi.MONTH,
                        WEIGHTAGE = kpi.WEIGHTAGE,
                        IS_LAST_LEVEL = kpi.IS_LAST_LEVEL,
                        YEAR = kpi.YEAR,
                        REPORT_CYCLE_ID = kpi.REPORT_CYCLE_ID,
                        SALES_CHANNEL_ID = kpi.SALES_CHANNEL_ID,
                        PARENT_KPI_ID = kpi.PARENT_KPI_ID,
                        REMARKS = kpi.REMARKS,
                    });
                }
                else
                {
                    List<Incentive_PayoutEnt> incentive = GetIncentivePayout(kpi.MONTH_CYCLE_ID, reportCycleId, kpi.KPI_ID);
                    string stringIncentive = "[";
                    for (int i = 0; i < incentive.Count; i++)
                    {
                        var atActual = incentive[i].IS_AT_ACTUAL == "Y" ? true : false;
                        //var isLinear = incentive[i].IsLinear == "Y" ? true : false;
                        //stringIncentive += @"{"IIncentiveID":" + incentive[i].ESI_KPI_INCENTIVE_PAYOUT + ",IOrder:" + incentive[i].CONDITION_ORDER + ", \'IOperator\":" + "\"" + incentive[i].RELATION_OPARETION + "\"" + ", \"IThreshold\":" + "\"" + incentive[i].THRESHOLD_PARCENT + "\"" + ",\"IAmount\":" + "\"" + incentive[i].ESI_KPI_INCENTIVE_PAYOUT + "\"" + ",\" IAtActual\":" + "\"" + incentive[i].IS_AT_ACTUAL + "\"" + "}";
                        stringIncentive += "{\'IIncentiveID\':" + incentive[i].ESI_KPI_INCENTIVE_PAYOUT + ",\'IOrder\':" + incentive[i].CONDITION_ORDER + ",\'IOperator\':" + "\'" + incentive[i].RELATION_OPARETION + "\'" + ",\'IThreshold\':" + "\'" + incentive[i].THRESHOLD_PARCENT + "\'" + ",\'IAmount\':" + "\'" + incentive[i].EQUEVALENT_PARCENT + "\'" + ",\'IAtActual\':" + "\'" + atActual + "\'" + "}";
                        if (i != incentive.Count - 1)
                        {
                            stringIncentive += ",";
                        };
                    }
                    stringIncentive += "]";

                    mainKPIs.Add(new KPIConfigurationEnt()
                    {
                        KPI_ID = kpi.KPI_ID,
                        KPI_CONFIG_ID = kpi.KPI_CONFIG_ID,
                        INCENTIVE_PAYOUT = kpi.INCENTIVE_PAYOUT,
                        INCENTIVE_PAYOUT_JSON = stringIncentive,
                        KPI_NAME = kpi.KPI_NAME,
                        QUARTER = kpi.QUARTER,
                        MONTH = kpi.MONTH,
                        WEIGHTAGE = kpi.WEIGHTAGE,
                        IS_LAST_LEVEL = kpi.IS_LAST_LEVEL,
                        YEAR = kpi.YEAR,
                        REPORT_CYCLE_ID = kpi.REPORT_CYCLE_ID,
                        SALES_CHANNEL_ID = kpi.SALES_CHANNEL_ID,
                        PARENT_KPI_ID = kpi.PARENT_KPI_ID,
                        REMARKS = kpi.REMARKS,
                    });
                }
            }
            kpiConfig.KPIs = mainKPIs;
            kpiConfig.SubKPIs = subKPIs;
            kpiConfig.Conditions = conditions;
           
            return kpiConfig;
        }
        public static List<Incentive_PayoutEnt> GetIncentivePayout(int monthCycleId, int reportCycle, int kpiId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GET_INCENTIVE_PAYOUT");
            procedure.AddInputParameter("PO_REPORT_CYCLE_ID", reportCycle, OracleType.Number);
            procedure.AddInputParameter("PO_QUARTER_MONTH_CYCLE_ID", monthCycleId, OracleType.Number);
            procedure.AddInputParameter("PO_KPI_ID", kpiId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<Incentive_PayoutEnt> results = new List<Incentive_PayoutEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new Incentive_PayoutEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static int SaveItem(KPIEnt obj)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_INSERTKPI");

            procedure.AddInputParameter("pKpiName", obj.Kpi_Name, OracleType.VarChar);
            procedure.AddInputParameter("pDisplayName", obj.Display_Name, OracleType.VarChar);
            procedure.AddInputParameter("pSalesGroupId", obj.Sales_Group_Id, OracleType.Number);
            procedure.AddInputParameter("pKpiType", obj.Kpi_Type, OracleType.Number);
            procedure.AddInputParameter("pIsActive", obj.Is_Active, OracleType.Number);
            procedure.AddInputParameter("pIsFinancial", obj.Is_Financial, OracleType.Number);
            procedure.AddInputParameter("pIsSourceManual", obj.Is_Source_Manual, OracleType.Number);
            procedure.AddInputParameter("pCreatedBy", obj.Created_By, OracleType.Number);
            procedure.AddInputParameter("pCreatedDate", obj.Created_Date, OracleType.DateTime);
            procedure.AddInputParameter("pRemarks", obj.Remarks, OracleType.VarChar);
            try
            {
                procedure.ExecuteNonQuery();
                if (procedure.ReturnMessage == "SUCCESSFUL")
                {
                    return procedure.ErrorCode;
                }
                return procedure.ErrorCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveSubKpiItem(SubKpiEnt obj)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_INSERTSUBKPI");

            procedure.AddInputParameter("pKpiName", obj.Kpi_Name, OracleType.VarChar);
            procedure.AddInputParameter("pDisplayName", obj.Display_Name, OracleType.VarChar);
            procedure.AddInputParameter("pSalesGroupId", obj.Sales_Group_Id, OracleType.Number);
            procedure.AddInputParameter("pKpiType", obj.Kpi_Type, OracleType.Number);
            procedure.AddInputParameter("pIsActive", obj.Is_Active, OracleType.Number);
            procedure.AddInputParameter("pIsFinancial", obj.Is_Financial, OracleType.Number);
            procedure.AddInputParameter("pIsSourceManual", obj.Is_Source_Manual, OracleType.Number);
            procedure.AddInputParameter("pCreatedBy", obj.Created_By, OracleType.Number);
            procedure.AddInputParameter("pCreatedDate", obj.Created_Date, OracleType.DateTime);
            procedure.AddInputParameter("pRemarks", obj.Remarks, OracleType.VarChar);
            procedure.AddInputParameter("pKpiId", obj.Kpi_id, OracleType.Number);
            try
            {
                procedure.ExecuteNonQuery();
                if (procedure.ReturnMessage == "SUCCESSFUL")
                {
                    return procedure.ErrorCode;
                }
                return procedure.ErrorCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveCondition(ConditionViewModel obj)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_INSERTCONDITION");

            procedure.AddInputParameter("pConditionName", obj.Condition_Name, OracleType.VarChar);
            procedure.AddInputParameter("pDisplayName", obj.Display_Name, OracleType.VarChar);
            procedure.AddInputParameter("pRemarks", obj.Remarks, OracleType.VarChar);
            procedure.AddInputParameter("pCreatedBy", obj.Created_By, OracleType.Number);
            procedure.AddInputParameter("pCreatedDate", obj.Created_Date, OracleType.DateTime);
            procedure.AddInputParameter("pKpiId", obj.Kpi_id, OracleType.Number);
            procedure.AddInputParameter("pIsActive", obj.Is_Active, OracleType.Number);

            try
            {
                procedure.ExecuteNonQuery();
                if (procedure.ReturnMessage == "SUCCESSFUL")
                {
                    return procedure.ErrorCode;
                }
                return procedure.ErrorCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
