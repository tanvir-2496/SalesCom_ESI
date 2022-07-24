using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class RuleGroupDAL
    {
        public static List<RuleGroupEnt> GetItemList()
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_RuleGroup");
        //    procedure.AddInputParameter("pEVENTTYPEID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<RuleGroupEnt> results = new List<RuleGroupEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new RuleGroupEnt(dr));
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
