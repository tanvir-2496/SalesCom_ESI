using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

public partial class ImportExcelToDataBase : System.Web.UI.Page
{

    List<ErrorMessageEnt> errorMessage;

    protected void pager_PreRender(object sender, EventArgs e)
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.SAFImportExcelAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
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
        if (connExcel.State == ConnectionState.Open)
            connExcel.Close();

        connExcel.Open();

        DataTable schemaTable = Common.FilterSchemaTable(connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "TABLE" }));
        DataRow[] filteredDataRow = schemaTable.Select("TABLE_NAME like '%$' or TABLE_NAME like '%$'''");

        connExcel.Close();

        DataTable filteredDatTable = new DataTable();

        if (filteredDataRow.Length > 0)
        {
            filteredDatTable = filteredDataRow.CopyToDataTable();
        }

        ddlSheets.Items.Clear();
        ddlSheets.Items.Add(new ListItem("Select Sheet", ""));
        ddlSheets.DataSource = filteredDatTable;//connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        ddlSheets.DataTextField = "TABLE_NAME";
        ddlSheets.DataValueField = "TABLE_NAME";
        ddlSheets.DataBind();

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
            this.lblResult.Text = "Please select a sheet";
        }
    }

    private void ImportData(DataTable dtExcelRecords, string currentUser)
    {

        DateTime Dateresult;

        if (DateTime.TryParse(txtImportDate.Text, out Dateresult))
        {
            if (dtExcelRecords.Rows.Count > 0)
            {
                errorMessage = new ImportExcelToDataBaseDAL().SaveExcelDataToTable(dtExcelRecords, Dateresult, currentUser);

                if (errorMessage != null && errorMessage.Count > 0)
                {
                    this.lblResult.Text = string.Format("Total {0} rows inserted at Temp Table", errorMessage[0].RowCount);
                    BindData();
                }
                else
                {
                    this.lblResult.Text = string.Format("Total {0} rows inserted", dtExcelRecords.Rows.Count);
                }
            }
            else
            {
                this.lblResult.Text = "Selected file does not contain any row";
            }
        }
        else
        {
            this.lblResult.Text = "Import date field is required";
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

            DataTable dtExcelSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
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
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        BindData();
        pager.SetPageProperties(0, pager.MaximumRows, false);
    }


    protected void ddlSheets_DataBound(object sender, EventArgs e)
    {
        if (this.ddlSheets.Items.Count > 0)
        {
            foreach (ListItem item in this.ddlSheets.Items)
            {
                item.Text = item.Text.Replace("$", String.Empty).Replace("'", String.Empty);
            }
        }
    }
}