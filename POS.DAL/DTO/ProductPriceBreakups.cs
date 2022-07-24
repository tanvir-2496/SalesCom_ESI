using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class ProductPriceBreakups
    {
        [DataMember] public System.Int32 BREAKUPMASTERID { get; set; }
        [DataMember] public System.Int32 CHANNELID { get; set; }
        [DataMember] public System.Int32 PRODUCTID { get; set; }
        [DataMember] public System.String ENABLEDYN { get; set; }
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember] public System.String APPROVEDBY { get; set; }
        [DataMember] public System.DateTime APPROVEDDATE { get; set; }
        [DataMember] public System.String DISCACCNO { get; set; }
        [DataMember] public System.String DISCPROJCODE { get; set; }
        [DataMember] public System.String FOCYN { get; set; }
        [DataMember] public System.String ALLOWDISCOUNTYN { get; set; }
        [DataMember]
        public System.String DISCACCNODR { get; set; }
        [DataMember]
        public System.String DISCPROJCODEDR { get; set; }

        public ProductPriceBreakups() { }
        public ProductPriceBreakups(DataRow objectRow)
        {
            if (objectRow["BREAKUPMASTERID"] != DBNull.Value) this.BREAKUPMASTERID = Convert.ToInt32(objectRow["BREAKUPMASTERID"]);
            if (objectRow["CHANNELID"] != DBNull.Value) this.CHANNELID = Convert.ToInt32(objectRow["CHANNELID"]);
            if (objectRow["PRODUCTID"] != DBNull.Value) this.PRODUCTID = Convert.ToInt32(objectRow["PRODUCTID"]);
            this.ENABLEDYN = objectRow["ENABLEDYN"] as System.String;
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
            this.APPROVEDBY = objectRow["APPROVEDBY"] as System.String;
            if (objectRow["APPROVEDDATE"] != DBNull.Value) this.APPROVEDDATE = Convert.ToDateTime(objectRow["APPROVEDDATE"]);
            this.DISCACCNO = objectRow["DISCACCNO"] as System.String;
            this.DISCPROJCODE = objectRow["DISCPROJCODE"] as System.String;
            this.FOCYN = objectRow["FOCYN"] as System.String;
            this.ALLOWDISCOUNTYN = objectRow["ALLOWDISCOUNTYN"] as System.String;
            this.DISCACCNODR = objectRow["DISCACCNODR"] as System.String;
            this.DISCPROJCODEDR = objectRow["DISCPROJCODEDR"] as System.String;
        }
    }
}