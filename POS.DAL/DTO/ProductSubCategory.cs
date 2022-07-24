using System; using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class ProductSubCategory
    {
        [DataMember] public System.Int32 CATEGORYID { get; set; }
        [DataMember] public System.Int32 SUBCATEGORYID { get; set; }
        [DataMember] public System.String SUBCATEGORYNAME { get; set; }
        [DataMember] public System.String CREATEDBY { get; set; }
        [DataMember] public System.DateTime CREATEDDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember] public System.String CATEGORYNAME { get; set; }
        public ProductSubCategory() { }
        public ProductSubCategory(DataRow objectRow)
        {
            if (objectRow["CATEGORYID"] != DBNull.Value) this.CATEGORYID = Convert.ToInt32(objectRow["CATEGORYID"]);
            if (objectRow["SUBCATEGORYID"] != DBNull.Value) this.SUBCATEGORYID = Convert.ToInt32(objectRow["SUBCATEGORYID"]);
            this.SUBCATEGORYNAME = objectRow["SUBCATEGORYNAME"] as System.String;
            this.CATEGORYNAME = objectRow["CATEGORYNAME"] as System.String;
            this.CREATEDBY = objectRow["CREATEDBY"] as System.String;
            if (objectRow["CREATEDDATE"] != DBNull.Value) this.CREATEDDATE = Convert.ToDateTime(objectRow["CREATEDDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
        }
    }
}