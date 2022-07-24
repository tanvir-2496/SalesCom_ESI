using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

public partial class SetupActivityAdd : System.Web.UI.Page
{
    protected string editMode
    {
        get { return ViewState["editMode"].ToString(); }
        set { ViewState["editMode"] = value; }
    }
    protected int ClaimId
    {
        get { return (int)ViewState["ClaimId"]; }
        set { ViewState["ClaimId"] = value; }
    }
    public int ReportId
    {
        get { return (int)ViewState["ReportId"]; }
        set { ViewState["ReportId"] = value; }
    }
    public int CycleId
    {
        get { return (int)ViewState["CycleId"]; }
        set { ViewState["CycleId"] = value; }
    }




    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.ActivityAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            ClaimId = -1;
            Common.PopulateCommissionReportId(ddlReportName);
            Common.AddSelectOne(ddlReportName);
            int Id;
            int.TryParse(Request["ClaimId"], out Id);

            ReportId = int.Parse(Request["ReportId"]);
            CycleId = int.Parse(Request["CycleId"]);


            if (!string.IsNullOrEmpty(Request["ClaimId"]) && Id > 0)
            {
                ClaimId = int.Parse(Request["ClaimId"]);

                editMode = "edit";
                CommissionClaimEnt commissionClaim = CommissionClaimDAL.GetItemList(ClaimId)[0];

                ddlReportName.SelectedValue = commissionClaim.ReportId.ToString();

                ddlReportName_SelectedIndexChanged(null, EventArgs.Empty);

                txtReferenceNumber.Text = commissionClaim.ReferenceNumber;
                txtCommissionCriterion.Text = commissionClaim.CommissionCriterion;
                ddlCycle.SelectedValue = commissionClaim.CycleId.ToString();
                txtModeOfPayment.Text = commissionClaim.ModeOfPayment;
                ddlHasWithdrawalList.SelectedValue = commissionClaim.HasWithdrawalList.ToString();
                btnSave.Visible = Permissions.ActivityAdd;
                btnReport.Visible = true;
                btnSampleFile.Visible = false;
            }
            if (!string.IsNullOrEmpty(Request["ReportId"]) && !string.IsNullOrEmpty(Request["CycleId"]) && Id <= 0)
            {
                editMode = "add";
                ddlReportName.SelectedValue = ReportId.ToString();
                ddlReportName_SelectedIndexChanged(null, EventArgs.Empty);
                ddlCycle.SelectedValue = CycleId.ToString();
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlHasWithdrawalList.SelectedValue == "0" || (ddlHasWithdrawalList.SelectedValue == "1" && ddlSheets.Items.Count == 0))
        {
            int ErrorCode = SaveData();
            MsgUtility.msg(editMode, ErrorCode, "Commission Claim", this, lblMsg, ddlReportName.SelectedItem.Text);
            if (editMode == "add")
            {
                if (ErrorCode >= 0)
                {
                    ClearData();
                }
            }
        }

        else
        {
            DataTable dtExcelRecords = new DataTable(); ;
            string FileName = lblFileName.Text;
            string Extension = Path.GetExtension(FileName);
            string FolderPath = Server.MapPath(ConfigurationManager.AppSettings["FolderPath"]);

            int result;

            string currentUser = (HttpContext.Current.Session["LoginInfo"] as LoginInfo).UserName;

            string FileMap = String.Format("{0}//{1}", FolderPath, FileName);

            if (ddlSheets.SelectedIndex != 0 && ddlSheets.SelectedValue != null)
            {

                if (this.rbHDR.SelectedValue == "Yes")
                {
                    dtExcelRecords = ReadExcelSheet(Extension, FileMap, ddlSheets.SelectedValue, true);
                    result = ImportData(dtExcelRecords, currentUser);
                }
                else
                {
                    dtExcelRecords = ReadExcelSheet(Extension, FileMap, ddlSheets.SelectedValue, false);
                    result = ImportData(dtExcelRecords, currentUser);
                }

                MsgUtility.msg(editMode, result, "Commission Claim", this, lblMsg, ddlReportName.SelectedItem.Text);

            }
            else
            {
                this.lblResult.ForeColor = Color.Red;
                this.lblResult.Text = "Please select a sheet";
            }
        }
    }


    private int ImportData(DataTable dtExcelRecords, string currentUser)
    {

        bool result = false;

        if (this.ddlReportName.SelectedIndex > 0)
        {
            if (dtExcelRecords.Rows.Count > 0)
            {
                bool isDuplicate = false;
                result = new ImportExcelToDataBaseDAL().SaveChannelWithdrawal(dtExcelRecords, int.Parse(ddlReportName.SelectedValue), currentUser, this.txtReferenceNumber.Text, this.txtCommissionCriterion.Text, this.txtModeOfPayment.Text, int.Parse(ddlCycle.SelectedValue), ddlHasWithdrawalList.SelectedValue, ref isDuplicate, ClaimId);

                if (result && isDuplicate == true)
                {
                    this.lblResult.ForeColor = Color.Red;
                    this.lblResult.Text = string.Format("Total {0} rows inserted but these data already inserted before", dtExcelRecords.Rows.Count);
                }
                else if (result)
                {
                    this.lblResult.ForeColor = Color.Green;
                    this.lblResult.Text = string.Format("Total {0} rows inserted successfully", dtExcelRecords.Rows.Count);
                }
                else
                {
                    this.lblResult.ForeColor = Color.Red;
                    this.lblResult.Text = "Error occurred during insertion.";
                }
            }
            else
            {
                this.lblResult.ForeColor = Color.Red;
                this.lblResult.Text = "Selected file does not contain any row";
            }
        }

        return result == true ? 0 : -1;
    }


    private void ClearData()
    {
        editMode = "add";
        ClaimId = -1;
        txtReferenceNumber.Text = txtCommissionCriterion.Text = txtModeOfPayment.Text = String.Empty;
        ddlReportName.SelectedIndex = ddlCycle.SelectedIndex = -1;
    }

    private int SaveData()
    {
        CommissionClaimEnt commissionClaimInfo = new CommissionClaimEnt();
        commissionClaimInfo.ClaimId = ClaimId;
        commissionClaimInfo.ReportId = int.Parse(ddlReportName.SelectedValue);
        commissionClaimInfo.ReferenceNumber = txtReferenceNumber.Text;
        commissionClaimInfo.CommissionCriterion = txtCommissionCriterion.Text;
        commissionClaimInfo.CycleId = int.Parse(ddlCycle.SelectedValue);
        commissionClaimInfo.ModeOfPayment = txtModeOfPayment.Text;
        commissionClaimInfo.HasWithdrawalList = ddlHasWithdrawalList.SelectedValue;

        if (editMode == "edit")
        {
            return CommissionClaimDAL.SaveItem(commissionClaimInfo, "U");
        }
        else
        {
            return CommissionClaimDAL.SaveItem(commissionClaimInfo, "I");
        }
    }

    protected void ddlReportName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlReportName.SelectedIndex > 0)
        {
            Common.PopulateCommissionCycleByReportId(ddlCycle, int.Parse(ddlReportName.SelectedValue));
            Common.AddSelectOne(ddlCycle);
        }

        else
        {
            this.ddlCycle.Items.Clear();
        }
    }
    protected void ddlHasWithdrawalList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlHasWithdrawalList.SelectedValue == "1")
        {
            this.pUpload.Visible = true;
            this.pImport.Visible = false;
        }
        else
        {
            this.pUpload.Visible = false;
            this.pImport.Visible = false;
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {

            string[] validFileTypes = { "xls", "xlsx" };
            string ext = System.IO.Path.GetExtension(fuComWithdrawal.PostedFile.FileName);
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
                if (fuComWithdrawal.HasFile)
                {
                    string FileName = Path.GetFileName(fuComWithdrawal.PostedFile.FileName);
                    string Extension = Path.GetExtension(fuComWithdrawal.PostedFile.FileName);
                    string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
                    string FilePath = Server.MapPath(FolderPath + FileName);
                    fuComWithdrawal.SaveAs(FilePath);
                    GetExcelSheets(FilePath, Extension, "Yes");
                }
            }
        }
        catch { }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.lblResult.Text = String.Empty;
        ddlSheets.DataSource = null;
        ddlSheets.DataBind();
        lblFileName.Text = String.Empty;
        pUpload.Visible = false;
        pImport.Visible = false;
        this.ddlHasWithdrawalList.SelectedIndex = 0;
    }
    protected void ddlSheets_DataBound(object sender, EventArgs e)
    {
        if (ddlSheets.Items.Count > 0)
        {
            foreach (ListItem item in ddlSheets.Items)
            {
                item.Text = item.Text.Replace("$", String.Empty).Replace("'", String.Empty);
            }
        }
    }


    private void GetExcelSheets(string FilePath, string Extension, string isHDR)
    {
        string conStr = "";
        bool isxls = false;
        switch (Extension)
        {
            case ".xls": //Excel 97-03
                isxls = true;
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
        DataRow[] filteredDataRow = isxls ? schemaTable.Select("TABLE_NAME like '%$'") : schemaTable.Select("TABLE_NAME like '%$'''");

        connExcel.Close();

        DataTable filteredTable = new DataTable();

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
        pImport.Visible = true;
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

    protected void btnDownload_Click(object sender, EventArgs e)
    {
        Common.Download("ChannelWithdrawal.xlsx", "ImportFileSample/ChannelWithdrawal.xlsx");
    }
}