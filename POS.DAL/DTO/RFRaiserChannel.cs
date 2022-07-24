using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class RFRaiserChannel
    {
        [DataMember] public System.Int32 RFRAISERID { get; set; }
        [DataMember] public System.Int32 CHANNELID { get; set; }

        public RFRaiserChannel() { }
        public RFRaiserChannel(DataRow objectRow)
        {
            if (objectRow["RFRAISERID"] != DBNull.Value) this.RFRAISERID = Convert.ToInt32(objectRow["RFRAISERID"]);
            if (objectRow["CHANNELID"] != DBNull.Value) this.CHANNELID = Convert.ToInt32(objectRow["CHANNELID"]);
        }
    }
}