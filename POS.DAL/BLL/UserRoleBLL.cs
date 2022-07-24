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
    public class UserRoleBLL
    {
      
        public static int Add(UserRole newUserRole)
        {
            return DAL_USERROLE.SaveItem(newUserRole, "I");
          
        }
        public static int Edit(UserRole userRole)
        {
            return DAL_USERROLE.SaveItem(userRole, "U");
           
        }
        public static int Delete(int UserInfoId,int UserRoleID)
        {
            UserRole userRole = new UserRole();
            userRole.USERID = UserRoleID;
            userRole.USERID = UserInfoId;
           return DAL_USERROLE.SaveItem(userRole, "D");
         
        }

        public static int UpdateHistory(int UserInfoId, int UserRoleID)
        {
            UserRole userRole = new UserRole();
            userRole.USERID = UserRoleID;
            userRole.USERID = UserInfoId;
            return DAL_USERROLE.SaveItem(userRole, "E");

        }

        public static List<UserRole> UserRoleGet(int UserRoleID,int UserInfoID)
        {
          //  log.Debug("User Exist");
            return DAL_USERROLE.GetItemList(UserRoleID, UserInfoID);
        }



       
    }
}
