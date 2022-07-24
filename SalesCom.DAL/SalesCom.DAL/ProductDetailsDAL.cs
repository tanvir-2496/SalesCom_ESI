using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class ProductDetailsDAL
    {

        public static List<ProductDetailsEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_ProductDetails");
            procedure.AddInputParameter("pPRODUCTID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ProductDetailsEnt> results = new List<ProductDetailsEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ProductDetailsEnt(dr));
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
