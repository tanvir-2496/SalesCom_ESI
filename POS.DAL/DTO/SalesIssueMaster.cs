using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class SalesIssueMaster
    {
        [DataMember] public System.Int32 SALESISSUEID { get; set; }
        [DataMember] public System.String SALESISSUECODE { get; set; }
        [DataMember] public System.DateTime SALESISSUEDATE { get; set; }
        [DataMember] public System.Int32 CUSTOMERID { get; set; }
        [DataMember] public System.String INVOICENO { get; set; }
        [DataMember] public System.String REMARKS { get; set; }
        [DataMember] public System.Int32 CENTERID { get; set; }
        [DataMember] public System.Int32 STOREID { get; set; }
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }

        public SalesIssueMaster() { }
        public SalesIssueMaster(DataRow objectRow)
        {
            if (objectRow["SALESISSUEID"] != DBNull.Value) this.SALESISSUEID = Convert.ToInt32(objectRow["SALESISSUEID"]);
            this.SALESISSUECODE = objectRow["SALESISSUECODE"] as System.String;
            if (objectRow["SALESISSUEDATE"] != DBNull.Value) this.SALESISSUEDATE = Convert.ToDateTime(objectRow["SALESISSUEDATE"]);
            if (objectRow["CUSTOMERID"] != DBNull.Value) this.CUSTOMERID = Convert.ToInt32(objectRow["CUSTOMERID"]);
            this.INVOICENO = objectRow["INVOICENO"] as System.String;
            this.REMARKS = objectRow["REMARKS"] as System.String;
            if (objectRow["CENTERID"] != DBNull.Value) this.CENTERID = Convert.ToInt32(objectRow["CENTERID"]);
            if (objectRow["STOREID"] != DBNull.Value) this.STOREID = Convert.ToInt32(objectRow["STOREID"]);
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
        }
    }
}