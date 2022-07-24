using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class AmountTypeDAL
    {

        public static List<AmountTypeEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_AmountType");
          //  procedure.AddInputParameter("pACTIVITYID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<AmountTypeEnt> results = new List<AmountTypeEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new AmountTypeEnt(dr));
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
