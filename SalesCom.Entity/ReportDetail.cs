using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class ReportDetail
    {

        public string TableName { get; set; }
        public string LevelName { get; set; }

        public ReportDetail()
        {
        }

        public ReportDetail(DataRow dr)
        {
            this.TableName = dr["TableName"].ToString();
            this.LevelName = dr["LevelName"].ToString();
            
        }
    }

   
}
