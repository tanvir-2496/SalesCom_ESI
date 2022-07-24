using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;

namespace SalesCom.DAL
{
    public class ClaimApprovalProcessDAL
    {
        public static List<ClaimApprovalProcessEnt> GetItemList(int publishId, int userId)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GET_ClaimPendingList");
            procedure.AddInputParameter("pPublish_Cycle_Id", publishId, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pUser_Id", userId, System.Data.OracleClient.OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ClaimApprovalProcessEnt> results = new List<ClaimApprovalProcessEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ClaimApprovalProcessEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static DataTable Get_Com_Claim_Data(Int64 CycleReportID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_Com_Claim_Data");
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

        public static int UpdateClaimAppStatus(ClaimApprovalProcessEnt obj, Int16 status, string comment, int user_id, string user_name)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "UpdateClaimAppStatus");
            procedure.AddInputParameter("pId", obj.Id, OracleType.Number);
            procedure.AddInputParameter("pReportCycleId", obj.report_cycle_id, OracleType.Number);
            procedure.AddInputParameter("pReportName", obj.reportname, OracleType.VarChar);
            procedure.AddInputParameter("pReportDuration", obj.report_duration, OracleType.VarChar);
            procedure.AddInputParameter("pCommission", obj.report_amt, OracleType.VarChar);
            procedure.AddInputParameter("pDiscard", obj.discard_amt, OracleType.VarChar);
            procedure.AddInputParameter("pClaim", obj.claim_amt, OracleType.VarChar);
            procedure.AddInputParameter("pFlowId", obj.flow_id, OracleType.Number);
            procedure.AddInputParameter("pDisburseFlowId", obj.disburse_flow_id, OracleType.Number);
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
