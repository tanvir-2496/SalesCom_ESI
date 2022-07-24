using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;

namespace SalesCom.DAL
{
    public class ReportPreExeConfigDAL
    {
        public static List<ReportPreExeConfigEnt> GetReportPreExeConfig(Int32 publishCycleId, Int32 reportId, Int32 cycleId, Int32 provisionCycleId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GetReportPreExeConfig");
            procedure.AddInputParameter("pPublishCycleId", publishCycleId, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pReportId", reportId, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pCycleId", cycleId, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pProvisionCycleId", provisionCycleId, System.Data.OracleClient.OracleType.Number);

            try
            {

                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ReportPreExeConfigEnt> result = new List<ReportPreExeConfigEnt>();

                foreach (DataRow dr in dt.Rows)
                {
                    result.Add(new ReportPreExeConfigEnt(dr));
                }

                return result;
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static int UpdateDataSource(ReportPreExeConfigEnt obj, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "UpdateReportPreExeConfig");
            procedure.AddInputParameter("pCycleReportId", obj.CycleReportId, OracleType.Number);
            procedure.AddInputParameter("pStatus", obj.Status, OracleType.Number);
            procedure.AddInputParameter("pProvisionCycleId", obj.ProvisionCycleId, OracleType.Number);
            procedure.AddInputParameter("pPublishCycleId", obj.PublishCycleId, OracleType.Number);
            procedure.AddInputParameter("pProvisionFromDate", obj.ProvisionFromDate, OracleType.DateTime);
            procedure.AddInputParameter("pProvisionToDate", obj.ProvisionToDate, OracleType.DateTime);
            procedure.AddInputParameter("pReportFromDate", obj.ReportFromDate, OracleType.DateTime);
            procedure.AddInputParameter("pReportToDate", obj.ReportToDate, OracleType.DateTime);
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
