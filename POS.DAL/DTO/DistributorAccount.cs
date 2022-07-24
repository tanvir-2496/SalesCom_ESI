using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class DistributorAccount
    {




        [DataMember]
        public int DISTRIBUTORID { get; set; }

        [DataMember]
        public int ACCOUNTTYPEID { get; set; }

        [DataMember]
        public string ACCOUNTTYPENAME { get; set; }

        [DataMember]
        public string ACCOUNTCODE { get; set; }

        [DataMember]
        public string DISTRIBUTORCODE { get; set; }

        [DataMember]
        public string ENABLEDYN { get; set; }

        [DataMember]
        public string DISTRIBUTORNAME { get; set; }





        public DistributorAccount()
        { }

        public DistributorAccount(DataRow row)
        {
            if (row["ACCOUNTTYPEID"] != DBNull.Value) ACCOUNTTYPEID = int.Parse(row["ACCOUNTTYPEID"].ToString());

            if (row["ACCOUNTTYPENAME"] != DBNull.Value) ACCOUNTTYPENAME = row["ACCOUNTTYPENAME"].ToString();

            if (row["ACCOUNTCODE"] != DBNull.Value) ACCOUNTCODE = row["ACCOUNTCODE"].ToString();

            if (row["DISTRIBUTORCODE"] != DBNull.Value) DISTRIBUTORCODE = row["DISTRIBUTORCODE"].ToString();



            if (row["DISTRIBUTORID"] != DBNull.Value) DISTRIBUTORID = int.Parse(row["DISTRIBUTORID"].ToString());

            if (row["DISTRIBUTORNAME"] != DBNull.Value) DISTRIBUTORNAME = row["DISTRIBUTORNAME"].ToString();
            try
            {

                if (row["ENABLEDYN"] != DBNull.Value) ENABLEDYN = row["ENABLEDYN"].ToString();
            }
            catch (Exception ex)

            { }
        
        }
    }
}
