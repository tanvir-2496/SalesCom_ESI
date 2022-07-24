using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class SalesReturnMaster
    {
        [DataMember] public System.Int32 SALESRETURNID { get; set; }
        [DataMember] public System.String SALESRETURNCODE { get; set; }
        [DataMember] public System.DateTime SALESRETURNDATE { get; set; }
        [DataMember] public System.Int32 CUSTOMERID { get; set; }
        [DataMember] public System.String REFNO { get; set; }
        [DataMember] public System.String REMARKS { get; set; }
        [DataMember] public System.Int32 CENTERID { get; set; }
        [DataMember] public System.Int32 STOREID { get; set; }
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }

        public SalesReturnMaster() { }
        public SalesReturnMaster(DataRow objectRow)
        {
            if (objectRow["SALESRETURNID"] != DBNull.Value) this.SALESRETURNID = Convert.ToInt32(objectRow["SALESRETURNID"]);
            this.SALESRETURNCODE = objectRow["SALESRETURNCODE"] as System.String;
            if (objectRow["SALESRETURNDATE"] != DBNull.Value) this.SALESRETURNDATE = Convert.ToDateTime(objectRow["SALESRETURNDATE"]);
            if (objectRow["CUSTOMERID"] != DBNull.Value) this.CUSTOMERID = Convert.ToInt32(objectRow["CUSTOMERID"]);
            this.REFNO = objectRow["REFNO"] as System.String;
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