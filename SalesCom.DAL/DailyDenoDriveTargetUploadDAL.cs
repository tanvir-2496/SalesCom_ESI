using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SalesCom.DAL;
using Oracle.ManagedDataAccess.Client;

namespace SalesCom.DAL
{
    public class DailyDenoDriveTargetUploadDAL
    {
        public static string ImportDatatoDatabaseTabel(DataTable dt, int campaignId,int imported_by)
        {
            try
            {
                logInsert(campaignId, "Delete target temp table", "Start", imported_by);
                DeleteTempTable();
                logInsert(campaignId, "Target bulk copy", "Start", imported_by);
                SaveUsingOracleBulkCopy("DAILY_DENO_CAM_TARGET_TEMP", dt);
                logInsert(campaignId, "Campain target process", "Excel validation start", imported_by);
                string message=TargetValidateAndProcess(campaignId,imported_by);
                string[] mesArray = message.Split(',');
                if (mesArray[0] == "Successful")
                {
                    return string.Format("Total {0} rows inserted", mesArray[1]);
                }
                else 
                {
                    return message;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
                        
        }  

        public static void SaveUsingOracleBulkCopy(string destTableName, DataTable dt)
        {
            try
            {
                using (var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(Connection.ConnectionString))
                {
                    connection.Open();
                    using (var bulkCopy = new OracleBulkCopy(connection, OracleBulkCopyOptions.UseInternalTransaction))
                    {
                        bulkCopy.DestinationTableName = destTableName;
                        bulkCopy.BulkCopyTimeout = 600;
                        bulkCopy.WriteToServer(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteTempTable()
        {
            try
            {
                using (System.Data.OracleClient.OracleConnection connection = new System.Data.OracleClient.OracleConnection(Connection.ConnectionString))
                {
                    System.Data.OracleClient.OracleCommand command = new System.Data.OracleClient.OracleCommand();
                    command.CommandText = "DELETE FROM DAILY_DENO_CAM_TARGET_TEMP";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static string TargetValidateAndProcess(int campaign_id, int imported_by)
        {
            try
            {
                using (System.Data.OracleClient.OracleConnection connection = new System.Data.OracleClient.OracleConnection(Connection.ConnectionString))
                {
                    System.Data.OracleClient.OracleCommand command = new System.Data.OracleClient.OracleCommand();
                    command.Connection = connection;
                    connection.Open();

                    command.CommandText = "VALIDATE_EXCEL_DATE";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("pCAMPAIGN_ID", OracleType.Number).Value = campaign_id;
                    command.Parameters.Add("pUSER_ID", OracleType.Number).Value = imported_by;
                    command.Parameters.Add("poERRORMESSAGE", OracleType.VarChar,10000).Direction = ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    return command.Parameters["poERRORMESSAGE"].Value.ToString();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static int logInsert(int campaignId,string actionName,string remarks,int createBy)
        {
            try
            {
                OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "DAILY_DENO_CAM_LOG_INSERT");
                procedure.AddInputParameter("PCAMPAIGN_ID", campaignId, OracleType.Number);
                procedure.AddInputParameter("pActionName", actionName, OracleType.VarChar);
                procedure.AddInputParameter("pRemarks", remarks, OracleType.VarChar);
                procedure.AddInputParameter("pCreateBy", createBy, OracleType.Number);

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

            catch (Exception ex)
            {
                throw ex;
            }

        }
       
    }
}
