using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class BalanceTransfer
    {
        [DataMember]
        public int BALANCETRANSFERID { get; set; }

        [DataMember]
        public int DISTRIBUTORID { get; set; }
            
        [DataMember]
        public string DISTRIBUTORCODE { get; set; }

        [DataMember]
        public int FROMAC { get; set; }

        [DataMember]
        public int TOAC { get; set; }

        [DataMember]
        public decimal AMOUNT { get; set; }

        [DataMember]
        public string TRANSFERSTATUS { get; set; }


        [DataMember]
        public string DISTRIBUTORNAME { get; set; }


        [DataMember]
        public string FROMACCOUNTTYPENAME { get; set; }

        [DataMember]
        public string TOACCOUNTTYPENAME { get; set; }

         [DataMember]
        public string REFNO { get; set; }


        
        

        [DataMember]
        public string REMARKS { get; set; }

        [DataMember]
        public string FROMACCOUNTCODE { get; set; }

        [DataMember]
        public string TOACCOUNTCODE { get; set; }

        [DataMember]
        public DateTime TRANSFERDATE { get; set; }

        [DataMember]
        public DateTime FROMDATE { get; set; }

        [DataMember]
        public DateTime TODATE { get; set; }

        [DataMember]
        public string ISALTERNATIVECHNL { get; set; }

        [DataMember]
        public int TODISTRIBUTORID { get; set; }

        [DataMember]
        public string TODISTRIBUTORCODE { get; set; }
        

        public BalanceTransfer()
        { }

        public BalanceTransfer(DataRow row)
        {
            if (row["BALANCETRANSFERID"] != DBNull.Value) BALANCETRANSFERID = int.Parse(row["BALANCETRANSFERID"].ToString());
            if (row["DISTRIBUTORID"] != DBNull.Value) DISTRIBUTORID = int.Parse(row["DISTRIBUTORID"].ToString());
            if (row["FROMAC"] != DBNull.Value) FROMAC = int.Parse(row["FROMAC"].ToString());
            if (row["TOAC"] != DBNull.Value) TOAC = int.Parse(row["TOAC"].ToString());
            if (row["AMOUNT"] != DBNull.Value) AMOUNT = decimal.Parse(row["AMOUNT"].ToString());


            if (row["FROMACCOUNTTYPENAME"] != DBNull.Value) FROMACCOUNTTYPENAME = row["FROMACCOUNTTYPENAME"].ToString();
            if (row["TOACCOUNTTYPENAME"] != DBNull.Value) TOACCOUNTTYPENAME = row["TOACCOUNTTYPENAME"].ToString();
            if (row["DISTRIBUTORNAME"] != DBNull.Value) DISTRIBUTORNAME = row["DISTRIBUTORNAME"].ToString();
            if (row["TRANSFERSTATUS"] != DBNull.Value) TRANSFERSTATUS = row["TRANSFERSTATUS"].ToString();

            if (row["FROMACCOUNTCODE"] != DBNull.Value) FROMACCOUNTCODE = row["FROMACCOUNTCODE"].ToString();
            if (row["TOACCOUNTCODE"] != DBNull.Value) TOACCOUNTCODE = row["TOACCOUNTCODE"].ToString();


            if (row["DISTRIBUTORCODE"] != DBNull.Value) DISTRIBUTORCODE = row["DISTRIBUTORCODE"].ToString();

            if (row["REMARKS"] != DBNull.Value) REMARKS = row["REMARKS"].ToString();
            if (row["TRANSFERDATE"] != DBNull.Value) TRANSFERDATE = Convert.ToDateTime(row["TRANSFERDATE"]);

            if (row["REFNO"] != DBNull.Value) REFNO = row["REFNO"].ToString();

            if (row["ISALTERNATIVECHNL"] != DBNull.Value) ISALTERNATIVECHNL = row["ISALTERNATIVECHNL"].ToString();

            try
            {
                if (row["TODISTRIBUTORID"] != DBNull.Value) TODISTRIBUTORID = int.Parse(row["TODISTRIBUTORID"].ToString());

                if (row["TODISTRIBUTORCODE"] != DBNull.Value) TODISTRIBUTORCODE = row["TODISTRIBUTORCODE"].ToString();
            }
            catch (Exception ex)
            { }
        }
    }
}
