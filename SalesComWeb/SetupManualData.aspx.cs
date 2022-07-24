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



public partial class SetupManualData : System.Web.UI.Page
{
    List<ErrorMessageEnt> errorMessage;

    protected void pager_PreRender(object sender, EventArgs e)
    {
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.ESISetupManualData)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            this.ddlYear.DataSource = Common.GenrateYear();
            this.ddlYear.DataBind();
            MonthDropDown();
            var userId = LoginInfo.Current.UserId;
            Common.PopulateSalesGroup(ddlSalesGroup, userId);

        }
    }
    protected void ddl_SalesGroup_IndexChanged(object sender, EventArgs e)
    {
        Common.PopulateDataType(ddlDataType, Convert.ToInt32(ddlSalesGroup.SelectedValue));
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
        Common.PopulateDataType(ddlDataType, Convert.ToInt32(ddlSalesGroup.SelectedValue));
        BindData();
        pager.SetPageProperties(0, pager.MaximumRows, false);
    }

    protected void ddlSheets_DataBound(object sender, EventArgs e)
    {
        RefineExcelSheetName();
    }

    protected void ddl_Quarter_IndexChanged(object sender, EventArgs e)
    {
        MonthDropDown();
    }

    public void MonthDropDown()
    {
        int firstMonthIndex = 1;
        if (ddlQuarter.SelectedValue == "1")
        {
            firstMonthIndex = 1;
        }
        if (ddlQuarter.SelectedValue == "2")
        {
            firstMonthIndex = 4;
        }
        if (ddlQuarter.SelectedValue == "3")
        {
            firstMonthIndex = 7;
        }
        if (ddlQuarter.SelectedValue == "4")
        {
            firstMonthIndex = 10;
        }
        this.ddlMonth.DataSource = Enumerable.Range(firstMonthIndex, 3).Select(i => new { I = i, M = DateTimeFormatInfo.CurrentInfo.GetMonthName(i) });
        ddlMonth.DataTextField = "M";
        ddlMonth.DataValueField = "I";
        this.ddlMonth.DataBind();
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

    private void ImportData(DataTable dtExcelRecords, string currentUser, string FileType, byte[] srcontent)
    {
        try 
        {
            if (checkThresholdMismatch(dtExcelRecords))
            {
                int year = Convert.ToInt32(ddlYear.SelectedValue);
                int quarter = Convert.ToInt32(ddlQuarter.SelectedValue);
                int month = Convert.ToInt32(ddlMonth.SelectedIndex) + 1;
                int manualdatacnfg_id = Convert.ToInt32(ddlDataType.SelectedValue);
                int imported_by = LoginInfo.Current.UserId;
                string imported_name = LoginInfo.Current.UserName;

                int eRowNum = ESI_ManualDataDAL.getRowNumber(manualdatacnfg_id);

                errorMessage = ESI_ManualDataDAL.UploadManualData(dtExcelRecords, eRowNum, year, quarter, month, manualdatacnfg_id, imported_by, imported_name, FileType, srcontent);

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
            
            #region Calculation_attachment
            string ext = String.Empty;
            byte[] srcontent = null;
            var filetype = "";
            if (ImageTypeFileUpLoad.HasFile)
            {
                ext = System.IO.Path.GetExtension(ImageTypeFileUpLoad.PostedFile.FileName);
                filetype = ext.Replace(".", String.Empty);
                srcontent = ImageTypeFileUpLoad.FileBytes;
            }
            #endregion

            if (ddlSheets.SelectedIndex != 0 && ddlSheets.SelectedValue != null)
            {

                if (this.rbHDR.SelectedValue == "Yes")
                {
                    dtExcelRecords = Common.ReadExcelSheet(Extension, FileMap, ddlSheets.SelectedValue, true);
                    ImportData(dtExcelRecords, currentUser, filetype, srcontent);
                }
                else
                {
                    dtExcelRecords = Common.ReadExcelSheet(Extension, FileMap, ddlSheets.SelectedValue, false);
                    ImportData(dtExcelRecords, currentUser, filetype, srcontent);
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
        if (ddlQuarter.SelectedIndex == 0)
        {
            lblResult.Text = "Quarter is Required!";
            this.ddlQuarter.Focus();
            return false;
        }

        if (ddlDataType.SelectedIndex == 0)
        {
            lblResult.Text = "Data Type Required!";
            this.ddlDataType.Focus();
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
        Common.Download("EsiManualData.xls", "ImportFileSample/EsiManualData.xls");
    }
}
