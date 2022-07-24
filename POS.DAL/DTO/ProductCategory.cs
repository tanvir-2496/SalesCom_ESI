using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class ProductCategory
    {
        [DataMember] public System.Int32 CATEGORYID { get; set; }
        [DataMember] public System.String CATEGORYNAME { get; set; }
        [DataMember] public System.String CREATEDBY { get; set; }
        [DataMember] public System.DateTime CREATEDDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember] public System.Int32 PRODFAMILYID { get; set; }
         [DataMember] public System.String PFCODE { get; set; }
         

        public ProductCategory() { }
        public ProductCategory(DataRow objectRow)
        {
            if (objectRow["CATEGORYID"] != DBNull.Value) this.CATEGORYID = Convert.ToInt32(objectRow["CATEGORYID"]);
            this.CATEGORYNAME = objectRow["CATEGORYNAME"] as System.String;
            this.PFCODE = objectRow["PFCODE"] as System.String;
            if (objectRow["PRODFAMILYID"] != DBNull.Value) this.PRODFAMILYID = Convert.ToInt32(objectRow["PRODFAMILYID"]);

            this.CREATEDBY = objectRow["CREATEDBY"] as System.String;
            if (objectRow["CREATEDDATE"] != DBNull.Value) this.CREATEDDATE = Convert.ToDateTime(objectRow["CREATEDDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
        }
    }
}