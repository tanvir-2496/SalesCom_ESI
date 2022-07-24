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
    public class RoleRightBLL
    {
        public static int Add(List<RoleRight> newRoleRights)
        {
            foreach(RoleRight right in newRoleRights)
            {
                DAL_ROLERIGHT.SaveItem(right, "I");
            }
            return 1;

        }

        public static int AddByUserRightGroup(int groupid, int roleId,string createdByUser)
        {

            List<RightInfo> list = RightInfoBLL.getUserRightInfoByGroup(groupid);
            if (list != null)
            {

                foreach (RightInfo right in list)
                {
                    RoleRight newRoleRight = new RoleRight();
                    newRoleRight.RIGHTID = right.RIGHTID;
                    newRoleRight.ROLEID = roleId;
                    newRoleRight.UPDATEBY = createdByUser;
                    DAL_ROLERIGHT.SaveItem(newRoleRight, "I");
                }
            }
            return 1;

        }
    
        public static int DeleteByRoleId(int roleId,string deleteBy)
        {
            RoleRight roleRight = new RoleRight();
            roleRight.ROLEID = roleId;
            roleRight.UPDATEBY = deleteBy;
            return DAL_ROLERIGHT.SaveItem(roleRight, "D");

        }
        public static int DeleteByRoleIdDMS(int roleId, string deleteBy)
        {
            RoleRight roleRight = new RoleRight();
            roleRight.ROLEID = roleId;
            roleRight.UPDATEBY = deleteBy;
            return DAL_ROLERIGHT.SaveItem(roleRight, "DMS");

        }

        public static int CheckPermission(int rightId, int userId)
        {
            List<RoleRight> list = DAL_ROLERIGHT.GetItemList(-1, rightId, userId);
            return (list.Count > 0) ? 1 : 0;
        }
        public static List< RoleRight> getRoleRightByRoleId(int roleId)
        {

           return DAL_ROLERIGHT.GetItemList(roleId,-1,-1);
           
        }

        public static List<RoleRight> getRoleRightByUserId(int userId)
        {

            return DAL_ROLERIGHT.GetItemList(-1, -1, userId);

        }

    }
}
