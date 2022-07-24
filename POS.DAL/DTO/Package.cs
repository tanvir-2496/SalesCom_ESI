using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class Package
    {
        [DataMember]
        public System.Int32 PACKAGEID { get; set; }

        [DataMember]
        public System.String PACKAGENAME { get; set; }
        public Package() { }
        public Package(DataRow objectRow)
        {
            
            if (objectRow["PACKAGEID"] != DBNull.Value) this.PACKAGEID = Convert.ToInt32(objectRow["PACKAGEID"]);
            this.PACKAGENAME = objectRow["PACKAGENAME"] as String;
        }
    }
}