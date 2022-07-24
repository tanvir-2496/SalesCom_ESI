using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Data.OracleClient;
using ESI.Entity;
using ESI.DAL;
using ESI.Entity.ViewModel;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginRecord"] == null)
        {
            
            List<LOGIN_INFORMATION> loginInformation = GET_LOGIN_INFORMATION(LoginInfo.Current.UserName);
            Session["loginRecord"] = loginInformation;
            string Unsuccessfultime;
            string Successfultime;
            try
            {
                 Successfultime = loginInformation.Where(t => t.ACTION_TYPE == "SUCCESSFULL LOGIN")
                 .Skip(1).Take(1).Single().LOG_DATE_TIME.ToString();
                 MsgUtility.loginMessageView(this.Page, "Login Record", "Last Successful Login", Successfultime);
			}
            catch (Exception ex)
            {

            }
			
			try
            {
                // Unsuccessfultime = loginInformation.Where(t => t.ACTION_TYPE != "SUCCESSFULL LOGIN")
                //.OrderByDescending(x => x.ID).FirstOrDefault().LOG_DATE_TIME.ToString();
                // MsgUtility.loginMessageView(this.Page, "Login Record", "Unsuccessful Login", Unsuccessfultime);
                List<String> unsuccessfulattemptList = loginInformation.Where(t => t.ACTION_TYPE != "SUCCESSFULL LOGIN")
                     .Select(t => t.LOG_DATE_TIME).Take(5).ToList();
                foreach (string unsuccessfulattempt in unsuccessfulattemptList)
                {
                    MsgUtility.loginMessageView(this.Page, "Login Record", "Unsuccessful Login", unsuccessfulattempt);
                }
            }
            catch (Exception ex)
            {

            }
        }
        //if (!this.Page.IsPostBack)
        //{
        //    ddlYear.DataSource = Common.GenrateYear();
        //    ddlYear.DataBind();
        //    int year = DateTime.Now.Year;
        //    int quarter = 0;
        //    int month = DateTime.Now.Month;
            
         

        //    var y = ddlYear.Items.FindByText(year.ToString());
        //    if (y != null)
        //        y.Selected = true;
        //    quarter = DateTime.Now.Month % 3 == 0 ? DateTime.Now.Month / 3 : DateTime.Now.Month / 3 + 1;
        //    var q = ddlQuarter.Items.FindByValue(quarter.ToString());
        //    if (q != null)
        //        q.Selected = true;
        //    deshboard(year, quarter, month);
        //}
        
    }

    public List<LOGIN_INFORMATION> GET_LOGIN_INFORMATION(string UserName)
    {
        List<LOGIN_INFORMATION> results = new List<LOGIN_INFORMATION>();
        DataTable dt = null;
        string strProcedureName = "SELECT ID, TO_CHAR(LOG_DATE_TIME, 'DD-MON-YY HH24:MI AM') LOG_DATE_TIME, USER_ID, USER_NAME, APPLICATION_NAME, MODULE_NAME, ACTIVITY_NAME, ACTION_TYPE FROM APPLICATION_LOGIN_INFO WHERE ACTIVITY_NAME = 'LOGIN' AND USER_NAME = '" + UserName + "' AND ACTION_TYPE ! = 'LOGOUT' ORDER BY ID DESC";
        using (OracleConnection connection = new OracleConnection(ConfigurationManager.ConnectionStrings["SalesComConnectionString"].ToString()))
        using (OracleCommand command = new OracleCommand())
        {
            command.Connection = connection;
            command.CommandText = strProcedureName;
            command.CommandType = CommandType.Text;
            try
            {
                connection.Open();
                dt = new DataTable(strProcedureName);
                using (OracleDataAdapter da = new OracleDataAdapter(command))
                {
                    da.Fill(dt);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
            }
        }

        foreach (DataRow dr in dt.Rows)
        {
            results.Add(new LOGIN_INFORMATION(dr));
        }
        return results;
    }
    public class LOGIN_INFORMATION
    {
        public int ID { get; set; }
        public string LOG_DATE_TIME { get; set; }
        public int USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public string APPLICATION_NAME { get; set; }
        public string MODULE_NAME { get; set; }
        public string ACTIVITY_NAME { get; set; }
        public string ACTION_TYPE { get; set; }

        public LOGIN_INFORMATION() { }

        public LOGIN_INFORMATION(DataRow dr)
        {
            if (dr["ID"] != DBNull.Value) { this.ID = Convert.ToInt32(dr["ID"]); }
            this.LOG_DATE_TIME = dr["LOG_DATE_TIME"] as String;
            if (dr["USER_ID"] != DBNull.Value) { this.USER_ID = Convert.ToInt32(dr["USER_ID"]); }
            this.USER_NAME = dr["USER_NAME"] as String;
            this.APPLICATION_NAME = dr["APPLICATION_NAME"] as String;
            this.MODULE_NAME = dr["MODULE_NAME"] as String;
            this.ACTIVITY_NAME = dr["ACTIVITY_NAME"] as String;
            this.ACTION_TYPE = dr["ACTION_TYPE"] as String;
        }

    }

    //public void deshboard(int year, int quarter, int month)
    //{
    //    int userId = LoginInfo.Current.UserId;
    //    int employeeId=UserMappDAL.GetEmployeeByUserId(userId).EMPLOYEENO.Length> 0 ?Convert.ToInt32( UserMappDAL.GetEmployeeByUserId(userId).EMPLOYEENO) : 0;

    //    SalesChannelEnt salesChannel = ESI_ReportDAL.GetSalesChannel(userId, "0"); //To Do Not Working.... have to check valid user id login 
    //    if (salesChannel.Sales_Channel_Id < 1)
    //    {
    //        salesChannel.Sales_Channel_Id = 0;
    //    }
    //    ReportCycleEnt reportCycle = ESI_ReportDAL.GetReportCycle(salesChannel.Sales_Channel_Id, year, quarter, month);
    //    if (reportCycle.REPORT_CYCLE_ID <= 0)
    //    {
    //        reportCycle.REPORT_CYCLE_ID = 0;
    //    }
    //    List<KPIvsAchievementEnt> report = ESI_ReportDAL.KPIvsAchievement(employeeId, reportCycle.REPORT_CYCLE_ID);
    //    //9332 ade 129

    //    //List<EmployeeTargetEnt> tList = ESI_ReportDAL.GetEmployeeTarget(employeeId, reportCycle.REPORT_CYCLE_ID);
      
    //    //foreach (var t in tList)
    //    //{
    //    //   if (t.Month == 1)
    //    //    {
    //    //        t.M1 = t.TargetValue;
    //    //    }
    //    //   else if (t.Month == 2)
    //    //   {
    //    //       t.M2 = t.TargetValue;
    //    //   }
    //    //   else if (t.Month == 3)
    //    //   {
    //    //       t.M3 = t.TargetValue;
    //    //   }
    //    //}
    //    //var targetList = tList.GroupBy(m => m.KPIName).Select(g => new EmployeeTargetEnt
    //    //{
    //    //    KPIName = g.First().KPIName,
    //    //    M1 = g.Sum(s => s.M1),
    //    //    M2 = g.Sum(s => s.M2),
    //    //    M3 = g.Sum(s => s.M3),
    //    //}).ToList();
    //    //ListViewTarget.DataSource = targetList;
    //    //ListViewTarget.DataBind();

    //    lv.DataSource = report;
    //    lv.DataBind();
        
    //    #region Chart Start
    //    if (report.Count<=0)
    //    {
    //        KPIChart.Visible = false;
    //        KPIChart.Controls.Clear();
    //    }
    //    else
    //    {
    //        KPIChart.Visible = true;
    //        KPIChart.Titles.Clear();
    //    }
    //    KPIChart.ChartAreas["KPIName"].AxisX.Interval = 1;
    //    KPIChart.DataSource = report;
    //    KPIChart.Series[0].XValueMember = "KPIName";
    //    KPIChart.Series[0].YValueMembers = "TotalQuarterAchievement";
    //    KPIChart.DataBind();
    //    #endregion
    //}
    //protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    int year = Convert.ToInt32( ddlYear.SelectedValue);
    //    int month = 0;
    //    int quarter = Convert.ToInt32(ddlQuarter.SelectedValue);
    //    if (quarter <1)
    //    {
    //        month = DateTime.Now.Month;
    //    }
    //    deshboard(year, quarter, month);
    //}
}
