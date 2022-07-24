using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class ReportGenTypeDAL
    {

        public static List<ReportGenTypeEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_ReportGenType");
            procedure.AddInputParameter("pREPORTGENTYPEID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ReportGenTypeEnt> results = new List<ReportGenTypeEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ReportGenTypeEnt(dr));
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
