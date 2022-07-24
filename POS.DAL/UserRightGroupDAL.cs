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
    public class DAL_USERRIGHTGROUP
    {
        public static List<UserRightGroup> GetItemList(int RIGHTGROUPID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "GET_TBLUSERRIGHTGROUP");
            procedure.AddInputParameter("p_RIGHTGROUPID", RIGHTGROUPID, OracleType.Number);
            

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<UserRightGroup> results = new List<UserRightGroup>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new UserRightGroup(dr));
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
