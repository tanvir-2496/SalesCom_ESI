using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OracleClient;
using SalesCom.DAL;

namespace ESI.DAL
{
    public static class ESI_ExcelToDataBaseDAL
    {
        public static List<ErrorMessageEnt> UploadTarget(DataTable data, int groupId, int sales_channel_id, int year, int quarter, int month, int kpi_id, int targetType, int imported_by, string imported_by_name, int reportCycleId,int KPI_CONFIG_ID,int condition_id)
        {
            List<ErrorMessageEnt> errorMessage = new List<ErrorMessageEnt>();
            int excelRowNumber = 1;
            OracleTransaction oracleTransaction;
            int rowAffected = 0;
            try
            {
                using (OracleConnection connection = new OracleConnection(Connection.ConnectionString))
                {
                    OracleCommand command = new OracleCommand();
                    command.CommandText = "DELETE FROM ESITARGETCONFIG_TMP";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    oracleTransaction = connection.BeginTransaction();
                    command.Transaction = oracleTransaction;
                    command.ExecuteNonQuery();

                    foreach (DataRow row in data.Rows)
                    {
                        if (!String.IsNullOrEmpty(row[0].ToString().Trim()))
                        {
                            command.CommandText = String.Format(@"INSERT INTO ESITARGETCONFIG_TMP (TARGET_CONFIG_ID, SALES_CHANNEL_ID, YEAR, QUARTER, MONTH, KPI_ID, CHANNEL_ID, TARGET_VALUE, IMPORTED_BY,IMPORTED_DATE,REPORT_CYCLE_ID,KPI_CONFIG_ID, TARGET_TYPE,CONDITION_ID) VALUES (ESITARGETCONFIG_TMP_SEQ.Nextval, {0}, {1}, {2}, {3}, {4}, '{5}', {6}, {7}, '{8}',{9},{10}, {11},{12})", sales_channel_id, year, quarter, month, kpi_id, row[0].ToString(), row[1], imported_by, System.DateTime.Now.ToString("dd-MMM-yyyy"), reportCycleId, KPI_CONFIG_ID, targetType, condition_id);
                            rowAffected += command.ExecuteNonQuery();
                        }
                    }

                    command.CommandText = "ESI_SYSNCHTARGETLOG";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();

                    command.CommandText = "ESI_DELETEKPITARGET";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("pImportedBy", OracleType.Number).Value = imported_by;
                    command.Parameters.Add("pConditionId", OracleType.Number).Value = condition_id;
                    command.ExecuteNonQuery();

                    command.CommandText = "ESI_SYSNCHKPITARGET";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("pImportedBy", OracleType.Number);
                    command.Parameters.Add("pConditionId", OracleType.Number);
                    command.Parameters.Add("pGroupId", OracleType.Number).Value = groupId;
                    command.ExecuteNonQuery();

                    command.CommandText = "select TARGET_CONFIG_ID, ERRORTEXT from ESITARGETCONFIG_TMP WHERE ERRORTEXT like '%DO NOT FOUND%'";
                    command.CommandType = CommandType.Text;
                    command.Parameters.Clear();

                    IDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        errorMessage.Add(new ErrorMessageEnt { RowNumber = Convert.ToInt32(reader["TARGET_CONFIG_ID"]), ErrorText = reader["ERRORTEXT"] as String, RowCount = rowAffected });
                    }

                    if (errorMessage.Count == 0)
                    {
                        int approvalStsId = getApprovalStatusId(reportCycleId, kpi_id, "Target");

                        ESI_ReportApprovalDAL.TargetReUploadAct(approvalStsId, "", imported_by, imported_by_name);

                        oracleTransaction.Commit();
                    }
                    else 
                    {
                        oracleTransaction.Rollback();
                    }
                    //oracleTransaction.Commit();
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message + " at line " + excelRowNumber.ToString());
            }

            return errorMessage;
        }

        public static int getApprovalStatusId(int reportCycleID, int kpi_id, string approvalName)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETAPPROVALFLOW");
            procedure.AddInputParameter("R_REPORT_CYCLE_ID", reportCycleID, OracleType.Number);
            procedure.AddInputParameter("R_KPIID", kpi_id, OracleType.Number);
            procedure.AddInputParameter("R_APPROVALNAME", approvalName, OracleType.VarChar);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();

                return Convert.ToInt32(dt.Rows[0]["approval_status_id"]);
               
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            
        }



    }
}
