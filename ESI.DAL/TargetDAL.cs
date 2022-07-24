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

namespace ESI.DAL
{
    public class TargetDAL
    {
        public static List<SalesChannelTargetViewModel> GetKPIApprovedByAllList(int status, int year, int quarter,string sGroup)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETSALESCHANNELFORTARGET");
            procedure.AddInputParameter("P_Status", status, OracleType.Number);
            procedure.AddInputParameter("P_YEAR", year, OracleType.Number);
            procedure.AddInputParameter("P_QUARTER", quarter, OracleType.Number);

            procedure.AddInputParameter("p_SALESGROUP", sGroup, OracleType.VarChar);
            procedure.AddInputParameter("P_PAGETYPE", "Target Setup", OracleType.VarChar);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<SalesChannelTargetViewModel> results = new List<SalesChannelTargetViewModel>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new SalesChannelTargetViewModel(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //
        public static List<KPICondition> GetKPICondition(int reportCycleId, int parentKpi)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETKPICONDITIONFORTARGET");
            procedure.AddInputParameter("P_REPORT_CYCLE_ID", reportCycleId, OracleType.Number);
            procedure.AddInputParameter("P_PARENT_KPI_ID", parentKpi, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<KPICondition> results = new List<KPICondition>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new KPICondition(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //KPITargetEnt

        public static List<KPITargetEnt> GetKPIByData(int reportCycleId, int parentKpi)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GET_KPISUBKPI_HASTARGET");
            procedure.AddInputParameter("pReportCycleId", reportCycleId, OracleType.Number);
            procedure.AddInputParameter("pKpiId", parentKpi, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<KPITargetEnt> results = new List<KPITargetEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new KPITargetEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static List<KPIEnt> GetKPIBySCHYQM(int reportCycleId, int parentKpi)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETKPISUBKPIFORTARGET");
            procedure.AddInputParameter("P_REPORT_CYCLE_ID", reportCycleId, OracleType.Number);
            procedure.AddInputParameter("P_PARENT_KPI_ID", parentKpi, OracleType.Number);

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
        public static List<TargetListEnt> GetTargetStatus(int reportCycleId, int month)//ToDo
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETTARGETSTATUS");
            procedure.AddInputParameter("P_REPORT_CYCLE_ID", reportCycleId, OracleType.Number);
            procedure.AddInputParameter("P_MONTH", month, OracleType.Number);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<TargetListEnt> results = new List<TargetListEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new TargetListEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static List<TargetListEntClone> GetTargetStatus_Clone(int reportCycleId, int month)//ToDo
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETTARGETSTATUS_CLONE");
            procedure.AddInputParameter("P_REPORT_CYCLE_ID", reportCycleId, OracleType.Number);
            procedure.AddInputParameter("P_MONTH", month, OracleType.Number);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<TargetListEntClone> results = new List<TargetListEntClone>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new TargetListEntClone(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static List<TargetListEntClone> GetTargetStatus_Approved(int reportCycleId, int month)//ToDo
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETTARGETSTATUS_APPROVED");
            procedure.AddInputParameter("P_REPORT_CYCLE_ID", reportCycleId, OracleType.Number);
            procedure.AddInputParameter("P_MONTH", month, OracleType.Number);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<TargetListEntClone> results = new List<TargetListEntClone>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new TargetListEntClone(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static List<KPIConfigurationEnt> GetKPIConfig(int reportCycleId, int year, int quarter, int month, int kpiId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETKPICONFIG");
            procedure.AddInputParameter("R_REPORT_CYCLE_ID", reportCycleId, OracleType.Number);
            procedure.AddInputParameter("R_YEAR", year, OracleType.Number);
            procedure.AddInputParameter("R_QUARTER", quarter, OracleType.Number);
            procedure.AddInputParameter("R_MONTH", month, OracleType.Number);
            procedure.AddInputParameter("R_KPIID", kpiId, OracleType.Number);

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

        public static string SaveItem(List<KPITargetFromData> dataFromItem, IList<KPITargetToData> dataToItem, int CreateBy)
        {
            //OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "ESI_TARGET_REPLICATE");
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_TARGET_REPLICATE");

            int FromSalesGroup = Convert.ToInt32(dataFromItem[0].FromSalesGroup);
            int FromYear = Convert.ToInt32(dataFromItem[0].FromYear);
            int FromQuarter = Convert.ToInt32(dataFromItem[0].FromQuarter);
            int FromMonth = Convert.ToInt32(dataFromItem[0].FromMonth);
            int Channel = Convert.ToInt32(dataFromItem[0].FromReportName);
            int FromKPI = Convert.ToInt32(dataFromItem[0].FromKPI);
            int FromSubKPI = Convert.ToInt32(dataFromItem[0].FromSubKPI);
            int FromCondition = Convert.ToInt32(dataFromItem[0].FromCondition);
         
            int ToCloneSalesGroup = Convert.ToInt32(dataToItem[0].ToCloneSalesGroup);
            int ToCloneYear = Convert.ToInt32(dataToItem[0].ToCloneYear);
            int ToCloneQuarter = Convert.ToInt32(dataToItem[0].ToCloneQuarter);
            int ToCloneMonth = Convert.ToInt32(dataToItem[0].ToCloneMonth);
            int ToChannel = Convert.ToInt32(dataToItem[0].ToCloneReportName);
            int ToCloneKPI = Convert.ToInt32(dataToItem[0].ToCloneKPI);
            int ToCloneSubKPI = Convert.ToInt32(dataToItem[0].ToCloneSubKPI);
            int ToCloneCondition = Convert.ToInt32(dataToItem[0].ToCloneCondition);

            procedure.AddInputParameter("pFromSalesGroupId", FromSalesGroup, OracleType.Number);//pFromSalesGroupId NUMBER,        
            procedure.AddInputParameter("pFromYear", FromYear, OracleType.Number);//pFromYear NUMBER,
            procedure.AddInputParameter("pFromQuarter", FromQuarter, OracleType.Number);//pFromQuarter NUMBER,
            procedure.AddInputParameter("pFromSalesChannelId", Channel, OracleType.Number);//pFromSalesChannelId VARCHAR2,
            procedure.AddInputParameter("pFromMonth", FromMonth, OracleType.Number);//pFromMonth NUMBER, 
            procedure.AddInputParameter("pFromKpi", FromKPI, OracleType.Number);//pFromKpi NUMBER, 
            procedure.AddInputParameter("pFromSubKpi", FromSubKPI, OracleType.Number);//pFromSubKpi NUMBER, 
            procedure.AddInputParameter("pFromCondition", FromCondition, OracleType.Number);//pFromCondition NUMBER, 

            procedure.AddInputParameter("pToSalesGroupId", ToCloneSalesGroup, OracleType.Number);//pFromSalesGroupId NUMBER,        
            procedure.AddInputParameter("pToYear", ToCloneYear, OracleType.Number);//pFromYear NUMBER,
            procedure.AddInputParameter("pToQuarter", ToCloneQuarter, OracleType.Number);//pFromQuarter NUMBER,
            procedure.AddInputParameter("pToSalesChannelId", ToChannel, OracleType.Number);//pFromSalesChannelId VARCHAR2,
            procedure.AddInputParameter("pToMonth", ToCloneMonth, OracleType.Number);//pFromMonth NUMBER, 
            procedure.AddInputParameter("pToKpi", ToCloneKPI, OracleType.Number);//pFromKpi NUMBER, 
            procedure.AddInputParameter("pToSubKpi", ToCloneSubKPI, OracleType.Number);//pFromSubKpi NUMBER, 
            procedure.AddInputParameter("pToCondition", ToCloneCondition, OracleType.Number);//pFromCondition NUMBER,
            procedure.AddInputParameter("pCreatedBy", CreateBy, OracleType.Number);//pCreatedBy NUMBER,
   


            try
            {
                procedure.ExecuteNonQuery();
                return procedure.ReturnMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
