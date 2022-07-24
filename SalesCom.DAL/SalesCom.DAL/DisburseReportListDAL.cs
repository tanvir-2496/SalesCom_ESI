using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class DisburseReportListDAL
    {
        public static List<DisburseReportListEnt> GetItemList(int publishId)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GET_DisburseReportList");
            procedure.AddInputParameter("pPublish_Cycle_Id", publishId, System.Data.OracleClient.OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<DisburseReportListEnt> results = new List<DisburseReportListEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new DisburseReportListEnt(dr));
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
