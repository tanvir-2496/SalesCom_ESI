using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Data;

namespace POS.DAL.DTO
{
    [DataContract]
    public class CommissionDetails
    {
        [DataMember]
        public System.Int32 COMMISSIONDETAILID { get; set; }
        [DataMember]
        public System.Int32 COMMISSIONMASTERID { get; set; }
        [DataMember]
        public System.String DISTRIBUTORCODE { get; set; }
        [DataMember]
        public System.Decimal AMOUNT { get; set; }
        [DataMember]
        public DateTime TRANSACTIONDATE { get; set; }
        [DataMember]
        public System.String REMARKS { get; set; }
        [DataMember]
        public string CREATEDBY { get; set; }
        [DataMember]
        public DateTime CREATEDDATE { get; set; }
        [DataMember]
        public string LASTUPDATEBY { get; set; }
        [DataMember]
        public DateTime LASTUPDATEDATE { get; set; }

        [DataMember]
        public string RECORDSTATUS { get; set; }
        
        [DataMember]
        public string STATUS { get; set; }

        public CommissionDetails()
        { }

        public CommissionDetails(DataRow row, bool LoadExcel)
        {
            if (LoadExcel)
            {
                if (row["Distributor Code"] != DBNull.Value)
                    DISTRIBUTORCODE = row["Distributor Code"].ToString();

                if (row["Amount"] != DBNull.Value)
                    AMOUNT = decimal.Parse(row["Amount"].ToString());

                if (row["Remarks"] != DBNull.Value)
                    REMARKS = row["Remarks"].ToString();
            }
        }

        public CommissionDetails(DataRow row)
        {
            if (row["COMMISSIONDETAILID"] != DBNull.Value) COMMISSIONDETAILID = int.Parse(row["COMMISSIONDETAILID"].ToString());

            if (row["COMMISSIONMASTERID"] != DBNull.Value) COMMISSIONMASTERID = int.Parse(row["COMMISSIONMASTERID"].ToString());

            if (row["DISTRIBUTORCODE"] != DBNull.Value) DISTRIBUTORCODE = row["DISTRIBUTORCODE"].ToString();

            if (row["AMOUNT"] != DBNull.Value) AMOUNT = Decimal.Parse(row["AMOUNT"].ToString());

            if (row["TRANSACTIONDATE"] != DBNull.Value) TRANSACTIONDATE = DateTime.Parse(row["TRANSACTIONDATE"].ToString());

            if (row["REMARKS"] != DBNull.Value) REMARKS = row["REMARKS"].ToString();

            if (row["CREATEDBY"] != DBNull.Value) CREATEDBY = row["CREATEDBY"].ToString();

            if (row["CREATEDDATE"] != DBNull.Value) CREATEDDATE = DateTime.Parse(row["CREATEDDATE"].ToString());

            if (row["LASTUPDATEBY"] != DBNull.Value) LASTUPDATEBY = row["LASTUPDATEBY"].ToString();

            if (row["LASTUPDATEDATE"] != DBNull.Value) LASTUPDATEDATE = DateTime.Parse(row["LASTUPDATEDATE"].ToString());

            if (row["STATUS"] != DBNull.Value) STATUS = row["STATUS"].ToString();

            if (row["RECORDSTATUS"] != DBNull.Value) STATUS = row["RECORDSTATUS"].ToString();
        }

    }
}
