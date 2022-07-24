using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;

namespace SalesCom.DAL
{
    public class PendingApprovalSummaryViewDAL
    {

        public static List<PendingApprovalSummaryViewEnt> GetItemList(int CycleId)
        {
            //GET_PendingApprovalSummaryView
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GET_PendingApprovalSummary");
            procedure.AddInputParameter("pReportCycleId", CycleId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<PendingApprovalSummaryViewEnt> results = new List<PendingApprovalSummaryViewEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new PendingApprovalSummaryViewEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }



        public static List<PendingApprovalSummaryViewEnt> GetProvisionSummaryView(int CycleId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GET_PROVISIONSUMMARYVIEW");
            procedure.AddInputParameter("pCYCLEREPORTID", CycleId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<PendingApprovalSummaryViewEnt> results = new List<PendingApprovalSummaryViewEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new PendingApprovalSummaryViewEnt(dr));
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
