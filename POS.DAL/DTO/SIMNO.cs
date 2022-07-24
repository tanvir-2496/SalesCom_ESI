using System; using System.Runtime.Serialization; 
using System.Data;
namespace POS.DAL
{
    
    [DataContract] public class SIMNO
    {
       [DataMember] public System.String SIMNUMBER { get; set; }
       
        public SIMNO() { }
        public SIMNO(DataRow objectRow)
        {

            this.SIMNUMBER = objectRow["SIMNUMBER"] as System.String;
            
        }
    }
}