using ClosedXML.Excel;
using ESI.DAL;
using ESI.Entity.ViewModel;
using POS.BLL;
using POS.DAL;
using SalesCom.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Common
/// </summary>
public class Common
{
    public Common()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static DataTable ReadExcelSheet(string fileExtension, string mapPath, string sheetName, Boolean skipFirstRow)
    {
        DataTable dtExcelRecords = new DataTable();

        try
        {
            string connectionString = string.Empty;

            if (fileExtension == ".xls")
            {
                if (skipFirstRow)
                {
                    connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + mapPath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
                }
                else
                {
                    connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + mapPath + ";Extended Properties=\"Excel 8.0;HDR=No;IMEX=1\"";
                }
            }
            else if (fileExtension == ".xlsx")
            {
                if (skipFirstRow)
                {
                    connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mapPath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
                }
                else
                {
                    connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mapPath + ";Extended Properties=\"Excel 12.0;HDR=No;IMEX=1\"";
                }
            }

            //Create OleDB Connection and OleDb Command
            OleDbConnection con = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            OleDbDataAdapter dAdapter = new OleDbDataAdapter(cmd);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //DataTable dtExcelSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string getExcelSheetName = sheetName;
            cmd.CommandText = "SELECT * FROM [" + getExcelSheetName + "]";
            // cmd.CommandText = "SELECT * FROM [$tr]";
            dAdapter.SelectCommand = cmd;
            dAdapter.Fill(dtExcelRecords);

            con.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return dtExcelRecords;
    }

    public static DataTable FilterSchemaTable(DataTable dataTable)
    {
        DataTable schemaTable = dataTable.Clone();

        foreach (DataRow dr in dataTable.Rows)
        {
            if (!dr.ItemArray[2].ToString().Contains("#"))
            {
                schemaTable.Rows.Add(dr.ItemArray);
            }
        }

        return schemaTable;
    }

    public static void AddSelectOne(DropDownList ddl)
    {
        ddl.Items.Insert(0, new ListItem(Resources.CommonMsg.SelectOne, "0"));
    }

    public static void AddSelectAll(DropDownList ddl)
    {
        ddl.Items.Insert(0, new ListItem(Resources.CommonMsg.SelectAll, "0"));
    }

    public static void InsertSelectOne(DropDownList ddl)
    {
        ddl.Items.Insert(0, new ListItem(Resources.CommonMsg.SelectOne, "-1"));
    }

    public static void CloseWindow(Page page, Type type)
    {
        ScriptManager.RegisterStartupScript(page, page.GetType(), "close", "parent.tb_remove();", true);
        RefreshParent(page, type);
    }

    public static void RefreshParent(Page page, Type type)
    {
        ScriptManager.RegisterStartupScript(page, type, "refresh", "parent.refreshWindow();", true);
    }

    public static string CurrentUser
    {
        get
        {
            return HttpContext.Current.User.Identity.Name;
        }
    }

    public static string CurrentUserName
    {
        get
        {
            return LoginInfo.Current.UserName;
        }
    }

    public static int CurrentCenterId
    {
        get { return LoginInfo.Current.CenterId; }
    }

    public static string getDataSource()
    {
        // return "PREDWH_NEW";
        string[] strConn = AppConstant.ConnectionString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        string[] strConn1 = strConn[0].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
        return strConn1[1].Trim();

    }

    public static string getUserID()
    {
        //   return "CFDB";

        string[] strConn = AppConstant.ConnectionString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        string[] strConn1 = strConn[1].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

        return strConn1[1].Trim();
    }

    public static string getPassword()
    {
        // return "CFDB0987";
        string[] strConn = AppConstant.ConnectionString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        string[] strConn1 = strConn[2].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

        return strConn1[1].Trim();

    }

    public static void PopulateWeekend(CheckBoxList lst)
    {
        string[] weekendList = { "Friday", "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday" };
        for (int i = 0; i < weekendList.Length; i++)
        {
            lst.Items.Add(new ListItem(weekendList[i], weekendList[i]));
        }
    }

    public static bool IsAlphaNumeric(string password)
    {
        Regex regexObj = new Regex(@"^\w*(?=\w*\d)(?=\w*[a-zA-z])\w*$");
        return regexObj.IsMatch(password);
    }

    public static void PopulateUserCenters(ListControl control, int pCenterId, int pUserId)
    {

        List<Center> list = CenterBLL.getCenter(-1, -1, -1, "");
        List<UserCenter> listUserCenter = UserCenterBLL.getUserCenter().ToList().FindAll(q => q.USERID == pUserId);

        var listFiltered = (from c in list
                            join uc in listUserCenter
                            on c.CENTERID equals uc.CENTERID
                            where uc.USERID == pUserId
                            select c).ToList();

        control.DataSource = listFiltered;
        control.DataTextField = "CENTERNAME";
        control.DataValueField = "CENTERID";
        control.DataBind();

    }

    public static void PopulateSIMValidationRule(ListControl control)
    {
        control.DataSource = ValidationRuleDAL.GetItemList(0);
        control.DataTextField = "ValidationName";
        control.DataValueField = "ValidationRuleId";
        control.DataBind();

    }

    public static void PopulateEventType(ListControl control)
    {
        control.DataSource = EventTypeDAL.GetItemList(0);
        control.DataTextField = "EventType";
        control.DataValueField = "EventTypeId";
        control.DataBind();

    }

    public static void PopulateProductDetail(ListControl control)
    {
        control.DataSource = ProductDetailsDAL.GetItemList(0);
        control.DataTextField = "ProductDetail";
        control.DataValueField = "PRODUCTID";
        control.DataBind();

    }

    public static void PopulateEventTypeByReportId(ListControl control, int reportId)
    {
        control.DataSource = EventTypeDAL.GetItemListByReportId(reportId);
        control.DataTextField = "EventType";
        control.DataValueField = "EventTypeId";
        control.DataBind();
    }

    public static void PopulateCommissionCycleByReportId(ListControl control, int reportId)
    {
        control.DataSource = CommissionCycleDAL.GetCommissionCycleByReport(reportId);
        control.DataTextField = "CycleDescription";
        control.DataValueField = "CycleId";
        control.DataBind();
    }

    public static void PopulateChannelType(ListControl control)
    {
        control.DataSource = ChannelTypeDAL.GetItemList(0);
        control.DataTextField = "ChannelType";
        control.DataValueField = "ChannelTypeId";
        control.DataBind();
    }

    public static void PopulateSegmentType(ListControl control)
    {
        control.DataSource = SegmentTypeDAL.GetItemList(0);
        control.DataTextField = "TypeName";
        control.DataValueField = "SegmentTypeID";
        control.DataBind();
    }

    public static void PopulateEvent(ListControl control)
    {
        control.DataSource = EventDAL.GetItemList(0);
        control.DataTextField = "EventName";
        control.DataValueField = "EventID";
        control.DataBind();
    }

    public static void PopulateEventByReportId(ListControl control, Int32 reportId)
    {
        control.DataSource = EventDAL.GetItemList(0, 0, String.Empty, reportId);
        control.DataTextField = "EventName";
        control.DataValueField = "EventID";
        control.DataBind();
    }

    public static void PopulateAmountType(ListControl control)
    {
        control.DataSource = AmountTypeDAL.GetItemList(0);
        control.DataTextField = "AmountTypeName";
        control.DataValueField = "AmountTypeId";
        control.DataBind();

    }

    public static void PopulateSegment(ListControl control)
    {
        control.DataSource = SegmentDAL.GetItemList(0);
        control.DataTextField = "SegmentName";
        control.DataValueField = "SegmentID";
        control.DataBind();

    }

    public static void PopulateValidationRule(ListControl control)
    {
        control.DataSource = ValidationRuleDAL.GetItemList(0);
        control.DataTextField = "ValidationName";
        control.DataValueField = "ValidationRuleId";
        control.DataBind();

    }

    public static void PopulateCommissionType(ListControl control)
    {
        control.DataSource = CommissionTypeDAL.GetItemList(0);
        control.DataTextField = "CommissionTypeName";
        control.DataValueField = "CommissionTypeID";
        control.DataBind();

    }

    public static void PopulateActivity(ListControl control)
    {
        control.DataSource = ActivityDAL.GetItemList(0);
        control.DataTextField = "ActivityName";
        control.DataValueField = "ActivityID";
        control.DataBind();
    }

    public static void PopulatePeriodType(ListControl control)
    {
        control.DataSource = PeriodTypeDAL.GetItemList(0);
        control.DataTextField = "PeriodTypeName";
        control.DataValueField = "PeriodTypeId";
        control.DataBind();
    }

    public static void PopulateSetupProcess(ListControl control)
    {
        control.DataSource = ListProcessStageDAL.GetSetupProcessList(0);
        control.DataTextField = "STRPROCESSNAME";
        control.DataValueField = "NUMID";
        control.DataBind();
    }

    public static void PopulateApprovalFlow(ListControl lc, string approvalType)
    {
        lc.DataSource = ApprovalFlowDAL.GetApprovalFlowList(0, approvalType);
        lc.DataTextField = "APPROVALNAME";
        lc.DataValueField = "APPROVALFLOWID";
        lc.DataBind();
    }

    public static void PopulateFlow(List<SalesCom.Entity.ApprovalFlowEnt> flow, ListControl lc)
    {
        lc.DataSource = flow;
        lc.DataTextField = "APPROVALNAME";
        lc.DataValueField = "APPROVALFLOWID";
        lc.DataBind();
    }
    public static void PopulateSetupReportApproval(List<SalesCom.Entity.ReportApprovalEnt> sortedReportList, ListControl lc)
    {
        lc.DataSource = sortedReportList;
        lc.DataTextField = "report_name";
        lc.DataValueField = "report_approval_id";
        lc.DataBind();
    }
    public static void PopulateApprovalLevel(ListControl lc)
    {
        lc.DataSource = LevelCollectionDAL.GetItemList(0);
        lc.DataTextField = "NAME";
        lc.DataValueField = "LEVELCOLLECTIONID";
        lc.DataBind();
    }

    public static void PopulateApprovalLevel(ListControl lc, int flowid)
    {
        lc.DataSource = ApprovalLevel20DAL.GetApprovalLevelByFlowId(0, flowid, 0);
        lc.DataTextField = "APPROVALLEVELNAME";
        lc.DataValueField = "APPROVALLEVELID";
        lc.DataBind();
    }

    public static void PopulateApprovalLevelByFlowID(ListControl lc, int flowID)
    {
        lc.DataSource = ApprovalLevelDAL.GetApprovalLevelWithJoin(0, flowID, 0);
        lc.DataTextField = "NAME";
        lc.DataValueField = "APPROVALLEVELID";
        lc.DataBind();
    }

    public static void PopulateUserInfo(ListControl lc)
    {
        lc.DataSource = LevelUserDAL.GetUserInfoList(0);
        lc.DataTextField = "USERNAME";
        lc.DataValueField = "USERID";
        lc.DataBind();
    }

    public static void PopulateCommissionReportId(ListControl lc)
    {
        lc.DataSource = CommissionReportDAL.GetItemList(0);
        lc.DataTextField = "ReportName";
        lc.DataValueField = "ReportId";
        lc.DataBind();
    }
    public static void PopulateTargetReportId(ListControl lc, int status, int year, int quarter, string sGroup)
    {
        lc.DataSource = TargetDAL.GetKPIApprovedByAllList(status, year, quarter, sGroup);
        lc.DataTextField = "sales_channel_name";
        lc.DataValueField = "report_cycle_id";

        lc.DataBind();
        lc.Items.Insert(0, new ListItem("Select Channel", "0"));
    }
    public static void PopulateKPI(ListControl lc, int reportCycleId)
    {
        lc.DataSource = TargetDAL.GetKPIBySCHYQM(reportCycleId, 0);
        lc.DataTextField = "Kpi_Name";
        lc.DataValueField = "Kpi_id";

        lc.DataBind();
        lc.Items.Insert(0, new ListItem("Select KPI", "0"));
    }

    public static void PopulateKPIData(ListControl lc, int reportCycleId)
    {
        lc.DataSource = TargetDAL.GetKPIByData(reportCycleId, 0);
        lc.DataTextField = "Kpi_Name";
        lc.DataValueField = "Kpi_id";

        lc.DataBind();
        lc.Items.Insert(0, new ListItem("Select KPI", "0"));
    }

    public static void PopulateSubKPIData(ListControl lc, int reportCycleId, int parentKPI)
    {
        lc.DataSource = TargetDAL.GetKPIByData(reportCycleId, parentKPI);
        lc.DataTextField = "Kpi_Name";
        lc.DataValueField = "Kpi_id";

        lc.DataBind();
        lc.Items.Insert(0, new ListItem("Select Sub KPI", "0"));
    }


    public static void PopulateSubKPI(ListControl lc, int reportCycleId, int parentKPI)
    {
        lc.DataSource = TargetDAL.GetKPIBySCHYQM(reportCycleId, parentKPI);
        lc.DataTextField = "Kpi_Name";
        lc.DataValueField = "Kpi_id";

        lc.DataBind();
        lc.Items.Insert(0, new ListItem("Select Sub KPI", "0"));
    }

    public static void PopulateCondition(ListControl lc, int reportCycleId, int parentKPI)
    {
        lc.DataSource = TargetDAL.GetKPICondition(reportCycleId, parentKPI);
        lc.DataTextField = "CON_NAME";
        lc.DataValueField = "CON_ID";

        lc.DataBind();
        lc.Items.Insert(0, new ListItem("Select Condition", "0"));
    }
    public static void PopulateAdHocReportId(ListControl lc)
    {
        lc.DataSource = AdHocReportDAL.GetItemList(0);
        lc.DataTextField = "report_name";
        lc.DataValueField = "ad_hoc_report_id";
        lc.DataBind();
    }

    public static void PopulateThresholdType(ListControl lc)
    {
        lc.DataSource = ThresholdDAL.GetAll(0);
        lc.DataTextField = "Name";
        lc.DataValueField = "ThresholdTypeId";
        lc.DataBind();
    }

    public static void PopulateCommissionCycleId(ListControl lc, int periodTypeId)
    {
        lc.DataSource = CommissionCycleDAL.GetCommissionCycle(0, periodTypeId);
        lc.DataTextField = "CYCLEDESCRIPTION";
        lc.DataValueField = "CYCLEID";
        lc.DataBind();
    }

    public static void PopulateCommissionCycleByYear(ListControl lc, int periodTypeId, int year)
    {
        lc.DataSource = CommissionCycleDAL.GetCommissionCycleByYear(periodTypeId, year);
        lc.DataTextField = "CYCLEDESCRIPTION";
        lc.DataValueField = "CYCLEID";
        lc.DataBind();
    }

    public static void PopulateChannelId(ListControl lc)
    {
        lc.DataSource = ChannelDAL.GetItemList(0);
        lc.DataTextField = "ChannelName";
        lc.DataValueField = "ChannelId";
        lc.DataBind();
    }

    public static void PopulateProductChannel(ListControl lc)
    {
        lc.DataSource = ProductChannelDAL.GetItemList(0);
        lc.DataTextField = "PRODCHHNAME";
        lc.DataValueField = "PRODUCTCHANNELID";
        lc.DataBind();
    }

    public static void PopulateLevelCollection(ListControl lc)
    {
        lc.DataSource = LevelCollectionDAL.GetItemList(0);
        lc.DataTextField = "NAME";
        lc.DataValueField = "LEVELCOLLECTIONID";
        lc.DataBind();
    }

    public static void BindProcessStageOrder(DropDownList ddl)
    {
        try
        {
            ddl.Items.Clear();
            ddl.Items.Insert(0, new ListItem("[All]", "0"));
            ddl.Items.Insert(1, new ListItem("1", "1"));
            ddl.Items.Insert(2, new ListItem("2", "2"));
            ddl.Items.Insert(3, new ListItem("3", "3"));
            ddl.Items.Insert(4, new ListItem("4", "4"));
            ddl.Items.Insert(5, new ListItem("5", "5"));
            ddl.Items.Insert(6, new ListItem("6", "6"));
            ddl.Items.Insert(7, new ListItem("7", "7"));
            ddl.Items.Insert(8, new ListItem("8", "8"));
            ddl.Items.Insert(9, new ListItem("9", "9"));
            ddl.Items.Insert(10, new ListItem("10", "10"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static void PopulateRuleGroup(ListControl control)
    {
        control.DataSource = RuleGroupDAL.GetItemList();
        control.DataTextField = "GroupName";
        control.DataValueField = "GroupID";
        control.DataBind();
    }

    public static void PopulateReportGenType(ListControl lc)
    {
        lc.DataSource = ReportGenTypeDAL.GetItemList(0);
        lc.DataTextField = "Name";
        lc.DataValueField = "ReportGenTypeId";
        lc.DataBind();
    }

    public static void PopulateChannelEventBatch(ListControl lc, int reportId)
    {
        lc.DataSource = ChannelEventBatchDAL.GetItemListByReportId(reportId);
        lc.DataTextField = "BATCHSOURCE";
        lc.DataValueField = "CHANNELEVENTBATCHID";
        lc.DataBind();
    }


    public static void PopulateAdHocReportList(ListControl control)
    {
        control.DataSource = AdHocReportDAL.Get_AdHoc_Report_List();
        control.DataTextField = "REPORT_NAME";
        control.DataValueField = "AD_HOC_REPORT_ID";
        control.DataBind();
    }

    public static void PopulateReportType(ListControl listControl)
    {
        listControl.DataSource = ReportTypeDAL.GetItemList(0);
        listControl.DataTextField = "REPORT_TYPE_NAME";
        listControl.DataValueField = "REPORT_TYPE_ID";
        listControl.DataBind();
    }



    public static string DateFormat(object obj)
    {
        if (obj == null)
            return "";

        DateTime dt = Convert.ToDateTime(obj);
        if (dt == DateTime.MinValue)
            return "";

        return dt.ToString("dd-MMM-yy");

    }

    public static string DateTimeFormat(object obj)
    {
        if (obj == null)
            return "";
        DateTime dt = Convert.ToDateTime(obj);
        if (dt == DateTime.MinValue)
            return "";
        return dt.ToString("dd-MMM-yy (HH:mm)");

    }


    public static int ProcessMyDataItem(object myValue)
    {
        if (myValue == null)
        {
            return 0;
        }
        return Convert.ToInt32(myValue);
    }

    public static string ProcessBoolData(object myValue)
    {
        string result = "Inactive";

        if (myValue != null)
        {
            if (Convert.ToInt32(myValue) == 1)
            {
                result = "Active";
            }
        }
        return result;
    }

    public static void Download(string sFileName, string sFilePath)
    {
        HttpContext.Current.Response.ContentType = "APPLICATION/OCTET-STREAM";
        String Header = "Attachment; Filename=" + sFileName;
        HttpContext.Current.Response.AppendHeader("Content-Disposition", Header);
        System.IO.FileInfo Dfile = new System.IO.FileInfo(HttpContext.Current.Server.MapPath(sFilePath));
        HttpContext.Current.Response.WriteFile(Dfile.FullName);
        HttpContext.Current.Response.End();
    }

    public static void ExportToExcel(DataTable dt, string fileName)
    {
        using (XLWorkbook wb = new XLWorkbook())
        {
            var ws = wb.Worksheets.Add(dt, "Report Particulars");
            ws.Tables.FirstOrDefault().ShowAutoFilter = false;

            HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", String.Format("attachment; filename={0}.xls", fileName));
            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                //HttpContext.Current.Response.Clear(); 
                MyMemoryStream.WriteTo(HttpContext.Current.Response.OutputStream);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
        }
    }

    public static void ToCSV(DataTable dt, string fileName)
    {

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Buffer = true;
        //HttpContext.Current.Response.AddHeader("content-disposition",
        //    "attachment;filename=DataTable.csv");
        HttpContext.Current.Response.AddHeader("content-disposition", String.Format("attachment; filename={0}.csv", fileName));

        HttpContext.Current.Response.Charset = "";
        HttpContext.Current.Response.ContentType = "application/text";


        StringBuilder sb = new StringBuilder();
        for (int k = 0; k < dt.Columns.Count; k++)
        {
            //add separator
            sb.Append(dt.Columns[k].ColumnName + ',');
        }
        //append new line
        sb.Append("\r\n");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            for (int k = 0; k < dt.Columns.Count; k++)
            {
                //add separator
                sb.Append(dt.Rows[i][k].ToString().Replace(",", ";") + ',');
            }
            //append new line
            sb.Append("\r\n");
        }
        HttpContext.Current.Response.Output.Write(sb.ToString());
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
      
    }

    public static void TestMethodCSV2(DataTable dtCSV, string fileName)
    {
        // int i = 1;
        //// i = dt.Rows.Count / 100000;

        // for (int j = 1; j<=i; j++)
        // {
        //     DataTable dtfind = dt.AsEnumerable().Skip(j * 100000).Take(100000).CopyToDataTable();
        //     if (dtfind.Rows.Count > 0)
        //     {
        //         using (XLWorkbook wb = new XLWorkbook())
        //         {
        //             var ws = wb.Worksheets.Add(dtfind, "Report Particulars");
        //             //ws.Tables.FirstOrDefault().ShowAutoFilter = false;
        //             HttpContext.Current.Response.Clear();
        //             HttpContext.Current.Response.Buffer = true;
        //             HttpContext.Current.Response.Charset = "";

        //             HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        //             HttpContext.Current.Response.AppendHeader("Content-Disposition", String.Format("attachment; filename={0}.xlsx", fileName));
        //             using (MemoryStream MyMemoryStream = new MemoryStream())
        //             {

        //                 wb.SaveAs(MyMemoryStream);
        //                 //HttpContext.Current.Response.Clear(); 
        //                 MyMemoryStream.WriteTo(HttpContext.Current.Response.OutputStream);
        //                 HttpContext.Current.Response.Flush();
        //                 HttpContext.Current.Response.End();
        //             }
        //         }
        //     }
        // }

        // HttpContext.Current.Response.Flush();
        // HttpContext.Current.Response.End();


        //using (XLWorkbook wb = new XLWorkbook())
        //{
        //    var ws = wb.Worksheets.Add(dt, "Report Particulars");
        //    ws.Tables.FirstOrDefault().ShowAutoFilter = false;

        //    HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //    HttpContext.Current.Response.AppendHeader("Content-Disposition", String.Format("attachment; filename={0}.csv", fileName));
        //    using (MemoryStream MyMemoryStream = new MemoryStream())
        //    {
        //        wb.SaveAs(MyMemoryStream);
        //        //HttpContext.Current.Response.Clear(); 
        //        MyMemoryStream.WriteTo(HttpContext.Current.Response.OutputStream);
        //        HttpContext.Current.Response.Flush();
        //        HttpContext.Current.Response.End();
        //    }
        //}
    }

    public static void TestMethodCSV(DataTable dtCSV, string fileName)
    {
    if (dtCSV != null && dtCSV.Rows.Count > 0)
           {
               // create object for the StringBuilder class
               StringBuilder sb = new StringBuilder();
 
               // Get name of columns from datatable and assigned to the string array
               string[] columnNames = dtCSV.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
 
               // Create comma sprated column name based on the items contains string array columnNames
               sb.AppendLine(string.Join(",", columnNames));
 
               // Fatch rows from datatable and append values as comma saprated to the object of StringBuilder class 
               foreach (DataRow row in dtCSV.Rows)
               {
                   IEnumerable<string> fields = row.ItemArray.Select(field => string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                   sb.AppendLine(string.Join(",", fields));
               }
 
               // save the file
               File.WriteAllText(@"D:\Codingzee.csv", sb.ToString());
           }
    }

    public static void ExportToExcelinXLSXformat(DataTable dt, string fileName)
    {
        using (XLWorkbook wb = new XLWorkbook())
        {
            var ws = wb.Worksheets.Add(dt, "Report Particulars");
            ws.Tables.FirstOrDefault().ShowAutoFilter = false;

            HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", String.Format("attachment; filename={0}.xlsx", fileName));
            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                //HttpContext.Current.Response.Clear(); 
                MyMemoryStream.WriteTo(HttpContext.Current.Response.OutputStream);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
        }
    }


    public static List<int> GenrateYear()
    {
        return Enumerable.Range(2015, Math.Abs((System.DateTime.Now.Year - 2014))).OrderByDescending(x => x).ToList();
    }

    public static void RemoveNullColumnFromDataTable(DataTable dt)
    {
        for (int i = dt.Rows.Count - 1; i >= 0; i--)
        {
            if (dt.Rows[i][0] == DBNull.Value)
                dt.Rows[i].Delete();
        }
        dt.AcceptChanges();
    }

    public static void PopulateSalesChannel(ListControl control, int sGroupID)
    {
        control.DataSource = ESI_SalesChannelDAL.GetItemList(sGroupID);
        control.DataTextField = "sales_channel_name";
        control.DataValueField = "sales_channel_id";
        control.DataBind();
        //control.Items.Insert(0, "[Select One]");
        control.Items.Insert(0, new ListItem("[Select One]", "0"));
    }
    public static void PopulateSalesGroup(ListControl control, int userId)
    {
        var salesGroup = SalesGroupDAL.GetSalesGroupByUserId(userId);
        control.DataSource = salesGroup;
        control.DataTextField = "SALES_GROUP_NAME";
        control.DataValueField = "SALES_GROUP_ID";
        control.DataBind();

        if (control.Items.Count == 0)
        {
            control.Attributes["style"] = "display: none;";
        }
        else
        {
            control.Attributes["style"] = "";
            //control.Items.Insert(0, "[Select One]");
            control.Items.Insert(0, new ListItem("[Select One]", "0"));
        }

    }
    public static int PopulateHoDnDirectorRoles(ListControl control, int userId)
    {
        var Employee = UserMappDAL.GetHoDnDirectorRoles(userId);
        control.DataSource = Employee;
        control.DataTextField = "NAME";//UNIT
        control.DataValueField = "EMPLOYEENO";
        control.DataBind();

        if (control.Items.Count == 0)
        {
            control.Attributes["style"] = "display: none;";
        }
        else
        {
            control.Attributes["style"] = "";
        }
        control.Items.Insert(0, "---Select All---");
        return Employee.Count;
    }
    public static int PopulateCXODirectorRoles(ListControl control, int userId)
    {
        var Employee = UserMappDAL.GetCXODirectorRoles(userId);
        control.DataSource = Employee;
        control.DataTextField = "NAME"; //DEPARTMENT
        control.DataValueField = "EMPLOYEENO";
        control.DataBind();

        if (control.Items.Count == 0)
        {
            control.Attributes["style"] = "display: none;";
        }
        else
        {
            control.Attributes["style"] = "";
        }
        control.Items.Insert(0, "---Select All---");
        return Employee.Count;
    }
    public static int PopulateRegionalHead(ListControl control, int userId)
    {
        var Employee = UserMappDAL.GetRegionalHead(userId);
        control.DataSource = Employee;
        control.DataTextField = "NAME";
        control.DataValueField = "EMPLOYEENO";
        control.DataBind();

        if (control.Items.Count == 0)
        {
            control.Attributes["style"] = "display: none;";
        }
        else
        {
            control.Attributes["style"] = "";
        }
        control.Items.Insert(0, "---Select All---");
        return Employee.Count;
    }
    public static int PopulateSalesEmployeeRoles(ListControl control, int userId)
    {
        var Employee = UserMappDAL.GetSalesEmployeeRoles(userId);
        control.DataSource = Employee;
        control.DataTextField = "NAME";
        control.DataValueField = "EMPLOYEENO";
        control.DataBind();

        if (control.Items.Count == 0)
        {
            control.Attributes["style"] = "display: none;";
        }
        else
        {
            control.Attributes["style"] = "";
        }
        control.Items.Insert(0, "---Select All---");
        return Employee.Count;
    }
    public static void PopulateKpiList(ListControl control, int group_id)
    {
        control.DataSource = ESI_KPIDAL.GetItemList(group_id);
        control.DataTextField = "kpi_name";
        control.DataValueField = "kpi_id";
        control.DataBind();
        control.Items.Insert(0, "[Select One]");
    }


    //public static void PopulateRegionalHead(ListControl control, int clusterId)
    //{
    //    control.DataSource = ESI_ReportDAL.GetRegionHeadList(clusterId);
    //    control.DataTextField = "kpi_name";
    //    control.DataValueField = "kpi_id";
    //    control.DataBind();
    //    control.Items.Insert(0, "[Select KPI]");
    //}

    //public static void PopulateMappingType(ListControl control)

    public static void PopulateMappingType(ListControl control, int group_id)
    {
        control.DataSource = ESI_ManualMappingDAL.GetItemList(group_id);
        control.DataTextField = "mapping_name";
        control.DataValueField = "manualmapcnfg_id";
        control.DataBind();
        control.Items.Insert(0, "[Select One]");
    }

    public static void PopulateDataType(ListControl control, int group_id)
    {
        control.DataSource = ESI_ManualDataDAL.GetItemList(group_id);
        control.DataTextField = "data_name";
        control.DataValueField = "manualdatacnfg_id";
        control.DataBind();
        control.Items.Insert(0, "[Select One]");
    }

    public static void PopulateSubKpiList(ListControl control, int kpiId)
    {
        control.DataSource = ESI_KPIDAL.GetSubKpiByKpiId(kpiId);
        control.DataTextField = "kpi_name";
        control.DataValueField = "kpi_id";
        control.DataBind();
        control.Items.Insert(0, "[Select One]");
    }
    public static void PopulateCDPReportList(ListControl control)
    {
        control.DataSource = CdpReportDAL.Get_CDP_Report_List();
        control.DataTextField = "report_name";
        control.DataValueField = "cdp_report_info_id";
        control.DataBind();
    }
    public static void PopulateDailyDenoCampignList(ListControl lc)
    {
        lc.DataSource = DailyDenoCampaignDAL.GetActiveItemList(0);
        lc.DataTextField = "CampaignName";
        lc.DataValueField = "CampaignID";
        lc.DataBind();
        lc.Items.Insert(0, "[Select One]");
    }


    public static void PopulateDenoCampignList(ListControl lc)
    {
        lc.DataSource = DenoCampaignDAL.GetActiveItemList(0);
        lc.DataTextField = "CampaignName";
        lc.DataValueField = "CampaignID";
        lc.DataBind();
        lc.Items.Insert(0, "[Select One]");
    }


    #region Deno Drive SetUp Related Code

    public static void RecipientType(ListControl control)
    {
        control.DataSource = DenoDriveDAL.GetRecipientType();
        control.DataTextField = "RecipientType";
        control.DataValueField = "RecipientId";
        control.DataBind();
    }

    public static void ModalityType(ListControl control)
    {
        control.DataSource = DenoDriveDAL.ModalityType();
        control.DataTextField = "ModalityType";
        control.DataValueField = "ModalityId";
        control.DataBind();
    }

    public static void GetModalityValue(ListControl control, int id)
    {
        control.DataSource = CampaignDenoDriveDAL.GetModalityValue(id);
        control.DataTextField = "Text";
        control.DataValueField = "Value";
        control.DataBind();
    }

    public static void ApprovalFlowType(ListControl control)
    {
        control.DataSource = DenoDriveDAL.ApprovalFlowType();
        control.DataTextField = "Text";
        control.DataValueField = "Value";
        control.DataBind();
    }

    #endregion
}
