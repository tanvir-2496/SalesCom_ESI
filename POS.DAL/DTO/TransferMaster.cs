using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class TransferMaster
    {
        [DataMember] public System.Int32 TRANSFERID { get; set; }
        [DataMember] public System.String TRANSFERCODE { get; set; }
        [DataMember] public System.DateTime TRANSFERDATE { get; set; }
        [DataMember] public System.String REFNO { get; set; }
        [DataMember] public System.Int32 RFID { get; set; }
        [DataMember] public System.String REMARKS { get; set; }
        [DataMember] public System.String FROMWAREHOUSEORCENTER { get; set; }
        [DataMember] public System.Int32 FROMWAREHOUSECENTERID { get; set; }
        [DataMember] public System.Int32 FROMSTOREID { get; set; }
        [DataMember] public System.String TOWAREHOUSEORCENTER { get; set; }
        [DataMember] public System.Int32 TOWAREHOUSECENTERID { get; set; }
        [DataMember] public System.Int32 TOSTOREID { get; set; }
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember] public System.DateTime STARTDATE { get; set; }
        [DataMember] public System.DateTime ENDDATE { get; set; }
        

        public TransferMaster() { }
        public TransferMaster(DataRow objectRow)
        {
            if (objectRow["TRANSFERID"] != DBNull.Value) this.TRANSFERID = Convert.ToInt32(objectRow["TRANSFERID"]);
            this.TRANSFERCODE = objectRow["TRANSFERCODE"] as System.String;
            if (objectRow["TRANSFERDATE"] != DBNull.Value) this.TRANSFERDATE = Convert.ToDateTime(objectRow["TRANSFERDATE"]);
            this.REFNO = objectRow["REFNO"] as System.String;
            this.REMARKS = objectRow["REMARKS"] as System.String;
            this.FROMWAREHOUSEORCENTER = objectRow["FROMWAREHOUSEORCENTER"] as System.String;
            if (objectRow["FROMWAREHOUSECENTERID"] != DBNull.Value) this.FROMWAREHOUSECENTERID = Convert.ToInt32(objectRow["FROMWAREHOUSECENTERID"]);
            if (objectRow["FROMSTOREID"] != DBNull.Value) this.FROMSTOREID = Convert.ToInt32(objectRow["FROMSTOREID"]);
            this.TOWAREHOUSEORCENTER = objectRow["TOWAREHOUSEORCENTER"] as System.String;
            if (objectRow["TOWAREHOUSECENTERID"] != DBNull.Value) this.TOWAREHOUSECENTERID = Convert.ToInt32(objectRow["TOWAREHOUSECENTERID"]);
            if (objectRow["TOSTOREID"] != DBNull.Value) this.TOSTOREID = Convert.ToInt32(objectRow["TOSTOREID"]);
            if (objectRow["RFID"] != DBNull.Value) this.RFID = Convert.ToInt32(objectRow["RFID"]);
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
        }
    }
}