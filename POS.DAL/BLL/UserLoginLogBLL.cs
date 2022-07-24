using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using POS.DAL;
using System.Collections.Generic;
using System.Security.Principal;

namespace POS.BLL
{
    public class UserLoginLogBLL
    {
        public static int Add(UserLoginLog userLoginLog, UserInfo userInfo, string machineName)
        {
            //WindowsIdentity wi = WindowsIdentity.GetCurrent();

            userLoginLog.LOGINNAME = userInfo.LOGINNAME;
            userLoginLog.LOGINGTIME = DateTime.Now;
            userLoginLog.MACHINENAME = machineName;
            
            int logId = UserLoginLogDAL.SaveItem(userLoginLog, "I");
            return logId;
        }
    }
}
