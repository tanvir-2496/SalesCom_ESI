using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using SalesCom.DAL;
using SalesCom.Entity;
using System.Data.OracleClient;

public class Channel
{

    public static List<ViewChannelEnt> GetStoreChannel(int startrows, int pagesize)
    {
        OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "Get_StoreChannel");
        procedure.AddInputParameter("pStartRows", startrows, OracleType.Number);
        procedure.AddInputParameter("pPageSize", pagesize, OracleType.Number);

        try
        {
            DataTable dt = procedure.ExecuteQueryToDataTable();
            List<ViewChannelEnt> results = new List<ViewChannelEnt>();
            foreach (DataRow dr in dt.Rows)
            {
                results.Add(new ViewChannelEnt(dr));
            }

            return results;
        }
        catch (Exception ex)
        {
            throw (ex);
        }

    }


    public int TotalNumberOfChannel()
    {
        int result = 0;
        OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "TotalNumberOfChannel");

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

        return result;
    }

}