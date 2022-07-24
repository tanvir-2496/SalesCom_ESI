using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using SalesCom.DAL;
using SalesCom.Entity;
using System.Data.OracleClient;

public class ChannelWithdrawal
{

    public static List<ChannelWithdrawalEnt> GetStoreChannelWithdrawal(int startrows, int pagesize, Int32 ReportId)
    {
         List<ChannelWithdrawalEnt> results = new List<ChannelWithdrawalEnt>();

        if (ReportId > 0)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_StoreChannelWithdrawal");
            procedure.AddInputParameter("pStartRows", startrows, OracleType.Number);
            procedure.AddInputParameter("pPageSize", pagesize, OracleType.Number);
            procedure.AddInputParameter("pReportId", ReportId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                results = new List<ChannelWithdrawalEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ChannelWithdrawalEnt(dr));
                }
               
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        else
        {
            results = new List<ChannelWithdrawalEnt>();
        }

        return results;
    }


    public int TotalChannelWithdrawal(Int32 ReportId)
    {
        int result = 0;

        if (ReportId > 0)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "TotalChannelWithdrawal");
            procedure.AddInputParameter("pReportId", ReportId, OracleType.Number);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<int> results = new List<int>();

                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(Convert.ToInt32(dr["TotalCount"]));
                }

                if (results.Count > 0)
                {
                    result = results[0];
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        return result;
    }

}