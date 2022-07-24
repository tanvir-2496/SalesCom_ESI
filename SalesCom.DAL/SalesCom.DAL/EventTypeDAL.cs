using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class EventTypeDAL
    {
        public static List<EventTypeEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_EventType");
            procedure.AddInputParameter("pEVENTTYPEID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<EventTypeEnt> results = new List<EventTypeEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new EventTypeEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static List<EventTypeEnt> GetItemListByReportId(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_EventTypeByReport");
            procedure.AddInputParameter("pREPORTID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<EventTypeEnt> results = new List<EventTypeEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new EventTypeEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public static int SaveItem(EventType2 obj, string strMode)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addEventType");
            procedure.AddInputParameter("pEVENTTYPEID", obj.EventTypeId, OracleType.Number);
            procedure.AddInputParameter("pEVENTTYPE", obj.EventType, OracleType.VarChar);

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
