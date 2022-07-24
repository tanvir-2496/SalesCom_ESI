using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class DigitalApprovalDAL
    {
        public static DataTable GetDigitalApproval(Int32 reportId, Int32 cycleId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GET_DigitalApproval");
            procedure.AddInputParameter("pReportId", reportId, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pCycleId", cycleId, System.Data.OracleClient.OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                return dt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
}
