using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web.Security;
using System.Data.OracleClient;
using System.Text.RegularExpressions;
using POS.BLL;
using System.Collections.Generic;
using POS.DAL;


public partial class ChangePassword : System.Web.UI.Page
{
    decimal passwordwarningdaycount = 0;
    protected string password
    {
        get
        {
            return ViewState["password"].ToString();
        }
        set
        {
            ViewState["password"] = value;
        }
    }

    protected int userId
    {
        get
        {
            if (Request.QueryString["passChange"] != null)
                return Convert.ToInt32(Request.QueryString["passChange"]);
            return LoginInfo.Current.UserId;
        }
        set
        {
            ViewState["passChange"] = value;
        }
    }

    protected int MaxLoginAttempt
    {
        get
        {
            return (int)ViewState["MAXLOGINATTEMPT"];
        }
        set
        {
            ViewState["MAXLOGINATTEMPT"] = value;
        }
    }

    protected int PasswordValidity
    {
        get
        {
            return (int)ViewState["PASSWORDVALIDITY"];
        }
        set
        {
            ViewState["PASSWORDVALIDITY"] = value;
        }
    }

    protected int PasswordWarningDays
    {
        get
        {
            return (int)ViewState["PASSWORDWARNINGDAYS"];
        }
        set
        {
            ViewState["PASSWORDWARNINGDAYS"] = value;
        }
    }
    protected int MaximumPasswordReuseTime
    {
        get
        {
            return (int)ViewState["MAXIMUMPASSWORDREUSETIME"];
        }
        set
        {
            ViewState["MAXIMUMPASSWORDREUSETIME"] = value;
        }
    }
    protected int PasswordLength
    {
        get
        {
            return (int)ViewState["PASSWORDLENGTH"];
        }
        set
        {
            ViewState["PASSWORDLENGTH"] = value;
        }
    }

    private void SetPasswordPolicyConfig()
    {
        int passwordValidity = 0;
        int passwordWarningDays = 0;
        int maximumPasswordReuseTime = 0;
        int passwordLength = 0;
        int maxLoginAttempt = 0;
        string str = string.Format(@"select * from passwordpolicyconfig");
        DataTable dt = new DataTable();

        using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            OracleDataAdapter cmd = new OracleDataAdapter(str, con);
            cmd.Fill(dt);

        }
        foreach (DataRow dr in dt.Rows)
        {
            if (dr["keyword"].ToString() == "PASSWORDVALIDITY") { int.TryParse(dr["keyvalue"].ToString(), out passwordValidity); }
            if (dr["keyword"].ToString() == "PASSWORDWARNINGDAYS") { int.TryParse(dr["keyvalue"].ToString(), out passwordWarningDays); }
            if (dr["keyword"].ToString() == "MAXIMUMPASSWORDREUSETIME") { int.TryParse(dr["keyvalue"].ToString(), out maximumPasswordReuseTime); }
            if (dr["keyword"].ToString() == "PASSWORDLENGTH") { int.TryParse(dr["keyvalue"].ToString(), out passwordLength); }
            if (dr["keyword"].ToString() == "MAXLOGINATTEMPT") { int.TryParse(dr["keyvalue"].ToString(), out maxLoginAttempt); }
        }
        PasswordValidity = passwordValidity;
        PasswordWarningDays = passwordWarningDays;
        MaximumPasswordReuseTime = maximumPasswordReuseTime;
        PasswordLength = passwordLength;
        MaxLoginAttempt = maxLoginAttempt;
    }
    protected override void OnPreInit(EventArgs e)
    {
        if (Request.QueryString["passChange"] != null)
        {
            this.MasterPageFile = "~/MasterPages/Login.master";
        }

        base.OnPreInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetPasswordPolicyConfig();
            if (Request.QueryString["passChange"] == null)
            {
                if (Request.Params["passwordwarningdaycount"] != null)
                {
                    passwordwarningdaycount = Convert.ToDecimal(Request.Params["passwordwarningdaycount"].ToString());
                    MsgUtility.msgCommon(this, lblMsg, "Your password will be expired within " + passwordwarningdaycount + " days.");
                }
            }
            else
            {
                MsgUtility.msgCommon(this, lblMsg, "Please set initial password.");
            }

        }
        else 
        {
            lblMsg.Text = "";
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int ErrorCode = SaveData();
        if (ErrorCode >= 0)
        {
            if (Request.QueryString["passChange"] != null)
            {
                Response.Redirect("Login.aspx");
            }
            else
                MsgUtility.msgSuccess(this, lblMsg, "Password changed successfully.");
        }

        // MsgUtility.msg("edit", ErrorCode, "Password", this, lblMsg,"");    
    }


    protected int SaveData() 
    {
      //  POS.DAL.UserInf user = new POS.DAL.UserInfo();

    
        UserInfo newUserInfo = new UserInfo();
        // newUserInfo.USERID = Convert.ToDecimal( LoginInfo.Current.UserId);
        int intUserID = 0;
        if (Request.QueryString["passChange"] != null)
        {
            intUserID = int.Parse(Request.QueryString["passChange"]);
        }
        else
        {
            intUserID = LoginInfo.Current.UserId;
        }
    
        newUserInfo = UserInfoBLL.getUserInfoById(intUserID);
        try
        {
            newUserInfo.PASSWORDCHANGEDBY = newUserInfo.USERNAME;
        }
        catch 
        { }

        if (!CheckProhibitedPass()) {  return -1; }
         if (newUserInfo.PASSWORD.Trim() == FormsAuthentication.HashPasswordForStoringInConfigFile(txtCurrentPassword.Text, "MD5"))
            {
                newUserInfo.PASSWORD = FormsAuthentication.HashPasswordForStoringInConfigFile(txtUserPassword.Text, "MD5");
              //  string conString = ConfigurationManager.ConnectionStrings["DMSConnectionString"].ToString();
                //UpdateDMSUserPassword(newUserInfo);
        
                InsertUserPasswordHistory(intUserID, newUserInfo.PASSWORD);
             
                return UserInfoBLL.SavePassword(newUserInfo);
            }
            else
            {
                MsgUtility.msgCommon(this,lblMsg,"Wrong Password!");
                return -1;
            }
        
        return 0;
        //txtCurrentPassword
    }

    private bool CheckProhibitedPass()
    {
        try
        {
            string ProhibitedPassString = ConfigurationManager.AppSettings["ProhibitedPass"].ToString();
            string[] ProhibitedPasswords = ProhibitedPassString.Split(',');
            string existpass = ProhibitedPasswords.ToList().Find(l => l == txtUserPassword.Text.Trim());

            if (txtUserPassword.Text.Trim().Length < PasswordLength)
            {

                MsgUtility.msgCommon(this, lblMsg, "New and confirmed passwords can't be less than " + PasswordLength  + " digit. Please re-enter");
              
                return false;
            }

            if (existpass != null)
            {
                MsgUtility.msgCommon(this, lblMsg, "Prohibited Password. Please choose another one !!");
                return false;
            }
            else if (!PasswordValidator.IsValidPassword(txtUserPassword.Text.Trim()))
            {
                MsgUtility.msgCommon(this, lblMsg, "Password should be alphanumeric. Please choose another one !!");
                return false;
            }

            else if (CheckSamePassword(userId, FormsAuthentication.HashPasswordForStoringInConfigFile(txtUserPassword.Text, "MD5"))>0)
            {
                int strSamePassMaxUse = MaximumPasswordReuseTime;// ConfigurationManager.AppSettings["SamePassMaxUse"].ToString();
                MsgUtility.msgCommon(this, lblMsg, "Please choose another password, Same password can not be used more than " + strSamePassMaxUse + " times!");
                return false;
            }

        }
        catch (Exception ex)
        {
            
        }

        return true;
    }



    private int InsertUserPasswordHistory(int userId, string password)
    {
        int i = -1;

        string strInsert = string.Format(@"Insert into TBLPASSWORDHISTORY(ID, PASSWORD,USERID)
                    values(POS_SEQ_PASSWORDHISTORY.NEXTVAL,'" + password + "'," + userId + ")");


        using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = CommandType.Text;
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = strInsert;

            i = cmd.ExecuteNonQuery();
            OracleString rowID = "1";
            //i = cmd.ExecuteOracleNonQuery(out rowID);
        }
        return i;
    }

    private int CheckSamePassword(int userId, string password)
    {
        int i = -1;
        int samePassMaxUse = MaximumPasswordReuseTime;
        string strInsert = string.Format(@"with a as (select rownum nu, f.* from (select id, password, userid from TBLPASSWORDHISTORY where USERID={0}  order by id desc) f
where  rownum<{1})
select count(1) noofdata from a where password='{2}'", userId, samePassMaxUse, password);


        using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = CommandType.Text;
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = strInsert;

            i = Convert.ToInt32(cmd.ExecuteScalar());
        }
        return i;
    }


    public bool AlphaNumericString(string s)
    {

        Regex r = new Regex(@"^\w*(?=\w*\d)(?=\w*[a-zA-z])\w*$");
        if (r.IsMatch(s))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

public class PasswordValidator
{

    private const string ALLOWED_SPECIAL_CHARS = @"@#$%&*+_()':;?.,![]\-";
    private static string ESCAPED_SPECIAL_CHARS;

    static PasswordValidator()
    {
        var escapedChars = new List<char>();
        foreach (char c in ALLOWED_SPECIAL_CHARS)
        {
            if (c == '[' || c == ']' || c == '\\' || c == '-')
                escapedChars.AddRange(new[] { '\\', c });
            else
                escapedChars.Add(c);
        }
        ESCAPED_SPECIAL_CHARS = new string(escapedChars.ToArray());
    }

    public static bool IsValidPassword(string input)
    {
        // Length requirement?
        // if (input.Length < 8) return false;

        // First just check for a digit
        if (!Regex.IsMatch(input, @"\d")) return false;

        // Then check for special character
        if (!Regex.IsMatch(input, "[" + ESCAPED_SPECIAL_CHARS + "]")) return false;

        // Require a letter?
        if (!Regex.IsMatch(input, "[A-Z]")) return false;

        // Require a letter?
        if (!Regex.IsMatch(input, "[a-z]")) return false;

        // DON'T allow anything else:
        if (Regex.IsMatch(input, @"[^a-zA-Z\d" + ESCAPED_SPECIAL_CHARS + "]")) return false;

        return true;
    }
}
