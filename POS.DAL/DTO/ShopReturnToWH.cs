using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class ShopReturnToWH
    {
        [DataMember] public System.Int32 RETURNID { get; set; }
        [DataMember] public System.String RETURNREFNO { get; set; }
        [DataMember] public System.Int32 CENTERID { get; set; }
        [DataMember] public System.Int32 WAREHOUSEID { get; set; }
        [DataMember] public System.DateTime RETURNDATE { get; set; }
        [DataMember] public System.Int32 INVENTORYOUTID { get; set; }
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
        public ShopReturnToWH() { }
        public ShopReturnToWH(DataRow objectRow)
        {
            if (objectRow["SHOPRETURNID"] != DBNull.Value) this.RETURNID = Convert.ToInt32(objectRow["SHOPRETURNID"]);
            this.RETURNREFNO = objectRow["RETURNREFNO"] as System.String;
            if (objectRow["CENTERID"] != DBNull.Value) this.CENTERID = Convert.ToInt32(objectRow["CENTERID"]);
            if (objectRow["WAREHOUSEID"] != DBNull.Value) this.WAREHOUSEID = Convert.ToInt32(objectRow["WAREHOUSEID"]);
            if (objectRow["RETURNDATE"] != DBNull.Value) this.RETURNDATE = Convert.ToDateTime(objectRow["RETURNDATE"]);
            if (objectRow["INVENTORYOUTID"] != DBNull.Value) this.INVENTORYOUTID = Convert.ToInt32(objectRow["INVENTORYOUTID"]);
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