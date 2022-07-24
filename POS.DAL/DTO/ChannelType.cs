using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class ChannelType
    {
        [DataMember] public System.Int32 CHANNELTYPEID { get; set; }
        [DataMember] public System.String CHANNELTYPENAME { get; set; }

        public ChannelType() { }
        public ChannelType(DataRow objectRow)
        {
            if (objectRow["CHANNELTYPEID"] != DBNull.Value) this.CHANNELTYPEID = Convert.ToInt32(objectRow["CHANNELTYPEID"]);
            this.CHANNELTYPENAME = objectRow["CHANNELTYPENAME"] as System.String;
        }
    }
}