using System;
using System.Data;
using System.Data.OracleClient;

namespace SalesCom.DAL
{
    public class CommissionDetailExportDAL
    {
        public static DataTable GetItemList(Int64 channelId, string channelCode, int CycleReportID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GET_CommReportDetailExport");
            procedure.AddInputParameter("pChannelId", channelId, OracleType.Number);
            procedure.AddInputParameter("pChannelCode", channelCode, OracleType.VarChar);
            procedure.AddInputParameter("pCYCLEREPORTID", CycleReportID, OracleType.Number);

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

        public static DataTable GetAllProvision(Int64 Id, int CycleReportID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GET_All_Provision");
            procedure.AddInputParameter("pChannelId", Id, OracleType.Number);
            procedure.AddInputParameter("pCYCLEREPORTID", CycleReportID, OracleType.Number);

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

        public static DataTable GetDistributorList(Int64 Id, int CycleReportID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GET_ReportDetailExportDis");
            procedure.AddInputParameter("pCYCLEREPORTID", CycleReportID, OracleType.Number);

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

        public static DataTable GetDistributorListProvision(Int64 Id, int CycleReportID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GET_REPORTDETAILEXPORTDISP");
            procedure.AddInputParameter("pChannelId", Id, OracleType.Number);
            procedure.AddInputParameter("pCYCLEREPORTID", CycleReportID, OracleType.Number);

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


        public static DataTable GetItemListByChannelIdCycleId(int channelId, string channelCode, int reportCycleId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "generate_report");
            procedure.AddInputParameter("distributor", channelId, OracleType.Number);
            procedure.AddInputParameter("pChannelCode", channelCode, OracleType.VarChar);
            procedure.AddInputParameter("reportid", reportCycleId, OracleType.Number);

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


        public static DataTable GenerateProvisionReport(Int64 ChannelId, int AmountTypeId, Int64 CycleReportID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "Provision_report");
            procedure.AddInputParameter("distributor", ChannelId, OracleType.Number);
            procedure.AddInputParameter("amounttypeID", AmountTypeId, OracleType.Number);
            procedure.AddInputParameter("reportid", CycleReportID, OracleType.Number);

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


        public static DataTable DetailsReportWise(int AmountTypeId, Int64 CycleReportID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "generate_detail_report");
            procedure.AddInputParameter("amounttypeID", AmountTypeId, OracleType.Number);
            procedure.AddInputParameter("reportid", CycleReportID, OracleType.Number);

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





        public static DataTable AdHocDetailReport(Int32 reportId, Int32 cycleId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GET_AdHocDetailReport");
            procedure.AddInputParameter("pReport_id", reportId, OracleType.Number);
            procedure.AddInputParameter("pCycle_id", cycleId, OracleType.Number);

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


        public static DataTable AdHocSummaryDetailReport(Int32 reportId, DateTime startCycle, DateTime endCycle)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "AdHocSummaryDetailReport");
            procedure.AddInputParameter("pReportId", reportId, OracleType.Number);
            procedure.AddInputParameter("pStart_Report_Date", startCycle, OracleType.DateTime);
            procedure.AddInputParameter("pEnd_Report_Date", endCycle, OracleType.DateTime);

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



        public static DataTable DetailsProvisionReport(int AmountTypeId, Int64 CycleReportID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "DETAIL_Provision_REPORT");
            procedure.AddInputParameter("amounttypeID", AmountTypeId, OracleType.Number);
            procedure.AddInputParameter("reportid", CycleReportID, OracleType.Number);

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
