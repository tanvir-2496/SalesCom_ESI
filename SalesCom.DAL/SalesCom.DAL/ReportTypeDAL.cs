using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;

namespace SalesCom.DAL
{
    public class ReportTypeDAL
    {
        public static List<ReportTypeEnt> GetItemList(int report_type_id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_Reort_Type");
            procedure.AddInputParameter("pReport_Type_Id", report_type_id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ReportTypeEnt> results = new List<ReportTypeEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ReportTypeEnt(dr));
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
