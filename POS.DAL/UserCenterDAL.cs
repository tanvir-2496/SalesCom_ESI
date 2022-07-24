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
    public class DAL_USERCENTER
    {
        public static List<UserCenter> GetItemList(int CENTERID, int USERID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "GET_USERCENTER");
            procedure.AddInputParameter("p_CENTERID", CENTERID, OracleType.Number);
            procedure.AddInputParameter("p_USERID", USERID, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<UserCenter> results = new List<UserCenter>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new UserCenter(dr));
                }

                return results;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static int SaveItem(UserCenter objserCenter, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "SAVE_USERCENTER");
            procedure.AddInputParameter("p_ENGAGEID", objserCenter.ENGAGEID, OracleType.Number);
            procedure.AddInputParameter("p_CENTERID", objserCenter.CENTERID, OracleType.Number);
            procedure.AddInputParameter("p_USERID", objserCenter.USERID, OracleType.Number);
            procedure.AddInputParameter("p_CREATEBYUSER", objserCenter.CREATEBYUSER, OracleType.VarChar);
            procedure.AddInputParameter("p_UPDATEBY", objserCenter.UPDATEBY, OracleType.VarChar);
            procedure.AddInputParameter("p_Str_Mode", strMode, OracleType.VarChar);

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