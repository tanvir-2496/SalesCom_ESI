using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class CustomerType
    {
        [DataMember] public System.Int32 CustomerTYPEID { get; set; }
        [DataMember] public System.String CustomerTYPENAME { get; set; }

        public CustomerType() { }
        public CustomerType(DataRow objectRow)
        {
            if (objectRow["CustomerTYPEID"] != DBNull.Value) this.CustomerTYPEID = Convert.ToInt32(objectRow["CustomerTYPEID"]);
            this.CustomerTYPENAME = objectRow["CustomerTYPENAME"] as System.String;
        }
    }
}