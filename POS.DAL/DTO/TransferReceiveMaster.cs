using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class TransferReceiveMaster
    {
        [DataMember] public System.Int32 TRANSFERRECEIVEID { get; set; }
        [DataMember] public System.String TRANSFERRECEIVECODE { get; set; }
        [DataMember] public System.DateTime TRANSFERRECEIVEDATE { get; set; }
        [DataMember] public System.String TRANSFERCODE { get; set; }
        [DataMember] public System.String REMARKS { get; set; }
        [DataMember] public System.String FROMWAREHOUSEORCENTER { get; set; }
        [DataMember] public System.Int32 FROMWAREHOUSECENTERID { get; set; }
        [DataMember] public System.Int32 FROMSTOREID { get; set; }
        [DataMember] public System.String RECEIVEWAREHOUSEORCENTER { get; set; }
        [DataMember] public System.Int32 RECEIVEWAREHOUSECENTERID { get; set; }
        [DataMember] public System.Int32 RECEIVESTOREID { get; set; }
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember] public System.DateTime STARTDATE { get; set; }
        [DataMember] public System.DateTime ENDDATE { get; set; }


        public TransferReceiveMaster() { }
        public TransferReceiveMaster(DataRow objectRow)
        {
            if (objectRow["TRANSFERRECEIVEID"] != DBNull.Value) this.TRANSFERRECEIVEID = Convert.ToInt32(objectRow["TRANSFERRECEIVEID"]);
            this.TRANSFERRECEIVECODE = objectRow["TRANSFERRECEIVECODE"] as System.String;
            if (objectRow["TRANSFERRECEIVEDATE"] != DBNull.Value) this.TRANSFERRECEIVEDATE = Convert.ToDateTime(objectRow["TRANSFERRECEIVEDATE"]);
            this.TRANSFERCODE = objectRow["TRANSFERCODE"] as System.String;
            this.REMARKS = objectRow["REMARKS"] as System.String;
            this.FROMWAREHOUSEORCENTER = objectRow["FROMWAREHOUSEORCENTER"] as System.String;
            if (objectRow["FROMWAREHOUSECENTERID"] != DBNull.Value) this.FROMWAREHOUSECENTERID = Convert.ToInt32(objectRow["FROMWAREHOUSECENTERID"]);
            if (objectRow["FROMSTOREID"] != DBNull.Value) this.FROMSTOREID = Convert.ToInt32(objectRow["FROMSTOREID"]);
            this.RECEIVEWAREHOUSEORCENTER = objectRow["RECEIVEWAREHOUSEORCENTER"] as System.String;
            if (objectRow["RECEIVEWAREHOUSECENTERID"] != DBNull.Value) this.RECEIVEWAREHOUSECENTERID = Convert.ToInt32(objectRow["RECEIVEWAREHOUSECENTERID"]);
            if (objectRow["RECEIVESTOREID"] != DBNull.Value) this.RECEIVESTOREID = Convert.ToInt32(objectRow["RECEIVESTOREID"]);
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
        }
    }
}