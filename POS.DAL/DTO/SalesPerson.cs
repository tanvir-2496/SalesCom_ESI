using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class SalesPerson
    {
        [DataMember] public System.Int32 SALESPERSONID { get; set; }
        [DataMember] public System.String CODE { get; set; }
        [DataMember] public System.String CONTACTNO { get; set; }
        [DataMember] public System.String NAME { get; set; }
        [DataMember] public System.String ENABLEDYN { get; set; }
        [DataMember] public System.String CREATEDBYUSER { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember] public System.Int32 CENTERID { get; set; }
        [DataMember] public System.String CENTERNAME { get; set; }
        public SalesPerson() { }
        public SalesPerson(DataRow objectRow)
        {
            if (objectRow["SALESPERSONID"] != DBNull.Value) this.SALESPERSONID = Convert.ToInt32(objectRow["SALESPERSONID"]);
            this.CODE = objectRow["CODE"] as System.String;
            this.CONTACTNO = objectRow["CONTACTNO"] as System.String;
            this.NAME = objectRow["NAME"] as System.String;
            this.ENABLEDYN = objectRow["ENABLEDYN"] as System.String;
            this.CREATEDBYUSER = objectRow["CREATEDBYUSER"] as System.String;
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            this.CENTERNAME = objectRow["CENTERNAME"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
            if (objectRow["CENTERID"] != DBNull.Value) this.CENTERID = Convert.ToInt32(objectRow["CENTERID"]);
        }
    }
}