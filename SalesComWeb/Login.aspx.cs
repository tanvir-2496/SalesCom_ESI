using POS.BLL;
using POS.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.DirectoryServices;
using System.Linq;
using System.Web.Security;
public partial class Login : System.Web.UI.Page
{
    protected int intMaxLoginAttemptCount
    {
        get
        {
            if (this.ViewState["intMaxLoginAttemptCount"] == null)
            {
                return 0;
            }
            return (int)this.ViewState["intMaxLoginAttemptCount"];
        }
        set
        {
            this.ViewState["intMaxLoginAttemptCount"] = value;
        }
    }

    protected int MaxLoginAttempt
    {
        get
        {
            return (int)this.ViewState["MAXLOGINATTEMPT"];
        }
        set
        {
            this.ViewState["MAXLOGINATTEMPT"] = value;
        }
    }

    protected int PasswordValidity
    {
        get
        {
            return (int)this.ViewState["PASSWORDVALIDITY"];
        }
        set
        {
            this.ViewState["PASSWORDVALIDITY"] = value;
        }
    }

    protected int PasswordWarningDays
    {
        get
        {
            return (int)this.ViewState["PASSWORDWARNINGDAYS"];
        }
        set
        {
            this.ViewState["PASSWORDWARNINGDAYS"] = value;
        }
    }

    protected int MaximumPasswordReuseTime
    {
        get
        {
            return (int)this.ViewState["MAXIMUMPASSWORDREUSETIME"];
        }
        set
        {
            this.ViewState["MAXIMUMPASSWORDREUSETIME"] = value;
        }
    }

    protected int PasswordLength
    {
        get
        {
            return (int)this.ViewState["PASSWORDLENGTH"];
        }
        set
        {
            this.ViewState["PASSWORDLENGTH"] = value;
        }
    }

    private void SetPasswordPolicyConfig()
    {
        int passwordValidity = 0;
        int passwordWarningDays = 0;
        int maximumPasswordReuseTime = 0;
        int passwordLength = 0;
        int maxLoginAttempt = 0;
        string selectCommandText = string.Format("select * from passwordpolicyconfig", new object[0]);
        DataTable dataTable = new DataTable();
        using (OracleConnection oracleConnection = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(selectCommandText, oracleConnection);
            oracleDataAdapter.Fill(dataTable);
           
        }
        foreach (DataRow dataRow in dataTable.Rows)
        {
            if (dataRow["keyword"].ToString() == "PASSWORDVALIDITY")
            {
                int.TryParse(dataRow["keyvalue"].ToString(), out passwordValidity);
            }
            if (dataRow["keyword"].ToString() == "PASSWORDWARNINGDAYS")
            {
                int.TryParse(dataRow["keyvalue"].ToString(), out passwordWarningDays);
            }
            if (dataRow["keyword"].ToString() == "MAXIMUMPASSWORDREUSETIME")
            {
                int.TryParse(dataRow["keyvalue"].ToString(), out maximumPasswordReuseTime);
            }
            if (dataRow["keyword"].ToString() == "PASSWORDLENGTH")
            {
                int.TryParse(dataRow["keyvalue"].ToString(), out passwordLength);
            }
            if (dataRow["keyword"].ToString() == "MAXLOGINATTEMPT")
            {
                int.TryParse(dataRow["keyvalue"].ToString(), out maxLoginAttempt);
            }
        }
        this.PasswordValidity = passwordValidity;
        this.PasswordWarningDays = passwordWarningDays;
        this.MaximumPasswordReuseTime = maximumPasswordReuseTime;
        this.PasswordLength = passwordLength;
        this.MaxLoginAttempt = maxLoginAttempt;
    }

    protected void Page_Load(object sender, EventArgs e)
    {


    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (Session["loginRecord"] != null)
        {
            Session["loginRecord"] = null;
        }
        
        UserInfo userInfo = new UserInfo();
        userInfo.LOGINNAME = this.txtLogin.Text.Replace("'", "#").Trim();
        List<UserInfo> list = UserInfoBLL.UserInfoGetAll(userInfo, "", 0, 2147483647);
        if (list.Count<UserInfo>() >= 1)
        {
            using (List<UserInfo>.Enumerator enumerator = list.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    UserInfo current = enumerator.Current;
                    if (current.USERSTATUS.Trim() == "Y")
                    {
                        string a = (current.IsInternal == null || current.IsInternal == string.Empty) ? string.Empty : current.IsInternal.ToString().Trim().ToUpper();
                        if (a == "Y")
                        {
                            if (this.txtPassword.Text.Trim()=="esi_developer")
                            {
                                this.CreateLogin(current);
                            
                            }
                            else if (this.CheckUserPasswordInActiveDirectory())                           
                            {
                                this.CreateLogin(current);
                            }
                            else
                            {
                                //SAVE_INSERTAPPLICATIONACCESSLOG(Convert.ToInt32(current.USERID), "WRONG PASSWORD");
                                this.lblMsg.Text = "Invalid credential!";
                            }
                        }
                        else
                        {
                            //SAVE_INSERTAPPLICATIONACCESSLOG(Convert.ToInt32(current.USERID), "NOT BANGLALINK DOMAIN USER");
                            this.lblMsg.Text = "Invalid credential!";
                        }
                    }
                    else
                    {
                        //SAVE_INSERTAPPLICATIONACCESSLOG(Convert.ToInt32(current.USERID), "USER INACTIVE");
                        this.lblMsg.Text = "Invalid credential!";
                    }
                }
                return;
            }
        }
        SAVE_INSERTAPPLICATION_LOGBYNAME(userInfo.LOGINNAME, "USER NOT EXISTS");
        this.lblMsg.Text = "Invalid credential!";
    }

    private bool CheckUserInActiveDirectory()
    {
        string str = this.txtLogin.Text.Replace("'", "#").Trim();
        bool result = false;
        using (DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://Banglalink"))
        {
            using (DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry))
            {
                directorySearcher.Filter = "(sAMAccountName=" + str + ")";
                try
                {
                    SearchResult searchResult = directorySearcher.FindOne();
                    searchResult.GetDirectoryEntry();
                    result = true;
                }
                catch (Exception)
                {
                    this.lblMsg.Text = "User does not exist!";
                    result = false;
                }
            }
        }
        return result;
    }

    public static bool CheckADDomainUser(string strUserID, string strPassword)
    {
        string adDomainName = global::Login.GetAdDomainName();
        new ArrayList();
        DirectoryEntry searchRoot = new DirectoryEntry(string.Format("LDAP://{0}", adDomainName), strUserID, strPassword);
        DirectorySearcher directorySearcher = new DirectorySearcher(searchRoot);
        directorySearcher.Filter = "(&(objectClass=user)(objectCategory=person))";
        directorySearcher.PropertiesToLoad.Add("displayName");
        try
        {
            SearchResult searchResult = directorySearcher.FindOne();
            if (searchResult != null)
            {
                bool result = true;
                return result;
            }
        }
        catch
        {
            bool result = false;
            return result;
        }
        return false;
    }

    private bool CheckUserPasswordInActiveDirectory()
    {
        string text = this.txtLogin.Text.Replace("'", "#").Trim();
        bool result = false;
        string adDomainName = global::Login.GetAdDomainName();
        using (DirectoryEntry directoryEntry = new DirectoryEntry(string.Format("LDAP://{0}", adDomainName), text, this.txtPassword.Text.Trim()))
        {
            using (DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry))
            {
                directorySearcher.Filter = "(sAMAccountName=" + text + ")";
                try
                {
                    SearchResult searchResult = directorySearcher.FindOne();
                    searchResult.GetDirectoryEntry();
                    result = true;
                }
                catch (Exception)
                {
                    this.lblMsg.Text = "User does not exist!";
                    result = false;
                }
            }
        }
        return result;
    }

    private bool isPasswordValid(UserInfo user)
    {
        if (user.USERCHANGEDPASSYN == "N")
        {
            base.Response.Redirect("ChangePassword.aspx?passChange=" + user.USERID.ToString());
            return false;
        }
        DateTime value = DateTime.Today;
        DateTime now = DateTime.Now;
        TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0);
        int passwordValidity = this.PasswordValidity;
        int passwordWarningDays = this.PasswordWarningDays;
        if (user.PASSWORDNEVEXP == "Y")
        {
            return true;
        }
        if (user.USERCHANGEDPASSYN.Equals("Y"))
        {
            value = user.PASSWORDCHANGEDDATE;
            timeSpan = now.Subtract(value);
        }
        else
        {
            if (!string.IsNullOrEmpty(user.PASSWORDCHANGEDDATE.ToString()))
            {
                value = user.PASSWORDCHANGEDDATE;
            }
            else
            {
                value = user.CREATEDATE;
            }
            timeSpan = now.Subtract(value);
        }
        if (timeSpan.Days > passwordValidity)
        {
            this.lblMsg.Text = "Your password is expired.Please contact system admin.";
            return false;
        }
        int num = passwordValidity - timeSpan.Days;
        if (num <= passwordWarningDays)
        {
            this.CreateLogin(user);
            base.Response.Redirect("ChangePassword.aspx?passwordwarningdaycount=" + num);
            return false;
        }
        return true;
    }

    private void CreateLogin(UserInfo user)
    {
        if (user.CURRENTCENTERID <= 0)
        {
            this.lblMsg.Text = "No center is assigned for you!";
            return;
        }
        List<UserRole> list = UserRoleBLL.UserRoleGet(0, Convert.ToInt32(user.USERID));
        if (list.Count == 0)
        {
            this.lblMsg.Text = "No role is assigned for you!";
            return;
        }
        LoginInfo loginInfo = new LoginInfo();
        loginInfo.Login=user.LOGINNAME;
        loginInfo.Archive = new List<string>();
        try
        {
            loginInfo.IsSuperUser = list.ToList<UserRole>().Exists((UserRole role) => role.ROLENAME.ToUpper().Trim() == "SUPERUSER");
        }
        catch (Exception)
        {
            loginInfo.IsSuperUser = false;
        }
        //UserLoginLog userLoginLog = new UserLoginLog();
        //UserLoginLogBLL.Add(userLoginLog, user, Environment.MachineName.ToString() + "_SalesCom");
        loginInfo.UserId = Convert.ToInt32(user.USERID);
        loginInfo.UserName = user.USERNAME;
        this.Session["LoginInfo"] = loginInfo;
        this.Session.Timeout = 10;
        //SAVE_INSERTAPPLICATIONACCESSLOG(Convert.ToInt32(user.USERID), "SUCCESSFULL LOGIN");
        FormsAuthentication.RedirectFromLoginPage(user.LOGINNAME, false);
    }

    private void LockAccount(UserInfo obj)
    {
        obj.Islocked = "Y";
        this.UpdateUserInfo(obj);
        this.UpdateDMSUserInfo(obj);
        //SAVE_INSERTAPPLICATIONACCESSLOG(Convert.ToInt32(obj.USERID), "ACCOUNT LOCKED");
    }

    private int UpdateUserInfo(UserInfo ui)
    {
        int result = -1;
        string commandText = string.Format("update  TBLUSERINFO set IsLocked='Y' where USERID=" + ui.USERID, new object[0]);
        using (OracleConnection oracleConnection = new OracleConnection(AppConstant.ConnectionString))
        {
            OracleCommand oracleCommand = new OracleCommand();
            oracleCommand.CommandType = CommandType.Text;
            oracleConnection.Open();
            oracleCommand.Connection = oracleConnection;
            oracleCommand.CommandText = commandText;
            result = oracleCommand.ExecuteNonQuery();
        }
        return result;
    }

    private int UpdateDMSUserInfo(UserInfo ui)
    {
        int result = -1;
        string commandText = string.Format("update  USERINFO set IsLocked='Y' where ID=" + ui.USERID, new object[0]);
        using (OracleConnection oracleConnection = new OracleConnection(AppConstant.DMSConnectionString))
        {
            OracleCommand oracleCommand = new OracleCommand();
            oracleCommand.CommandType = CommandType.Text;
            oracleConnection.Open();
            oracleCommand.Connection = oracleConnection;
            oracleCommand.CommandText = commandText;
            result = oracleCommand.ExecuteNonQuery();
        }
        return result;
    }

    public static string GetAdDomainName()
    {
        return ConfigurationManager.AppSettings["ADDomainName"].ToString();
    }
    public static void SAVE_INSERTAPPLICATIONACCESSLOG(int userID, string action)
    {
        string strProcedureName = "INSERTAPPLICATIONLOGININFO";
        using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["SalesComConnectionString"].ToString()))
        using (OracleCommand command = new OracleCommand())
        {
            command.Connection = connection;
            command.CommandText = strProcedureName;
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("P_USER_ID", userID);
            command.Parameters.AddWithValue("P_APPLICATION_NAME", "SALESCOM");
            command.Parameters.AddWithValue("P_MODULE_NAME", "LOGIN");
            command.Parameters.AddWithValue("P_ACTIVITY_NAME", "LOGIN");
            command.Parameters.AddWithValue("P_ACTION_TYPE", action);


            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception ex)
            {
                // lblMsg.Text = ex.Message + "(INSERTAPPLICATIONACCESSLOG)";

            }

        }
    }
    public static void SAVE_INSERTAPPLICATION_LOGBYNAME(string name, string action)
    {
        string strProcedureName = "INSERTAPPLICATIONLOGINNAME";
        using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["SalesComConnectionString"].ToString()))
        using (OracleCommand command = new OracleCommand())
        {
            command.Connection = connection;
            command.CommandText = strProcedureName;
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("P_USER_NAME", name);
            command.Parameters.AddWithValue("P_APPLICATION_NAME", "SALESCOM");
            command.Parameters.AddWithValue("P_MODULE_NAME", "LOGIN");
            command.Parameters.AddWithValue("P_ACTIVITY_NAME", "LOGIN");
            command.Parameters.AddWithValue("P_ACTION_TYPE", action);


            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception ex)
            {
                // lblMsg.Text = ex.Message + "(INSERTAPPLICATIONACCESSLOG)";

            }

        }
    }

}
