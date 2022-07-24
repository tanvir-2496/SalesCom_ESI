using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class LevelDetailList
    {
        public int DetailId { get; set; }
        public string TableName { get; set; }
        public string LevelName { get; set; }

        public LevelDetailList() { }

        public LevelDetailList(DataRow dr)
        {
            if (dr["ID"] != DBNull.Value) { this.DetailId = Convert.ToInt32(dr["Id"]); }
            this.TableName = dr["TableName"] as String;
            this.LevelName = dr["LevelName"] as String;
        }
    }
}
