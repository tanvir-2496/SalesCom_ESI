using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class LevelCollectionEnt
    {
        public int LevelCollectionId { get; set; }
        public string Name { get; set; }

        public LevelCollectionEnt() { }

        public LevelCollectionEnt(DataRow dr)
        {
            if (dr["LevelCollectionid"] != DBNull.Value) { this.LevelCollectionId = Convert.ToInt32(dr["LevelCollectionid"]); }
            this.Name = dr["Name"] as String;
        }
    }
}
