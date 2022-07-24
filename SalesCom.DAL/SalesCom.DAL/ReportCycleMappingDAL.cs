using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class ReportCycleMappingDAL
    {
        public static List<ReportCycleMappingEnt> GetItemList(int reportId, string reportName, int cycleId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_Report_Cycle_Mapping");
            procedure.AddInputParameter("pReportId", reportId, OracleType.Number);
            procedure.AddInputParameter("pReportName", reportName, OracleType.VarChar);
            procedure.AddInputParameter("pCycleId", cycleId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ReportCycleMappingEnt> results = new List<ReportCycleMappingEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ReportCycleMappingEnt(dr));
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
