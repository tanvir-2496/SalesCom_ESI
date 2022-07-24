using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;

namespace SalesCom.DAL
{
    public class ApprovalFlowDAL
    {
        public static List<ApprovalFlowEnt> GetApprovalFlowList(int Id, string approvalType)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_ApprovalFlow");
            procedure.AddInputParameter("pAPPROVALFLOWID", Id, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pApprovalType", approvalType, System.Data.OracleClient.OracleType.VarChar);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ApprovalFlowEnt> approvalFlow = new List<ApprovalFlowEnt>();

                foreach (DataRow dr in dt.Rows)
                {
                    approvalFlow.Add(new ApprovalFlowEnt(dr));
                }

                return approvalFlow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveItem(ApprovalFlowEnt obj, string strMode,int userId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addApprovalFlow");

            procedure.AddInputParameter("pApprovalFlowID", obj.ApprovalFlowID, OracleType.Number);
            procedure.AddInputParameter("pApprovalName", obj.ApprovalName, OracleType.VarChar);
            procedure.AddInputParameter("pApprovalType", obj.ApprovalType, OracleType.VarChar);
            procedure.AddInputParameter("p_Str_Mode", strMode, OracleType.VarChar);
            procedure.AddInputParameter("p_user", userId, OracleType.Number);
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
