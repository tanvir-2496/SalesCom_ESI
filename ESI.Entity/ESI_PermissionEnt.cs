using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity
{
    public class ESI_PermissionEnt
    {
        public int numOfPermission { get; set; }
       
        public ESI_PermissionEnt()
        {

        }

        public ESI_PermissionEnt(DataRow dr)
        {
            if (dr["numOfPermission"] != DBNull.Value) { this.numOfPermission = Convert.ToInt32(dr["numOfPermission"]); }
        }
    }
}
