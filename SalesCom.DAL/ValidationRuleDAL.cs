using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class ValidationRuleDAL
    {
        public static List<ValidationRuleEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_SimValidationRule");
            procedure.AddInputParameter("pVALIDATIONRULEID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ValidationRuleEnt> results = new List<ValidationRuleEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ValidationRuleEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static int SaveItem(ValidationRule2 obj, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addSimValidationRule");
            procedure.AddInputParameter("pSIMVALIDATIONRULEID", obj.ValidationRuleId, OracleType.Number);
            procedure.AddInputParameter("pVALIDATIONNAME", obj.ValidationName, OracleType.VarChar);
            procedure.AddInputParameter("pEFFECTIVEDATE", obj.EffectiveDate, OracleType.DateTime);
            procedure.AddInputParameter("pEXPIREDATE", obj.ExpireDate, OracleType.DateTime);
            procedure.AddInputParameter("pPROCEDURE", obj.Procedure, OracleType.VarChar);
            procedure.AddInputParameter("pISACTIVE", obj.IsActive, OracleType.Number);
            procedure.AddInputParameter("pACTIVITYID", obj.ActivityId, OracleType.Number);
            procedure.AddInputParameter("pIsDynamic", obj.IsDynamic, OracleType.VarChar);
            procedure.AddInputParameter("pCreateBy", obj.CreateBy, OracleType.Number);
            procedure.AddInputParameter("pUpdateBy", obj.UpdateBy, OracleType.Number);
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
