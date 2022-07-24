using System;
using System.Runtime.Serialization;
using System.Data;

namespace POS.DAL
{
    [DataContract] 
    public class UserLoginLog
    {
        [DataMember]
        public System.Int32 ID { get; set; }
        [DataMember]
        public System.String LOGINNAME { get; set; }
        [DataMember]
        public System.DateTime LOGINGTIME { get; set; }
        [DataMember]
        public System.String MACHINENAME { get; set; }

        public UserLoginLog() { }
    }
}
