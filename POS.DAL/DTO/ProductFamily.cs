using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class ProductFamily
    {
       
        [DataMember] public System.Int32 PFID { get; set; }
        [DataMember] public System.String PFCODE { get; set; }
         

        public ProductFamily() { }
        public ProductFamily(DataRow objectRow)
        {
            if (objectRow["PFID"] != DBNull.Value) this.PFID = Convert.ToInt32(objectRow["PFID"]);
            this.PFCODE = objectRow["PFCODE"] as System.String;
               }
    }
}