using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class ReportWiseRedisburseInitiationDAL
    {
        public static List<ClaimMismatchEnt> SaveRedisburseList(DataTable data, int reportCycleId)
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
                        command.CommandText = "SETUP.RedisburseMismatch";
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

        public static string SetRedisburseInitiation(ReportWiseDisburseInitiationEnt rwdi)
        {
            string result = String.Empty;

            try
            {
                using (OracleConnection connection = new OracleConnection(Connection.ConnectionString))
                {
                    OracleCommand command = new OracleCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SETUP.InitiateRedisburse";
                    command.Parameters.Add("pRCycleId", OracleType.Number).Value = rwdi.ReportCycleId;
                    command.Parameters.Add("pDNumber", OracleType.Number).Value = rwdi.CurrentRedisburseNumber;
                    command.Parameters.Add("pRFlow", OracleType.Number).Value = rwdi.RedisburseFlowId;
                    command.Parameters.Add("pOrderId", OracleType.Number).Value = rwdi.CurrentOrderId;
                    command.Parameters.Add("pRName", OracleType.VarChar).Value = rwdi.ReportName;
                    command.Parameters.Add("pRDuration", OracleType.VarChar).Value = rwdi.ReportDuration;
                    command.Parameters.Add("pCWAmount", OracleType.Number).Value = rwdi.CurrentWithheldAmount;
                    command.Parameters.Add("pUserId", OracleType.Number).Value = rwdi.UserId;
                    command.Parameters.Add("pUserName", OracleType.VarChar).Value = rwdi.UserName;
                    command.Parameters.Add("pErrMessage", OracleType.VarChar, 500).Direction = ParameterDirection.Output;
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    result = command.Parameters["pErrMessage"].Value as String;
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
