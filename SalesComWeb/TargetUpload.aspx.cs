using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SalesCom.Entity;

using SalesCom.DAL;
using SalesCom.Entity;

using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using Microsoft.Win32;
using System.Globalization;
using ESI.DAL;
using ESI.Entity.ViewModel;
using ESI.Entity;


public partial class TargetUpload : System.Web.UI.Page
{

    List<ErrorMessageEnt> errorMessage;
    
    protected void pager_PreRender(object sender, EventArgs e)
    {
    }
    protected void Page_Load(object sender, EventArgs e)
    { 
        if (!IsPostBack)
        {
            if (!Permissions.ESITargetUpload)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            this.ddlYear.DataSource = Common.GenrateYear();
            this.ddlYear.DataBind();
            var userId = LoginInfo.Current.UserId;
            Common.PopulateSalesGroup(ddlSalesGroup, userId);
            ClearAllDropdown();
        }
    }
    #region Selected DropDown 

    protected void ClearAllDropdown()
    {
        this.ddlReportName.Items.Clear();
        this.ddlReportName.DataBind();

        this.ddlMonth.Items.Clear();
        this.ddlMonth.DataBind();

        this.ddlKPI.Items.Clear();
        this.ddlKPI.DataBind();
        this.ddlKPI.Items.Insert(0, new ListItem("Select KPI", "0"));

        this.ddlSubKPI.Items.Clear();
        this.ddlSubKPI.DataBind();
        this.ddlSubKPI.Items.Insert(0, new ListItem("Select Sub KPI", "0"));

        this.ddlCondition.Items.Clear();
        this.ddlCondition.DataBind();
        this.ddlCondition.Items.Insert(0, new ListItem("Select Condition", "0"));
    }

    protected void ddlSalesGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearAllDropdown();
        string salesGroup = ddlSalesGroup.SelectedItem.Text;
        if (Convert.ToInt32(ddlSalesGroup.SelectedItem.Value) == 0)
        {
            return;
        }
        var year = Convert.ToInt32(ddlYear.SelectedValue == "" ? DateTime.Now.Year.ToString() : ddlYear.SelectedValue);
        var quarter = Convert.ToInt32(ddlQuarter.SelectedValue == "0" ? "1" : ddlQuarter.SelectedValue);
        Common.PopulateTargetReportId(ddlReportName, 0, year, quarter, salesGroup);
    }
    protected void ddl_Year_IndexChanged(object sender, EventArgs e)
    {
        ClearAllDropdown();
        string salesGroup = ddlSalesGroup.SelectedItem.Text;
        if (Convert.ToInt32(ddlSalesGroup.SelectedItem.Value) == 0)
        {
            return;
        }
        var year = Convert.ToInt32(ddlYear.SelectedValue == "" ? DateTime.Now.Year.ToString() : ddlYear.SelectedValue);
        var quarter = Convert.ToInt32(ddlQuarter.SelectedValue == "0" ? "1" : ddlQuarter.SelectedValue);
        Common.PopulateTargetReportId(ddlReportName, 0, year, quarter, salesGroup);
    }
    protected void ddl_Quarter_IndexChanged(object sender, EventArgs e)
    {
        ClearAllDropdown();
        string salesGroup = ddlSalesGroup.SelectedItem.Text;
        if (Convert.ToInt32(ddlSalesGroup.SelectedItem.Value) == 0)
        {
            return;
        }
        var year = Convert.ToInt32(ddlYear.SelectedValue == "" ? DateTime.Now.Year.ToString() : ddlYear.SelectedValue);
        var quarter = Convert.ToInt32(ddlQuarter.SelectedValue == "0" ? "1" : ddlQuarter.SelectedValue);
        Common.PopulateTargetReportId(ddlReportName, 0, year, quarter, salesGroup);
    }
    protected void ddlReportName_SelectedIndexChanged(object sender, EventArgs e)
    {
        var reportCycleId = Convert.ToInt32(ddlReportName.SelectedValue == "" ? "1" : ddlReportName.SelectedValue);

        this.ddlKPI.Items.Clear();
        this.ddlKPI.DataBind();
        this.ddlKPI.Items.Insert(0, new ListItem("Select KPI", "0"));

        this.ddlSubKPI.Items.Clear();
        this.ddlSubKPI.DataBind();
        this.ddlSubKPI.Items.Insert(0, new ListItem("Select Sub KPI", "0"));

        Common.PopulateKPI(ddlKPI, reportCycleId);
        MonthDropDown();
        var monthid = Convert.ToInt32(ddlMonth.SelectedValue == "" ? "1" : ddlMonth.SelectedValue);
        //Target Status
        try
        {
            List<TargetListEnt> TargetList = TargetDAL.GetTargetStatus(reportCycleId, monthid);
            foreach (var target in TargetList)
            {
                if (target.targetValue > 0)
                {
                    target.status = "Target Uploaded";
                }
                else
                {
                    target.status = "";
                }
            }
            lv_Target_Status.DataSource = TargetList;
            lv_Target_Status.DataBind();
        }
        catch (Exception ex)
        {
            this.lblResult.ForeColor = Color.Red;
            this.lblResult.Text = "Error Occured!!!";
        }

    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        var reportCycleId = Convert.ToInt32(ddlReportName.SelectedValue == "" ? "1" : ddlReportName.SelectedValue);
        var monthid = Convert.ToInt32(ddlMonth.SelectedValue == "" ? "1" : ddlMonth.SelectedValue);
        //Target Status
        try
        {
            List<TargetListEnt> TargetList = TargetDAL.GetTargetStatus(reportCycleId, monthid);
            foreach (var target in TargetList)
            {
                if (target.targetValue > 0)
                {
                    target.status = "Target Uploaded";
                }
                else
                {
                    target.status = "";
                }
            }
            lv_Target_Status.DataSource = TargetList;
            lv_Target_Status.DataBind();
        }
        catch (Exception ex)
        {
            this.lblResult.ForeColor = Color.Red;
            this.lblResult.Text = "Error Occured!!!";
        }
    }
    protected void ddl_KPI_IndexChanged(object sender, EventArgs e)
    {
        var reportCycleId = Convert.ToInt32(ddlReportName.SelectedValue == "" ? "1" : ddlReportName.SelectedValue);
        var parentKPI = Convert.ToInt32(ddlKPI.SelectedValue == "" ? "1" : ddlKPI.SelectedValue);
        Common.PopulateSubKPI(ddlSubKPI, reportCycleId, parentKPI);
        Common.PopulateCondition(ddlCondition, reportCycleId, parentKPI);
    }

    protected void ddl_SubKPI_IndexChanged(object sender, EventArgs e)
    {
        var reportCycleId = Convert.ToInt32(ddlReportName.SelectedValue == "" ? "1" : ddlReportName.SelectedValue);
        var parentKPI = Convert.ToInt32(ddlSubKPI.SelectedValue == "" ? "1" : ddlSubKPI.SelectedValue);
        Common.PopulateCondition(ddlCondition, reportCycleId, parentKPI);
    }  

    public void MonthDropDown() {

        string reportname = ddlReportName.SelectedItem.Text;
        this.ddlMonth.Items.Clear(); 
        this.ddlMonth.DataBind();

        if (reportname.Contains("_M1_"))
        {
            ddlMonth.Items.Insert(0, new ListItem("M1", "1"));
        }
        else if (reportname.Contains("_M1_"))
        {
            ddlMonth.Items.Insert(0, new ListItem("M2", "2"));
        }
        else if (reportname.Contains("_M1_"))
        {
            ddlMonth.Items.Insert(0, new ListItem("M3", "3"));
        }
        else
        {
            ddlMonth.Items.Insert(0, new ListItem("Quarterly", "0"));
            ddlMonth.Items.Insert(1, new ListItem("M1", "1"));
            ddlMonth.Items.Insert(2, new ListItem("M2", "2"));
            ddlMonth.Items.Insert(3, new ListItem("M3", "3"));
        }
    }
    #endregion
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.PostedFile != null)
        {
            UploadExcelFileToApplicationServer();
            btnCancel.Visible = true;
            btnUploadAnotherKPITarget.Visible = false;
        }
            
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveDataToDatabase();
        btnCancel.Visible = false;
        btnUploadAnotherKPITarget.Visible = true;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Reset();
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        BindData();
        pager.SetPageProperties(0, pager.MaximumRows, false);
    }

    protected void btnShowPreviousImportData_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewCommissionReportTarget.aspx");
    }
    protected void ddlSheets_DataBound(object sender, EventArgs e)
    {
        RefineExcelSheetName();
    }

    private void UploadExcelFileToApplicationServer()
    {
        try
        {
            this.lv.DataSource = null;
            string[] validFileTypes = { "xls", "xlsx" };
            string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
            bool isValidFile = false;
            for (int i = 0; i < validFileTypes.Length; i++)
            {
                if (ext == "." + validFileTypes[i])
                {
                    isValidFile = true;
                    break;
                }
            }
            if (!isValidFile)
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "Invalid File, please upload file with extensions: " +
                               string.Join(" or ", validFileTypes);
            }
            else
            {
                if (FileUpload1.HasFile)
                {
                    string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                    string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
                    string FilePath = Server.MapPath(FolderPath + FileName);
                    FileUpload1.SaveAs(FilePath);
                    GetExcelSheets(FilePath, Extension, "Yes");
                }
            }
        }
        catch (Exception ex)
        {
            this.lblResult.ForeColor = Color.Red;
            this.lblResult.Text = "Error Occured!!!";
        }
    }

    private void GetExcelSheets(string FilePath, string Extension, string isHDR)
    {
        DataTable schemaTable;
        string conStr = "";

        switch (Extension)
        {
            case ".xls": //Excel 97-03
                conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                break;
            case ".xlsx": //Excel 07
                conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                break;
        }

        conStr = String.Format(conStr, FilePath, isHDR);
        OleDbConnection conn = new OleDbConnection(conStr);
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = conn;

        if (conn.State == ConnectionState.Open)
            conn.Close();

        conn.Open();

        schemaTable = Common.FilterSchemaTable(conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "TABLE" }));

        DataRow[] filteredDataRow = schemaTable.Select("TABLE_NAME like '%$' or TABLE_NAME like '%$'''");
        DataTable filteredTable = new DataTable();

        conn.Close();

        if (filteredDataRow.Length > 0)
        {
            filteredTable = filteredDataRow.CopyToDataTable();
        }

        ddlSheets.Items.Clear();
        ddlSheets.Items.Add(new ListItem("Select Sheet", ""));
        ddlSheets.DataSource = filteredTable;
        ddlSheets.DataTextField = "TABLE_NAME";
        ddlSheets.DataValueField = "TABLE_NAME";
        ddlSheets.DataBind();

        lblFileName.Text = Path.GetFileName(FilePath);
        Panel2.Visible = true;
        Panel1.Visible = false;

    }

    private void ImportData(DataTable dtExcelRecords, string currentUser)
    {
        try 
        {
            if (checkThresholdMismatch(dtExcelRecords))
            {
                int reportCycleId = Convert.ToInt32(ddlReportName.SelectedValue);
                int year = Convert.ToInt32(ddlYear.SelectedValue);
                int quarter = Convert.ToInt32(ddlQuarter.SelectedValue);
                int month = Convert.ToInt32(ddlMonth.SelectedValue);
                int kpi_id = (Convert.ToInt32(ddlSubKPI.SelectedValue) > 0) ? Convert.ToInt32(ddlSubKPI.SelectedValue) : Convert.ToInt32(ddlKPI.SelectedValue);
                int targetType = Convert.ToInt32(ddlTargetType.SelectedValue);
                int conditionId = Convert.ToInt32(ddlCondition.SelectedValue);
                int imported_by = LoginInfo.Current.UserId;
                string imported_by_name = LoginInfo.Current.UserName;

                int groupId = Convert.ToInt32(ddlSalesGroup.SelectedValue);
                List<KPIConfigurationEnt> kpiConfig = TargetDAL.GetKPIConfig(reportCycleId, year, quarter, month, kpi_id);
                errorMessage = ESI_ExcelToDataBaseDAL.UploadTarget(dtExcelRecords, groupId, kpiConfig[0].SALES_CHANNEL_ID, year, quarter, month, kpi_id, targetType, imported_by, imported_by_name, kpiConfig[0].REPORT_CYCLE_ID, kpiConfig[0].KPI_CONFIG_ID,conditionId);
               
                if (errorMessage != null && errorMessage.Count > 0)
                {
                    this.lblResult.ForeColor = Color.Red;
                    this.lblResult.Text = string.Format("Error Occured!!! Total {0} rows inserted at Temp Table", errorMessage[0].RowCount);
                    BindData();
                }
                else
                {
                    this.lblResult.ForeColor = Color.Green;
                    this.lblResult.Text = string.Format("Total {0} rows inserted", dtExcelRecords.Rows.Count);
                }
            }
        }
        catch (Exception ex)
        {
            this.lblResult.ForeColor = Color.Red;
            this.lblResult.Text = "Error Occured!!!";
        }

    }


    private bool checkThresholdMismatch(DataTable dt)
    {

        if (!(dt.Rows.Count > 0))
        {
            this.lblResult.ForeColor = Color.Red;
            this.lblResult.Text = "Selected file does not contain any row";
            return false;
        }
        
        else
        {
            return true;
        }

    }


    private void Reset()
    {
        lblResult.Text = String.Empty;
        ddlSheets.DataSource = null;
        ddlSheets.DataBind();
        lblFileName.Text = String.Empty;
        Panel2.Visible = false;
        Panel1.Visible = true;
        lv.Visible = false;
    }
    private void BindData()
    {
        if (errorMessage != null)
        {
            lv.Visible = true;
            lv.DataSource = errorMessage;
            lv.DataBind();
            this.lblResult.ForeColor = Color.Red;
            lblResults.Text = String.Format("Total results: {0}", errorMessage.Count);
            pager.Visible = errorMessage.Count > pager.PageSize;
        }
    }
    private void RefineExcelSheetName()
    {
        if (this.ddlSheets.Items.Count > 0)
        {
            foreach (ListItem item in this.ddlSheets.Items)
            {
                item.Text = item.Text.Replace("$", String.Empty).Replace("'", String.Empty);
            }
        }
    }

    private void SaveDataToDatabase()
    {
        if (CheckInput())
        {
            DataTable dtExcelRecords = new DataTable(); ;
            string FileName = lblFileName.Text;
            string Extension = Path.GetExtension(FileName);
            string FolderPath = Server.MapPath(ConfigurationManager.AppSettings["FolderPath"]);

            string currentUser = (HttpContext.Current.Session["LoginInfo"] as LoginInfo).UserName;

            string FileMap = String.Format("{0}//{1}", FolderPath, FileName);

            if (ddlSheets.SelectedIndex != 0 && ddlSheets.SelectedValue != null)
            {

                if (this.rbHDR.SelectedValue == "Yes")
                {
                    dtExcelRecords = Common.ReadExcelSheet(Extension, FileMap, ddlSheets.SelectedValue, true);
                    ImportData(dtExcelRecords, currentUser);
                }
                else
                {
                    dtExcelRecords = Common.ReadExcelSheet(Extension, FileMap, ddlSheets.SelectedValue, false);
                    ImportData(dtExcelRecords, currentUser);
                }
            }
            else
            {
                this.lblResult.ForeColor = Color.Red;
                this.lblResult.Text = "Please select a sheet";
            }
        }
    }

    private bool CheckInput()
    {

        if (ddlReportName.SelectedValue == "0")
        {
            lblResult.Text = "Sales Channel Required!";
            this.ddlReportName.Focus();
            return false;
        }
        if (ddlYear.SelectedValue == "0")
        {
            lblResult.Text = "Year Required!";
            this.ddlYear.Focus();
            return false;
        }
        if (ddlQuarter.SelectedValue == "0")
        {
            lblResult.Text = "Quarter Required!";
            this.ddlQuarter.Focus();
            return false;
        }
        if (ddlKPI.SelectedValue == "0")
        {
            lblResult.Text = "KPI Required!";
            this.ddlKPI.Focus();
            return false;
        }
        else
        {
            lblResult.Text = String.Empty;
            return true;
        }

    }

    protected void btnDownloadSample_Click(object sender, EventArgs e)
    {
        Common.Download("EsiTargetFileSample.xls", "ImportFileSample/EsiTargetFileSample.xls");
    }
}