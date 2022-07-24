using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

public partial class SetupActivity : System.Web.UI.Page
{

    List<ErrorMessageEnt> errorMessage;
    //List<CommissionReportTargetsEnt> commissionReportTargets;

    protected void pager_PreRender(object sender, EventArgs e)
    {
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (!Permissions.ImportCommissionTargetView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            Common.PopulateCommissionReportId(ddlReportName);
            Common.AddSelectOne(ddlReportName);
            Common.PopulateThresholdType(ddlThresholdType);
            Common.AddSelectOne(ddlThresholdType);
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.PostedFile != null)
            UploadExcelFileToApplicationServer();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveDataToDatabase();
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
    protected void ddlReportName_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.PopulateEventTypeByReportId(ddlEventType, int.Parse(ddlReportName.SelectedValue));
        Common.AddSelectOne(ddlEventType);
        Common.PopulateCommissionCycleByReportId(ddlReportCycle, int.Parse(ddlReportName.SelectedValue));
        Common.AddSelectOne(ddlReportCycle);
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
            throw ex;
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

   
        if (checkThresholdMismatch(dtExcelRecords))
        {
            errorMessage = new ImportExcelToDataBaseDAL().SaveCommissionTarget(dtExcelRecords, int.Parse(ddlReportName.SelectedValue), int.Parse(ddlEventType.SelectedValue), currentUser, int.Parse(ddlReportCycle.SelectedValue), int.Parse(ddlThresholdType.SelectedValue));

            if (errorMessage != null && errorMessage.Count > 0)
            {
                this.lblResult.ForeColor = Color.Green;
                this.lblResult.Text = string.Format("Total {0} rows inserted at Temp Table", errorMessage[0].RowCount);
                BindData();
            }
            else
            {
                this.lblResult.ForeColor = Color.Green;
                this.lblResult.Text = string.Format("Total {0} rows inserted", dtExcelRecords.Rows.Count);
            }
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
        else if (ddlThresholdType.SelectedIndex > 1 && dt.Columns.Count < 3)
        {
            this.lblResult.ForeColor = Color.Red;
            lblResult.Text = "Threshold is missing on workbook";
            return false;
        }
        else if (ddlThresholdType.SelectedIndex == 1 && (dt.Columns.Count >= 3))
        {
            this.lblResult.ForeColor = Color.Red;
            lblResult.Text = "You have choose none type threshold, but slected excel sheet contains more columns";
            return false;
        }
        else
        {
            return true;
        }

    }


    private void Reset()
    {
        this.lblResult.Text = String.Empty;
        ddlSheets.DataSource = null;
        ddlSheets.DataBind();
        lblFileName.Text = String.Empty;
        Panel2.Visible = false;
        Panel1.Visible = true;
    }
    private void BindData()
    {
        if (errorMessage != null)
        {
            lv.DataSource = errorMessage;
            lv.DataBind();
            this.lblResult.ForeColor = Color.Green;
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

        if (ddlReportName.SelectedIndex == 0)
        {
            lblResult.Text = "Report Name Required!";
            this.ddlReportName.Focus();
            return false;
        }
        else if (ddlReportCycle.SelectedIndex == 0)
        {
            lblResult.Text = "Report Cycle Required!";
            this.ddlReportName.Focus();
            return false;
        }
        else if (ddlEventType.SelectedIndex == 0)
        {
            lblResult.Text = "Event Type Required!";
            this.ddlEventType.Focus();
            return false;
        }

        else if (ddlThresholdType.SelectedIndex == 0)
        {
            lblResult.Text = "Threshold status required";
            this.ddlThresholdType.Focus();
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
        Common.Download("VariableCommissionTarget.xlsx", "ImportFileSample/VariableCommissionTarget.xlsx");
    }
}