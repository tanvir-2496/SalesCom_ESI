using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class CommissionReportAllDAL
    {
        public static List<CommissionReportAllEnt> GetItemList(int ReportID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GET_CommReportAll");
            //procedure.AddInputParameter("pReportID", ReportID, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<CommissionReportAllEnt> results = new List<CommissionReportAllEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new CommissionReportAllEnt(dr));
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
