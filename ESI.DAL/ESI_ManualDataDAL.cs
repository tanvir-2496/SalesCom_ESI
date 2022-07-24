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
    public class ESI_ManualDataDAL
    {
        public static List<ManualDataEnt> GetItemList(int SalesGroupId)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETMDATAGBYGROUPID");
            procedure.AddInputParameter("P_SALES_GROUP_ID", SalesGroupId, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<ManualDataEnt> results = new List<ManualDataEnt>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new ManualDataEnt(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static List<ErrorMessageEnt> UploadManualData(DataTable data, int eRowNum, int year, int quarter, int month, int manualdatacnfg_id, int imported_by, string imported_by_name, string FileType,byte[] srcontent)
        {
            List<ErrorMessageEnt> errorMessage = new List<ErrorMessageEnt>();
            int excelRowNumber = 1;
            OracleTransaction oracleTransaction;
            int rowAffected = 0;
            int returnValue = 0;
            try
            {
                using (OracleConnection connection = new OracleConnection(Connection.ConnectionString))
                {
                    OracleCommand command = new OracleCommand();
                    
                    command.CommandText = "DELETE FROM ESIMANUALDATA_TMP";
                    command.Connection = connection;

                    command.CommandType = CommandType.Text;
                    connection.Open();
                    oracleTransaction = connection.BeginTransaction();

                    command.Transaction = oracleTransaction;

                    command.ExecuteNonQuery();

                    if (eRowNum == 2)
                    {
                        foreach (DataRow row in data.Rows)
                        {
                            if (!String.IsNullOrEmpty(row[0].ToString().Trim()))
                            {
                                string channel_id = row[0].ToString();
                                double count_data = Convert.ToDouble(row[1]);
                                command.CommandText = String.Format(@"INSERT INTO ESIMANUALDATA_TMP (MANUALDATATMP_ID, MANUALDATACNFG_ID, CHANNEL_ID, COUNT_DATA, IMPORTED_BY, IMPORTED_BY_NAME, YEAR, QUARTER, MONTH) VALUES (ESIMANUALDATA_TMP_SEQ.Nextval, {0}, '{1}', {2}, {3}, '{4}', {5}, {6}, {7})", manualdatacnfg_id, channel_id, count_data, imported_by, imported_by_name, year, quarter, month);
                                
                                rowAffected += command.ExecuteNonQuery();
                                
                            }
                        }
                    }

                    if (eRowNum == 3)
                    {
                        foreach (DataRow row in data.Rows)
                        {
                            if (!String.IsNullOrEmpty(row[0].ToString().Trim()))
                            {
                                string channel_id = row[0].ToString();
                                double count_data = Convert.ToDouble(row[1]);
                                double amount_data = Convert.ToDouble(row[2]);

                                command.CommandText = String.Format(@"INSERT INTO ESIMANUALDATA_TMP (MANUALDATATMP_ID, MANUALDATACNFG_ID, CHANNEL_ID, COUNT_DATA, AMOUNT_DATA, IMPORTED_BY, IMPORTED_BY_NAME, YEAR, QUARTER, MONTH) VALUES (ESIMANUALDATA_TMP_SEQ.Nextval, {0}, '{1}', {2}, {3}, {4}, '{5}', {6}, {7}, {8})", manualdatacnfg_id, channel_id, count_data, amount_data, imported_by, imported_by_name, year, quarter, month);

                                rowAffected += command.ExecuteNonQuery();
                            }
                        }
                    }

                    command.CommandText = "ESI_SYSNCHMANUALDATALOG";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();

                    command.CommandText = "ESI_SYSNCHMANUALDATA";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("pImportedBy", OracleType.Number).Value = imported_by;
                    OracleParameter param = new OracleParameter("po_returnvalue", OracleType.Number);
                    param.Direction = ParameterDirection.Output;
                    command.Parameters.Add(param);
                    command.ExecuteNonQuery();
                    returnValue = Convert.ToInt32((param as OracleParameter).Value);

                    command.CommandText = "select manualdatatmp_id, errortext from esimanualdata_tmp WHERE ERRORTEXT like '%NOT EXIST%'";
                    command.CommandType = CommandType.Text;
                    command.Parameters.Clear();

                    IDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        errorMessage.Add(new ErrorMessageEnt { RowNumber = Convert.ToInt32(reader["manualdatatmp_id"]), ErrorText = reader["ERRORTEXT"] as String, RowCount = rowAffected });
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

                if (returnValue > 0)
                {
                    if (FileType != "" && srcontent != null)
                    {

                        int result = 0;
                        string sqlFinalQuery = String.Empty;

                        sqlFinalQuery = String.Format(@"UPDATE ESIMANUALDATA_HISTORY SET SRCONTENT = :BlobParameter, FTYPE = '{0}' WHERE ESIMANUALDATA_HISTORY_ID = {1}", FileType, returnValue);

                        OracleConnection conn = new OracleConnection(Connection.ConnectionString);
                        conn.Open();
                        OracleTransaction trn = conn.BeginTransaction();
                        OracleCommand commd;
                        OracleParameter param = new OracleParameter();
                        param.OracleType = OracleType.Blob;
                        param.ParameterName = "BlobParameter";
                        param.Value = srcontent;
                        commd = new OracleCommand(sqlFinalQuery, conn);
                        commd.Parameters.Add(param);
                        commd.Transaction = trn;

                        try
                        {
                            result = commd.ExecuteNonQuery();
                            trn.Commit();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            trn.Rollback();
                            throw (ex);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message + " at line " + excelRowNumber.ToString());
            }

            return errorMessage;
        }


        public static int getRowNumber(int manualdatacnfg_id)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GETROWNUMBER");
            procedure.AddInputParameter("P_CONFIG_ID", manualdatacnfg_id, OracleType.Number);

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();

                return Convert.ToInt32(dt.Rows[0]["erownum"]);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static int SaveESIManualDataHeader(int salesGroupId, string kpiHeaderName)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_INSERT_MANUALDATACONFIG");
            procedure.AddInputParameter("pKpiName", kpiHeaderName, OracleType.NVarChar);
            procedure.AddInputParameter("pSalesGroupId", salesGroupId, OracleType.Number);
            try
            {
                procedure.ExecuteNonQuery();
                return procedure.ReturnMessage == "SUCCESSFUL" ? procedure.ErrorCode : procedure.ErrorCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetManualDataHeader(int salesGroupId, string name)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_GET_MANUAL_HEADER");
            procedure.AddInputParameter("pSalesGroupId", salesGroupId, OracleType.Number);
            procedure.AddInputParameter("pHeaderName", name, OracleType.VarChar);

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
        public static int UpdateESIManualDataHeader(int id, int status)
        {
            ESI_OracleProcedure procedure = new ESI_OracleProcedure("ESI_UPDATE_MANUALDATACONFIG");
            procedure.AddInputParameter("pId", id, OracleType.Number);
            procedure.AddInputParameter("pStatus", status, OracleType.Number);
            try
            {
                procedure.ExecuteNonQuery();
                return procedure.ReturnMessage == "SUCCESSFUL" ? procedure.ErrorCode : procedure.ErrorCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
