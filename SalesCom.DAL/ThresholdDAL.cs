using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class ThresholdDAL
    {
        public static List<ThresholdEnt> GetAll(int thresholdTypeId)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_Threshold");
            procedure.AddInputParameter("pThresholdTypeId", thresholdTypeId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ThresholdEnt> results = new List<ThresholdEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ThresholdEnt(dr));
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
