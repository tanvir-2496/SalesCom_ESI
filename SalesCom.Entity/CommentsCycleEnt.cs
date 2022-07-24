using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class CommentsCycleEnt
    {
        public string CycleId { get; set; }
        public string Comments { get; set; }

        public CommentsCycleEnt() { }

        public CommentsCycleEnt(DataRow dr)
        {
            //if (dr["CycleId"] != DBNull.Value) { CycleId = Convert.ToInt32(dr["CycleId"]); }
            CycleId = dr["CycleId"] as String;
            Comments = dr["Comments"] as String;
        }
    }
}
