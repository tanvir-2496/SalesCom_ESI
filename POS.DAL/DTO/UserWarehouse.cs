using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]
    public class UserWarehouse
    {
        [DataMember]  public System.Decimal USERID { get; set; }
        [DataMember]  public System.String USERNAME { get; set; }
        [DataMember]  public System.Decimal WAREHOUSEID { get; set; }
        [DataMember]  public System.String WAREHOUSECODE { get; set; }
        [DataMember]  public System.String WAREHOUSENAME { get; set; }
        
      public  UserWarehouse(){}
      public UserWarehouse(DataRow objectRow)
        {
            if (objectRow["USERID"] != DBNull.Value) this.USERID = Convert.ToDecimal(objectRow["USERID"]);
            this.USERNAME = objectRow["USERNAME"] as System.String;
            if (objectRow["WAREHOUSEID"] != DBNull.Value) this.WAREHOUSEID = Convert.ToDecimal(objectRow["WAREHOUSEID"]);
            this.WAREHOUSECODE = objectRow["WAREHOUSECODE"] as System.String;
            this.WAREHOUSENAME = objectRow["WAREHOUSENAME"] as System.String;
           
       }
    }
}
