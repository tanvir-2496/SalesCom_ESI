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
    public class UserMasterRoleBLL
    {

        public static int Add(UserMasterRole newUserMasterRole)
        {
            return DAL_USERMASTERROLE.SaveItem(newUserMasterRole, "I");
          
        }
        public static int Edit(UserMasterRole UserMasterRole)
        {
            return DAL_USERMASTERROLE.SaveItem(UserMasterRole, "U");
           
        }
        public static int Delete(int UserInfoId,int UserMasterRoleID)
        {
            UserMasterRole UserMasterRole = new UserMasterRole();
            UserMasterRole.USERID = UserMasterRoleID;
            UserMasterRole.USERID = UserInfoId;
           return DAL_USERMASTERROLE.SaveItem(UserMasterRole, "D");
         
        }
        public static List<UserMasterRole> UserMasterRoleGet(int UserMasterRoleID,int UserInfoID)
        {
           // log.Debug("User Exist");
            return DAL_USERMASTERROLE.GetItemList(UserMasterRoleID, UserInfoID);
        }



       
    }
}
