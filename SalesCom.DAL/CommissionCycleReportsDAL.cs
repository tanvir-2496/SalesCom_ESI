using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class CommissionCycleReportsDAL
    {
        public static List<CommissionCycleReportsEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_CommissionCycleReports");
            procedure.AddInputParameter("pCYCLEREPORTID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<CommissionCycleReportsEnt> results = new List<CommissionCycleReportsEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new CommissionCycleReportsEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static int SaveItem(CommissionCycleReportsEnt obj, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "AddCommissionCycleReports");
            procedure.AddInputParameter("pCYCLEREPORTID", obj.CycleReportId, OracleType.Number);
            procedure.AddInputParameter("pREPORTID", obj.ReportId, OracleType.Number);
            procedure.AddInputParameter("pCYCLEID", obj.CycleId, OracleType.Number);
            procedure.AddInputParameter("pVERSION", obj.Version, OracleType.Number);
            procedure.AddInputParameter("pREPORTSTAGE", obj.ReportStage, OracleType.Number);
            procedure.AddInputParameter("pSTATUS", obj.Status, OracleType.VarChar);
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
