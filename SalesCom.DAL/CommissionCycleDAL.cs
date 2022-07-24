using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class CommissionCycleDAL
    {
        public static List<CommissionCycleEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GetCommissionCycle");
            procedure.AddInputParameter("pCommissionCycleId", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<CommissionCycleEnt> results = new List<CommissionCycleEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new CommissionCycleEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public static List<CommissionCycleEnt> GetCommissionCycle(int Id, int periodTypeId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GETCOMMISSIONCYCLEBYPeriod");
            procedure.AddInputParameter("pCommissionCycleId", Id, OracleType.Number);
            procedure.AddInputParameter("pPeriodTypeId", periodTypeId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<CommissionCycleEnt> results = new List<CommissionCycleEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new CommissionCycleEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static List<ReportCycleEnt> GetCommissionCycleByYear(int periodTypeId, int year)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GetCommissionCycleByYear");
            procedure.AddInputParameter("pPeriodTypeId", periodTypeId, OracleType.Number);
            procedure.AddInputParameter("pYear", year, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ReportCycleEnt> results = new List<ReportCycleEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ReportCycleEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static List<ReportCycleEnt> GetCommissionCycleByReport(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GetCommissionCycleByReport");
            procedure.AddInputParameter("pReportId", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ReportCycleEnt> results = new List<ReportCycleEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ReportCycleEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public static int SaveItem(CommissionCycle2 obj, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "AddCommissionCycle");
            procedure.AddInputParameter("PCYCLEID", obj.CycleId, OracleType.Number);
            procedure.AddInputParameter("PCYCLEDESCRIPTION", obj.CycleDescription, OracleType.VarChar);
            procedure.AddInputParameter("PPERIODSTARTDATE", obj.PeriodStartDate, OracleType.DateTime);
            procedure.AddInputParameter("PPERIODENDDATE", obj.PeriodEndDate, OracleType.DateTime);
            procedure.AddInputParameter("PCYCLESTATUSID", obj.CycleStatusId, OracleType.Number);

            procedure.AddInputParameter("pCreateBy", obj.CreateBy, OracleType.Number);
            procedure.AddInputParameter("pUpdateBy", obj.UpdateBy, OracleType.Number);

            procedure.AddInputParameter("pstrmode", strMode, OracleType.VarChar);

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
