using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class LevelUser20DAL
    {
        public static List<LevelUser20Ent> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_LevelUser");
            procedure.AddInputParameter("pLEVELUSERID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<LevelUser20Ent> results = new List<LevelUser20Ent>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new LevelUser20Ent(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public static List<UserInfo20Ent> GetUserInfoList(int Id, string Username)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GET_UserInfo");
            procedure.AddInputParameter("pUSERID", Id, OracleType.Number);
            procedure.AddInputParameter("pUserName", Username, OracleType.VarChar);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<UserInfo20Ent> results = new List<UserInfo20Ent>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new UserInfo20Ent(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public static List<UserInfoForView20> GetUserInfoForView(int Id, int approvalFlowId, int approvalLevelId, string UserName)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GET_UserInfoForView");
            procedure.AddInputParameter("pLEVELUSERID", Id, OracleType.Number);
            procedure.AddInputParameter("pAPPROVALFLOWID", approvalFlowId, OracleType.Number);
            procedure.AddInputParameter("pAPPROVALLEVELID", approvalLevelId, OracleType.Number);
            procedure.AddInputParameter("pUserName", UserName, OracleType.VarChar);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<UserInfoForView20> results = new List<UserInfoForView20>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new UserInfoForView20(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public static int SaveItem(LevelUser20Ent obj, string strMode, int currentUser)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "addLevelUser");
            procedure.AddInputParameter("pLEVELUSERID", obj.LevelUserId, OracleType.Number);
            procedure.AddInputParameter("pUSERID", obj.UserId, OracleType.Number);
            procedure.AddInputParameter("pAPPROVALLEVELID", obj.ApprovalLevelId, OracleType.Number);
            procedure.AddInputParameter("pMobile", obj.Mobile, OracleType.VarChar);
            procedure.AddInputParameter("pEmail", obj.Email, OracleType.VarChar);
            procedure.AddInputParameter("pLoginName", obj.LoginName, OracleType.VarChar);
            procedure.AddInputParameter("pFullName", obj.FullName, OracleType.VarChar);
            procedure.AddInputParameter("p_Str_Mode", strMode, OracleType.VarChar);
            procedure.AddInputParameter("p_Current_User", currentUser, OracleType.Number);

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


        public static int DelteItem(int levelUserId,int userId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "deleteLevelUser");
            procedure.AddInputParameter("plevelUserId",levelUserId, OracleType.Number);
            procedure.AddInputParameter("PUSERID", userId, OracleType.Number);

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
