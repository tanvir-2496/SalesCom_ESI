using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class ProductVatChallan
    {
        [DataMember] public System.Int32 VATCHALLANID { get; set; }        
        [DataMember] public System.Int32 PRODUCTID { get; set; }    
        [DataMember] public System.DateTime CREATEDATE { get; set; }
        [DataMember] public System.String LASTUPDATEBY { get; set; }
        [DataMember] public System.DateTime LASTUPDATEDATE { get; set; }        
        [DataMember] public System.String CREATEBYUSER { get; set; }
        [DataMember] public System.Decimal FACEVALUE { get; set; }
        [DataMember] public System.Decimal SDRATE { get; set; }
        [DataMember] public System.Decimal VATRATE { get; set; }
        [DataMember] public System.Int32 VATPOLICYID { get; set; }
        [DataMember] public System.Decimal ASSVALUE { get; set; }        
        [DataMember] public System.String PRODUCTNAME { get; set; }
        [DataMember] public System.String ISINCUSIVE { get; set; }
        
      
        public ProductVatChallan() { }
        public ProductVatChallan(DataRow objectRow)
        {
            if (objectRow["VATCHALLANID"] != DBNull.Value) this.VATCHALLANID = Convert.ToInt32(objectRow["VATCHALLANID"]);
            this.PRODUCTNAME = objectRow["PRODUCTNAME"] as System.String;
            if (objectRow["PRODUCTID"] != DBNull.Value) this.PRODUCTID = Convert.ToInt32(objectRow["PRODUCTID"]);
            if (objectRow["CREATEDATE"] != DBNull.Value) this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
            this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
            if (objectRow["LASTUPDATEDATE"] != DBNull.Value) this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
            this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
            if (objectRow["FACEVALUE"] != DBNull.Value) this.FACEVALUE = Convert.ToDecimal(objectRow["FACEVALUE"]);
            if (objectRow["SDRATE"] != DBNull.Value) this.SDRATE = Convert.ToDecimal(objectRow["SDRATE"]);
            if (objectRow["VATRATE"] != DBNull.Value) this.VATRATE = Convert.ToDecimal(objectRow["VATRATE"]);
            if (objectRow["VATPOLICYID"] != DBNull.Value) this.VATPOLICYID = Convert.ToInt32(objectRow["VATPOLICYID"]);
            if (objectRow["ASSVALUE"] != DBNull.Value) this.ASSVALUE = Convert.ToDecimal(objectRow["ASSVALUE"]);
            this.ISINCUSIVE = objectRow["ISINCUSIVE"] as System.String;
           
        }
    }
}
