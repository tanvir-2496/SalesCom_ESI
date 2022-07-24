using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class SIMType
    {
        [DataMember] public System.Int32 ID { get; set; }
        [DataMember] public System.String NAME { get; set; }

        public SIMType() { }
        public SIMType(DataRow objectRow)
        {
            if (objectRow["ID"] != DBNull.Value) this.ID = Convert.ToInt32(objectRow["ID"]);
            this.NAME = objectRow["NAME"] as System.String;
        }
    }
}