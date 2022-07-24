using System;
using System.Data;
using System.Data.OracleClient;

namespace ESI.DAL
{
    public class ESI_ReportExportDAL
    {
        public static DataTable DetailsTargetReport(int ReportCycleId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETAPPROVEDTARGETLIST");
            procedure.AddInputParameter("PREPORT_CYCLE_ID", ReportCycleId, OracleType.Number);

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

        public static DataTable DetailsKpiWiseTargetReport(int ReportCycleId, int kpi_id, int month)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETAKPIWISETARGETLIST");
            procedure.AddInputParameter("PREPORT_CYCLE_ID", ReportCycleId, OracleType.Number);
            procedure.AddInputParameter("PKPI_ID", kpi_id, OracleType.Number);
            procedure.AddInputParameter("PMONTH", month, OracleType.Number);

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
