using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class EventExDAL
    {
        public static List<EventExEnt> GetItemList(int Id, int channelId, string eventName, Int32 reportId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_EventEx");
            procedure.AddInputParameter("pEVENTID", Id, OracleType.Number);
            procedure.AddInputParameter("pChannelTypeId", channelId, OracleType.Number);
            procedure.AddInputParameter("pEventName", eventName, OracleType.VarChar);
            procedure.AddInputParameter("pReportId", reportId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<EventExEnt> results = new List<EventExEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new EventExEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static int SaveItem(EventExEnt obj, string strMode)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addEventEx");
            procedure.AddInputParameter("pEVENTID", obj.EventId, OracleType.Number);
            procedure.AddInputParameter("pEVENTNAME", obj.EventName, OracleType.VarChar);
            procedure.AddInputParameter("pEVENTTYPEID", obj.EventTypeId, OracleType.Number);
            procedure.AddInputParameter("pEFFECTIVEDATE", obj.EffectiveDate, OracleType.DateTime);
            procedure.AddInputParameter("pEXPIRYDATE", obj.ExpiryDate, OracleType.DateTime);
            procedure.AddInputParameter("pFREQUENCY", obj.Frequency, OracleType.Number);
            procedure.AddInputParameter("pCHANNELTYPEID", obj.ChannelTypeId, OracleType.Number);
            procedure.AddInputParameter("pApprovalFlowId", obj.ApprovalFlowId, OracleType.Number);

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
