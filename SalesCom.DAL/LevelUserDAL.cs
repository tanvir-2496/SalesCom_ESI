using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class LevelUserDAL
    {
        public static List<LevelUserEnt> GetItemList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_LevelUser");
            procedure.AddInputParameter("pLEVELUSERID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<LevelUserEnt> results = new List<LevelUserEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new LevelUserEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public static List<UserInfoEnt> GetUserInfoList(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_UserInfo");
            procedure.AddInputParameter("pUSERID", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<UserInfoEnt> results = new List<UserInfoEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new UserInfoEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public static List<UserInfoForView> GetUserInfoForView(int Id, int approvalFlowId, int approvalLevelId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_UserInfoForView");
            procedure.AddInputParameter("pLEVELUSERID", Id, OracleType.Number);
            procedure.AddInputParameter("pAPPROVALFLOWID", approvalFlowId, OracleType.Number);
            procedure.AddInputParameter("pAPPROVALLEVELID", approvalLevelId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<UserInfoForView> results = new List<UserInfoForView>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new UserInfoForView(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public static int SaveItem(LevelUserEnt obj, string strMode)
        {

            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "addLevelUser");
            procedure.AddInputParameter("pLEVELUSERID", obj.LevelUserId, OracleType.Number);
            procedure.AddInputParameter("pUSERID", obj.UserId, OracleType.Number);
            procedure.AddInputParameter("pLEVELCOLLECTIONID", obj.LevelCollectionID, OracleType.Number);
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
