using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class EventRuleDAL
    {
        public static List<EventRuleEnt> GetItemList(int EventRuleID, int EventId, int reportId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_EVENTRULE");
            procedure.AddInputParameter("pEVENTRULEID", EventRuleID, OracleType.Number);
            procedure.AddInputParameter("pEventId", EventId, OracleType.Number);
            procedure.AddInputParameter("pReportId", reportId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<EventRuleEnt> results = new List<EventRuleEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new EventRuleEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static int SaveItem(EventRule2 obj, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addEVENTRULE");
            procedure.AddInputParameter("pEVENTRULEID", obj.EventRuleID, OracleType.Number);
            procedure.AddInputParameter("pEVENTRULENAME", obj.EventRuleName, OracleType.VarChar);
            procedure.AddInputParameter("pEVENTID", obj.EventID, OracleType.VarChar);
            procedure.AddInputParameter("pSEGMENTID", obj.SegmentID, OracleType.Number);
            procedure.AddInputParameter("pMINAMOUNT", obj.MinAmount, OracleType.Number);
            procedure.AddInputParameter("pMAXAMOUNT", obj.MaxAmount, OracleType.Number);
            procedure.AddInputParameter("pAMOUNTTYPEID", obj.AmountTypeID, OracleType.Number);
            procedure.AddInputParameter("pCOMMISSIONTYPE", obj.CommissionType, OracleType.Number);
            procedure.AddInputParameter("pCOMMISSIONVALUE", obj.CommissionValue, OracleType.Number);
            procedure.AddInputParameter("pMAXCOMMISSIONPEREVENT", obj.MaxCommissionPerevent, OracleType.Number);
            procedure.AddInputParameter("pVALIDATIONRULEID", obj.ValidationRuleID, OracleType.Number);
            procedure.AddInputParameter("pRULEGROUP", obj.RuleGroupID, OracleType.Number);

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
