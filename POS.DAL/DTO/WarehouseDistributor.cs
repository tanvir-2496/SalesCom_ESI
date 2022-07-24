using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data;

namespace POS.DAL
{
    [DataContract]
    public class WarehouseDistributor
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int WAREHOUSEID { get; set; }

        [DataMember]
        public int DISTRIBUTORID { get; set; }

        [DataMember]
        public string DISTRIBUTORNAME { get; set; }

        [DataMember]
        public string DISTRIBUTORCODE { get; set; }

        public WarehouseDistributor() { }

        public WarehouseDistributor(DataRow row)
        {
            if (row["ID"] != DBNull.Value) ID = int.Parse(row["ID"].ToString());

            if (row["WAREHOUSEID"] != DBNull.Value) WAREHOUSEID =int.Parse(row["WAREHOUSEID"].ToString());

            if (row["DISTRIBUTORID"] != DBNull.Value) DISTRIBUTORID =int.Parse(row["DISTRIBUTORID"].ToString());

            if (row["DISTRIBUTORNAME"] != DBNull.Value) DISTRIBUTORNAME = row["DISTRIBUTORNAME"].ToString();

            if (row["DISTRIBUTORCODE"] != DBNull.Value) DISTRIBUTORCODE = row["DISTRIBUTORCODE"].ToString();
            
        }

    }

}
