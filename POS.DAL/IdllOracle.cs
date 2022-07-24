using System;
using System.Data;
using System.Web;
using System.Configuration;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Collections;

namespace POS.DAL
{
    class IdllOracle
    {
        interface IdllOraclePOS
        {
            DataTable ExecuteStoredProcedureDataTable(string strProcedureName, OracleParameter[] arlParams);
            int ExecuteNonQueryStoredProcedure(string strProcedureName, OracleParameter[] arlParams);
            int ExecuteNonQueryStoredProcedure(string strProcedureName, OracleParameter[] arlParams, OracleConnection connection, OracleTransaction txn);
        }
    }
}
