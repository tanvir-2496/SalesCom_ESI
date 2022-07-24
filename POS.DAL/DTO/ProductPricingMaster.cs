using System; using System.Runtime.Serialization; 
using System.Data;
namespace POS.DAL
{

[DataContract] public class ProductPricingMaster{
[DataMember] public System.Int32 PRICINGMASTERID{get ; set ;}
[DataMember] public System.Int32 PROMOTIONCYCLEID{get ; set ;}
[DataMember] public System.Int32 PRODUCTID{get ; set ;}
[DataMember] public System.Decimal INVPRICE{get ; set ;}
[DataMember] public System.String CREATEBYUSER{get ; set ;}
[DataMember] public System.DateTime CREATEDATE{get ; set ;}
[DataMember] public System.String LASTUPDATEBY{get ; set ;}
[DataMember] public System.DateTime LASTUPDATEDATE{get ; set ;}
[DataMember] public System.String APPROVEDBY{get ; set ;}
[DataMember] public System.DateTime APPROVEDDATE{get ; set ;}
[DataMember] public System.String AMOUNTISFIXEDYN{get ; set ;}
[DataMember] public System.Decimal MINVAL{get ; set ;}
[DataMember] public System.String APPROVEDYN{get ; set ;}
[DataMember] public System.String PROMOTIONCYCLENAME { get; set; }
[DataMember] public System.String PRODUCTNAME { get; set; }
[DataMember] public System.String PRODUCTCODE { get; set; }

public ProductPricingMaster(){}
public ProductPricingMaster(DataRow objectRow)
{
 if (objectRow["PRICINGMASTERID"] !=DBNull.Value) this.PRICINGMASTERID = Convert.ToInt32(objectRow["PRICINGMASTERID"]);
 if (objectRow["PROMOTIONCYCLEID"] !=DBNull.Value) this.PROMOTIONCYCLEID = Convert.ToInt32(objectRow["PROMOTIONCYCLEID"]);
 if (objectRow["PRODUCTID"] !=DBNull.Value) this.PRODUCTID = Convert.ToInt32(objectRow["PRODUCTID"]);
 if (objectRow["INVPRICE"] != DBNull.Value) this.INVPRICE = Convert.ToDecimal(objectRow["INVPRICE"]);
this.CREATEBYUSER = objectRow["CREATEBYUSER"] as System.String;
 if (objectRow["CREATEDATE"] !=DBNull.Value)this.CREATEDATE = Convert.ToDateTime(objectRow["CREATEDATE"]);
this.LASTUPDATEBY = objectRow["LASTUPDATEBY"] as System.String;
 if (objectRow["LASTUPDATEDATE"] !=DBNull.Value)this.LASTUPDATEDATE = Convert.ToDateTime(objectRow["LASTUPDATEDATE"]);
this.APPROVEDBY = objectRow["APPROVEDBY"] as System.String;
 if (objectRow["APPROVEDDATE"] !=DBNull.Value)this.APPROVEDDATE = Convert.ToDateTime(objectRow["APPROVEDDATE"]);
this.AMOUNTISFIXEDYN = objectRow["AMOUNTISFIXEDYN"] as System.String;
if (objectRow["MINVAL"] != DBNull.Value) this.MINVAL = Convert.ToDecimal(objectRow["MINVAL"]);
this.APPROVEDYN = objectRow["APPROVEDYN"] as System.String;
this.PROMOTIONCYCLENAME = objectRow["PROMOTIONCYCLENAME"] as System.String;
this.PRODUCTNAME = objectRow["PRODUCTNAME"] as System.String;
this.PRODUCTCODE = objectRow["PRODUCTCODE"] as System.String;
}
}}