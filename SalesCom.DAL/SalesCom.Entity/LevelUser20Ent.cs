using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class LevelUser20Ent
    {
        public int LevelUserId { get; set; }
        public int UserId { get; set; }
        public int ApprovalLevelId { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string LoginName { get; set; }

        public LevelUser20Ent() { }

        public LevelUser20Ent(DataRow dr)
        {
            if (dr["LEVELUSERID"] != DBNull.Value) { this.LevelUserId = Convert.ToInt32(dr["LEVELUSERID"]); }
            if (dr["USERID"] != DBNull.Value) { this.UserId = Convert.ToInt32(dr["USERID"]); }
            if (dr["APPROVALLEVELID"] != DBNull.Value) { this.ApprovalLevelId = Convert.ToInt32(dr["APPROVALLEVELID"]); }
            this.Email = dr["Email"] as String;
            this.Mobile = dr["Mobile"] as String;
            this.LoginName = dr["LoginName"] as String;
            this.FullName = dr["FullName"] as String;
        }
    }

    public class UserInfo20Ent
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string LoginName { get; set; }

        public UserInfo20Ent() { }

        public UserInfo20Ent(DataRow dr)
        {
            this.UserName = dr["USERNAME"] as String;
            if (dr["USERID"] != DBNull.Value) { this.UserId = Convert.ToInt32(dr["USERID"]); }
            this.LoginName = dr["LOGINNAME"] as String;
        }
    }

    public class UserInfoForView20
    {
        public int LevelUserId { get; set; }
        public int UserId { get; set; }
        public int ApprovalLevelId { get; set; }
        public string ApprovalLevelName { get; set; }
        public int ApprovalFlowId { get; set; }
        public string ApprovalName { get; set; }
        public string UserName { get; set; }
        public string LoginName { get; set; }
        
        public string Mobile { get; set; }
        public string Email { get; set; }

        public UserInfoForView20() { }

        public UserInfoForView20(DataRow dr)
        {
            if (dr["LEVELUSERID"] != DBNull.Value) { this.LevelUserId = Convert.ToInt32(dr["LEVELUSERID"]); }
            if (dr["USERID"] != DBNull.Value) { this.UserId = Convert.ToInt32(dr["USERID"]); }
            if (dr["APPROVALLEVELID"] != DBNull.Value) { this.ApprovalLevelId = Convert.ToInt32(dr["APPROVALLEVELID"]); }
            this.ApprovalLevelName = dr["APPROVALLEVELNAME"] as String;
            if (dr["APPROVALFLOWID"] != DBNull.Value) { this.ApprovalFlowId = Convert.ToInt32(dr["APPROVALFLOWID"]); }
            this.ApprovalName = dr["APPROVALNAME"] as String;
            this.UserName = dr["USERNAME"] as String;
            this.LoginName = dr["LoginName"] as String;

            this.Mobile = dr["Mobile"] as String;
            this.Email = dr["Email"] as String;

        }
    }

}
