
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
    public class UserRightGroupBLL
    {

        public static List<UserRightGroup> getUserRightGroups(int groupid)
        {
            return DAL_USERRIGHTGROUP.GetItemList(groupid);
        }

    }
}
