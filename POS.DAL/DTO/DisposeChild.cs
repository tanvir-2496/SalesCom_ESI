using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class DisposeChild
    {
        [DataMember] public System.Int32 DISPOSEID { get; set; }
        [DataMember] public System.Int32 CHILDID { get; set; }
        [DataMember] public System.Int32 PRODUCTID { get; set; }
        [DataMember] public System.Decimal QTY { get; set; }
        [DataMember] public System.String SIMSTART { get; set; }
        [DataMember] public System.String SIMEND { get; set; }
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }

        public DisposeChild() { }
        public DisposeChild(DataRow objectRow)
        {
            if (objectRow["DISPOSEID"] != DBNull.Value) this.DISPOSEID = Convert.ToInt32(objectRow["DISPOSEID"]);
            if (objectRow["CHILDID"] != DBNull.Value) this.CHILDID = Convert.ToInt32(objectRow["CHILDID"]);
            if (objectRow["PRODUCTID"] != DBNull.Value) this.PRODUCTID = Convert.ToInt32(objectRow["PRODUCTID"]);
            if (objectRow["QTY"] != DBNull.Value) this.QTY = Convert.ToDecimal(objectRow["QTY"]);
            if (objectRow["SIMSTART"] != DBNull.Value) this.SIMSTART = objectRow["SIMSTART"].ToString();
            if (objectRow["SIMEND"] != DBNull.Value) this.SIMEND = objectRow["SIMEND"].ToString();
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
        }
    }
}