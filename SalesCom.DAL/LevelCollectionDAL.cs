using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class LevelCollectionDAL
    {
        public static List<LevelCollectionEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_LevelCollection");
            procedure.AddInputParameter("pLEVELCOLLECTIONID", Id, System.Data.OracleClient.OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<LevelCollectionEnt> results = new List<LevelCollectionEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new LevelCollectionEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static int SaveItem(LevelCollectionEnt obj, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addLevelCollection");
            procedure.AddInputParameter("pLEVELCOLLECTIONID", obj.LevelCollectionId, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pNAME", obj.Name, System.Data.OracleClient.OracleType.VarChar);
            procedure.AddInputParameter("p_Str_Mode", strMode, System.Data.OracleClient.OracleType.VarChar);

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
