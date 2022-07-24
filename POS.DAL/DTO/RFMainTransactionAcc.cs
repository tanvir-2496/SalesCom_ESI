using System;
using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract]
    public class RFMainTransactionAcc
    {


        [DataMember]
        public System.Int32 RFMAINTRANSACTIONACCID { get; set; }


        [DataMember]
        public System.Int32 TRANSACTIONORDER { get; set; }

        [DataMember]
        public System.Int32 RFID { get; set; }

        [DataMember]
        public System.String ACCOUNTTYPENAME { get; set; }

        [DataMember]
        public System.String ACCOUNTCODE { get; set; }

        [DataMember]
        public System.Decimal AVAILABLEAMOUNT { get; set; }

        [DataMember]
        public System.Decimal REQUESTAMOUNT { get; set; }


        [DataMember]
        public System.Int32 ACCOUNTTYPEID { get; set; }

        [DataMember]
        public System.Int32 TRANSACTIONID { get; set; }

        [DataMember]
        public System.Int32 RTRANSACTIONID { get; set; }

        


        [DataMember]
        public System.String ISRF { get; set; }

        [DataMember]
        public System.String ENABLEDYN { get; set; }





        public RFMainTransactionAcc() { }
        public RFMainTransactionAcc(DataRow objectRow)
        {


            try
            {
                if (objectRow["TRANSACTIONID"] != DBNull.Value) this.TRANSACTIONID = Convert.ToInt32(objectRow["TRANSACTIONID"]);

            }
            catch { }

            try
            {
                if (objectRow["RTRANSACTIONID"] != DBNull.Value) this.RTRANSACTIONID = Convert.ToInt32(objectRow["RTRANSACTIONID"]);

            }
            catch { }

            try
            {
                if (objectRow["ACCOUNTTYPEID"] != DBNull.Value) this.ACCOUNTTYPEID = Convert.ToInt32(objectRow["ACCOUNTTYPEID"]);

            }
            catch { }

            try
            {
                if (objectRow["TRANSACTIONORDER"] != DBNull.Value) this.TRANSACTIONORDER = Convert.ToInt32(objectRow["TRANSACTIONORDER"]);

            }
            catch { }

            try
            {
                if (objectRow["RFMAINTRANSACTIONACCID"] != DBNull.Value) this.RFMAINTRANSACTIONACCID = Convert.ToInt32(objectRow["RFMAINTRANSACTIONACCID"]);

            }
            catch { }


            try
            {
                if (objectRow["RFID"] != DBNull.Value) this.RFID = Convert.ToInt32(objectRow["RFID"]);

            }
            catch
            {

            }


            if (objectRow["ACCOUNTCODE"] != DBNull.Value) this.ACCOUNTCODE = objectRow["ACCOUNTCODE"].ToString();
            if (objectRow["ACCOUNTTYPENAME"] != DBNull.Value) this.ACCOUNTTYPENAME = objectRow["ACCOUNTTYPENAME"].ToString();

            if (objectRow["AVAILABLEAMOUNT"] != DBNull.Value) this.AVAILABLEAMOUNT = Convert.ToDecimal(objectRow["AVAILABLEAMOUNT"]);
            if (objectRow["REQUESTAMOUNT"] != DBNull.Value) this.REQUESTAMOUNT = Convert.ToDecimal(objectRow["REQUESTAMOUNT"]);



            if (objectRow["ISRF"] != DBNull.Value) this.ISRF = objectRow["ISRF"].ToString();
            try
            {
                if (objectRow["ENABLEDYN"] != DBNull.Value) this.ENABLEDYN = objectRow["ENABLEDYN"].ToString();
            }
            catch (Exception ex)
            { }


        }
    }
}