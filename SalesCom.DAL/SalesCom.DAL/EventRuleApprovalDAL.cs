
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class EventRuleApprovalDAL
    {
        public static List<EventRuleApprovalEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_EventRuleApproval");
            procedure.AddInputParameter("pEVENTAPPROVALID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<EventRuleApprovalEnt> results = new List<EventRuleApprovalEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new EventRuleApprovalEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public static int SaveItem(EventRuleApprovalEnt obj, string strMode, Int16 OrderId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addEventRuleApproval");
            procedure.AddInputParameter("pEventApprovalId", obj.EventApprovalId, OracleType.Number);
            procedure.AddInputParameter("pEventRuleId", obj.EventRuleId, OracleType.Number);
            procedure.AddInputParameter("pFlowId", obj.FlowId, OracleType.Number);
            procedure.AddInputParameter("pLevelId", obj.LevelId, OracleType.Number);
            procedure.AddInputParameter("pCycleId", obj.CycleId, OracleType.Number);
            procedure.AddInputParameter("pStatus", obj.Status, OracleType.VarChar);
            procedure.AddInputParameter("pComments", obj.Comments, OracleType.VarChar);
            procedure.AddInputParameter("pOrderId", OrderId, OracleType.VarChar);
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
