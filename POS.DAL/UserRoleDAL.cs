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
    public class DAL_USERROLE
    {
        public static List<UserRole> GetItemList(int ROLEID, int USERID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "GET_USERROLES");
            procedure.AddInputParameter("p_ROLEID", ROLEID, OracleType.Number);
            procedure.AddInputParameter("p_USERID", USERID, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<UserRole> results = new List<UserRole>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new UserRole(dr));
                }

                return results;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static int SaveItem(UserRole objserRole, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "SAVE_USERROLES");
            procedure.AddInputParameter("p_USERID", objserRole.USERID, OracleType.Number);
            procedure.AddInputParameter("p_ROLEID", objserRole.ROLEID, OracleType.Number);
            procedure.AddInputParameter("p_LASTUPDATEBY", objserRole.LASTUPDATEBY, OracleType.VarChar);
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
