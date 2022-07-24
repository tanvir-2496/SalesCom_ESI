using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class AdHocPendingApprovalDAL
    {
        public static List<AdHocPendingApprovalEnt> GetItemList(int Id, int userId, DateTime startGenerationKey, DateTime endGenerationKey)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GET_AdHocPendingApproval");
            procedure.AddInputParameter("pId", Id, OracleType.Number);
            procedure.AddInputParameter("pUser_Id", userId, OracleType.Number);
            procedure.AddInputParameter("pStart_Generation_Date", startGenerationKey, OracleType.DateTime);
            procedure.AddInputParameter("pEnd_Generation_Date", endGenerationKey, OracleType.DateTime);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<AdHocPendingApprovalEnt> results = new List<AdHocPendingApprovalEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new AdHocPendingApprovalEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static List<AdHocReportViewEnt> GetAdHocReport(int reportId, DateTime startReportDate, DateTime endReportDate)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GetAdHocReport");
            procedure.AddInputParameter("pReport_Id", reportId, OracleType.Number);
            procedure.AddInputParameter("pStart_Report_Date", startReportDate, OracleType.DateTime);
            procedure.AddInputParameter("pEnd_Report_Date", endReportDate, OracleType.DateTime);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<AdHocReportViewEnt> results = new List<AdHocReportViewEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new AdHocReportViewEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static List<AdHocSummaryReport> GetAdHocSummaryReport(Int32 reportId, DateTime startGenerationKey, DateTime endGenerationKey)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GetAdHocSummaryReport");
            procedure.AddInputParameter("pReportId", reportId, OracleType.Number);
            procedure.AddInputParameter("pStart_Generation_Date", startGenerationKey, OracleType.DateTime);
            procedure.AddInputParameter("pEnd_Generation_Date", endGenerationKey, OracleType.DateTime);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<AdHocSummaryReport> results = new List<AdHocSummaryReport>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new AdHocSummaryReport(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public static List<ApprovalHistory> GetApprovalHistory(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GetApprovalHistory");
            procedure.AddInputParameter("pId", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ApprovalHistory> results = new List<ApprovalHistory>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ApprovalHistory(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static int UpdateAdHocPendingStatus(ApprovalDetail obj)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "UpdateAdHocPendingStatus");
            procedure.AddInputParameter("pId", obj.Id, OracleType.Number);
            procedure.AddInputParameter("pReportName", obj.ReportName, OracleType.VarChar);
            procedure.AddInputParameter("pReportDate", obj.ReportDate, OracleType.VarChar);
            procedure.AddInputParameter("pReportGenDate", obj.ReportGenDate, OracleType.VarChar);
            procedure.AddInputParameter("pCommission", obj.Commission, OracleType.VarChar);
            procedure.AddInputParameter("pFlowId", obj.FlowId, OracleType.Number);
            procedure.AddInputParameter("pLevelName", obj.LevelName, OracleType.VarChar);
            procedure.AddInputParameter("pLevelId", obj.LevelId, OracleType.Number);
            procedure.AddInputParameter("pOrder", obj.Order, OracleType.Number);
            procedure.AddInputParameter("pStatus", obj.Status, OracleType.Number);
            procedure.AddInputParameter("pComment", obj.Comment, OracleType.VarChar);
            procedure.AddInputParameter("pUserId", obj.UserId, OracleType.Number);
            procedure.AddInputParameter("pUserName", obj.UserName, OracleType.VarChar);

            try
            {
                procedure.ExecuteNonQuery();
                if (procedure.ReturnMessage == "SUCCESSFUL")
                {
                    return procedure.ErrorCode;
                }
                return procedure.ErrorCode + Utility.ErrorCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
