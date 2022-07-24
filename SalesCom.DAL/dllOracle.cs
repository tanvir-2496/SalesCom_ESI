using System;
using System.Data;
using System.Web;
using System.Configuration;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Collections;

namespace SalesCom.DAL
{
    public class dllOracle
    {

        public DataSet GetDataSet(string strSQL)
        {
            OracleConnection connection = null;
            OracleCommand command = null;
            DataSet dataSet = null;
            try
            {
                connection = new OracleConnection(Connection.ConnectionString);
                command = new OracleCommand();
                command.CommandText = strSQL;
                command.Connection = connection;
                dataSet = new DataSet();
                OracleDataAdapter dataAdapter = new OracleDataAdapter();
                connection.Open();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataSet);
                connection.Close();
                return dataSet;
            }
            catch (Exception exp)
            {
            }
            finally
            {
                if (command != null) command.Dispose();
                if (connection != null && connection.State != ConnectionState.Closed) connection.Close();
            }
            return null;
        }

        //public int ExecuteSQLQueryAction(string strSQL, ArrayList arlParams)
        //{
        //    OracleConnection connection = null;
        //    OracleCommand command = null;
        //    int intResult = 0;
        //    connection = new OracleConnection(Connection.ConnectionString);
        //    OracleTransaction objTransaction = (OracleTransaction)connection.BeginTransaction(IsolationLevel.ReadCommitted);
        //    try
        //    {
        //        command = new OracleCommand();
        //        command.CommandText = strSQL;
        //        command.Connection = connection;
        //        if (arlParams != null)
        //        {
        //            for (int i = 0; i < arlParams.Count; i++)
        //                command.Parameters.Add(arlParams[i]);
        //        }
        //        command.Transaction = objTransaction;
        //        OracleString rowid;
        //        intResult = command.ExecuteOracleNonQuery(out rowid);
        //        objTransaction.Commit();
        //        command.Parameters.Clear();

        //    }
        //    catch (Exception ex)
        //    {
        //        objTransaction.Rollback();
        //        throw (ex);
        //    }
        //    finally
        //    {

        //        if (command != null) command.Dispose();
        //        if (connection != null && connection.State != ConnectionState.Closed) connection.Close();
        //    }
        //    return intResult;

        //} // ExecuteSQLQueryAction

        public DataTable ExecuteStoredProcedureDataTable(string strProcedureName, OracleParameter[] arlParams)
        {

            using (OracleConnection connection = new OracleConnection(Connection.ConnectionString))
            using (OracleCommand command = new OracleCommand())
            {
                command.Connection = connection;
                command.CommandText = strProcedureName;
                command.CommandType = CommandType.StoredProcedure;


                if (arlParams != null)
                {
                    for (int i = 0; i < arlParams.Length; i++)
                    {
                        if (arlParams[i].Value == null)
                        {
                            arlParams[i].Value = DBNull.Value;
                        }
                        command.Parameters.Add(arlParams[i]);
                    }

                }
                try
                {

                    connection.Open();
                    DataTable dt = new DataTable(strProcedureName);



                    using (OracleDataAdapter da = new OracleDataAdapter(command))
                    {
                            da.Fill(dt);
                    }
                    return dt;
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }


        }

        public int ExecuteNonQueryStoredProcedure(string strProcedureName, OracleParameter[] arlParams)
        {
            int intResult = 0;
            using (OracleConnection connection = new OracleConnection(Connection.ConnectionString))
            using (OracleCommand command = new OracleCommand())
            {


                try
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = strProcedureName;
                    command.Connection = connection;

                    if (arlParams != null)
                    {
                        for (int i = 0; i < arlParams.Length; i++)
                        {
                            if (arlParams[i].Value == null)
                            {
                                arlParams[i].Value = DBNull.Value;
                            }
                            command.Parameters.Add(arlParams[i]);//.ToString().Trim('@'), OracleType.VarChar).Value = arlParams[i].Value;
                        }
                    }

                    OracleString rowID = "1";

                    intResult = command.ExecuteOracleNonQuery(out rowID);


                    return intResult;

                }
                catch (Exception ex)
                {

                    throw (ex);
                }
            }

        }
        public int ExecuteNonQueryStoredProcedure(string strProcedureName, OracleParameter[] arlParams, OracleConnection connection, OracleTransaction objTransaction)
        {
            int intResult = 0;

            using (OracleCommand command = new OracleCommand())
            {
                try
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = strProcedureName;
                    command.Transaction = objTransaction;
                    command.Connection = connection;
                    if (arlParams != null)
                    {
                        for (int i = 0; i < arlParams.Length; i++)
                        {
                            if (arlParams[i].Value == null)
                            {
                                arlParams[i].Value = DBNull.Value;
                            }
                            command.Parameters.Add(arlParams[i]);//.ToString().Trim('@'), OracleType.VarChar).Value = arlParams[i].Value;
                        }
                    }

                    OracleString rowID = "1";

                    intResult = command.ExecuteOracleNonQuery(out rowID);
                    command.Parameters.Clear();
                    return intResult;

                }
                catch (Exception ex)
                {

                    throw (ex);
                }
            }
        }

        public byte[] GetBytes(string sql)
        {
            byte[] b = new byte[0];
            using (OracleConnection connection = new OracleConnection(Connection.ConnectionString))
            using (OracleCommand command = new OracleCommand(sql, connection))
            {


                try
                {
                    connection.Open();
                    OracleDataReader dr = command.ExecuteReader();
                    dr.Read();
                    if (dr[0] != DBNull.Value)
                        b = (byte[])dr[0];

                    connection.Close();
                    return b;

                }
                catch (Exception ex)
                {

                    throw (ex);
                }
            }

        }

    }
}