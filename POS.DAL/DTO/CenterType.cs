using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class CenterType
    {
        [DataMember] public System.Int32 CENTERTYPEID { get; set; }
        [DataMember] public System.String CENTERTYPENAME { get; set; }

        public CenterType() { }
        public CenterType(DataRow objectRow)
        {
            if (objectRow["CENTERTYPEID"] != DBNull.Value) this.CENTERTYPEID = Convert.ToInt32(objectRow["CENTERTYPEID"]);
            this.CENTERTYPENAME = objectRow["CENTERTYPENAME"] as System.String;
        }
    }
}