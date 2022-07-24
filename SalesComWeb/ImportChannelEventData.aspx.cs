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
            Common.PopulateChannelType(ddlChannelType);
            Common.AddSelectOne(ddlChannelType);
            Common.PopulateAmountType(ddlAmountType);
            Common.AddSelectOne(ddlAmountType);
        }

        this.btnSynchronize.Visible = false;
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
        //BindData();
        pager.SetPageProperties(0, pager.MaximumRows, false);
    }
    protected void ddlReportName_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.PopulateEventTypeByReportId(ddlEventType, int.Parse(ddlReportName.SelectedValue));
        Common.AddSelectOne(ddlEventType);
        Common.PopulateCommissionCycleByReportId(ddlReportCycle, int.Parse(ddlReportName.SelectedValue));
        Common.AddSelectOne(ddlReportCycle);
        Common.PopulateChannelEventBatch(ddlChannelEventBatch, int.Parse(ddlReportName.SelectedValue));
        Common.AddSelectOne(ddlChannelEventBatch);

    }
    protected void btnShowPreviousImportData_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewChannelEventImportData.aspx");
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
                Label1.Text = "Invalid File. Please upload a File with extension " +
                               string.Join(",", validFileTypes);
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
                conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]
                         .ConnectionString;
                break;
            case ".xlsx": //Excel 07
                conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]
                         .ConnectionString;
                break;
        }

        conStr = String.Format(conStr, FilePath, isHDR);
        OleDbConnection connExcel = new OleDbConnection(conStr);
        OleDbCommand cmdExcel = new OleDbCommand();
        OleDbDataAdapter oda = new OleDbDataAdapter();
        cmdExcel.Connection = connExcel;
        connExcel.Open();
        schemaTable = Common.FilterSchemaTable(connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null));
        ddlSheets.Items.Clear();
        ddlSheets.Items.Add(new ListItem("Select Sheet", ""));
        ddlSheets.DataSource = schemaTable;
        ddlSheets.DataTextField = "TABLE_NAME";
        ddlSheets.DataValueField = "TABLE_NAME";
        ddlSheets.DataBind();
        connExcel.Close();
        lblFileName.Text = Path.GetFileName(FilePath);
        Panel2.Visible = true;
        Panel1.Visible = false;
    }


    private void ImportData(DataTable dtExcelRecords, string currentUser)
    {
        if (dtExcelRecords.Rows.Count > 0)
        {
            bool isExist = new ImportExcelToDataBaseDAL().ChannelEventCheck(int.Parse(ddlEventType.SelectedValue), int.Parse(ddlChannelEventBatch.SelectedValue));

            if (isExist)
            {
                ClientScript.RegisterStartupScript(GetType(), "id", "ReConfirm()", true);
            }
            else
            {
                InsertDataToDataBase(dtExcelRecords);
            }
        }
        else
        {
            this.lblResult.ForeColor = Color.Red;
            this.lblResult.Text = "Selected file does not contain any row";
        }

    }


    private void ImportDataWithConfirmation(DataTable dtExcelRecords, string currentUser)
    {
        if (this.ddlEventType.SelectedIndex > 0 && this.ddlReportName.SelectedIndex > 0 && this.ddlReportCycle.SelectedIndex > 0 && this.ddlChannelType.SelectedIndex > 0 && this.ddlAmountType.SelectedIndex > 0 && ddlChannelEventBatch.SelectedIndex > 0)
        {
            if (dtExcelRecords.Rows.Count > 0)
            {
                InsertDataToDataBase(dtExcelRecords);
            }
        }
    }

    private void InsertDataToDataBase(DataTable dtExcelRecords)
    {
        bool result = new ImportExcelToDataBaseDAL().SaveChannelEventToTempTable(dtExcelRecords, int.Parse(ddlChannelType.SelectedValue), int.Parse(ddlReportName.SelectedValue), int.Parse(ddlChannelEventBatch.SelectedValue), int.Parse(ddlReportCycle.SelectedValue), int.Parse(ddlEventType.SelectedValue), ddlAmountType.SelectedValue, LoginInfo.Current.UserName);

        if (result)
        {
            this.lblResult.ForeColor = Color.Green;
            this.lblResult.Text = string.Format("Total {0} rows inserted in Temp Table", dtExcelRecords.Rows.Count);
            //BindData();
            this.btnSynchronize.Visible = true;
        }
        else
        {
            this.lblResult.ForeColor = Color.Green;
            this.lblResult.Text = "Error occurred during running the process.";
            this.btnSynchronize.Visible = false;
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
                item.Text = item.Text.Replace("$", String.Empty);
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
        else if (ddlAmountType.SelectedIndex == 0)
        {
            lblResult.Text = "Amount Type Required!";
            this.ddlAmountType.Focus();
            return false;
        }
        else if (ddlChannelType.SelectedIndex == 0)
        {
            lblResult.Text = "Channel Type Required!";
            this.ddlChannelType.Focus();
            return false;
        }
        else if (ddlChannelEventBatch.SelectedIndex == 0)
        {
            lblResult.Text = "Channel Event Batch Required!";
            this.ddlChannelEventBatch.Focus();
            return false;
        }
        else
        {
            return true;
        }
    }

    protected void btnSynchronize_Click(object sender, EventArgs e)
    {
        Synchronize(ddlEventType, ddlChannelEventBatch, lblResult, btnSynchronize);
    }

    private void Synchronize(DropDownList eventType, DropDownList channelEventBatch, Label result, Button synchronize)
    {
        if (eventType.SelectedIndex > 0 && channelEventBatch.SelectedIndex > 0)
        {
            Boolean success = new ImportExcelToDataBaseDAL().Synchronize(int.Parse(channelEventBatch.SelectedValue), int.Parse(eventType.SelectedValue), LoginInfo.Current.UserName);

            if (success)
            {
                result.ForeColor = Color.Green;
                result.Text = "Data successfully synchronized.";
                BindData();
                synchronize.Visible = true;
            }
            else
            {
                result.ForeColor = Color.Green;
                result.Text = "Error occurred during running the process.";
            }
        }
        else
        {

            if (eventType.SelectedIndex == 0)
            {
                result.ForeColor = Color.Red;
                result.Text = "Event name cannot be empty!";
            }

            else if (channelEventBatch.SelectedIndex == 0)
            {
                result.ForeColor = Color.Red;
                result.Text = "Channel event batch cannot be empty!";
            }
        }
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
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
                    ImportDataWithConfirmation(dtExcelRecords, currentUser);
                }
                else
                {
                    dtExcelRecords = Common.ReadExcelSheet(Extension, FileMap, ddlSheets.SelectedValue, false);
                    ImportDataWithConfirmation(dtExcelRecords, currentUser);
                }
            }
            else
            {
                this.lblResult.ForeColor = Color.Red;
                this.lblResult.Text = "Please select a sheet";
            }
        }
    }
}