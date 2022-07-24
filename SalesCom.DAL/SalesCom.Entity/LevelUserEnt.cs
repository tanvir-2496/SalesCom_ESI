using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class LevelUserEnt
    {
        public int LevelUserId { get; set; }
        public int UserId { get; set; }
        public int LevelCollectionID { get; set; }

        public LevelUserEnt() { }

        public LevelUserEnt(DataRow dr)
        {
            if (dr["LEVELUSERID"] != DBNull.Value) { this.LevelUserId = Convert.ToInt32(dr["LEVELUSERID"]); }
            if (dr["USERID"] != DBNull.Value) { this.UserId = Convert.ToInt32(dr["USERID"]); }
            if (dr["LevelCollectionID"] != DBNull.Value) { this.LevelCollectionID = Convert.ToInt32(dr["LevelCollectionID"]); }
        }
    }

    public class UserInfoEnt
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string LoginName { get; set; }

        public UserInfoEnt() { }

        public UserInfoEnt(DataRow dr)
        {
            this.UserName = dr["USERNAME"] as String;
            if (dr["USERID"] != DBNull.Value) { this.UserId = Convert.ToInt32(dr["USERID"]); }
            this.LoginName = dr["LOGINNAME"] as String;
        }
    }

    public class UserInfoForView
    {
        public int LevelUserId { get; set; }
        public int UserId { get; set; }
        public int LevelCollectionID { get; set; }
        public string Name { get; set; }
        public int ApprovalFlowId { get; set; }
        public string ApprovalName { get; set; }
        public string UserName { get; set; }

        public UserInfoForView() { }

        public UserInfoForView(DataRow dr)
        {
            if (dr["LEVELUSERID"] != DBNull.Value) { this.LevelUserId = Convert.ToInt32(dr["LEVELUSERID"]); }
            if (dr["USERID"] != DBNull.Value) { this.UserId = Convert.ToInt32(dr["USERID"]); }
            if (dr["LevelCollectionID"] != DBNull.Value) { this.LevelCollectionID = Convert.ToInt32(dr["LevelCollectionID"]); }
            this.Name = dr["Name"] as String;
            if (dr["APPROVALFLOWID"] != DBNull.Value) { this.ApprovalFlowId = Convert.ToInt32(dr["APPROVALFLOWID"]); }
            this.ApprovalName = dr["APPROVALNAME"] as String;
            this.UserName = dr["USERNAME"] as String;
        }
    }

}
