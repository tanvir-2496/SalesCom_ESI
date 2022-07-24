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
    public class UserGroupBLL
    {
        public static int Add(UserGroup newUserGroup)
        {
            return     DAL_USERGROUP.SaveItem(newUserGroup, "I");
          
        }
        public static int Edit(UserGroup UserGroup)
        {
            return DAL_USERGROUP.SaveItem(UserGroup, "U");
            
        }
        public static int Delete(int UserGroupId)
        {
            UserGroup UserGroup = new UserGroup();
            UserGroup.USERGROUPID = UserGroupId;
            return DAL_USERGROUP.SaveItem(UserGroup, "D");
            
        }
        public static List<UserGroup> getUserGroups()
        {
            return DAL_USERGROUP.GetItemList(-1);
        }

        public static UserGroup getUserGroupById(int id)
        {

            List<UserGroup> UserGroups = DAL_USERGROUP.GetItemList(id);
            if (UserGroups.Count == 1)
            {
                return UserGroups[0];
            }

            return new UserGroup();

        }

    }
}
