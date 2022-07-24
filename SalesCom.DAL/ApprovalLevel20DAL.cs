using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class ApprovalLevel20DAL
    {     
        public static List<ApprovalLevel20Ent> GetApprovalLevelList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_ApprovalLevel");
            procedure.AddInputParameter("pAPPROVALLEVELID", Id, System.Data.OracleClient.OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ApprovalLevel20Ent> approvalLevel = new List<ApprovalLevel20Ent>();

                foreach (DataRow dr in dt.Rows)
                {
                    approvalLevel.Add(new ApprovalLevel20Ent(dr));
                }

                return approvalLevel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<ApprovalLevel20Ent> GetApprovalLevelByFlowId(int id, int approvalId, int orderId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GET_ApprovalIdByFlowId");
            procedure.AddInputParameter("pAPPROVALLEVELID", id, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pAPPROVALFLOWID", approvalId, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pORDERID", orderId, System.Data.OracleClient.OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ApprovalLevel20Ent> results = new List<ApprovalLevel20Ent>();

                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ApprovalLevel20Ent(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static int SaveItem(ApprovalLevel20Ent obj, string strMode,int userId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "addApprovalLevel");

            procedure.AddInputParameter("pAPPROVALLEVELID", obj.ApprovalLevelID, OracleType.Number);
            procedure.AddInputParameter("pAPPROVALLEVELNAME", obj.ApprovalLevelName, OracleType.VarChar);
            procedure.AddInputParameter("pORDERID", obj.OrderID, OracleType.Number);
            procedure.AddInputParameter("pAPPROVALFLOWID", obj.ApprovalFlowID, OracleType.Number);
            procedure.AddInputParameter("p_Str_Mode", strMode, OracleType.VarChar);
            procedure.AddInputParameter("p_Current_User", userId, OracleType.Number);
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
