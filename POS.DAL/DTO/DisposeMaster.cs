using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class DisposeMaster
    {
        [DataMember] public System.Int32 DISPOSEID { get; set; }
        [DataMember] public System.DateTime DISPOSEDATE { get; set; }
        [DataMember] public System.String WAREHOUSEORCENTERYN { get; set; }
        [DataMember] public System.Int32 WAREHOUSECENTERID { get; set; }
        [DataMember]
        public System.String WAREHOUSEORCENTERNAME { get; set; }
        [DataMember]
        public System.String WAREHOUSEORCENTER { get; set; }
        [DataMember] public System.Int32 STOREID { get; set; }
        [DataMember] public System.String REFNO { get; set; }
        [DataMember] public System.String REMARKS { get; set; }
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember] public System.String ISDIRECTDISPOSEYN { get; set; }
        [DataMember] public System.String DISPOSECODE { get; set; }


        [DataMember]        public System.DateTime STARTDATE { get; set; }
        [DataMember]        public System.DateTime ENDDATE { get; set; }

        public DisposeMaster() { }
        public DisposeMaster(DataRow objectRow)
        {
            if (objectRow["DISPOSEID"] != DBNull.Value) this.DISPOSEID = Convert.ToInt32(objectRow["DISPOSEID"]);
            if (objectRow["DISPOSEDATE"] != DBNull.Value) this.DISPOSEDATE = Convert.ToDateTime(objectRow["DISPOSEDATE"]);
            this.WAREHOUSEORCENTERYN = objectRow["WAREHOUSEORCENTERYN"] as System.String;
            if (objectRow["WAREHOUSECENTERID"] != DBNull.Value) this.WAREHOUSECENTERID = Convert.ToInt32(objectRow["WAREHOUSECENTERID"]);
            this.WAREHOUSEORCENTERNAME = objectRow["WAREHOUSEORCENTERNAME"] as System.String;
            this.WAREHOUSEORCENTER = objectRow["WAREHOUSEORCENTER"] as System.String;
            if (objectRow["STOREID"] != DBNull.Value) this.STOREID = Convert.ToInt32(objectRow["STOREID"]);
            this.REFNO = objectRow["REFNO"] as System.String;
            this.REMARKS = objectRow["REMARKS"] as System.String;
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
            this.ISDIRECTDISPOSEYN = objectRow["ISDIRECTDISPOSEYN"] as System.String;
            this.DISPOSECODE = objectRow["DISPOSECODE"] as System.String;
        }
    }
}