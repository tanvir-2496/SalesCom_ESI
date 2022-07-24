using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ErrorMessageEnt
    {
        public int RowNumber { get; set; }
        public string ErrorText { get; set; }
        public string SimNo { get; set; }
        public string MSISDN { get; set; }
        public int RowCount { get; set; }

        public ErrorMessageEnt() { }

        public ErrorMessageEnt(DataRow dr)
        {
            if (DBNull.Value != dr["RowNumber"]) { this.RowNumber = Convert.ToInt32(dr["RowNumber"]); }
            this.ErrorText = dr["ErrorText"] as String;
            if (DBNull.Value != dr["SimNo"]) this.SimNo = dr["SimNo"] as String;
            if (DBNull.Value != dr["MSISDN"]) this.MSISDN = dr["MSISDN"] as String;
        }
    }


    public class CountMessage
    {
        public int RowNumber { get; set; }
        public string ErrorText { get; set; }

        public CountMessage() { }
        public CountMessage(DataRow dr)
        {
            if (DBNull.Value != dr["RowNumber"]) { this.RowNumber = Convert.ToInt32(dr["RowNumber"]); }
            this.ErrorText = dr["ErrorText"] as String;
        }
    }
}
