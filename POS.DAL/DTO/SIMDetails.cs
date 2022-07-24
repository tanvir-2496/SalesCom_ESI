using System; using System.Runtime.Serialization; 
using System.Data;
namespace POS.DAL
{
    
    [DataContract] public class SIMDetails
    {
       [DataMember] public System.String SIM_ST { get; set; }
       [DataMember]    public System.String SIM_EN { get; set; }
       
        public SIMDetails() { }
        public SIMDetails(DataRow objectRow)
        {

            this.SIM_ST = objectRow["SIM_ST"] as System.String;
            this.SIM_EN = objectRow["SIM_EN"] as System.String;
            
        }
    }
}