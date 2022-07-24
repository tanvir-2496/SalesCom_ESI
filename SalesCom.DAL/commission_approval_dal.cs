﻿using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class commission_approval_dal
    {
    
        public static List<commission_approval_ent> GetItemList(int Id, int userId, int CycleReportId, int publishedMonth)
        {
            //GET_PendingApproval
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GET_CommissionPendingList");
            procedure.AddInputParameter("pId", Id, OracleType.Number);
            procedure.AddInputParameter("pUser_Id", userId, OracleType.Number);
            procedure.AddInputParameter("pBase_Cycle_Id", CycleReportId, OracleType.Number);
            procedure.AddInputParameter("pPublish_Cycle_Id", publishedMonth, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<commission_approval_ent> results = new List<commission_approval_ent>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new commission_approval_ent(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static List<ApprovalHistory> GetCommissionApprovalHistory(int Id, Int16 approvalTypeId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GetComApprovalHis");
            procedure.AddInputParameter("pId", Id, OracleType.Number);
            procedure.AddInputParameter("pApprovalTypeId", approvalTypeId, OracleType.Number);

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

        public static int UpdateComAppStatus(commission_approval_ent obj, Int16 status, int user_id, string user_name)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "UpdateComAppStatus");
            procedure.AddInputParameter("pId", obj.id, OracleType.Number);
            procedure.AddInputParameter("pReportCycleId", obj.report_cycle_id, OracleType.Number);
            procedure.AddInputParameter("pReportName", obj.report_name, OracleType.VarChar);
            procedure.AddInputParameter("pBaseCycle", obj.base_moth, OracleType.VarChar);
            procedure.AddInputParameter("pPublishCycle", obj.publish_month, OracleType.VarChar);
            procedure.AddInputParameter("pCommission", obj.com_amount, OracleType.VarChar);
            procedure.AddInputParameter("pFlowId", obj.flow_id, OracleType.Number);
            procedure.AddInputParameter("pClaimFlowId", obj.claim_flow_id, OracleType.Number);
            procedure.AddInputParameter("pLevelName", obj.current_level, OracleType.VarChar);
            procedure.AddInputParameter("pLevelId", obj.level_id, OracleType.Number);
            procedure.AddInputParameter("pOrder", obj.order_id, OracleType.Number);
            procedure.AddInputParameter("pStatus", status, OracleType.Number);
            procedure.AddInputParameter("pComment", obj.comments, OracleType.VarChar);
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