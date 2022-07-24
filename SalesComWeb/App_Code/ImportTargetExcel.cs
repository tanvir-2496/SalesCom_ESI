using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ImportTargetExcel
/// </summary>
public class ImportTargetExcel
{
	public ImportTargetExcel()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public static List<ViewChannelEnt> GetImportTargetData(int startrows, int pagesize)
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


    public int TotalNumberOfImportData()
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