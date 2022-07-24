using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class ReturnProduct
    {
        [DataMember]
        public int RETURNPRODUCTID { get; set; }

        [DataMember]
        public int WHRETURNID { get; set; }
        

        [DataMember]
        public string OrderNo { get; set; }

        [DataMember]
        public DateTime RETURNDATE { get; set; }

        [DataMember]
        public string REMARKS { get; set; }

        [DataMember]
        public string RECORDSTATUS { get; set; }


        [DataMember]
        public DateTime FROMDATE { get; set; }

        [DataMember]
        public DateTime TODATE { get; set; }


        [DataMember]
        public string TRANSACTIONREFNO { get; set; }


        [DataMember]
        public Int32 ACCOUNTTYPEID { get; set; }

        [DataMember]
        public Int32 ACCTRANSACTIONTYPEID { get; set; }

        [DataMember]
        public System.String CREATEBYUSER { get; set; }
        [DataMember]
        public System.DateTime CREATEDATE { get; set; }
        [DataMember]
        public System.String LASTUPDATEBY { get; set; }
        [DataMember]
        public System.DateTime LASTUPDATEDATE { get; set; }




        [DataMember]
        public string RETURNSTATUS { get; set; }



        [DataMember]
        public Int32 WAREHOUSEID { get; set; }



        [DataMember]
        public String WAREHOUSENAME { get; set; }


        [DataMember]
        public System.String PAYABLEORRECEIVEABLE { get; set; }

        public ReturnProduct()
        { }

        public ReturnProduct(DataRow row)
        {
            try
            {
                if (row["RETURNPRODUCTID"] != DBNull.Value) RETURNPRODUCTID = int.Parse(row["RETURNPRODUCTID"].ToString());
            }
            catch (Exception ex)
            { }

            try
            {
                if (row["RETURNDATE"] != DBNull.Value) RETURNDATE = Convert.ToDateTime(row["RETURNDATE"].ToString());
            }
            catch (Exception ex)
            { }

            try
            {
                if (row["REMARKS"] != DBNull.Value) REMARKS = row["REMARKS"].ToString();
            }
            catch (Exception ex)
            { }

            try
            {
                if (row["RECORDSTATUS"] != DBNull.Value) RECORDSTATUS = row["RECORDSTATUS"].ToString();
            }
            catch (Exception ex)
            { }

            try
            {
                if (row["TRANSACTIONREFNO"] != DBNull.Value) TRANSACTIONREFNO = row["TRANSACTIONREFNO"].ToString();
            }
            catch (Exception ex)
            { }

            try
            {
                if (row["ACCOUNTTYPEID"] != DBNull.Value) ACCOUNTTYPEID = int.Parse(row["ACCOUNTTYPEID"].ToString());
            }
            catch (Exception)
            { }

            try
            {
                if (row["ACCTRANSACTIONTYPEID"] != DBNull.Value) ACCTRANSACTIONTYPEID = int.Parse(row["ACCTRANSACTIONTYPEID"].ToString());
            }
            catch (Exception ex)
            { }

            try
            {
                this.CREATEBYUSER = row["CREATEBYUSER"] as System.String;
            }
            catch (Exception ex)
            { }

            try
            {
                this.LASTUPDATEBY = row["LASTUPDATEBY"] as System.String;
            }
            catch (Exception ex)
            { }

            try
            {
                if (row["WAREHOUSEID"] != DBNull.Value) WAREHOUSEID = int.Parse(row["WAREHOUSEID"].ToString());
            }
            catch (Exception ex)
            { }

            try
            {
                this.PAYABLEORRECEIVEABLE = row["PAYABLEORRECEIVEABLE"] as System.String;
            }
            catch (Exception ex)
            { }

            try
            {
                this.RETURNSTATUS = row["RETURNSTATUS"] as System.String;
            }
            catch (Exception ex)
            { }

            try
            {
                if (row["CREATEDATE"] != DBNull.Value) CREATEDATE = Convert.ToDateTime(row["CREATEDATE"].ToString());
            }
            catch (Exception ex)
            { }

            try
            {
                this.CREATEBYUSER = row["CREATEBYUSER"] as System.String;
            }
            catch (Exception ex)
            { }

            try
            {
                this.LASTUPDATEBY = row["LASTUPDATEBY"] as System.String;
            }
            catch (Exception ex)
            { }

            try
            {
                if (row["LASTUPDATEDATE"] != DBNull.Value) LASTUPDATEDATE = Convert.ToDateTime(row["LASTUPDATEDATE"].ToString());
            }
            catch (Exception ex)
            { }

            try
            {
                if (row["WAREHOUSENAME"] != DBNull.Value) this.WAREHOUSENAME = row["WAREHOUSENAME"] as System.String;
            }
            catch (Exception ex)
            { }

            try
            {
                if (row["OrderNo"] != DBNull.Value) this.OrderNo = row["OrderNo"] as System.String;
            }
            catch (Exception ex)
            { }

            try
            {
                if (row["WHRETURNID"] != DBNull.Value) WHRETURNID = int.Parse(row["WHRETURNID"].ToString());
            }
            catch (Exception ex)
            { }

        }
    }
}
