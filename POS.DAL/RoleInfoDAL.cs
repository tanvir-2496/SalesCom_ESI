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
    public class DAL_ROLEINFO
    {
        public static List<RoleInfo> GetItemList(int ROLEID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "GET_ROLEINFO");
            procedure.AddInputParameter("p_ROLEID", ROLEID, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<RoleInfo> results = new List<RoleInfo>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new RoleInfo(dr));
                }

                return results;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static int SaveItem(RoleInfo objoleInfo, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "SAVE_ROLEINFO");
            procedure.AddInputParameter("p_ROLEID", objoleInfo.ROLEID, OracleType.Number);
            procedure.AddInputParameter("p_ROLEGROUPID", objoleInfo.ROLEGROUPID, OracleType.Number);
            procedure.AddInputParameter("p_ROLENAME", objoleInfo.ROLENAME, OracleType.VarChar);
            procedure.AddInputParameter("p_DESCRIPTION", objoleInfo.DESCRIPTION, OracleType.VarChar);
            procedure.AddInputParameter("p_ACTIVEYN", objoleInfo.ACTIVEYN, OracleType.VarChar);
            procedure.AddInputParameter("p_CREATEBYUSER", objoleInfo.CREATEBYUSER, OracleType.VarChar);
            procedure.AddInputParameter("p_LASTUPDATEBY", objoleInfo.LASTUPDATEBY, OracleType.VarChar);
            procedure.AddInputParameter("p_GROUPEMAIL", objoleInfo.GROUPEMAIL, OracleType.VarChar);
            
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
