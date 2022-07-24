using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class CenterSubType
    {
        [DataMember] public System.Int32 CENTERSUBTYPEID { get; set; }
        [DataMember] public System.String CENTERSUBTYPENAME { get; set; }

        public CenterSubType() { }
        public CenterSubType(DataRow objectRow)
        {
            if (objectRow["CENTERSUBTYPEID"] != DBNull.Value) this.CENTERSUBTYPEID = Convert.ToInt32(objectRow["CENTERSUBTYPEID"]);
            this.CENTERSUBTYPENAME = objectRow["CENTERSUBTYPENAME"] as System.String;
        }
    }
}