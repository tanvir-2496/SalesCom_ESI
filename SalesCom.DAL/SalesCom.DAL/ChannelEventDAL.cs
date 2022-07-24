using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class ChannelEventDAL
    {
        public static List<ChannelEventEnt> GetChannelEvent(int channelEventId, int eventTypeId, int channelEventBatchId, string importBy, DateTime importDate)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_ChannelEvent");
            procedure.AddInputParameter("pChannelEventId", channelEventId, OracleType.Number);
            procedure.AddInputParameter("pEventTypeId", eventTypeId, OracleType.Number);
            procedure.AddInputParameter("pChannelEventBatchId", channelEventBatchId, OracleType.Number);
            procedure.AddInputParameter("pImportBy", importBy, OracleType.VarChar);
            procedure.AddInputParameter("pImportDate", importDate, OracleType.DateTime);

            //try
            //{
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ChannelEventEnt> results = new List<ChannelEventEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ChannelEventEnt(dr));
                }

                return results;
            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}

        }

    }
}
