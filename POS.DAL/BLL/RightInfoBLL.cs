using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Collections.Generic;
using POS.DAL;

namespace POS.BLL
{
    public class RightInfoBLL
    {
        public static List<RightInfo> getUserRightInfoByGroup(int groupId)
        {
            return DAL_RIGHTINFO.GetItemList(-1,groupId);
        }
    }
}
