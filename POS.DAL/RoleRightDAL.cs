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
    public class DAL_ROLERIGHT
    {
        public static List<RoleRight> GetItemList(int ROLEID, int RIGHTID,int USERID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "GET_ROLERIGHT");
            procedure.AddInputParameter("p_ROLEID", ROLEID, OracleType.Number);
            procedure.AddInputParameter("p_RIGHTID", RIGHTID, OracleType.Number);
            procedure.AddInputParameter("p_USERID", USERID, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<RoleRight> results = new List<RoleRight>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new RoleRight(dr));
                }

                return results;


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public static int SaveItem(RoleRight objoleRight, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "SAVE_ROLERIGHT");
            procedure.AddInputParameter("p_ROLEID", objoleRight.ROLEID, OracleType.Number);
            procedure.AddInputParameter("p_RIGHTID", objoleRight.RIGHTID, OracleType.Number);
            procedure.AddInputParameter("p_UPDATEBY", objoleRight.UPDATEBY, OracleType.VarChar);
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
