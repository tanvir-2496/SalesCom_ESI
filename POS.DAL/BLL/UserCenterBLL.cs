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
    public class UserCenterBLL
    {
        public static int Add(UserCenter newUserCenter)
        {
            return DAL_USERCENTER.SaveItem(newUserCenter, "I");
           
        }
        public static int Edit(UserCenter newUserCenter)
        {
            return DAL_USERCENTER.SaveItem(newUserCenter, "U");
         
        }
        public static int Delete(int intUserCenterid)
        {
            UserCenter userCenter = new UserCenter();
            userCenter.CENTERID = intUserCenterid;
            return DAL_USERCENTER.SaveItem(userCenter, "D");
            
        }
        public static List<UserCenter> getUserCenter()
        {
            return DAL_USERCENTER.GetItemList(-1,-1);
        }
        public static UserCenter getUserCenterById(int CenterID,int UserID)
        {
            List<UserCenter> userCenter = DAL_USERCENTER.GetItemList(CenterID,UserID);
            if (userCenter.Count == 1)
            {
                return userCenter[0];
            }

            return new UserCenter();
        }


        public static string RemoveUserFromCenter(int userId, string UpdateBy)
        {
            return AssignUserToNewCenter(userId, -1, UpdateBy);
        }



        public static string AssignUserToNewCenter(int userid, int centerid,string UpdateBy)
        {

            UserInfo user = UserInfoBLL.getUserInfoById(userid);
            if (user.USERID <= 0)
            {
                return "User Not found";
            }


            if (user.CURRENTCENTERID == centerid)
            {
                return "User Already Assigned to this center";
            }



            List<UserCenter> history = DAL_USERCENTER.GetItemList(user.CURRENTCENTERID, userid);

            if (history.Count > 0)
            {
                UserCenter current = history.OrderByDescending(uc => uc.UPDATEDATE).First();


                if (current.RELEASEDATE < System.DateTime.Now.AddYears(-5))
                {
                    current.RELEASEDATE = System.DateTime.Now;
                    current.UPDATEBY = UpdateBy;
                    Edit(current);

                    if (centerid > 0)
                    {

                        current.ENGAGEID = -1;
                        current.RELEASEDATE = DateTime.MinValue;

                        current.CENTERID = centerid;
                        current.CREATEBYUSER = UpdateBy;

                        Add(current);
                    }
                }
            }
            else
            {
                if (centerid > 0)
                {
                    UserCenter newCenter = new UserCenter();
                    newCenter.CENTERID = centerid;
                    newCenter.CREATEBYUSER = newCenter.UPDATEBY = UpdateBy;
                    newCenter.RELEASEDATE = DateTime.MinValue;
                    newCenter.USERID = userid;

                    Add(newCenter);
                }
            }

            if (centerid > 0)
            {
                user.CURRENTCENTERID = centerid;
            }
            else
            {
                user.CURRENTCENTERID = 0;
            }
            user.LASTUPDATEBY = UpdateBy;
            UserInfoBLL.Edit(user);

            return "SUCCESSFUL";
        }
    }
}
