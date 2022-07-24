using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class ApprovalLevelDAL
    {
        public static List<ApprovalLevelEnt> GetApprovalLevelList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_ApprovalLevel");
            procedure.AddInputParameter("pAPPROVALLEVELID", Id, System.Data.OracleClient.OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ApprovalLevelEnt> approvalLevel = new List<ApprovalLevelEnt>();

                foreach (DataRow dr in dt.Rows)
                {
                    approvalLevel.Add(new ApprovalLevelEnt(dr));
                }

                return approvalLevel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<ApprovalLevelEnt> GetApprovalLevelByFlowId(int id, int approvalId, int orderId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_ApprovalIdByFlowId");
            procedure.AddInputParameter("pAPPROVALLEVELID", id, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pAPPROVALFLOWID", approvalId, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pORDERID", orderId, System.Data.OracleClient.OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ApprovalLevelEnt> results = new List<ApprovalLevelEnt>();

                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ApprovalLevelEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ApprovalLevelWithJoin> GetApprovalLevelWithJoin(int id, int approvalId, int orderId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_ApprovalLevelWithJoin");
            procedure.AddInputParameter("pAPPROVALLEVELID", id, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pAPPROVALFLOWID", approvalId, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pORDERID", orderId, System.Data.OracleClient.OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ApprovalLevelWithJoin> results = new List<ApprovalLevelWithJoin>();

                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ApprovalLevelWithJoin(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveItem(ApprovalLevelEnt obj, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addApprovalLevel");

            procedure.AddInputParameter("pAPPROVALLEVELID", obj.ApprovalLevelID, OracleType.Number);
            procedure.AddInputParameter("pLEVELCOLLECTIONID", obj.LevelCollectionId, OracleType.Number);
            procedure.AddInputParameter("pORDERID", obj.OrderID, OracleType.Number);
            procedure.AddInputParameter("pAPPROVALFLOWID", obj.ApprovalFlowID, OracleType.Number);
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
    }
}
