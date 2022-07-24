using ESI.Entity;
using SalesCom.Entity;
using ESI.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SalesCom.DAL;


namespace ESI.DAL
{
    public class ESI_ManualMappingDAL
    {
        public static List<ManualMappingEnt> GetItemList(int SalesGroupId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETMAPPINGBYGROUPID");
            procedure.AddInputParameter("P_SALES_GROUP_ID", SalesGroupId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ManualMappingEnt> results = new List<ManualMappingEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ManualMappingEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static List<ErrorMessageEnt> UploadManualMapping(DataTable data, int manualmapcnfg_id, int imported_by, int year, int quarter, int month)
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
                    command.CommandText = "DELETE FROM ESIMAPPINGTMP";
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
                            string channel_code = row[0].ToString();
                            string employee_id = row[1].ToString();
                            command.CommandText = String.Format(@"INSERT INTO ESIMAPPINGTMP (mappingtmp_id, channel_code, employee_id, IMPORTED_BY) VALUES (ESIMAPPINGTMP_SEQ.Nextval, '{0}', '{1}', {2})", channel_code, employee_id, imported_by);
                            rowAffected += command.ExecuteNonQuery();
                        }
                    }

                    command.CommandText = "ESI_SYSNCHMAPPINGLOG";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();

                    command.CommandText = "ESI_SYSNCHMAPPINGDDZM";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("pMappingConfig", OracleType.Number).Value = manualmapcnfg_id;
                    command.Parameters.Add("pImportedBy", OracleType.Number).Value = imported_by;
                    command.Parameters.Add("pYear", OracleType.Number).Value = year;
                    command.Parameters.Add("pQuarter", OracleType.Number).Value = quarter;
                    command.Parameters.Add("pMonth", OracleType.Number).Value = month;
                    command.ExecuteNonQuery();

                    command.CommandText = "select mappingtmp_id, errortext from ESIMAPPINGTMP WHERE ERRORTEXT like '%DD NOT FOUND%' OR ERRORTEXT like '%DUPLICATE%'";
                    command.CommandType = CommandType.Text;
                    command.Parameters.Clear();

                    IDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        errorMessage.Add(new ErrorMessageEnt { RowNumber = Convert.ToInt32(reader["mappingtmp_id"]), ErrorText = reader["ERRORTEXT"] as String, RowCount = rowAffected });
                    }

                    if (errorMessage.Count == 0)
                    {
                        oracleTransaction.Commit();
                    }
                    else
                    {
                        oracleTransaction.Rollback();
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message + " at line " + excelRowNumber.ToString());
            }

            return errorMessage;
        }

    }
}
