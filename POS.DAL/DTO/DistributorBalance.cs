using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Reflection;

namespace POS.DAL
{
    [DataContract]
    [Serializable]
    public class DistributorBalance
    {
        [DataMember]
        public int DISTRIBUTORID{get;set;}
        
        [DataMember]
        public decimal BALANCE{get;set;}
  
        [DataMember]
        public decimal CREDITLIMIT{get;set;}
  
        [DataMember]
        public decimal CREDITBALANCE{get;set;}

        [DataMember]
        public string ACCOUNTTYPENAME { get; set; }

        [DataMember]
        public string ACCOUNTCODE { get; set; }

        [DataMember]
        public int ACCOUNTID { get; set; }



        [DataMember]
        public string DRORCR { get; set; }


        public DistributorBalance()
        { }

        public DistributorBalance(DataRow row)
        {


            try
            {

                if (row["DISTRIBUTORID"] != DBNull.Value) DISTRIBUTORID = int.Parse(row["DISTRIBUTORID"].ToString());
            }
            catch { }

            try
            {

                if (row["BALANCE"] != DBNull.Value) BALANCE = decimal.Parse(row["BALANCE"].ToString());
            }
            catch { }

            try
            {
                if (row["CREDITLIMIT"] != DBNull.Value) CREDITLIMIT = decimal.Parse(row["CREDITLIMIT"].ToString());
            }
            catch { }

            try
            {

                if (row["CREDITBALANCE"] != DBNull.Value) CREDITBALANCE = decimal.Parse(row["CREDITBALANCE"].ToString());
            }
            catch
            { }

            try
            {

                ACCOUNTTYPENAME = row["ACCOUNTTYPENAME"].ToString();
            }
            catch { }

            try
            {

                ACCOUNTCODE = row["ACCOUNTCODE"].ToString();
            }
            catch { }

            try
            {

                DRORCR = row["DRORCR"].ToString();
            }
            catch { }


            try
            {

                ACCOUNTID = int.Parse(row["ACCOUNTID"].ToString());
            }
            catch { }

            
        }
    }
}
