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
    public class RoleInfoBLL
    {
        public static int Add(RoleInfo newRoleInfo)
        {
            return DAL_ROLEINFO.SaveItem(newRoleInfo, "I");
          
        }
        public static int Edit(RoleInfo roleInfo)
        {
            return DAL_ROLEINFO.SaveItem(roleInfo, "U");
            
        }
        public static int Delete(int RoleInfoId)
        {
            
            //delete all rights associate with this role
         //   RoleRightBLL.DeleteByRoleId(RoleInfoId, "");
            
            
            RoleInfo roleInfo = new RoleInfo();
            roleInfo.ROLEID = RoleInfoId;



            return  DAL_ROLEINFO.SaveItem(roleInfo, "D");
          
        }
        public static List<RoleInfo> getRoleInfos()
        {
            return DAL_ROLEINFO.GetItemList(-1);
        }

        public static RoleInfo getRoleInfoById(int id)
        {

            List<RoleInfo> roleInfos = DAL_ROLEINFO.GetItemList(id);
            if (roleInfos.Count == 1)
            {
                return roleInfos[0];
            }

            return new RoleInfo();

        }

    }
}
