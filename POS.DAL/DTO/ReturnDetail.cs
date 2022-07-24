using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class ReturnDetail
    {
        [DataMember] public System.Int32 RETURNID { get; set; }
        [DataMember] public System.Int32 PRODUCTID { get; set; }
        [DataMember] public System.Int32 RETURNQTY { get; set; }
        [DataMember] public System.String RFNO { get; set; }
        [DataMember] public System.String PRODUCTNAME { get; set; }
        [DataMember] public System.Int32 PROMOTIONCYCLEID { get; set; }
        public ReturnDetail() { }
        public ReturnDetail(DataRow objectRow)
        {
            if (objectRow["RETURNID"] != DBNull.Value) this.RETURNID = Convert.ToInt32(objectRow["RETURNID"]);
            if (objectRow["PRODUCTID"] != DBNull.Value) this.PRODUCTID = Convert.ToInt32(objectRow["PRODUCTID"]);
            if (objectRow["RETURNQTY"] != DBNull.Value) this.RETURNQTY = Convert.ToInt32(objectRow["RETURNQTY"]);
            this.RFNO = objectRow["RFNO"] as String;
            try
            {
                this.PRODUCTNAME = objectRow["PRODUCTNAME"] as String;
            }
            catch { }
        }
    }
}