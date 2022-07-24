using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class EventValidationDAL
    {
        public static List<EventValidationEnt> GetItemList(int SIMValidationRuleID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_EventValidation");
            procedure.AddInputParameter("pEVENTID", SIMValidationRuleID, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<EventValidationEnt> results = new List<EventValidationEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new EventValidationEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static int SaveItem(EventValidationEnt obj, string strMode)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addEventValidation");
            procedure.AddInputParameter("pEVENTVALIDATIONID", obj.EventValidationID, OracleType.Number);
            procedure.AddInputParameter("pEVENTID", obj.EventID, OracleType.VarChar);
            procedure.AddInputParameter("pVALIDATIONRULEID", obj.ValidationRuleID, OracleType.Number);
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
