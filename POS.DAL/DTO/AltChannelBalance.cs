using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data;

namespace POS.DAL
{
    [DataContract]
    public class AltChannelBalance
    {
        [DataMember]
        public string DISTRIBUTORCODE { get; set; }


        [DataMember]
        public decimal AMOUNT { get; set; }

        public AltChannelBalance(DataRow objectRow)
        {
            if (objectRow["DISTRIBUTORCODE"] != DBNull.Value) this.DISTRIBUTORCODE = objectRow["DISTRIBUTORCODE"].ToString();
            if (objectRow["AMOUNT"] != DBNull.Value) this.AMOUNT = Convert.ToDecimal(objectRow["AMOUNT"]);
        }
    }
}
