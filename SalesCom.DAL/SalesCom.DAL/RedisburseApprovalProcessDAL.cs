using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class RedisburseApprovalProcessDAL
    {
        public static List<RedisburseApprovalProcessEnt> GetItemList(Int32 userId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_RedisbursePendingList");
            procedure.AddInputParameter("pUser_Id", userId, System.Data.OracleClient.OracleType.Number);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<RedisburseApprovalProcessEnt> results = new List<RedisburseApprovalProcessEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new RedisburseApprovalProcessEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public static List<ApprovalHistory> GetRedisburseApprovalHistory(int Id)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GetRedisburseAppHis");
            procedure.AddInputParameter("pId", Id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ApprovalHistory> results = new List<ApprovalHistory>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ApprovalHistory(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}
