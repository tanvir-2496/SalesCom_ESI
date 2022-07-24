using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class EventDAL
    {
        public static List<EventEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_Event");
            procedure.AddInputParameter("pEVENTID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<EventEnt> results = new List<EventEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new EventEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static List<EventEnt> GetItemList(int Id, int channelId, string eventName, Int32 reportId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_EventByNameAndChannel");
            procedure.AddInputParameter("pEVENTID", Id, OracleType.Number);
            procedure.AddInputParameter("pChannelTypeId", channelId, OracleType.Number);
            procedure.AddInputParameter("pEventName", eventName, OracleType.VarChar);
            procedure.AddInputParameter("pReportId", reportId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<EventEnt> results = new List<EventEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new EventEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public static int SaveItem(Event2 obj, string strMode)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addEvent");
            procedure.AddInputParameter("pEVENTID", obj.EventID, OracleType.Number);
            procedure.AddInputParameter("pEVENTNAME", obj.EventName, OracleType.VarChar);
            procedure.AddInputParameter("pEVENTTYPEID", obj.EventTypeID, OracleType.Number);
            procedure.AddInputParameter("pEFFECTIVEDATE", obj.EffectiveDate, OracleType.DateTime);
            procedure.AddInputParameter("pEXPIRYDATE", obj.ExpiryDate, OracleType.DateTime);
            procedure.AddInputParameter("pFREQUENCY", obj.Frequency, OracleType.Number);
            procedure.AddInputParameter("pCHANNELTYPEID", obj.ChannelTypeID, OracleType.Number);
            procedure.AddInputParameter("pProductChannelId", obj.ProductChannelId, OracleType.Number);
            procedure.AddInputParameter("pREPORTID", obj.ReportId, OracleType.Number);

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
