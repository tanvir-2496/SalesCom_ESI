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
    public class DAL_USERINFO
    {
        public static List<UserInfo> GetItemList(int USERID, int USERGROUPID, string LOGINNAME, string USERNAME, string LoggedUser, int CURRENTCENTERID, int STARTROW, int MAXROWS)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "GET_USERINFO");
            procedure.AddInputParameter("p_USERID", USERID, OracleType.Number);
            procedure.AddInputParameter("p_USERGROUPID", USERGROUPID, OracleType.Number);
            procedure.AddInputParameter("p_LOGINNAME", LOGINNAME, OracleType.VarChar);
            procedure.AddInputParameter("p_USERNAME", USERNAME, OracleType.VarChar);
            procedure.AddInputParameter("p_CURRENTCENTERID", CURRENTCENTERID, OracleType.Number);
            procedure.AddInputParameter("p_LOGGEDUSER", LoggedUser, OracleType.VarChar);
            procedure.AddInputParameter("p_STARTROW", STARTROW, OracleType.Number);
            procedure.AddInputParameter("p_MAXROWS", MAXROWS, OracleType.Number);


            //try
            //{
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<UserInfo> results = new List<UserInfo>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new UserInfo(dr));
                }

                return results;


            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}

        }

        public static int GetItemListCount(int USERID, int USERGROUPID, string LOGINNAME, string USERNAME, string LoggedUser, int CURRENTCENTERID)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "GET_USERINFO_COUNT");
            procedure.AddInputParameter("p_USERID", USERID, OracleType.Number);
            procedure.AddInputParameter("p_USERGROUPID", USERGROUPID, OracleType.Number);
            procedure.AddInputParameter("p_LOGINNAME", LOGINNAME, OracleType.VarChar);
            procedure.AddInputParameter("p_USERNAME", USERNAME, OracleType.VarChar);
            procedure.AddInputParameter("p_CURRENTCENTERID", CURRENTCENTERID, OracleType.Number);
            procedure.AddInputParameter("p_LOGGEDUSER", LoggedUser, OracleType.VarChar);



            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();


                return Convert.ToInt32(dt.Rows[0][0]);


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static int SaveItem(UserInfo objserInfo, string strMode)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "SAVE_USERINFO");
            procedure.AddInputParameter("p_USERID", objserInfo.USERID, OracleType.Number);
            procedure.AddInputParameter("p_USERNAME", objserInfo.USERNAME, OracleType.VarChar);
            procedure.AddInputParameter("p_DESCRIPTION", objserInfo.DESCRIPTION, OracleType.VarChar);
            procedure.AddInputParameter("p_DEPARTMENT", objserInfo.DEPARTMENT, OracleType.VarChar);
            procedure.AddInputParameter("p_PASSWORD", objserInfo.PASSWORD, OracleType.VarChar);
            procedure.AddInputParameter("p_USERGROUPID", objserInfo.USERGROUPID, OracleType.Number);
            procedure.AddInputParameter("p_USERSTATUS", objserInfo.USERSTATUS, OracleType.VarChar);
            procedure.AddInputParameter("p_EMAILADDR", objserInfo.EMAILADDR, OracleType.VarChar);
            procedure.AddInputParameter("p_MOBILENO", objserInfo.MOBILENO, OracleType.VarChar);
            procedure.AddInputParameter("p_PASSWORDNEVEXP", objserInfo.PASSWORDNEVEXP, OracleType.VarChar);
            procedure.AddInputParameter("p_USERCHANGEDPASSYN", objserInfo.USERCHANGEDPASSYN, OracleType.VarChar);
            procedure.AddInputParameter("p_CREATEBYUSER", objserInfo.CREATEBYUSER, OracleType.VarChar);
            procedure.AddInputParameter("p_LASTUPDATEBY", objserInfo.LASTUPDATEBY, OracleType.VarChar);
            procedure.AddInputParameter("p_LOGINNAME", objserInfo.LOGINNAME, OracleType.VarChar);

            procedure.AddInputParameter("p_PASSWORDCHANGEDDATE", objserInfo.PASSWORDCHANGEDDATE, OracleType.DateTime);
            procedure.AddInputParameter("p_CURRENTCENTERID", objserInfo.CURRENTCENTERID, OracleType.Number);


            procedure.AddInputParameter("p_CURRENTTELLERID", objserInfo.CURRENTTELLERID, OracleType.Number);
            procedure.AddInputParameter("p_PASSWORDCHANGEDBY", objserInfo.PASSWORDCHANGEDBY, OracleType.VarChar);
            procedure.AddInputParameter("p_SMSPASSWORD", objserInfo.SMSPASSWORD, OracleType.VarChar);

            procedure.AddInputParameter("p_DISTRIBUTOR", objserInfo.DISTRIBUTOR, OracleType.Number);
            procedure.AddInputParameter("p_USERTYPE", objserInfo.USERTYPE, OracleType.Number);
            procedure.AddInputParameter("p_DOMAIN", objserInfo.DOMAIN, OracleType.VarChar);


            procedure.AddInputParameter("p_USERLOCKED", objserInfo.Islocked, OracleType.VarChar);

            procedure.AddInputParameter("p_IsInternal", objserInfo.IsInternal, OracleType.VarChar);

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

        public static int SavePassword(UserInfo objserInfo)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaPOS(), "SAVE_USERPASSWORD");
            procedure.AddInputParameter("p_USERID", objserInfo.USERID, OracleType.Number);
            procedure.AddInputParameter("p_PASSWORD", objserInfo.PASSWORD, OracleType.VarChar);
            procedure.AddInputParameter("p_PASSWORDCHANGEDBY", objserInfo.PASSWORDCHANGEDBY, OracleType.VarChar);

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
