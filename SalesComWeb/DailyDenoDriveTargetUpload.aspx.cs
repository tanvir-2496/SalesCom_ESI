using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SalesCom.Entity;
using SalesCom.DAL;

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

using System.Collections;
using System.Data.OracleClient;
using System.DirectoryServices;
using System.Web.Security;


public partial class DailyDenoDriveTargetUpload : System.Web.UI.Page
{
    List<ErrorMessageEnt> errorMessage;

    protected void pager_PreRender(object sender, EventArgs e)
    {
    }

    protected Int32 CampaignID
    {
        get { return (Int32)ViewState["CampaignID"]; }
        set { ViewState["CampaignID"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.DailyCampaignUpdate)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            var userId = LoginInfo.Current.UserId;
            Common.PopulateDailyDenoCampignList(ddlReportName);

            if (!string.IsNullOrEmpty(Request["CampaignID"]))
            {
                CampaignID = int.Parse(Request.QueryString["CampaignID"]);
                ddlReportName.ClearSelection();
                ddlReportName.Items.FindByValue(CampaignID.ToString()).Selected = true;
                ddlReportName.Enabled = false;
            }
        }
    }
    
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        int campaignId;
        var dropdowvalue = ddlReportName.SelectedValue;
        bool isNumber = int.TryParse(dropdowvalue, out campaignId);
        if (campaignId > 0)
        {
            if (FileUpload1.PostedFile != null)
                UploadExcelFileToApplicationServer();
        }
        else {
            this.lblMessage.ForeColor = Color.Red;
            this.lblMessage.Text = "Please select a campaign.";
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        try
        {
            SaveDataToDatabase();
        }
        catch (Exception ex)
        {
        }
        
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
            //throw ex;
            this.lblResult.ForeColor = Color.Red;
            this.lblResult.Text = "Error Occured!!!" +ex.Message;
        }
    }

    private void GetExcelSheets(string FilePath, string Extension, string isHDR)
    {
        try
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
            Panel3.Visible = false;
            this.lblResult.Text = String.Empty;
            this.lblMessage.Text = String.Empty;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        

    }

    private void SaveDataToDatabase()
    {
        if (true)//CheckInput()
        {
            DataTable dtExcelRecords = new DataTable(); ;
            string FileName = lblFileName.Text;
            string Extension = Path.GetExtension(FileName);
            string FolderPath = Server.MapPath(ConfigurationManager.AppSettings["FolderPath"]);
            string currentUser = (HttpContext.Current.Session["LoginInfo"] as LoginInfo).UserName;
            string FileMap = String.Format("{0}//{1}", FolderPath, FileName);
            var campaignId = Convert.ToInt32(ddlReportName.SelectedValue == "" ? "1" : ddlReportName.SelectedValue);

            if (ddlSheets.SelectedIndex != 0 && ddlSheets.SelectedValue != null)
            {

                if (this.rbHDR.SelectedValue == "Yes")
                {
                    dtExcelRecords = Common.ReadExcelSheet(Extension, FileMap, ddlSheets.SelectedValue, true);
                    int columnCount= dtExcelRecords.Columns.Count;
                    if (columnCount <= 13)
                    {
                        ImportData(dtExcelRecords, campaignId);
                    }
                    else
                    {
                        this.lblResult.ForeColor = Color.Red;
                        this.lblResult.Text = "Your Selected sheet contains 14 columns but the max limit is 13 columns.";
                    }
                }
                else
                {
                    dtExcelRecords = Common.ReadExcelSheet(Extension, FileMap, ddlSheets.SelectedValue, false);
                    int columnCount = dtExcelRecords.Columns.Count;
                    if (columnCount <= 13)
                    {
                        ImportData(dtExcelRecords, campaignId);
                    }
                    else
                    {
                        this.lblResult.ForeColor = Color.Red;
                        this.lblResult.Text = "Your Selected sheet contains 14 columns but the max is 13 columns.";
                    }
                }
            }
            else
            {
                this.lblResult.ForeColor = Color.Red;
                this.lblResult.Text = "Please select a sheet";
            }
        }
    }

    private void ImportData(DataTable dtExcelRecords, int campaignId)
    {
        try 
        {
            if (checkThresholdMismatch(dtExcelRecords))
            {
                int imported_by = LoginInfo.Current.UserId;
                string imported_name = LoginInfo.Current.UserName;

                var message = DailyDenoDriveTargetUploadDAL.ImportDatatoDatabaseTabel(dtExcelRecords, campaignId, imported_by);
                this.lblResult.ForeColor = Color.Green;
                this.lblResult.Text = message;
                
            }
        }
        catch (Exception ex)
        {
            this.lblResult.ForeColor = Color.Red;
            this.lblResult.Text = "Error Occured!!! "+ex.Message;
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
        this.lblResult.Text = String.Empty;
        ddlSheets.DataSource = null;
        ddlSheets.DataBind();
        lblFileName.Text = String.Empty;
        Panel2.Visible = false;
        Panel1.Visible = true;
        Panel3.Visible = true;
        this.lblMessage.Text = String.Empty;
    }

    private void BindData()
    {
        if (errorMessage != null)
        {
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

    protected void btnDownloadSample_Click(object sender, EventArgs e)
    {
        Common.Download("DailyDenoCampTarget.xlsx", "ImportFileSample/DailyDenoCampTarget.xlsx");
    }
}
