using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using POS.DAL;
using System.Collections.Generic;

namespace POS.BLL
{
    public class RoleGroupBLL
    {
        public static int Add(RoleGroup newRoleGroup)
        {
            return DAL_ROLEGROUP.SaveItem(newRoleGroup, "I");
           
        }
        public static int Edit(RoleGroup roleGroup)
        {
            return DAL_ROLEGROUP.SaveItem(roleGroup, "U");
            
        }
        public static int Delete(int RoleGroupId)
        {
            RoleGroup roleGroup = new RoleGroup();
            roleGroup.ROLEGROUPID = RoleGroupId;
            return DAL_ROLEGROUP.SaveItem(roleGroup, "D");
          
        }
        public static List<RoleGroup> getRoleGroups()
        {
            return DAL_ROLEGROUP.GetItemList(-1);
        }

        public static RoleGroup getRoleGroupById(int id)
        {

            List<RoleGroup> roleGroups = DAL_ROLEGROUP.GetItemList(id);
            if (roleGroups.Count == 1)
            {
                return roleGroups[0];
            }

            return new RoleGroup();

        }

    }
}
