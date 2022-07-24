using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class EventRuleExDAL
    {
        public static List<EventRuleExEnt> GetItemList(int EventRuleID, int EventId, Int32 userId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_EVENTRULEEX");
            procedure.AddInputParameter("pEVENTRULEID", EventRuleID, OracleType.Number);
            procedure.AddInputParameter("pEventId", EventId, OracleType.Number);
            procedure.AddInputParameter("pUserId", userId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<EventRuleExEnt> results = new List<EventRuleExEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new EventRuleExEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public static List<EventRuleExEnt> GetItemListFromLog(Int64 lastLogId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_EVENTRULEEXLOG");
            procedure.AddInputParameter("pLastLogId", lastLogId, OracleType.Number);
          

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<EventRuleExEnt> results = new List<EventRuleExEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new EventRuleExEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public static int SaveItem(EventRuleExEnt obj, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "AddEventRuleEx");
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
