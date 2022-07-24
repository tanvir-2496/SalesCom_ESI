using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class PayableReceivableChild
    {
        [DataMember]
        public int PAYABLERECEIVEABLEID { get; set; }

        [DataMember]
        public int PAYABLERECEIVEABLEDETAILSID { get; set; }

        [DataMember]
        public int DISTRIBUTORID { get; set; }

        [DataMember]
        public string DISTRIBUTORCODE { get; set; }

        [DataMember]
        public string DISTRIBUTORNAME { get; set; }

        [DataMember]
        public decimal AMOUNT { get; set; }

        [DataMember]
        public string REMARKS { get; set; }

        [DataMember]
        public string RECORDSTATUS { get; set; }

        [DataMember]
        public string STATUS { get; set; }


        public PayableReceivableChild()
        { }

        public PayableReceivableChild(DataRow row,bool LoadExcel)
        {
            if (LoadExcel)
            {
                if (row["Distributor Code"] != DBNull.Value)
                    DISTRIBUTORCODE = row["Distributor Code"].ToString();

                try
                {
                    if (row["Distributor Name"] != DBNull.Value)
                        DISTRIBUTORNAME = row["Distributor Name"].ToString();
                }
                catch { }
                if (row["Amount"] != DBNull.Value)
                    AMOUNT = decimal.Parse(row["Amount"].ToString());

                if (row["Remarks"] != DBNull.Value)
                    REMARKS = row["Remarks"].ToString();
            }
        }

        public PayableReceivableChild(DataRow row)
        {
            if (row["PAYABLERECEIVEABLEID"] != DBNull.Value)
                this.PAYABLERECEIVEABLEID = int.Parse(row["PAYABLERECEIVEABLEID"].ToString());

            if (row["PAYABLERECEIVEABLEDETAILSID"] != DBNull.Value)
                this.PAYABLERECEIVEABLEDETAILSID = int.Parse(row["PAYABLERECEIVEABLEDETAILSID"].ToString());

            if (row["DISTRIBUTORID"] != DBNull.Value)
                this.DISTRIBUTORID = int.Parse(row["DISTRIBUTORID"].ToString());

            if (row["DISTRIBUTORCODE"] != DBNull.Value)
                DISTRIBUTORCODE = row["DISTRIBUTORCODE"].ToString();


            try
            {
                if (row["DISTRIBUTORNAME"] != DBNull.Value)
                    DISTRIBUTORNAME = row["DISTRIBUTORNAME"].ToString();

            }
            catch
            { }
            if (row["AMOUNT"] != DBNull.Value)
                this.AMOUNT = decimal.Parse(row["AMOUNT"].ToString());

            if (row["REMARKS"] != DBNull.Value)
                this.REMARKS = row["REMARKS"].ToString();

            try
            {
                if (row["RECORDSTATUS"] != DBNull.Value)
                    this.RECORDSTATUS = row["RECORDSTATUS"].ToString();

                if (row["STATUS"] != DBNull.Value)
                    this.STATUS = row["STATUS"].ToString();
            }
            catch (Exception ex)
            { 
            
            }


        }
    }
}
