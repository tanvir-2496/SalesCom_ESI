using System;
using System.Data;
using System.Web;
using System.Configuration;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.IO;
using System.Collections;


namespace POS.DAL
{
    public class DAL_RIGHTINFO
    {
        public static List<RightInfo> GetItemList(int RIGHTID, int RIGHTGROUPID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "GET_TBLRIGHTINFO");
            procedure.AddInputParameter("p_RIGHTID", RIGHTID, OracleType.Number);
            procedure.AddInputParameter("p_RIGHTGROUPID", RIGHTGROUPID, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<RightInfo> results = new List<RightInfo>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new RightInfo(dr));
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
