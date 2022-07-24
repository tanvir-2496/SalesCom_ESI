using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class ShopReceiveFromWH
    {
        [DataMember] public System.Int32 RECEIVINGID { get; set; }
        [DataMember] public System.Int32 CENTERID { get; set; }
        [DataMember] public System.String RECEIVINGREFNO { get; set; }
        [DataMember] public System.Int32 WAREHOUSEID { get; set; }
        [DataMember] public System.DateTime RECEIVINGDATE { get; set; }
        [DataMember] public System.Int32 INVENTORYINID { get; set; }
        [DataMember] public System.String REMARKS { get; set; }
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember] public System.DateTime STARTDATE { get; set; }
        [DataMember] public System.DateTime ENDDATE { get; set; }
        [DataMember] public System.String WAREHOUSENAME { get; set; }
        [DataMember] public System.String WAREHOUSECODE { get; set; }
        [DataMember] public System.String CENTERNAME { get; set; }
        public ShopReceiveFromWH() { }
        public ShopReceiveFromWH(DataRow objectRow)
        {
            if (objectRow["RECEIVINGID"] != DBNull.Value) this.RECEIVINGID = Convert.ToInt32(objectRow["RECEIVINGID"]);
            if (objectRow["CENTERID"] != DBNull.Value) this.CENTERID = Convert.ToInt32(objectRow["CENTERID"]);
            this.RECEIVINGREFNO = objectRow["RECEIVINGREFNO"] as System.String;
            if (objectRow["WAREHOUSEID"] != DBNull.Value) this.WAREHOUSEID = Convert.ToInt32(objectRow["WAREHOUSEID"]);
            if (objectRow["RECEIVINGDATE"] != DBNull.Value) this.RECEIVINGDATE = Convert.ToDateTime(objectRow["RECEIVINGDATE"]);
            if (objectRow["INVENTORYINID"] != DBNull.Value) this.INVENTORYINID = Convert.ToInt32(objectRow["INVENTORYINID"]);
            this.REMARKS = objectRow["REMARKS"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
            this.WAREHOUSENAME = objectRow["WAREHOUSENAME"] as System.String;
            this.WAREHOUSECODE = objectRow["WAREHOUSECODE"] as System.String;
            this.CENTERNAME = objectRow["CENTERNAME"] as System.String;
           // if (objectRow["STARTDATE"] != DBNull.Value) this.STARTDATE = Convert.ToDateTime(objectRow["STARTDATE"]);
            //if (objectRow["ENDDATE"] != DBNull.Value) this.ENDDATE = Convert.ToDateTime(objectRow["ENDDATE"]);
        }
    }
}