using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class TeleSMSActivation
    {
        public TeleSMSActivation()
        { }

        [DataMember]
        public Int64 ID { get; set; }

        [DataMember]
        public string MSISDN { get; set; }


        [DataMember]
        public string SENDER { get; set; }

        [DataMember]
        public string EQUIPID { get; set; }

        [DataMember]
        public DateTime VASRECEIVEDATE { get; set; }

        [DataMember]
        public string APISTRING { get; set; }

        [DataMember]
        public DateTime EXECUTIONDATE { get; set; }

        [DataMember]
        public DateTime CREATIONDATE { get; set; }

        [DataMember]
        public int STATUS { get; set; }

        [DataMember]
        public long VASSMSID { get; set; }

        [DataMember]
        public string EXECERRMSG { get; set; }

        [DataMember]
        public string OTHER_INFO_UPDATED { get; set; }

        [DataMember]
        public DateTime INFO_UPDATE_TIME { get; set; }

        [DataMember]
        public string SIMNO { get; set; }

        [DataMember]
        public string INFO_UPDATE_USER { get; set; }

        [DataMember]
        public string TABSACTIVATED { get; set; }

        [DataMember]
        public string SALESMANCODE { get; set; }

        [DataMember]
        public string FIRSTNAME { get; set; }

        [DataMember]
        public string LASTNAME { get; set; }


        [DataMember]
        public string ALTERNATIVENUMBER { get; set; }

        [DataMember]
        public string ADDRESS { get; set; }

        [DataMember]
        public string ASSIGNNAME { get; set; }

        [DataMember]
        public string REMARKS { get; set; }


        [DataMember]
        public string INFOUPDATE { get; set; }


        [DataMember]
        public string SMSSTATUS { get; set; }

        [DataMember]
        public long ASD { get; set; }

        [DataMember]
        public int PROMOTIONID { get; set; }

        [DataMember]
        public string PAYORDERNUBER { get; set; }

        [DataMember]
        public string CALLERNAME { get; set; }

        [DataMember]
        public string GOLDORSILVER { get; set; }

        [DataMember]
        public int PRODUCTID { get; set; }

        [DataMember]
        public string CUSTNAME { get; set; }
              
       
        [DataMember]
        public System.DateTime FROMDATE { get; set; }
        
        [DataMember]
        public System.DateTime TODATE { get; set; }

        [DataMember]
        public System.Int32 INVOICEID { get; set; }

        [DataMember]
        public System.Int32 CENTERID { get; set; }

        [DataMember]
        public string CENTERCODE { get; set; }

        [DataMember]
        public int INVOICEPRODUCTID { get; set; }

        [DataMember]
        public int INVOICEAMOUNT { get; set; }

        public TeleSMSActivation(DataRow row)
        {
            if (row["ID"] != DBNull.Value)
                ID = Int64.Parse(row["ID"].ToString());

            if (row["MSISDN"] != DBNull.Value)
                MSISDN = row["MSISDN"].ToString();
            
            if (row["SENDER"] != DBNull.Value)
                SENDER = row["SENDER"].ToString();

            if (row["EQUIPID"] != DBNull.Value)
                EQUIPID = row["EQUIPID"].ToString();

            if (row["VASRECEIVEDATE"] != DBNull.Value)
                VASRECEIVEDATE = DateTime.Parse(row["VASRECEIVEDATE"].ToString());

            if (row["APISTRING"] != DBNull.Value)
                APISTRING = row["APISTRING"].ToString();

            if (row["EXECUTIONDATE"] != DBNull.Value)
                EXECUTIONDATE = DateTime.Parse(row["EXECUTIONDATE"].ToString());

            if (row["CREATIONDATE"] != DBNull.Value)
                CREATIONDATE = DateTime.Parse(row["CREATIONDATE"].ToString());

            if (row["STATUS"] != DBNull.Value)
                STATUS =int.Parse(row["STATUS"].ToString());

            if (row["VASSMSID"] != DBNull.Value)
                VASSMSID = long.Parse(row["VASSMSID"].ToString());

            if (row["EXECERRMSG"] != DBNull.Value)
                EXECERRMSG = row["EXECERRMSG"].ToString();

            if (row["OTHER_INFO_UPDATED"] != DBNull.Value)
                OTHER_INFO_UPDATED = row["OTHER_INFO_UPDATED"].ToString();

            if (row["INFO_UPDATE_TIME"] != DBNull.Value)
                INFO_UPDATE_TIME =DateTime.Parse(row["INFO_UPDATE_TIME"].ToString());

            if (row["SIMNO"] != DBNull.Value)
                SIMNO = row["SIMNO"].ToString();

            if (row["INFO_UPDATE_USER"] != DBNull.Value)
                INFO_UPDATE_USER = row["INFO_UPDATE_USER"].ToString();

            if (row["TABSACTIVATED"] != DBNull.Value)
                TABSACTIVATED = row["TABSACTIVATED"].ToString();
            
            if (row["SALESMANCODE"] != DBNull.Value)
                SALESMANCODE = row["SALESMANCODE"].ToString();

            if (row["FIRSTNAME"] != DBNull.Value)
                FIRSTNAME = row["FIRSTNAME"].ToString();

            if (row["LASTNAME"] != DBNull.Value)
                LASTNAME = row["LASTNAME"].ToString();

            if (row["ALTERNATIVENUMBER"] != DBNull.Value)
                ALTERNATIVENUMBER = row["ALTERNATIVENUMBER"].ToString();

            if (row["ADDRESS"] != DBNull.Value)
                ADDRESS = row["ADDRESS"].ToString();

            if (row["ASSIGNNAME"] != DBNull.Value)
                ASSIGNNAME = row["ASSIGNNAME"].ToString();

            if (row["REMARKS"] != DBNull.Value)
                REMARKS = row["REMARKS"].ToString();


            if (row["INFOUPDATE"] != DBNull.Value)
                INFOUPDATE = row["INFOUPDATE"].ToString();

            if (row["SMSSTATUS"] != DBNull.Value)
                SMSSTATUS = row["SMSSTATUS"].ToString();

            if (row["ASD"] != DBNull.Value)
                ASD = long.Parse(row["ASD"].ToString());

            if (row["PROMOTIONID"] != DBNull.Value)
                PROMOTIONID = int.Parse(row["PROMOTIONID"].ToString());

            if (row["PAYORDERNUBER"] != DBNull.Value)
                PAYORDERNUBER = row["PAYORDERNUBER"].ToString();

            if (row["CALLERNAME"] != DBNull.Value)
                CALLERNAME = row["CALLERNAME"].ToString();

            if (row["GOLDORSILVER"] != DBNull.Value)
                GOLDORSILVER = row["GOLDORSILVER"].ToString();

            if (row["PRODUCTID"] != DBNull.Value)
                PRODUCTID = int.Parse(row["PRODUCTID"].ToString());

            if (row["CUSTNAME"] != DBNull.Value)
                CUSTNAME = row["CUSTNAME"].ToString();

            if (row["INVOICEID"] != DBNull.Value)
                INVOICEID = int.Parse(row["INVOICEID"].ToString());

            if (row["CENTERID"] != DBNull.Value)
                CENTERID = int.Parse(row["CENTERID"].ToString());

            if (row["CENTERCODE"] != DBNull.Value)
                CENTERCODE = row["CENTERCODE"].ToString();

            if (row["INVOICEPRODUCTID"] != DBNull.Value)
                INVOICEPRODUCTID = int.Parse(row["INVOICEPRODUCTID"].ToString());

            if (row["INVOICEAMOUNT"] != DBNull.Value)
                 INVOICEAMOUNT = int.Parse(row["INVOICEAMOUNT"].ToString());
            
            
        }



    }
}
