using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class Channel
    {
        [DataMember] public System.Int32 CHANNELID { get; set; }
        [DataMember] public System.String CHANNELNAME { get; set; }
        [DataMember] public System.Int32 PARENTCHANNELID { get; set; }
        [DataMember] public System.String CHANNELCODE { get; set; }
        [DataMember] public System.String ISLEAF { get; set; }
        [DataMember] public System.Int32 CHANELTYPEID { get; set; }
        [DataMember] public System.String ROOTPATH { get; set; }
        
        public Channel() { }
        public Channel(DataRow objectRow)
        {
            if (objectRow["CHANNELID"] != DBNull.Value) this.CHANNELID = Convert.ToInt32(objectRow["CHANNELID"]);
            this.CHANNELNAME = objectRow["CHANNELNAME"] as System.String;
            this.ROOTPATH = objectRow["ROOTPATH"] as System.String;
            if (objectRow["PARENTCHANNELID"] != DBNull.Value) this.PARENTCHANNELID = Convert.ToInt32(objectRow["PARENTCHANNELID"]);
            this.CHANNELCODE = objectRow["CHANNELCODE"] as System.String;
            this.ISLEAF = objectRow["ISLEAF"] as System.String;
            if (objectRow["CHANELTYPEID"] != DBNull.Value) this.CHANELTYPEID = Convert.ToInt32(objectRow["CHANELTYPEID"]);
        }
    }
}