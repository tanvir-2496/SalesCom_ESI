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
    public class UserInfoBLL
    {
        public static int Add(UserInfo newUserInfo)
        {
            int centerId = newUserInfo.CURRENTCENTERID;
            newUserInfo.CURRENTCENTERID = 0;
            newUserInfo.USERCHANGEDPASSYN = "N";

           
                newUserInfo.PASSWORDCHANGEDDATE = DateTime.Now;
            

          
            int userId = DAL_USERINFO.SaveItem(newUserInfo, "I");
            if(userId >0){
                if (centerId > 0)
                {
                    UserCenterBLL.AssignUserToNewCenter(userId, centerId, newUserInfo.LASTUPDATEBY);
                }

            }
            return userId;
        }
        public static int Edit(UserInfo userInfo)
        {
          
            int error = DAL_USERINFO.SaveItem(userInfo, "U");
            return error;
        }
        public static int SavePassword(UserInfo userInfo)
        {
            int error = DAL_USERINFO.SavePassword(userInfo);
            return error;
        }
        public static int Delete(int UserInfoId)
        {
            UserInfo UserInfo = new UserInfo();
            UserRole userRole = new UserRole();
            UserInfo.USERID = UserInfoId;
            userRole.USERID = UserInfoId;
            DAL_USERINFO.SaveItem(UserInfo, "D");
            return DAL_USERROLE.SaveItem(userRole, "D");
        }
        
        public static List<UserInfo> getUserInfos(int USERID, int USERGROUPID, string LOGINNAME, string USERNAME, int CURRENTCENTERID,string LoggedUser ,int STARTROW, int MAXROWS)
        {
            //int USERID, int USERGROUPID, int PAGINGSIZE,int STARTROW
            return DAL_USERINFO.GetItemList(USERID, USERGROUPID, LOGINNAME, USERNAME,LoggedUser,  CURRENTCENTERID, STARTROW, MAXROWS);
        }

        public static List<UserInfo> UserInfoGetAll(UserInfo newUserInfo, string LoggedUser, int intStartRow, int intMaxRows)
        {
            return getUserInfos(Convert.ToInt32(newUserInfo.USERID), Convert.ToInt32(newUserInfo.USERGROUPID), newUserInfo.LOGINNAME, newUserInfo.USERNAME, newUserInfo.CURRENTCENTERID, LoggedUser, intStartRow, intMaxRows);

        }

        public static List<UserInfo> getUserInfoByCenterId(int CURRENTCENTERID)
        {
            //int USERID, int USERGROUPID, int PAGINGSIZE,int STARTROW
            return DAL_USERINFO.GetItemList(0, 0, "","","", CURRENTCENTERID, 1, int.MaxValue);
        }

        public static List<UserInfo> getUnAssignedUserInfo()
        {
            //int USERID, int USERGROUPID, int PAGINGSIZE,int STARTROW
            return DAL_USERINFO.GetItemList(0, 0, "","","", -1, 1, int.MaxValue);
        }


        public static int getUserInfoCount(int USERID, int USERGROUPID, string LOGINNAME, string USERNAME,string LoggedUser, int CURRENTCENTERID)
        {
            //int USERID, int USERGROUPID, int PAGINGSIZE,int STARTROW
            return DAL_USERINFO.GetItemListCount(USERID, USERGROUPID, LOGINNAME, USERNAME, LoggedUser,CURRENTCENTERID);
        }


        //public static int getUserInfoByCenterId(int USERID, int USERGROUPID, string LOGINNAME, string USERNAME)
        //{
        //    //int USERID, int USERGROUPID, int PAGINGSIZE,int STARTROW
        //    return DAL_USERINFO.GetItemListCount(USERID, USERGROUPID, LOGINNAME, USERNAME);
        //}

        public static UserInfo getUserInfoById(int id)
        {

            List<UserInfo> UserInfos = DAL_USERINFO.GetItemList(id,0,"","","",0,0,0);
            if (UserInfos.Count == 1)
            {
                return UserInfos[0];
            }

            return new UserInfo();

        }

        public static int PasswordValidity(int UserID)
        {
            try
            {
                UserInfo userInfo = UserInfoBLL.getUserInfoById(UserID);
                UserGroup userGroup = UserGroupBLL.getUserGroupById(Convert.ToInt32(userInfo.USERGROUPID));
                return Convert.ToInt32(userGroup.PASSWORDVALIDITY);
            }
            catch
            {
                return 0;
            }
        }

    }
}
