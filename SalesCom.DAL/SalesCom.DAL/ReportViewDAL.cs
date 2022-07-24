﻿using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace SalesCom.DAL
{
    public class ReportViewDAL
    {

        public static List<ReportViewWithTotal> GetItemList(Int32 commissionCycleId, string reportName)
        {
            //GET_ReportView changed for new approval process implementation 
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GET_CommissionData");
            procedure.AddInputParameter("pCommissionCycleId", commissionCycleId, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pReportName", reportName, System.Data.OracleClient.OracleType.VarChar);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ReportViewWithTotal> results = new List<ReportViewWithTotal>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ReportViewWithTotal(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static List<ReportViewWithMonth> ComReportExecusionProvision(int baseMonth, int publishedId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GET_REPORTVIEWPROVISION");
            procedure.AddInputParameter("pBaseMonth", baseMonth, System.Data.OracleClient.OracleType.Number);
            procedure.AddInputParameter("pPublishId", publishedId, System.Data.OracleClient.OracleType.Number);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ReportViewWithMonth> results = new List<ReportViewWithMonth>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ReportViewWithMonth(dr));
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