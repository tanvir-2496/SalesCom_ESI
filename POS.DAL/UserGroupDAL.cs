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
    public class DAL_USERGROUP
    {
        public static List<UserGroup> GetItemList(int USERGROUPID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "GET_USERGROUP");
            procedure.AddInputParameter("p_USERGROUPID", USERGROUPID, OracleType.Number);
            procedure.AddInputParameter("p_USERID",0, OracleType.Number);
            
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<UserGroup> results = new List<UserGroup>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new UserGroup(dr));
                }

                return results;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static int SaveItem(UserGroup objserGroup, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "SAVE_USERGROUP");
            procedure.AddInputParameter("p_USERGROUPID", objserGroup.USERGROUPID, OracleType.Number);
            procedure.AddInputParameter("p_USERGROUPNAME", objserGroup.USERGROUPNAME, OracleType.VarChar);
            procedure.AddInputParameter("p_DESCRIPTION", objserGroup.DESCRIPTION, OracleType.VarChar);
            procedure.AddInputParameter("p_CREATEBYUSER", objserGroup.CREATEBYUSER, OracleType.VarChar);
            procedure.AddInputParameter("p_LASTUPDATEBY", objserGroup.LASTUPDATEBY, OracleType.VarChar);
            procedure.AddInputParameter("p_Str_Mode", strMode, OracleType.VarChar);
            procedure.AddInputParameter("p_PASSWORDVALIDITY", objserGroup.PASSWORDVALIDITY, OracleType.Number);
            procedure.AddInputParameter("p_PASSWORDWARNINGDAYS", objserGroup.PASSWORDWARNINGDAYS, OracleType.Number);
            
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
