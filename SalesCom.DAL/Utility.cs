using System;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;

namespace SalesCom.DAL
{

    public class Utility
    {
        private System.String strConnection;
        public string ConnectionString
        {
            get
            {
                return strConnection;
            }
            set
            {
                strConnection = value;
            }
        }
        
        //public static string GetConnectionStringOracle()
        //{
        //    return "Data Source=PreDWH_new; User ID=CFDBT; Password=CFDB0987;";
        //    return ConfigurationSettings.AppSettings["GetPOSConnectionString"].ToString();
        //}



        public static string GetSchemaSetup()
        {
            return "Setup.";
        }

        public static string GetSchemaSetup_2()
        {
            return "Setup_2.";
        }
  
        public static int ErrorCode = -10000000;
    }

    public static class Connection
    {
        private static System.String strConnection;
        public static   string ConnectionString
        {
            get
            {
                return strConnection;
            }
            set
            {
                strConnection = value;
            }
        }
    }

}
