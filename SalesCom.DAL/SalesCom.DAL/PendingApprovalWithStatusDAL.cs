using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;

namespace SalesCom.DAL
{
    public class PendingApprovalWithStatusDAL
    {
        public static int UpdateStatusWithComments(PendingApprovalWithStatusAndCommentEnt obj, string userName, double payableAmout, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "updatePendingApproval");
            procedure.AddInputParameter("pPENDINGAPPROVALID", obj.PendingApprovalId, OracleType.Number);
            procedure.AddInputParameter("pLEVELID", obj.LevelId, OracleType.Number);
            procedure.AddInputParameter("pAPPROVALFLOWID", obj.ApprovalFlowId, OracleType.Number);
            procedure.AddInputParameter("pCYCLEID", obj.CycleId, OracleType.Number);
            procedure.AddInputParameter("pSTATUS", obj.Status, OracleType.Number);
            procedure.AddInputParameter("pCOMMENTS", obj.Comments, OracleType.VarChar);
            procedure.AddInputParameter("pORDERID", obj.OrderId, OracleType.Number);
            procedure.AddInputParameter("pUserName", userName, OracleType.VarChar);
            procedure.AddInputParameter("pPayableAmount", payableAmout, OracleType.Number);
            procedure.AddInputParameter("p_Str_Mode", strMode, OracleType.VarChar);

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


        public static List<CommentsCycleEnt> GetPreviousComment(int Id, int reportCycleId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_PreviousComments");
            procedure.AddInputParameter("pAPPROVALFLOWID", Id, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pReportCycleId", reportCycleId, System.Data.OracleClient.OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<CommentsCycleEnt> results = new List<CommentsCycleEnt>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        results.Add(new CommentsCycleEnt(dr));
                    }
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
