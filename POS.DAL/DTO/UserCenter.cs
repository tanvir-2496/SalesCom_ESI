using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class UserCenter
    {
        [DataMember] public System.Int32 ENGAGEID { get; set; }
        [DataMember] public System.Int32 CENTERID { get; set; }
        [DataMember] public System.Int32 USERID { get; set; }
        [DataMember] public System.DateTime ENGAMENTDATE { get; set; }
        [DataMember] public System.DateTime RELEASEDATE { get; set; }
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.String UPDATEBY { get; set; }
        [DataMember] public System.DateTime UPDATEDATE { get; set; }

        public UserCenter() { }
        public UserCenter(DataRow objectRow)
        {
            if (objectRow["ENGAGEID"] != DBNull.Value) this.ENGAGEID = Convert.ToInt32(objectRow["ENGAGEID"]);
            if (objectRow["CENTERID"] != DBNull.Value) this.CENTERID = Convert.ToInt32(objectRow["CENTERID"]);
            if (objectRow["USERID"] != DBNull.Value) this.USERID = Convert.ToInt32(objectRow["USERID"]);
            if (objectRow["ENGAMENTDATE"] != DBNull.Value) this.ENGAMENTDATE = Convert.ToDateTime(objectRow["ENGAMENTDATE"]);
            if (objectRow["RELEASEDATE"] != DBNull.Value) this.RELEASEDATE = Convert.ToDateTime(objectRow["RELEASEDATE"]);
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            this.UPDATEBY = objectRow["UPDATEBY"] as System.String;
            if (objectRow["UPDATEDATE"] != DBNull.Value) this.UPDATEDATE = Convert.ToDateTime(objectRow["UPDATEDATE"]);
        }
    }
}