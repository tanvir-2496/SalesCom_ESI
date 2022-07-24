using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class SPendingApprovalDAL
    {
        public static List<SPendingApprovalEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_PendingApproval");
            procedure.AddInputParameter("pPENDINGAPPROVALID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<SPendingApprovalEnt> results = new List<SPendingApprovalEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new SPendingApprovalEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static List<PendingApprovalViewEnt> GetPendingApprovalViewList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_PendingApprovalView");
            procedure.AddInputParameter("pPENDINGAPPROVALID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<PendingApprovalViewEnt> results = new List<PendingApprovalViewEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new PendingApprovalViewEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public static int SaveItem(SPendingApprovalEnt obj, string strMode)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addPendingApproval");
            procedure.AddInputParameter("pPENDINGAPPROVALID", obj.PendingApprovalId, OracleType.Number);
            procedure.AddInputParameter("pLEVELID", obj.LevelId, OracleType.Number);
            procedure.AddInputParameter("pAPPROVALFLOWID", obj.ApprovalflowId, OracleType.Number);
            procedure.AddInputParameter("pCYCLEID", obj.CycleId, OracleType.Number);
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
