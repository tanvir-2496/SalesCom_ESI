using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class ShopCalender
    {
        [DataMember] public System.DateTime CALENDERDATE { get; set; }
        [DataMember] public System.Int32 CENTERID { get; set; }
        [DataMember] public System.String STATUS { get; set; }
        [DataMember] public System.DateTime OPENINGTIME { get; set; }
        [DataMember] public System.DateTime CLOSINGTIME { get; set; }
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember] public System.DateTime FROMDATE{ get; set; }
        [DataMember] public System.DateTime TODATE { get; set; }
        [DataMember] public System.String CENTERCODE { get; set; }
        [DataMember] public System.String CENTERNAME { get; set; }
        public ShopCalender() { }
        public ShopCalender(DataRow objectRow)
        {
            if (objectRow["CALENDERDATE"] != DBNull.Value) this.CALENDERDATE = Convert.ToDateTime(objectRow["CALENDERDATE"]);
            if (objectRow["CENTERID"] != DBNull.Value) this.CENTERID = Convert.ToInt32(objectRow["CENTERID"]);
            this.STATUS = objectRow["STATUS"] as System.String;
            if (objectRow["OPENINGTIME"] != DBNull.Value) this.OPENINGTIME = Convert.ToDateTime(objectRow["OPENINGTIME"]);
            if (objectRow["CLOSINGTIME"] != DBNull.Value) this.CLOSINGTIME = Convert.ToDateTime(objectRow["CLOSINGTIME"]);
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            this.CENTERCODE = objectRow["CENTERCODE"] as System.String;
            this.CENTERNAME = objectRow["CENTERNAME"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
        }
    }
}