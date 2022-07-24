using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class ProductChannelDAL
    {
        public static List<ProductChannelEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_ProductChannel");
            procedure.AddInputParameter("pProductChannelId", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ProductChannelEnt> results = new List<ProductChannelEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ProductChannelEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public static int SaveItem(ProductChannelEnt obj, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addProductChannel");
            procedure.AddInputParameter("pProductChannelId", obj.ProductChannelId, OracleType.Number);
            procedure.AddInputParameter("pProdChhName", obj.ProdChhName, OracleType.VarChar);
            procedure.AddInputParameter("pEffectiveDate", obj.EffectiveDate, OracleType.DateTime);
            procedure.AddInputParameter("pExpireDate", obj.ExpireDate, OracleType.DateTime);
            procedure.AddInputParameter("pProcedure", obj.ProcedureName, OracleType.VarChar);
            procedure.AddInputParameter("pIsActive", obj.IsActive, OracleType.Number);
            procedure.AddInputParameter("pIsDynamic", obj.IsDynamic, OracleType.VarChar);
            procedure.AddInputParameter("p_Str_Mode", strMode, OracleType.VarChar);


            try
            {
                procedure.ExecuteNonQuery();
                if (procedure.ReturnMessage == "SUCCESSFUL")
                {
                    return procedure.ErrorCode;
                }
                return procedure.ErrorCode + Utility.ErrorCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
