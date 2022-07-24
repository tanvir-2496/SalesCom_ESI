using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
  public  class CdpReportEntity
    {
        public string RETAILER_CODE { get; set; }
        public string TOPUP_MSISDN { get; set; }
        public Decimal DISBURSE_AMOUNT { get; set; }
        public DateTime create_date { get; set; }
        public DateTime disburse_date { get; set; }
        public string response_status { get; set; }
        public string report_date { get; set; }


        public CdpReportEntity()
        { }
        public CdpReportEntity(DataRow dr)
        {
            if (dr["RETAILER_CODE"] != DBNull.Value) this.RETAILER_CODE = Convert.ToString(dr["RETAILER_CODE"]);
            if (dr["TOPUP_MSISDN"] != DBNull.Value) this.TOPUP_MSISDN = Convert.ToString(dr["TOPUP_MSISDN"]);
            if (dr["DISBURSE_AMOUNT"] != DBNull.Value) this.DISBURSE_AMOUNT = Convert.ToDecimal(dr["DISBURSE_AMOUNT"]);

            if (dr["generate_date"] != DBNull.Value) this.create_date = Convert.ToDateTime(dr["generate_date"]);
            if (dr["topup_date"] != DBNull.Value) this.disburse_date = Convert.ToDateTime(dr["topup_date"]);
            if (dr["disburse_status"] != DBNull.Value) this.response_status = Convert.ToString(dr["disburse_status"]);
            if (dr["report_date"] != DBNull.Value) this.report_date = Convert.ToString(dr["report_date"]);
            //if (dr["UPDATED_BY"] != DBNull.Value) this.Updated_By = Convert.ToInt32(dr["UPDATED_BY"]);
            //if (dr["UPDATED_DATE"] != DBNull.Value) this.Updated_Date = Convert.ToDateTime(dr["UPDATED_DATE"]);
        }
    }
}
