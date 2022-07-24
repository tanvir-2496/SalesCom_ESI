using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class AltBalanceTransferMaster
    {
        [DataMember]
        public int BALANCETRANSFERMASTERID { get; set; }

        [DataMember]
        public int DISTRIBUTORID { get; set; }
            
        [DataMember]
        public string DISTRIBUTORCODE { get; set; }

        [DataMember]
        public int FROMAC { get; set; }
               

        [DataMember]
        public string TRANSFERSTATUS { get; set; }


        [DataMember]
        public string DISTRIBUTORNAME { get; set; }


        [DataMember]
        public string FROMACCOUNTTYPENAME { get; set; }

       
         [DataMember]
        public string REFNO { get; set; }


        
        

        [DataMember]
        public string REMARKS { get; set; }

        [DataMember]
        public string FROMACCOUNTCODE { get; set; }

       

        [DataMember]
        public DateTime TRANSFERDATE { get; set; }

        [DataMember]
        public DateTime FROMDATE { get; set; }

        [DataMember]
        public DateTime TODATE { get; set; }

        [DataMember]
        public string ISALTERNATIVECHNL { get; set; }

        [DataMember]
        public decimal TOTALAMOUNT { get; set; }

              

        public AltBalanceTransferMaster()
        { }

        public AltBalanceTransferMaster(DataRow row)
        {
            if (row["BALANCETRANSFERMASTERID"] != DBNull.Value) BALANCETRANSFERMASTERID = int.Parse(row["BALANCETRANSFERMASTERID"].ToString());
            if (row["DISTRIBUTORID"] != DBNull.Value) DISTRIBUTORID = int.Parse(row["DISTRIBUTORID"].ToString());
            if (row["FROMAC"] != DBNull.Value) FROMAC = int.Parse(row["FROMAC"].ToString());
            
            if (row["FROMACCOUNTTYPENAME"] != DBNull.Value) FROMACCOUNTTYPENAME = row["FROMACCOUNTTYPENAME"].ToString();
           
            if (row["DISTRIBUTORNAME"] != DBNull.Value) DISTRIBUTORNAME = row["DISTRIBUTORNAME"].ToString();
            if (row["TRANSFERSTATUS"] != DBNull.Value) TRANSFERSTATUS = row["TRANSFERSTATUS"].ToString();

            if (row["FROMACCOUNTCODE"] != DBNull.Value) FROMACCOUNTCODE = row["FROMACCOUNTCODE"].ToString();
           


            if (row["DISTRIBUTORCODE"] != DBNull.Value) DISTRIBUTORCODE = row["DISTRIBUTORCODE"].ToString();

            if (row["REMARKS"] != DBNull.Value) REMARKS = row["REMARKS"].ToString();
            if (row["TRANSFERDATE"] != DBNull.Value) TRANSFERDATE = Convert.ToDateTime(row["TRANSFERDATE"]);

            if (row["REFNO"] != DBNull.Value) REFNO = row["REFNO"].ToString();

            if (row["ISALTERNATIVECHNL"] != DBNull.Value) ISALTERNATIVECHNL = row["ISALTERNATIVECHNL"].ToString();

            if (row["TOTALAMOUNT"] != DBNull.Value) TOTALAMOUNT = decimal.Parse(row["TOTALAMOUNT"].ToString());

           
        }
    }
}
