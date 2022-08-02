using ESI.Entity;
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
    public static class ESI_ReportDAL
    {
        public static List<KPIvsAchievementEnt> KPIvsAchievement(int employeeId, int reportCycleId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETKPIVSACHIEVEMENTTST"); //"ESI_GETKPIVSACHIEVEMENT"  "ESI_GETREPORTCYCLEBYSCHIDQTRY"
            procedure.AddInputParameter("PI_Employee_ID", employeeId, OracleType.Number);
            procedure.AddInputParameter("PI_REPORT_CYCLE_ID", reportCycleId, OracleType.Number);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<KPIvsAchievementEnt> results = new List<KPIvsAchievementEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new KPIvsAchievementEnt(dr));
                }
                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
           
        }

        public static List<KPIvsAchievementEnt> KPIvsAchievementChart(int employeeId, int reportCycleId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETKPIVSACHIEVEMENTCHART"); //"ESI_GETKPIVSACHIEVEMENT"  "ESI_GETREPORTCYCLEBYSCHIDQTRY"
            procedure.AddInputParameter("PI_Employee_ID", employeeId, OracleType.Number);
            procedure.AddInputParameter("PI_REPORT_CYCLE_ID", reportCycleId, OracleType.Number);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<KPIvsAchievementEnt> results = new List<KPIvsAchievementEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new KPIvsAchievementEnt(dr));
                }
                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static List<KPIvsAchievementForHigherEnt> KPIvsAchievementSalesEmployee(int employeeId, int year, int quarter)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETKPIVSACHI_Hierarchy"); //"ESI_GETREPORTCYCLEBYSCHIDQTRY"
            procedure.AddInputParameter("PI_Employee_ID", employeeId, OracleType.Number);
            procedure.AddInputParameter("PI_YEAR", year, OracleType.Number);
            procedure.AddInputParameter("PI_QUARTER", quarter, OracleType.Number);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<KPIvsAchievementForHigherEnt> results = new List<KPIvsAchievementForHigherEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new KPIvsAchievementForHigherEnt(dr));
                }
                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static List<KPIvsAchievementForHigherEnt> KPIvsAchievementForRH(int employeeId, int year, int quarter)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETKPIVSACHIEVEMENTFORRH"); //"ESI_GETREPORTCYCLEBYSCHIDQTRY"
            procedure.AddInputParameter("PI_Employee_ID", employeeId, OracleType.Number);
            procedure.AddInputParameter("PI_YEAR", year, OracleType.Number);
            procedure.AddInputParameter("PI_QUARTER", quarter, OracleType.Number);
            //procedure.AddInputParameter("PI_REPORT_CYCLE_ID", reportCycleId, OracleType.Number);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<KPIvsAchievementForHigherEnt> results = new List<KPIvsAchievementForHigherEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new KPIvsAchievementForHigherEnt(dr));
                }
                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static List<KPIvsAchievementForHigherEnt> KPIvsAchievementForDirective(int employeeId, int year, int quarter)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETKPIVSACHIEVEMENTFORDR"); //"ESI_GETREPORTCYCLEBYSCHIDQTRY"
            procedure.AddInputParameter("PI_Employee_ID", employeeId, OracleType.Number);
            procedure.AddInputParameter("PI_YEAR", year, OracleType.Number);
            procedure.AddInputParameter("PI_QUARTER", quarter, OracleType.Number);
            //procedure.AddInputParameter("PI_REPORT_CYCLE_ID", reportCycleId, OracleType.Number);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<KPIvsAchievementForHigherEnt> results = new List<KPIvsAchievementForHigherEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new KPIvsAchievementForHigherEnt(dr));
                }
                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static List<KPIvsAchievementForHigherEnt> KPIvsAchievementForCCO(int employeeId, int year, int quarter)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETKPIVSACHIEVEMENTFORCXO"); //"ESI_GETKPIVSACHIEVEMENTFORCCR"
            procedure.AddInputParameter("PI_Employee_ID", employeeId, OracleType.Number);
            procedure.AddInputParameter("PI_YEAR", year, OracleType.Number);
            procedure.AddInputParameter("PI_QUARTER", quarter, OracleType.Number);
            //procedure.AddInputParameter("PI_REPORT_CYCLE_ID", reportCycleId, OracleType.Number);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<KPIvsAchievementForHigherEnt> results = new List<KPIvsAchievementForHigherEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new KPIvsAchievementForHigherEnt(dr));
                }
                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static List<KPIvsAchievementForHigherEnt> KPIvsAchievementForCD(int employeeId, int year, int quarter)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETKPIVSACHIEVEMENTFORCD"); //"ESI_GETREPORTCYCLEBYSCHIDQTRY"
            procedure.AddInputParameter("PI_Employee_ID", employeeId, OracleType.Number);
            procedure.AddInputParameter("PI_YEAR", year, OracleType.Number);
            procedure.AddInputParameter("PI_QUARTER", quarter, OracleType.Number);
            //procedure.AddInputParameter("PI_REPORT_CYCLE_ID", reportCycleId, OracleType.Number);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<KPIvsAchievementForHigherEnt> results = new List<KPIvsAchievementForHigherEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new KPIvsAchievementForHigherEnt(dr));
                }
                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static List<SalesChannelEnt> GetALLSALESCHANNEL()
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETALLSALESCHANNEL");

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<SalesChannelEnt> results = new List<SalesChannelEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new SalesChannelEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static List<ReportCycleEnt> GetReportCycleListBuSalesChannel(int salesChannelId, int year, int quarter, int month)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETREPORTCYCLEBYSALESCHL");
            procedure.AddInputParameter("R_SALESCHANNEL_ID", salesChannelId, OracleType.Number);
            procedure.AddInputParameter("R_YEAR", year, OracleType.Number);
            procedure.AddInputParameter("R_QUARTER", quarter, OracleType.Number);
            procedure.AddInputParameter("R_MONTH", month, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ReportCycleEnt> results = new List<ReportCycleEnt>();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        results.Add(new ReportCycleEnt(dr));
                    }
                    return results;
                }
                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static List<KPIvsAchievementForHigherEnt> KPIvsAchievementForAll(int selfEmployeeId, int employeeId, int reportCycleId, int designation)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETKPIVSACHIEVEMENTFORALL"); //"ESI_GETKPIVSACHIEVEMENTFORCCR"
            procedure.AddInputParameter("PI_SelfEmployeeId", selfEmployeeId, OracleType.Number);
            procedure.AddInputParameter("PI_Employee_ID", employeeId, OracleType.Number);
            procedure.AddInputParameter("PI_REPORT_CYCLE_ID", reportCycleId, OracleType.Number);
            procedure.AddInputParameter("PI_DESIGNATION", designation, OracleType.Number);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<KPIvsAchievementForHigherEnt> results = new List<KPIvsAchievementForHigherEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new KPIvsAchievementForHigherEnt(dr));
                }
                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static DataTable ReportData(Int64 CycleReportID)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GET_DETAIL_REPORT");
            procedure.AddInputParameter("R_REPORT_CYCLEID", CycleReportID, OracleType.Number);

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

        public static DataTable DetailReportData(Int64 CycleReportID)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GET_SUMMARY_REPORT_DETAIL");
            procedure.AddInputParameter("R_REPORT_CYCLEID", CycleReportID, OracleType.Number);

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

        public static DataTable KpiVsAchievementDownload(int employeeId, int reportCycleId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETKPIVSACHIEVEMENT_REPORT"); //"ESI_GETREPORTCYCLEBYSCHIDQTRY"
            procedure.AddInputParameter("R_EMPNO", employeeId, OracleType.Number);
            procedure.AddInputParameter("R_REPORT_CYCLEID", reportCycleId, OracleType.Number);

            try 
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                DataTable newDt = new DataTable();
                
                return dt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static List<kpi_approval_ent> GetApprovedReport(int channelId, string sales_group, int year, int quarter, string procedure_name)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure(procedure_name); //"ESI_GETREPORTCYCLEBYSCHIDQTRY"
            procedure.AddInputParameter("RSALES_CHANNEL_ID", channelId, OracleType.Number);
            procedure.AddInputParameter("RSALES_GROUP", sales_group, OracleType.VarChar);
            procedure.AddInputParameter("RYEAR", year, OracleType.Number);
            procedure.AddInputParameter("RQUARTER", quarter, OracleType.Number);
            
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<kpi_approval_ent> results = new List<kpi_approval_ent>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new kpi_approval_ent(dr));
                }
                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static List<EmployeeTargetEnt> GetEmployeeTarget(int channelId,int ReportCycleId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETEMPLOYEETARGET");
            procedure.AddInputParameter("PI_USER_ID", channelId, OracleType.Number);
            procedure.AddInputParameter("PI_REPORTCYCLEID", ReportCycleId, OracleType.VarChar);


            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<EmployeeTargetEnt> results = new List<EmployeeTargetEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new EmployeeTargetEnt(dr));
                }
                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static ReportCycleEnt GetReportCycle(int employeeId, int year, int quarter, int month)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETREPORTCYCLEDESHBOARD");
            procedure.AddInputParameter("R_EMPLOYEE_ID", employeeId, OracleType.Number);
            procedure.AddInputParameter("R_YEAR", year, OracleType.Number);
            procedure.AddInputParameter("R_QUARTER", quarter, OracleType.Number);
            procedure.AddInputParameter("R_MONTH", month, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                //List<ReportCycleEnt> results = new List<ReportCycleEnt>();
                //foreach (DataRow dr in dt.Rows)
                //{
                //    results.Add(new ReportCycleEnt(dr));
                //}
                if (dt.Rows.Count > 0)
                {
                    return new ReportCycleEnt(dt.Rows[0]);
                }
                return new ReportCycleEnt();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static List<ReportCycleEnt> GetReportCycleList(int employeeId, int year, int quarter, int month)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETREPORTCYCLEDESHBOARD");
            procedure.AddInputParameter("R_EMPLOYEE_ID", employeeId, OracleType.Number);
            procedure.AddInputParameter("R_YEAR", year, OracleType.Number);
            procedure.AddInputParameter("R_QUARTER", quarter, OracleType.Number);
            procedure.AddInputParameter("R_MONTH", month, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ReportCycleEnt> results = new List<ReportCycleEnt>();
                if (dt.Rows.Count > 0)
                {                   
                    foreach (DataRow dr in dt.Rows)
                    {
                        results.Add(new ReportCycleEnt(dr));
                    }
                    return results;
                }
                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static DataTable ESI_GETREPORTSCORECAR_INFO(int reportcycleid)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETREPORTSCORECAR_INFO");
            procedure.AddInputParameter("R_REPORT_CYCLE_ID", reportcycleid, OracleType.Number);

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
        public static ReportCycleEnt GetReportCycleById(int reportCycleId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETREPORTCYCLE");
            procedure.AddInputParameter("p_REPORT_CYCLE_ID", reportCycleId, OracleType.Number);
           
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                //List<ReportCycleEnt> results = new List<ReportCycleEnt>();
                //foreach (DataRow dr in dt.Rows)
                //{
                //    results.Add(new ReportCycleEnt(dr));
                //}
                if (dt.Rows.Count > 0)
                {
                    return new ReportCycleEnt(dt.Rows[0]);
                }
                return new ReportCycleEnt();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static SalesChannelEnt GetSalesChannel(int UserId, string employeeNo)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETSALESCHANNELBYUSER");
            procedure.AddInputParameter("PO_USER_ID", UserId, OracleType.Number);
            procedure.AddInputParameter("PO_EMPLOYEE_NO", employeeNo, OracleType.VarChar);
          
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                //List<ReportCycleEnt> results = new List<ReportCycleEnt>();
                //foreach (DataRow dr in dt.Rows)
                //{
                //    results.Add(new ReportCycleEnt(dr));
                //}
                if (dt.Rows.Count > 0)
                {
                    return new SalesChannelEnt(dt.Rows[0]);
                }
                return new SalesChannelEnt();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static int GetUserDesignation(int employeeId)
        {
            if (employeeId <=0)
            {
                return 0;
            }
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETDESIGNATIONBYEMPLOYEENO");
            procedure.AddInputParameter("p_EMPLOYEE_NO", employeeId, OracleType.Number);

            try 
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                string desigantion = Convert.ToString(dt.Rows[0]["designation"]);
                string designationLbl = Convert.ToString(dt.Rows[0]["DESIGNATIONLEVEL"]) == "" ? "0" : Convert.ToString(dt.Rows[0]["DESIGNATIONLEVEL"]);
                int desigantionLebel = Convert.ToInt32(designationLbl);
                return desigantionLebel;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            
        }
        //public static object GetRegionHeadList(int clusterId)
        //{
        //    throw new NotImplementedException();
        //}
        public static List<KPIEnt> GetRegionHeadList(int clusterId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETKPIBYGROUPID");
            procedure.AddInputParameter("P_SALES_GROUP_ID", clusterId, OracleType.Number);

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

    }
}
