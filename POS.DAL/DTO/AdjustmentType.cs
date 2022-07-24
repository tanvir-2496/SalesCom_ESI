using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class AdjustmentType
    {
        [DataMember] public System.Int32 ADJUSTMENTTYPEID { get; set; }
        [DataMember] public System.String ADJUSTMENTTYPENAME { get; set; }

        public AdjustmentType() { }
        public AdjustmentType(DataRow objectRow)
        {
            if (objectRow["ADJUSTMENTTYPEID"] != DBNull.Value) this.ADJUSTMENTTYPEID = Convert.ToInt32(objectRow["ADJUSTMENTTYPEID"]);
            this.ADJUSTMENTTYPENAME = objectRow["ADJUSTMENTTYPENAME"] as System.String;
        }
    }
}
