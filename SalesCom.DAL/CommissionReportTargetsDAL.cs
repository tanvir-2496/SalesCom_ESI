using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class CommissionReportTargetsDAL
    {
    
        public static List<CommissionReportTargetsEnt> GetItemList(int reportId, int eventTypeId, int reportCycle)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_CommissionReportTargets");
            procedure.AddInputParameter("pReportId", reportId, OracleType.Number);
            procedure.AddInputParameter("pEventTypeId", eventTypeId, OracleType.Number);
            procedure.AddInputParameter("pReportCycle", reportCycle, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<CommissionReportTargetsEnt> results = new List<CommissionReportTargetsEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new CommissionReportTargetsEnt(dr));
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
