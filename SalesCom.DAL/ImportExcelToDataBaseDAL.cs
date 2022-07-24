using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
    public class ImportExcelToDataBaseDAL
    {
        public List<ErrorMessageEnt> SaveExcelDataToTable(DataTable data, DateTime transactionDate, string importedBy)
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
                    command.CommandText = "DELETE FROM TEMPEXCELTODATABASE";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    oracleTransaction = connection.BeginTransaction();
                    command.Transaction = oracleTransaction;
                    command.ExecuteNonQuery();

                    foreach (DataRow row in data.Rows)
                    {
                        command.CommandText = String.Format("INSERT INTO TEMPEXCELTODATABASE (ID, SIMNO, MSISDN, IMPORTEDBY, IMPORTDATE ) VALUES (TEMPEXCELTODATABASE_ID.Nextval, '{0}', '{1}', '{2}', '{3}')", row[0].ToString(), row[1].ToString(), importedBy, transactionDate.ToString("dd-MMM-yyyy"));
                        rowAffected += command.ExecuteNonQuery();
                    }

                    command.CommandText = "SYNCHRONOUSTEMPDATA";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("pTransactionDate", OracleType.DateTime).Value = transactionDate.ToString("dd-MMM-yyyy");
                    command.Parameters.Add("ImportedBy", OracleType.VarChar).Value = importedBy;
                    command.ExecuteNonQuery();

                    command.CommandText = "select ID, ERRORTEXT, SIMNO, MSISDN from TEMPEXCELTODATABASE WHERE ERRORTEXT = 'DUPLICATE'";
                    command.CommandType = CommandType.Text;
                    command.Parameters.Clear();

                    IDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        errorMessage.Add(new ErrorMessageEnt { RowNumber = Convert.ToInt32(reader["ID"]), ErrorText = reader["ERRORTEXT"] as String, SimNo = reader["SIMNO"] as String, MSISDN = reader["MSISDN"] as String, RowCount = rowAffected });
                    }


                    oracleTransaction.Commit();
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message + " at line " + excelRowNumber.ToString());
            }


            return errorMessage;
        }

        public List<ErrorMessageEnt> SaveCommissionTarget(DataTable data, int reportId, int eventId, string importedBy, int cycleId, int thresholdTypeId)
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
                    command.CommandText = "DELETE FROM COMMISSIONREPORTTARGETS_TEMP";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    oracleTransaction = connection.BeginTransaction();
                    command.Transaction = oracleTransaction;
                    command.ExecuteNonQuery();

                    if (thresholdTypeId == 1)
                    {
                        foreach (DataRow row in data.Rows)
                        {
                            if (!String.IsNullOrEmpty(row[0].ToString().Trim()))
                            {
                                command.CommandText = String.Format("INSERT INTO COMMISSIONREPORTTARGETS_TEMP (ID, REPORTID, CHANNELID, EVENTTYPEID, TARGETVALUE, IMPORTEDBY, IMPORTDATE, CYCLEID) VALUES (COMMISSIONTARGETS_TEMP_ID.Nextval, '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", reportId, row[0].ToString(), eventId, row[1].ToString(), importedBy, System.DateTime.Now.ToString("dd-MMM-yyyy"), cycleId);
                                rowAffected += command.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        foreach (DataRow row in data.Rows)
                        {
                            if (!String.IsNullOrEmpty(row[0].ToString().Trim()))
                            {
                                command.CommandText = String.Format("INSERT INTO COMMISSIONREPORTTARGETS_TEMP (ID, REPORTID, CHANNELID, EVENTTYPEID, TARGETVALUE, IMPORTEDBY, IMPORTDATE, CYCLEID, THRESHOLDTYPEID, THRESHOLD) VALUES (COMMISSIONTARGETS_TEMP_ID.Nextval, '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', {7}, '{8}')", reportId, row[0].ToString(), eventId, row[1].ToString(), importedBy, System.DateTime.Now.ToString("dd-MMM-yyyy"), cycleId, thresholdTypeId, row[2].ToString());
                                rowAffected += command.ExecuteNonQuery();
                            }
                        }
                    }

                    command.CommandText = "SysnchCommissionTarget";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("pREPORTID", OracleType.Number).Value = reportId;
                    command.Parameters.Add("pCYCLEID", OracleType.VarChar).Value = cycleId;
                    command.Parameters.Add("pImportedBy", OracleType.VarChar).Value = importedBy;

                    command.ExecuteNonQuery();

                    command.CommandText = "select ID, ERRORTEXT from COMMISSIONREPORTTARGETS_TEMP WHERE ERRORTEXT like '%DUP%'";
                    command.CommandType = CommandType.Text;
                    command.Parameters.Clear();

                    IDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        errorMessage.Add(new ErrorMessageEnt { RowNumber = Convert.ToInt32(reader["ID"]), ErrorText = reader["ERRORTEXT"] as String, RowCount = rowAffected });
                    }

                    oracleTransaction.Commit();
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message + " at line " + excelRowNumber.ToString());
            }

            return errorMessage;
        }

        public bool SaveChannelWithdrawal(DataTable data, int reportId, string importedBy, string refNumber, string comCriterion, string modeOfPayment, Int32 cycleId, string hasWithdrawalList, ref bool isDuplicate, Int32 claimId)
        {
            List<ErrorMessageEnt> errorMessage = new List<ErrorMessageEnt>();
            int excelRowNumber = 1;
            OracleTransaction oracleTransaction;
            int rowAffected = 0;
            try
            {
                using (OracleConnection connection = new OracleConnection(Connection.ConnectionString))
                {
                    int OutClaimId = 0;
                    OracleCommand command = new OracleCommand();

                    command.CommandText = "DELETE FROM CHANNELWITHDRAWAL_TEMP";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    oracleTransaction = connection.BeginTransaction();
                    command.Transaction = oracleTransaction;
                    command.ExecuteNonQuery();

                    if (claimId >= 1)
                    {
                        command.CommandText = String.Format("UPDATE COMMISSIONCLAIM SET REFERENCENUMBER = '{0}',COMMISSIONCRITERION='{1}', MODEOFPAYMENT='{2}', HasWithdrawalList = '{3}' WHERE CLAIMID= {4}", refNumber, comCriterion, modeOfPayment, hasWithdrawalList, claimId);
                        command.ExecuteNonQuery();
                        OutClaimId = claimId;
                    }
                    else
                    {
                        command.CommandText = String.Format("INSERT INTO COMMISSIONCLAIM ( CLAIMID,REPORTID,REFERENCENUMBER,COMMISSIONCRITERION,CycleId,MODEOFPAYMENT, HasWithdrawalList ) VALUES (   COMMISSIONCLAIM_SEQ.NEXTVAL, {0},'{1}','{2}',{3},'{4}', '{5}' ) returning CLAIMID into :pClaimId", reportId, refNumber, comCriterion, cycleId, modeOfPayment, hasWithdrawalList);
                        OracleParameter param = new OracleParameter("pClaimId", OracleType.Number);
                        param.Direction = ParameterDirection.ReturnValue;
                        command.Parameters.Add(param);
                        command.ExecuteNonQuery();
                        int.TryParse(command.Parameters["pClaimId"].Value.ToString(), out OutClaimId);
                    }

                    command.Parameters.Clear();

                    foreach (DataRow row in data.Rows)
                    {
                        command.CommandText = String.Format("INSERT INTO CHANNELWITHDRAWAL_TEMP (ID, REPORTID, CHANNELID,  IMPORTEDBY, IMPORTDATE, CLAIMID) VALUES (CHANNELWITHDRAWAL_ID.Nextval, '{0}', '{1}', '{2}', '{3}', '{4}' )", reportId, row[0].ToString(), importedBy, System.DateTime.Now.ToString("dd-MMM-yyyy"), OutClaimId);
                        excelRowNumber++;
                        rowAffected += command.ExecuteNonQuery();
                    }

                    command.CommandText = "SYSNCHCHANNELWITHDRAWAL";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("pREPORTID", OracleType.Number).Value = reportId;
                    command.Parameters.Add("pCycleId", OracleType.Number).Value = cycleId;
                    command.Parameters.Add("pImportedBy", OracleType.VarChar).Value = importedBy;
                    command.ExecuteNonQuery();

                    command.CommandText = "select ID, ERRORTEXT from CHANNELWITHDRAWAL_TEMP WHERE ERRORTEXT like '%DUP%'";
                    command.CommandType = CommandType.Text;
                    command.Parameters.Clear();

                    IDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        errorMessage.Add(new ErrorMessageEnt { RowNumber = Convert.ToInt32(reader["ID"]), ErrorText = reader["ERRORTEXT"] as String, RowCount = rowAffected });
                    }

                    if (errorMessage.Count > 0)
                    {
                        isDuplicate = true;
                    }

                    oracleTransaction.Commit();
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message + " at line " + excelRowNumber.ToString());
            }
            return rowAffected.Equals(data.Rows.Count);
        }

        public static List<CountMessage> GetErrorText()
        {
            OracleProcedure procedure = new OracleProcedure(Utility.GetSchemaSetup(), "GET_Errortext");

            try
            {
                DataTable dt = procedure.ExecuteQueryToDataTable();
                List<CountMessage> results = new List<CountMessage>();
                foreach (DataRow dr in dt.Rows)
                {
                    results.Add(new CountMessage(dr));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public Boolean SaveChannelEventToTempTable(DataTable data, int channelTypeId, int reportId, int channeleventBatch, int reportCycleId, int eventTypeId, string amountType, string importedBy)
        {

            int rowAffected = 0;
            int rowNumber = 1;

            try
            {
                using (OracleConnection connection = new OracleConnection(Connection.ConnectionString))
                {

                    OracleCommand command = new OracleCommand();
                    command.CommandText = "DELETE FROM CHANNELEVENT_TEMP";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();



                    foreach (DataRow row in data.Rows)
                    {
                        if (!String.IsNullOrEmpty(row[0].ToString().Trim()))
                        {
                            command.CommandText = String.Format("INSERT INTO CHANNELEVENT_TEMP (ID,EXTERNALID,CHANNELCODE,CHANNELTYPEID,EVENTTYPEID,EVENTDATE,EVENTAMOUNT,AMOUNTTYPE,CHANNELEVENTBATCHID,STATUS,IMPORTBY,IMPORTDATE, MSISDN, SIMNUMBER) VALUES (JALLYFISH_TEMP.Nextval, {0}, '{1}', {2}, {3}, {4}, {5}, {6},{7},'{8}','{9}',{10}, '{11}' , '{12}')", rowNumber, row[0].ToString(), channelTypeId, eventTypeId, "sysdate", row[3].ToString(), amountType, channeleventBatch, "N", importedBy, "sysdate", row[1].ToString(), row[2].ToString());
                            rowAffected += command.ExecuteNonQuery();
                            rowNumber++;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return rowAffected.Equals(rowNumber - 1);
        }

        public bool Synchronize(int channeleventBatch, int eventTypeId, string importedBy)
        {
            int result = 0;

            try
            {
                using (OracleConnection connection = new OracleConnection(Connection.ConnectionString))
                {

                    OracleCommand command = new OracleCommand();

                    command.CommandText = "SysnchChanneLeventBatch";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("pChanneleventBatch", OracleType.Number).Value = channeleventBatch;
                    command.Parameters.Add("pEventTypeId", OracleType.VarChar).Value = eventTypeId;
                    command.Parameters.Add("pImportedBy", OracleType.VarChar).Value = importedBy;

                    command.Connection = connection;
                    connection.Open();

                    result = command.ExecuteNonQuery();

                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result > 0;
        }

        public bool ChannelEventCheck(int eventId, int channelEventBatchId)
        {
            Int32 result = 0;

            try
            {

                using (OracleConnection connection = new OracleConnection(Connection.ConnectionString))
                {
                    OracleCommand command = new OracleCommand();
                    command.CommandText = String.Format("SELECT COUNT(1) TCount FROM CHANNELEVENT_JALLYFISH WHERE EVENTTYPEID = {0} AND CHANNELEVENTBATCHID = {1}", eventId, channelEventBatchId);
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    command.Connection.Open();
                    IDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result = Convert.ToInt32(reader["TCount"]);
                    }

                    command.Connection.Close();

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result > 0;
        }


    }
}
