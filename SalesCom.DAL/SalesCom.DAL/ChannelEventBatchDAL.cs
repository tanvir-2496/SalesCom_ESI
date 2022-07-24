using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class ChannelEventBatchDAL
    {
        public static List<ChannelEventBatchEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_ChannelEventBatch");
            procedure.AddInputParameter("pCHANNELEVENTBATCHID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ChannelEventBatchEnt> results = new List<ChannelEventBatchEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ChannelEventBatchEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static List<ChannelEventBatchEntEx> GetItemListByReportId(int reportId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_CEventBatchByReportId");
            procedure.AddInputParameter("pChannelReportId", reportId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ChannelEventBatchEntEx> results = new List<ChannelEventBatchEntEx>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ChannelEventBatchEntEx(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public static int SaveItem(ChannelEventBatchEnt obj, string strMode)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addChannelEventBatch");
            procedure.AddInputParameter("pCHANNELEVENTBATCHID", obj.ChannelEventBatchId, OracleType.Number);
            procedure.AddInputParameter("pBATCHSOURCE", obj.BatchSource, OracleType.VarChar);
            procedure.AddInputParameter("pBATCHDATE", obj.BatchDate, OracleType.DateTime);
            procedure.AddInputParameter("pISREADY", obj.IsReady, OracleType.VarChar);
            procedure.AddInputParameter("pBATCHTYPE", obj.BatchType, OracleType.VarChar);
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
