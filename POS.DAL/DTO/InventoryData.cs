using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Data;
using System.Runtime.Serialization;

namespace POS.DAL
{
    [DataContract]public class InventoryData
    {
        [DataMember]
        public int INVENTORYDATAID { get; set; }

        [DataMember]
        public DateTime TRANSACTIONDATE { get; set; }

        [DataMember]
        public int PRODUCTID { get; set; }

        [DataMember]
        public string PRODUCTNAME { get; set; }

        [DataMember]
        public int STOREID { get; set; }

        [DataMember]
        public string STORENAME { get; set; }

        [DataMember]
        public string SIMSTART { get; set; }

        [DataMember]
        public string SIMEND { get; set; }

        [DataMember]
        public string RECORDSTATUS { get; set; }

        [DataMember]
        public string CREATEBYUSER { get; set; }

        [DataMember]
        public string CREATEDATE { get; set; }

        [DataMember]
        public int WAREHOUSECENTERID { get; set; }

        [DataMember]
        public string WAREHOUSECENTER { get; set; }

        [DataMember]
        public string WAREHOUSECENTERYN { get; set; }

        [DataMember]
        public string REMARKS { get; set; }


        public InventoryData() { }

        public InventoryData(DataRow datarow)
        {
            if (datarow["INVENTORYDATAID"] != DBNull.Value)
                this.INVENTORYDATAID = int.Parse(datarow["INVENTORYDATAID"].ToString());
            
            if (datarow["TRANSACTIONDATE"] != DBNull.Value)
                this.TRANSACTIONDATE = DateTime.Parse(datarow["TRANSACTIONDATE"].ToString());

            if (datarow["PRODUCTID"] != DBNull.Value)
                this.PRODUCTID = int.Parse(datarow["PRODUCTID"].ToString());

            if (datarow["STOREID"] != DBNull.Value)
                this.STOREID = int.Parse(datarow["STOREID"].ToString());

            if (datarow["SIMSTART"] != DBNull.Value)
                this.SIMSTART = datarow["SIMSTART"].ToString();

            if (datarow["SIMEND"] != DBNull.Value)
                this.SIMEND = datarow["SIMEND"].ToString();

            if (datarow["RECORDSTATUS"] != DBNull.Value)
                this.RECORDSTATUS = datarow["RECORDSTATUS"].ToString();

            if (datarow["CREATEBYUSER"] != DBNull.Value)
                this.CREATEBYUSER = datarow["CREATEBYUSER"].ToString();

            if (datarow["CREATEDATE"] != DBNull.Value)
                this.CREATEDATE = datarow["CREATEDATE"].ToString();

            if (datarow["WAREHOUSECENTERID"] != DBNull.Value)
                this.WAREHOUSECENTERID = int.Parse(datarow["WAREHOUSECENTERID"].ToString());

            if (datarow["WAREHOUSECENTERYN"] != DBNull.Value)
                this.WAREHOUSECENTERYN = datarow["WAREHOUSECENTERYN"].ToString();

            if (datarow["PRODUCTNAME"] != DBNull.Value)
                this.PRODUCTNAME = datarow["PRODUCTNAME"].ToString();

            if (datarow["STORENAME"] != DBNull.Value)
                this.STORENAME = datarow["STORENAME"].ToString();

            if (datarow["WAREHOUSECENTER"] != DBNull.Value)
                this.WAREHOUSECENTER = datarow["WAREHOUSECENTER"].ToString();

            if (datarow["REMARKS"] != DBNull.Value)
                REMARKS = datarow["REMARKS"].ToString();
        }
    }
}
