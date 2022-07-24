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
            if (!Permissions.ChannelWithdrawalAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            Common.PopulateCommissionReportId(ddlReportName);
            Common.AddSelectOne(ddlReportName);
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
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
        catch { }
    }

    private void GetExcelSheets(string FilePath, string Extension, string isHDR)
    {
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

        ddlSheets.Items.Clear();
        ddlSheets.Items.Add(new ListItem("Select Sheet", ""));
        ddlSheets.DataSource = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        ddlSheets.DataTextField = "TABLE_NAME";
        ddlSheets.DataValueField = "TABLE_NAME";
        ddlSheets.DataBind();
        connExcel.Close();
        lblFileName.Text = Path.GetFileName(FilePath);
        Panel2.Visible = true;
        Panel1.Visible = false;
    }
    protected void btnSave_Click(object sender, EventArgs e)
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
                dtExcelRecords = ReadExcelSheet(Extension, FileMap, ddlSheets.SelectedValue, true);
                ImportData(dtExcelRecords, currentUser);
            }
            else
            {
                dtExcelRecords = ReadExcelSheet(Extension, FileMap, ddlSheets.SelectedValue, false);
                ImportData(dtExcelRecords, currentUser);
            }
        }
        else
        {
            this.lblResult.ForeColor = Color.Red;
            this.lblResult.Text = "Please select a sheet";
        }
    }

    private void ImportData(DataTable dtExcelRecords, string currentUser)
    {

        if (this.ddlReportName.SelectedIndex > 0)
        {
            if (dtExcelRecords.Rows.Count > 0)
            {
             //errorMessage = new ImportExcelToDataBaseDAL().SaveChannelWithdrawal(dtExcelRecords, int.Parse(ddlReportName.SelectedValue), currentUser, this.txtRefNumber.Text, this.txtCommissionCriterion.Text, this.txtModeOfPayment.Text, int.Parse(ddlReportCycle.SelectedValue), "1");

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
            else
            {
                this.lblResult.ForeColor = Color.Red;
                this.lblResult.Text = "Selected file does not contain any row";
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
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
        lv.DataSource = errorMessage;
        lv.DataBind();
        this.lblResult.ForeColor = Color.Green;
        lblResults.Text = String.Format("Total results: {0}", errorMessage.Count);
        pager.Visible = errorMessage.Count > pager.PageSize;
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

            DataTable dtExcelSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string getExcelSheetName = sheetName;
            cmd.CommandText = "SELECT * FROM [" + getExcelSheetName + "]";
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
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        BindData();
        pager.SetPageProperties(0, pager.MaximumRows, false);
    }


    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewChannelWithdrawal.aspx", true);
    }
    protected void ddlSheets_DataBound(object sender, EventArgs e)
    {
        if (ddlSheets.Items.Count > 0)
        {
            foreach (ListItem item in ddlSheets.Items)
            {
                item.Text = item.Text.Replace("$", String.Empty);
            }
        }
    }
    protected void ddlReportName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlReportName.SelectedIndex > 0)
        {
            Common.PopulateCommissionCycleByReportId(ddlReportCycle, int.Parse(ddlReportName.SelectedValue));
            Common.AddSelectOne(ddlReportCycle);
        }

        else
        {
            this.ddlReportCycle.Items.Clear();
        }
    }
}