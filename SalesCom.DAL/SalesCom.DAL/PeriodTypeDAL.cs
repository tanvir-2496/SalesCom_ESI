using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class PeriodTypeDAL
    {
        public static List<PeriodTypeEnt> GetItemList(int Id)
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
        public static int SaveItem(PeriodTypeEnt obj, string strMode)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addPeriodType");
            procedure.AddInputParameter("pPERIODTYPEID", obj.PeriodTypeId, OracleType.Number);
            procedure.AddInputParameter("pPERIODTYPENAME", obj.PeriodTypeName, OracleType.VarChar);
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
