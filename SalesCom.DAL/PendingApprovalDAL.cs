using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class PendingApprovalDAL
    {
        public static List<PendingApprovalEnt> GetItemList(int Id, int userId, int CycleReportId, int publishedMonth)
        {
            //GET_CommissionPendingList
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GET_PendingApproval");
            procedure.AddInputParameter("pPENDINGAPPROVALID", Id, OracleType.Number);
            procedure.AddInputParameter("pUserId", userId, OracleType.Number);
            procedure.AddInputParameter("pCycleReportId", CycleReportId, OracleType.Number);
            procedure.AddInputParameter("pCycleMonth", publishedMonth, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<PendingApprovalEnt> results = new List<PendingApprovalEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new PendingApprovalEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static int SaveItem(PendingApprovalEnt obj, string strMode)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addPendingApproval");
            procedure.AddInputParameter("pPENDINGAPPROVALID", obj.PendingApprovalId, OracleType.Number);
            procedure.AddInputParameter("pLAVELID", obj.LevelId, OracleType.Number);
            procedure.AddInputParameter("pAPPROVALFLOWID", obj.ApprovalflowId, OracleType.Number);
            procedure.AddInputParameter("pCYCLEID", obj.ReportCycleId, OracleType.Number);
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
