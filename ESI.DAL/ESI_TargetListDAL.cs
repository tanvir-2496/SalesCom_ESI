using ESI.Entity;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;

namespace ESI.DAL
{
    public class ESI_TargetListDAL
    {
        public static List<TargetListEnt> GetTargetList(int report_cycle_id, int month)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETAPPROVEDTARGETLIST");
            procedure.AddInputParameter("PREPORT_CYCLE_ID", report_cycle_id, OracleType.Number);
            procedure.AddInputParameter("PMONTH", month, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<TargetListEnt> results = new List<TargetListEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new TargetListEnt(dr));
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
