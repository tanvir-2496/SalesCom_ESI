using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class InitiateClaimDAL
    {
        public static List<InitiateClaimEnt> GetItemList(Int32 commissionCycleId)
        {
            //GET_ReportView changed for new approval process implementation GET_DataForClaim
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GET_DataForClaim_Stg");
            procedure.AddInputParameter("pCommissionCycleId", commissionCycleId, System.Data.OracleClient.OracleType.Number);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<InitiateClaimEnt> results = new List<InitiateClaimEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new InitiateClaimEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static List<ClaimMismatchEnt> SaveDiscardList(DataTable data, int reportCycleId)
        {
            List<ClaimMismatchEnt> claimMismatch = new List<ClaimMismatchEnt>();
            int rowAffected = 0;
            int excelRowNumber = 1;

            try
            {
                using (OracleConnection connection = new OracleConnection(Connection.ConnectionString))
                {
                    OracleCommand command = new OracleCommand();
                    command.CommandText = "truncate table claim_discard_list";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();

                    foreach (DataRow row in data.Rows)
                    {
                        if (!String.IsNullOrEmpty(row[0].ToString().Trim()))
                        {
                            command.CommandText = String.Format("insert into claim_discard_list (channel_code, discard_amount, comments) values ('{0}', {1}, '{2}')", row[0].ToString(), row[1].ToString(), row[2].ToString());
                            rowAffected += command.ExecuteNonQuery();
                        }

                        excelRowNumber++;
                    }

                    if (rowAffected == data.Rows.Count)
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "SETUP.GetMismatchClaim";
                        command.Parameters.Add("pReportCycleId", OracleType.Number).Value = reportCycleId;
                        command.Parameters.Add("pErrorMessage", OracleType.VarChar, 100).Direction = ParameterDirection.Output;
                        command.Parameters.Add("pCursor", OracleType.Cursor).Direction = ParameterDirection.Output;

                        IDataReader dr = command.ExecuteReader();

                        if (command.Parameters["pErrorMessage"].Value as String == "SUCCESSFUL")
                        {
                            while (dr.Read())
                            {
                                claimMismatch.Add(new ClaimMismatchEnt { channel_code = dr["channel_code"] as string, status = dr["status"] as String });
                            }
                        }
                    }


                    connection.Dispose();
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message + " at line " + excelRowNumber.ToString());
            }

            return claimMismatch;
        }

        public static string InsertDiscardData(int reportCycleId, string reportName, int reportTypeId, int reportFlow, string reportDuration, decimal totalCommission, decimal totalClaim, int userId, string userName, string hasClaimInput)
        {
            string result = String.Empty;

            try
            {
                using (OracleConnection connection = new OracleConnection(Connection.ConnectionString))
                {
                    OracleCommand command = new OracleCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SETUP.InsertDiscardData";
                    command.Parameters.Add("pReportCycleId", OracleType.Number).Value = reportCycleId;
                    command.Parameters.Add("pReportFlow", OracleType.Number).Value = reportFlow;
                    command.Parameters.Add("pReportName", OracleType.VarChar).Value = reportName;
                    command.Parameters.Add("pReportTypeId", OracleType.Number).Value = reportTypeId;
                    command.Parameters.Add("pReportDuration", OracleType.VarChar).Value = reportDuration;
                    command.Parameters.Add("pCommission", OracleType.Number).Value = totalCommission;
                    command.Parameters.Add("pClaim", OracleType.Number).Value = totalClaim;
                    command.Parameters.Add("pUserId", OracleType.Number).Value = userId;
                    command.Parameters.Add("pUserName", OracleType.VarChar).Value = userName;
                    command.Parameters.Add("pHasClaimInput", OracleType.VarChar).Value = hasClaimInput;
                    command.Parameters.Add("pErrorMessage", OracleType.VarChar, 500).Direction = ParameterDirection.Output;
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    result = command.Parameters["pErrorMessage"].Value as String;
                    connection.Dispose();
                }
            }

            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        public static DataTable Get_Claim_Detail_Report(int pReportCycleId, int pReportId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GENERATE_CLAIM_DETAIL");
            procedure.AddInputParameter("pReportCycleId", pReportCycleId, OracleType.Number);
            procedure.AddInputParameter("pReportId", pReportId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                return dt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }

}
