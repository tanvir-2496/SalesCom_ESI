using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class CommissionReportTargetsEnt
    {

        public string REPORTNAME { get; set; }
        public string CHANNELNAME { get; set; }
        public string CHANNELCODE { get; set; }
        public string EVENTTYPE { get; set; }
        public int TARGETVALUE { get; set; }
        public string IMPORTEDBY { get; set; }
        public DateTime IMPORTDATE { get; set; }

        public string CYCLEDESCRIPTION { get; set; }

        public CommissionReportTargetsEnt() { }

        public CommissionReportTargetsEnt(DataRow dr)
        {
            this.REPORTNAME = dr["REPORTNAME"] as String;
            this.CHANNELNAME = dr["CHANNELNAME"] as String;
            this.EVENTTYPE = dr["EVENTTYPE"] as String;
            if (dr["TARGETVALUE"] != DBNull.Value) { this.TARGETVALUE = Convert.ToInt32(dr["TARGETVALUE"]); }
            this.IMPORTEDBY = dr["IMPORTEDBY"] as String;
            if (dr["IMPORTDATE"] != DBNull.Value) { this.IMPORTDATE = Convert.ToDateTime(dr["IMPORTDATE"]); }
            this.CYCLEDESCRIPTION = dr["CYCLEDESCRIPTION"] as String;
            this.CHANNELCODE = dr["CHANNELCODE"] as String;
        }
    }
}
