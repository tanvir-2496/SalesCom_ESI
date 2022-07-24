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
    public class DAL_ROLEGROUP
    {
        public static List<RoleGroup> GetItemList(int ROLEGROUPID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "GET_ROLEGROUP");
            procedure.AddInputParameter("p_ROLEGROUPID", ROLEGROUPID, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<RoleGroup> results = new List<RoleGroup>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new RoleGroup(dr));
                }

                return results;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static int SaveItem(RoleGroup objoleGroup, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "SAVE_ROLEGROUP");
            procedure.AddInputParameter("p_ROLEGROUPID", objoleGroup.ROLEGROUPID, OracleType.Number);
            procedure.AddInputParameter("p_ROLEGROUPNAME", objoleGroup.ROLEGROUPNAME, OracleType.VarChar);
            procedure.AddInputParameter("p_CREATEBYUSER", objoleGroup.CREATEBYUSER, OracleType.VarChar);
            procedure.AddInputParameter("p_LASTUPDATEBY", objoleGroup.LASTUPDATEBY, OracleType.VarChar);
            procedure.AddInputParameter("p_DESCRIPTION", objoleGroup.DESCRIPTION, OracleType.VarChar);
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
