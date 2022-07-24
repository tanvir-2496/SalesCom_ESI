using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;

namespace SalesCom.DAL
{
    public class CommonDAL
    {
        public static List<PeriodTypeEnt> GetPeriodListList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_PeridType");
            procedure.AddInputParameter("pPERIODTYPEID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<PeriodTypeEnt> results = new List<PeriodTypeEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new PeriodTypeEnt(dr));
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
