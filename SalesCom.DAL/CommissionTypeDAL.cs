using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class CommissionTypeDAL
    {

        public static List<CommissionTypeEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_CommissionType");
          //  procedure.AddInputParameter("pACTIVITYID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<CommissionTypeEnt> results = new List<CommissionTypeEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new CommissionTypeEnt(dr));
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
