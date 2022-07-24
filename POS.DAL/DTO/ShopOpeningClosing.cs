using System; using System.Runtime.Serialization; 
using System.Data;
namespace POS.DAL
{
    [DataContract] public class ShopOpeningClosing
    {
        [DataMember] public System.Int32 SHOPOPENCLOSEID { get; set; }
        [DataMember] public System.Int32 CENTERID { get; set; }
        [DataMember] public System.DateTime WORKINGDATE { get; set; }
        [DataMember] public System.DateTime OPENINGTIME { get; set; }
        [DataMember] public System.DateTime CLOSINGTIME { get; set; }
        [DataMember] public System.String OPENEDBYUSER { get; set; }
        [DataMember] public System.String CLOSEDBYUSER { get; set; }
        [DataMember] public System.String REOPENBY { get; set; }
        [DataMember] public System.String CENTERNAME { get; set; }

        public ShopOpeningClosing() { }
        public ShopOpeningClosing(DataRow objectRow)
        {
            if (objectRow["SHOPOPENCLOSEID"] != DBNull.Value) this.SHOPOPENCLOSEID = Convert.ToInt32(objectRow["SHOPOPENCLOSEID"]);
            if (objectRow["CENTERID"] != DBNull.Value) this.CENTERID = Convert.ToInt32(objectRow["CENTERID"]);
            if (objectRow["WORKINGDATE"] != DBNull.Value) this.WORKINGDATE = Convert.ToDateTime(objectRow["WORKINGDATE"]);
            if (objectRow["OPENINGTIME"] != DBNull.Value) this.OPENINGTIME = Convert.ToDateTime(objectRow["OPENINGTIME"]);
            if (objectRow["CLOSINGTIME"] != DBNull.Value) this.CLOSINGTIME = Convert.ToDateTime(objectRow["CLOSINGTIME"]);
            this.OPENEDBYUSER = objectRow["OPENEDBYUSER"] as System.String;
            this.CLOSEDBYUSER = objectRow["CLOSEDBYUSER"] as System.String;
            this.REOPENBY = objectRow["REOPENBY"] as System.String;
            this.CENTERNAME = objectRow["CENTERNAME"] as System.String;
        }
    }
}
