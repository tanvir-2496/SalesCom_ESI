using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class CommissionReportEventsDAL
    {
        public static List<CommissionReportEventsEnt> GetItemList(int ReportID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_COMMISSIONREPORTEVENTS");
            procedure.AddInputParameter("pReportID", ReportID, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<CommissionReportEventsEnt> results = new List<CommissionReportEventsEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new CommissionReportEventsEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static int SaveItem(CommissionReportEventsEnt obj, string strMode)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addCOMMISSIONREPORTEVENTS");
            procedure.AddInputParameter("pReportID", obj.ReportID, OracleType.Number);
            procedure.AddInputParameter("pEVENTID", obj.EventID, OracleType.VarChar);
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
