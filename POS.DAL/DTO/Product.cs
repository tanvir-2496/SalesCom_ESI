using System; 
using System.Runtime.Serialization;
using System.Data;
namespace POS.DAL
{

    [DataContract] public class Product
    {
        [DataMember] public System.Int32 PRODUCTID { get; set; }
        [DataMember] public System.String PRODUCTCODE { get; set; }
        [DataMember] public System.String PRODUCTNAME { get; set; }
        [DataMember] public System.Int32 SUBCATEGORYID { get; set; }
        [DataMember] public System.String INVENTORYYN { get; set; }
        [DataMember] public System.String SERIALIZEDYN { get; set; }
        [DataMember] public System.String ISSALEABLEYN { get; set; }
        [DataMember] public System.String ISSERVICEYN { get; set; }
        [DataMember] public System.String ENABLEDYN { get; set; }
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }
        [DataMember] public System.String ENABLEORDISABLEBY { get; set; }
        [DataMember] public System.DateTime ENABLEORDISABLEDATE { get; set; }
        [DataMember] public System.String SUBCATEGORYNAME { get; set; }
        [DataMember] public System.String CATEGORYNAME { get; set; }
        [DataMember] public System.String ISDELIVEREDBYWAREHOUSE { get; set; }
        [DataMember] public System.Int32 PRODFAMILYID { get; set; }
        [DataMember] public System.String ISMSISDNMANDATORYYN { get; set; }
        [DataMember] public System.Int32 SIMTYPE { get; set; }
        [DataMember] public System.String DESCRIPTION { get; set; }

        

        public Product() { }
        public Product(DataRow objectRow)
        {
     
            if (objectRow["PRODUCTID"] != DBNull.Value) this.PRODUCTID = Convert.ToInt32(objectRow["PRODUCTID"]);
            this.PRODUCTCODE = objectRow["PRODUCTCODE"] as System.String;
            this.PRODUCTNAME = objectRow["PRODUCTNAME"] as System.String;
            if (objectRow["SUBCATEGORYID"] != DBNull.Value) this.SUBCATEGORYID = Convert.ToInt32(objectRow["SUBCATEGORYID"]);
            this.INVENTORYYN = objectRow["INVENTORYYN"] as System.String;
            this.SERIALIZEDYN = objectRow["SERIALIZEDYN"] as System.String;
            this.ISSERVICEYN = objectRow["ISSERVICEYN"] as System.String;
            this.ISSALEABLEYN = objectRow["ISSALEABLEYN"] as System.String;
            this.ENABLEDYN = objectRow["ENABLEDYN"] as System.String;
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
            this.ENABLEORDISABLEBY = objectRow["ENABLEORDISABLEBY"] as System.String;
            this.ISMSISDNMANDATORYYN = objectRow["ISMSISDNMANDATORYYN"] as System.String;
            if (objectRow["ENABLEORDISABLEDATE"] != DBNull.Value) this.ENABLEORDISABLEDATE = Convert.ToDateTime(objectRow["ENABLEORDISABLEDATE"]);
            try
            {
                if (objectRow["SUBCATEGORYNAME"] != DBNull.Value) this.SUBCATEGORYNAME = objectRow["SUBCATEGORYNAME"] as System.String;
                if (objectRow["CATEGORYNAME"] != DBNull.Value) this.CATEGORYNAME = objectRow["CATEGORYNAME"] as System.String;
            }
            catch { }
            this.ISDELIVEREDBYWAREHOUSE = objectRow["ISDELIVEREDBYWAREHOUSE"] as System.String;


            if (objectRow["PRODFAMILYID"] != DBNull.Value) this.PRODFAMILYID = Convert.ToInt32(objectRow["PRODFAMILYID"]);
            if (objectRow["SIMTYPE"] != DBNull.Value) this.SIMTYPE = Convert.ToInt32(objectRow["SIMTYPE"]);

            this.DESCRIPTION = objectRow["DESCRIPTION"] as System.String;
        }
    }
}