using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using SalesCom.Entity;


namespace SalesCom.DAL
{
   public class CdpReportDAL
    {


        public static DataTable ReportData(DateTime startDate, DateTime endDate, int rName, string rType)
        {
            CDPOracleProcedure procedure = new CDPOracleProcedure("CDP_GET_REPORT");
            procedure.AddInputParameter("P_CDP_REPORT_INFO_ID", rName, OracleType.Number);
            procedure.AddInputParameter("P_response_status", rType, OracleType.VarChar);
            procedure.AddInputParameter("P_FROMDATE", startDate, OracleType.DateTime);
            procedure.AddInputParameter("P_TODATE", endDate, OracleType.DateTime);


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

        public static List<CdpReportEntity> GetCdpReport(DateTime startDate, DateTime endDate, int rName, string rType)
        {
            CDPOracleProcedure procedure = new CDPOracleProcedure("CDP_GET_REPORT");
            procedure.AddInputParameter("P_CDP_REPORT_INFO_ID", rName, OracleType.Number);
            procedure.AddInputParameter("P_response_status", rType, OracleType.VarChar);
            procedure.AddInputParameter("P_FROMDATE", startDate, OracleType.DateTime);
            procedure.AddInputParameter("P_TODATE", endDate, OracleType.DateTime);
            //procedure.Direction = ParameterDirection.Output;
            //manager.AddParameter(param);
            //  procedure.AddInputParameter("pACTIVITYID", Id, OracleType.Number);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<CdpReportEntity> results = new List<CdpReportEntity>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new CdpReportEntity(dr));
                }
                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }



        public static List<CdpReportListEntity> Get_CDP_Report_List()
        {
           // OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_AdHoc_Report_List");
            CDPOracleProcedure procedure = new CDPOracleProcedure("CDP_GET_REPORT_LIST");

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<CdpReportListEntity> results = new List<CdpReportListEntity>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new CdpReportListEntity(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


    }
}
