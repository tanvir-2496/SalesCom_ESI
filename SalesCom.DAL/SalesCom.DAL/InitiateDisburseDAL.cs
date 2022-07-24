using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class InitiateDisburseDAL
    {
        public static List<InitiateDisburseEnt> GetItemList(Int32 commissionCycleId)
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup_2(), "GET_DataForDisburse");
            procedure.AddInputParameter("pCommissionCycleId", commissionCycleId, System.Data.OracleClient.OracleType.Number);
            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<InitiateDisburseEnt> results = new List<InitiateDisburseEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new InitiateDisburseEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static List<ClaimMismatchEnt> SaveWithheldList(DataTable data, int reportCycleId)
        {
            List<ClaimMismatchEnt> claimMismatch = new List<ClaimMismatchEnt>();
            int rowAffected = 0;
            int excelRowNumber = 1;

            try
            {
                using (OracleConnection connection = new OracleConnection(Connection.ConnectionString))
                {
                    OracleCommand command = new OracleCommand();
                    command.CommandText = "truncate table withheld_list";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();

                    foreach (DataRow row in data.Rows)
                    {
                        if (!String.IsNullOrEmpty(row[0].ToString().Trim()))
                        {
                            command.CommandText = String.Format("insert into withheld_list (channel_code, comments) values ('{0}', '{1}')", row[0].ToString(), row[1].ToString());
                            rowAffected += command.ExecuteNonQuery();
                        }

                        excelRowNumber++;
                    }

                    if (rowAffected == data.Rows.Count)
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "SETUP.GetMismatchWithheld";
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

        public static string SetWithheldList(int reportCycleId, string reportName, int reportFlow, string reportDuration, string claimAmount, int userId, string userName, string hasWithhaldList)
        {
            string result = String.Empty;

            try
            {
                using (OracleConnection connection = new OracleConnection(Connection.ConnectionString))
                {
                    OracleCommand command = new OracleCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SETUP.SetWithheldList";
                    command.Parameters.Add("pReportCycleId", OracleType.Number).Value = reportCycleId;
                    command.Parameters.Add("pReportFlow", OracleType.Number).Value = reportFlow;
                    command.Parameters.Add("pReportName", OracleType.VarChar).Value = reportName;
                    command.Parameters.Add("pReportDuration", OracleType.VarChar).Value = reportDuration;
                    command.Parameters.Add("pUserId", OracleType.Number).Value = userId;
                    command.Parameters.Add("pClaimAmount", OracleType.VarChar).Value = claimAmount;
                    command.Parameters.Add("pUserName", OracleType.VarChar).Value = userName;
                    command.Parameters.Add("pHasWithhaldList", OracleType.VarChar).Value = hasWithhaldList; 
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

    }
}
