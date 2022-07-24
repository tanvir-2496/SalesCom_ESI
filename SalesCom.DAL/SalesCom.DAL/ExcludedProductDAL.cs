using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;

namespace SalesCom.DAL
{
    public class ExcludedProductDAL
    {

        public static List<ExcludedProductEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_ExcludedProduct");
            procedure.AddInputParameter("pExcludedProductId", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ExcludedProductEnt> results = new List<ExcludedProductEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ExcludedProductEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static int SaveItem(ExcludedProductEnt obj, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addExcludedProduct");
            procedure.AddInputParameter("pExcludedProductId", obj.ExcludedProductId, OracleType.Number);
            procedure.AddInputParameter("pReportId", obj.ReportId, OracleType.VarChar);
            procedure.AddInputParameter("pProductId", obj.ProductId, OracleType.Number);
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
