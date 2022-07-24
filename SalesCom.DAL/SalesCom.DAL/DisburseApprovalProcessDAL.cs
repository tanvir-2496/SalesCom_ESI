using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class DisburseApprovalProcessDAL
    {
        public static List<DisburseApprovalProcessEnt> GetItemList(int userId, int publishId, int periodTypeId)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GET_DisbursePendingList");
            procedure.AddInputParameter("pUser_Id", userId, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pPublish_Cycle_Id", publishId, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pPeriodTypeId", periodTypeId, System.Data.OracleClient.OracleType.Number);
            

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<DisburseApprovalProcessEnt> results = new List<DisburseApprovalProcessEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new DisburseApprovalProcessEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static DataTable Get_Disburse_Data(Int64 CycleReportID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_Disburse_Data");
            procedure.AddInputParameter("pReport_Cycle_Id", CycleReportID, System.Data.OracleClient.OracleType.Number);

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


        public static DataTable Get_Final_Disburse_Details(Int64 CycleReportID, string reportName, string reportDuration)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_Final_Disburse");
            procedure.AddInputParameter("pReport_Cycle_Id", CycleReportID, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pReport_Name", reportName, System.Data.OracleClient.OracleType.VarChar);
            procedure.AddInputParameter("pReport_Duration", reportDuration, System.Data.OracleClient.OracleType.VarChar);

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

        public static DataTable Get_POS_Upload_Details(Int64 CycleReportID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_POS_Upload_Details");
            procedure.AddInputParameter("pReport_Cycle_Id", CycleReportID, System.Data.OracleClient.OracleType.Number);

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

        public static int UpdateDisAppStatus(DisburseApprovalProcessEnt obj, Int16 status, string comment, int user_id, string user_name)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "UpdateDisAppStatus");
            procedure.AddInputParameter("pId", obj.Id, OracleType.Number);
            procedure.AddInputParameter("pReportCycleId", obj.report_cycle_id, OracleType.Number);
            procedure.AddInputParameter("pReportName", obj.reportname, OracleType.VarChar);
            procedure.AddInputParameter("pReportDuration", obj.report_duration, OracleType.VarChar);
            procedure.AddInputParameter("pClaim", obj.claim_amt, OracleType.VarChar);
            procedure.AddInputParameter("pDisburse", obj.disburse_amt, OracleType.VarChar);
            procedure.AddInputParameter("pFlowId", obj.flow_id, OracleType.Number);
            procedure.AddInputParameter("pLevelName", obj.level_name, OracleType.VarChar);
            procedure.AddInputParameter("pLevelId", obj.level_id, OracleType.Number);
            procedure.AddInputParameter("pOrder", obj.orderid, OracleType.Number);
            procedure.AddInputParameter("pStatus", status, OracleType.Number);
            procedure.AddInputParameter("pComment", comment, OracleType.VarChar);
            procedure.AddInputParameter("pUserId", user_id, OracleType.Number);
            procedure.AddInputParameter("pUserName", user_name, OracleType.VarChar);

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
