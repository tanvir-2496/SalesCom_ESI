using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System; using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class Exitordermaster
    {
        [DataMember]
        public System.Int32 WHISSUEID { get; set; }
        [DataMember]
        public System.String WHISSUECODE { get; set; }
        [DataMember]
        public System.DateTime WHISSUEDATE { get; set; }
        [DataMember]
        public System.Int32 RFRAISERID { get; set; }
        [DataMember]
        public System.String DISTRIBUTORNAME { get; set; }
        [DataMember]
        public System.String RFNO { get; set; }
        [DataMember]
        public System.String REMARKS { get; set; }
        [DataMember]
        public System.Int32 WAREHOUSEID { get; set; }
        [DataMember]
        public System.String CREATEBYUSER { get; set; }
        [DataMember]
        public System.DateTime CREATEDATE { get; set; }
        [DataMember]
        public System.String LASTUPDATEBY { get; set; }
        [DataMember]
        public System.String ISCOURIER { get; set; }
        [DataMember]
        public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember]
        public System.Int32 STOREID { get; set; }
        [DataMember]
        public System.Int32 RFID { get; set; }
        [DataMember]
        public System.DateTime STARTDATE { get; set; }
        [DataMember]
        public System.DateTime ENDDATE { get; set; }
        public Exitordermaster() { }
        public Exitordermaster(DataRow objectRow)
        {
            if (objectRow["WHISSUEID"] != DBNull.Value) this.WHISSUEID = Convert.ToInt32(objectRow["WHISSUEID"]);
            this.WHISSUECODE = objectRow["WHISSUECODE"] as System.String;
            if (objectRow["WHISSUEDATE"] != DBNull.Value) this.WHISSUEDATE = Convert.ToDateTime(objectRow["WHISSUEDATE"]);
            if (objectRow["RFRAISERID"] != DBNull.Value) this.RFRAISERID = Convert.ToInt32(objectRow["RFRAISERID"]);
            this.DISTRIBUTORNAME = objectRow["DISTRIBUTORNAME"] as System.String;
            this.RFNO = objectRow["RFNO"] as System.String;
            this.REMARKS = objectRow["REMARKS"] as System.String;
            if (objectRow["WAREHOUSEID"] != DBNull.Value) this.WAREHOUSEID = Convert.ToInt32(objectRow["WAREHOUSEID"]);
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);

            if (objectRow["STOREID"] != DBNull.Value) this.STOREID = Convert.ToInt32(objectRow["STOREID"]);
            if (objectRow["RFID"] != DBNull.Value) this.RFID = Convert.ToInt32(objectRow["RFID"]);
            try
            {
                this.ISCOURIER = objectRow["ISCOURIER"] as System.String;
            }
            catch { }
        }
    }
}
