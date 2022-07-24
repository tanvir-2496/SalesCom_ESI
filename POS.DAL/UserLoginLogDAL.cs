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
    public class UserLoginLogDAL
    {
        public static int SaveItem(UserLoginLog userLoginLog, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "SAVE_USERLOGINLOG"); //LOG_USERLOGIN
            procedure.AddInputParameter("p_ID", userLoginLog.ID, OracleType.Number);
            procedure.AddInputParameter("p_LOGINNAME", userLoginLog.LOGINNAME, OracleType.VarChar);
            procedure.AddInputParameter("p_LOGINGTIME", userLoginLog.LOGINGTIME, OracleType.DateTime);
            procedure.AddInputParameter("p_MACHINENAME", userLoginLog.MACHINENAME, OracleType.VarChar);
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
