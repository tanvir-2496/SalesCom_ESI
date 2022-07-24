using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class Region
    {
        [DataMember] public System.Int32 REGIONID { get; set; }
        [DataMember] public System.String REGIONCODE { get; set; }
        [DataMember] public System.String REGIONNAME { get; set; }

        public Region() { }
        public Region(DataRow objectRow)
        {
            if (objectRow["REGIONID"] != DBNull.Value) this.REGIONID = Convert.ToInt32(objectRow["REGIONID"]);
            this.REGIONCODE = objectRow["REGIONCODE"] as System.String;
            this.REGIONNAME = objectRow["REGIONNAME"] as System.String;
        }
    }
}