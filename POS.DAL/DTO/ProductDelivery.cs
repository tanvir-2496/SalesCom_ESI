using System;
using System.Runtime.Serialization;
using System.Data;

namespace POS.DAL
{
    [DataContract]
    public class ProductDelivery
    {
        [DataMember]
        public System.Int32 ID { get; set; }



        [DataMember]
        public System.Int32 CENTERID { get; set; }
        [DataMember]
        public System.Int32 INVOICEID { get; set; }
        [DataMember]
        public System.String SAFNO { get; set; }
        [DataMember]
        public System.String INVOICENO { get; set; }
        [DataMember]
        public System.String SERIALNO { get; set; }
        [DataMember]
        public System.String MSISDNNO { get; set; }
        [DataMember]
        public System.DateTime DELIVERYDATE { get; set; }
        [DataMember]
        public System.Int32 PRODUCTID { get; set; }
        [DataMember]
        public System.Int32 PROMOTIONCYCLEID { get; set; }
        [DataMember]
        public System.String PRODUCTCODE { get; set; }
        [DataMember]
        public System.String PROMOTIONNAME { get; set; }
        [DataMember]
        public System.String PRODUCTNAME { get; set; }

        public ProductDelivery() { }
        public ProductDelivery(DataRow objectRow)
        {
            if (objectRow["ID"] != DBNull.Value) this.ID = Convert.ToInt32(objectRow["ID"]);
            if (objectRow["INVOICEID"] != DBNull.Value) this.INVOICEID = Convert.ToInt32(objectRow["INVOICEID"]);
            if (objectRow["CENTERID"] != DBNull.Value) this.CENTERID = Convert.ToInt32(objectRow["CENTERID"]);



            this.SAFNO = objectRow["SAFNO"] as System.String;
            this.SERIALNO = objectRow["SERIALNO"] as System.String;
            this.MSISDNNO = objectRow["MSISDNNO"] as System.String;
            if (objectRow["DELIVERYDATE"] != DBNull.Value) 
            this.DELIVERYDATE = Convert.ToDateTime(objectRow["DELIVERYDATE"]);
            try
            {
                if (objectRow["PRODUCTID"] != DBNull.Value) this.PRODUCTID = Convert.ToInt32(objectRow["PRODUCTID"]);
                if (objectRow["PROMOTIONCYCLEID"] != DBNull.Value) this.PROMOTIONCYCLEID = Convert.ToInt32(objectRow["PROMOTIONCYCLEID"]);
            }
            catch {
                this.PRODUCTID = 0;
                this.PROMOTIONCYCLEID = 0;
            }

            try
            {
                this.PROMOTIONNAME = objectRow["PROMOTIONNAME"] as System.String;
                this.PRODUCTNAME = objectRow["PRODUCTNAME"] as System.String;
                this.PRODUCTCODE = objectRow["PRODUCTCODE"] as System.String;
            
            }
            catch 
            {
                //this.PRODUCTCODE = "";
                //this.PROMOTIONNAME = "";
            }

            try
            {

                this.INVOICENO = objectRow["INVOICENO"] as string;
            }
            catch { }

        }
    }
}