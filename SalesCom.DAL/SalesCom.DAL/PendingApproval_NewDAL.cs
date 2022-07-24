using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class PendingApproval_NewDAL
    {
        public static List<PendingApproval_NewEnt> GetItemList(int Id, int userId, int CycleReportId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GET_PendingApprovalNew");
            procedure.AddInputParameter("pID", Id, OracleType.Number);
            procedure.AddInputParameter("pUserId", userId, OracleType.Number);
            procedure.AddInputParameter("pCycleReportId", CycleReportId, OracleType.Number);


            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<PendingApproval_NewEnt> results = new List<PendingApproval_NewEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new PendingApproval_NewEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static int SaveItem(PendingApproval_NewEnt obj, string strMode)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addPendingApprovalNew");

            procedure.AddInputParameter("pID", obj.Id, OracleType.Number);
            procedure.AddInputParameter("pAPPROVALFLOWID", obj.ApprovalFlowId, OracleType.Number);
            procedure.AddInputParameter("pCYCLEID", obj.CycleId, OracleType.Number);
            procedure.AddInputParameter("pSTATUS", obj.Status, OracleType.Number);
            procedure.AddInputParameter("pCOMMENTS", obj.Comments, OracleType.VarChar);
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
