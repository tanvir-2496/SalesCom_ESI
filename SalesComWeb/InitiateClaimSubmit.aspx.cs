using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class InitiateClaimSubmit : System.Web.UI.Page
{

    protected int ReportCycleId
    {
        get { return (int)ViewState["ReportCycleId"]; }
        set { ViewState["ReportCycleId"] = value; }
    }

    protected int ReportTypeId
    {
        get { return (int)ViewState["ReportTypeId"]; }
        set { ViewState["ReportTypeId"] = value; }
    }

    protected int ReportFlow
    {
        get { return (int)ViewState["ReportFlow"]; }
        set { ViewState["ReportFlow"] = value; }
    }

    protected decimal CommissionAmount
    {
        get { return (decimal)ViewState["CommissionAmount"]; }
        set { ViewState["CommissionAmount"] = value; }
    }

    protected decimal ClaimAmount
    {
        get { return (decimal)ViewState["ClaimAmount"]; }
        set { ViewState["ClaimAmount"] = value; }
    }

    protected string ReportDuration
    {
        get { return (string)ViewState["ReportDuration"]; }
        set { ViewState["ReportDuration"] = value; }
    }

    protected bool DuplicateRow
    {
        get { return (bool)ViewState["DuplicateRow"]; }
        set { ViewState["DuplicateRow"] = value; }
    }

    protected bool NegativeOrInvalid
    {
        get { return (bool)ViewState["NegativeOrInvalid"]; }
        set { ViewState["NegativeOrInvalid"] = value; }
    }

    protected bool FireDataBind
    {
        get { return (bool)ViewState["FireDataBind"]; }
        set { ViewState["FireDataBind"] = value; }
    }

    protected bool DataLoaded
    {
        get { return (bool)ViewState["DataLoaded"]; }
        set { ViewState["DataLoaded"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!Permissions.InitiateClaimApprovalUpload)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            ReportCycleId = -1;
            DataLoaded = false;
            FireDataBind = false;
            ClaimAmount = 0;
            decimal commissionAmount;
            if (!String.IsNullOrEmpty(Request["RCID"]))
            {
                ReportCycleId = int.Parse(Request.QueryString["RCID"]);
                ReportFlow = int.Parse(Request.QueryString["RF"]);
                ReportDuration = Request.QueryString["RD"];
                ReportCycleId = int.Parse(Request.QueryString["RCID"]);
                ReportTypeId = int.Parse(Request.QueryString["RTI"]);
                this.lblSetReportName.Text = Request.QueryString["RN"];
                decimal.TryParse(Request.QueryString["RC"], out commissionAmount);
                this.lblCommissionAmount.Text = commissionAmount.ToString();
                CommissionAmount = commissionAmount;
            }
        }

    }

    protected void btnLoad_Click(object sender, EventArgs e)
    {
        FireDataBind = true;
        DataLoaded = true;
        LoadDataToGrid();
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        FireDataBind = false;
        SubmitDataToDataBase();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Reset();
    }

    protected void btnDuplicate_Click(object sender, EventArgs e)
    {
        try
        {
            Common.ExportToExcel(GridToTable(true), String.Format("Duplicate_Channel_Code_{0}", System.DateTime.Now.ToString("ddMMyyy-HHmmss")));
        }
        catch (Exception ex)
        {
            this.lblResult.ForeColor = Color.Red;
            this.lblResult.Text = ex.Message;
        }
    }

    protected void gvLoadData_DataBound(object sender, EventArgs e)
    {
        GridViewDataBound(FireDataBind);
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        UploadFile();
    }

    protected void btnDownloadSample_Click(object sender, EventArgs e)
    {
        Common.Download("Channel Discard List Sample.xlsx", "ImportFileSample/Channel Discard List Sample.xlsx");
    }

    private void UploadFile()
    {
        this.lblResult.Text = "";
        try
        {
            if (fuExcelFiles.PostedFile != null && fuExcelFiles.HasFile)
            {
                string FileName = Path.GetFileName(fuExcelFiles.PostedFile.FileName);
                string Extension = Path.GetExtension(fuExcelFiles.PostedFile.FileName);
                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
                string FilePath = Server.MapPath(FolderPath + FileName);
                fuExcelFiles.SaveAs(FilePath);

                if (GetExcelSheets(FilePath, Extension, "Yes"))
                {
                    lblFileName.Text = Path.GetFileName(FilePath);
                    plImport.Visible = true;
                    plUpload.Visible = false;
                    this.chkHasInput.Enabled = false;
                    this.lblOperation.Visible = true;
                    this.btnLoad.Visible = true;
                    this.btnSubmit.Visible = true;
                    this.btnSubmit.Text = "Submit";
                    this.btnCancel.Visible = true;
                }
                else
                {
                    this.lblResult.ForeColor = Color.Red;
                    this.lblResult.Text = "Worksheet name does not match with recommended TEMPLATE!";
                }
            }
        }
        catch (Exception ex)
        {
            this.lblResult.Text = ex.Message;
        }
    }

    private void LoadDataToGrid()
    {
        DataTable dtExcelRecords = new DataTable(); ;
        string FileName = lblFileName.Text;
        string Extension = Path.GetExtension(FileName);
        string FolderPath = Server.MapPath(ConfigurationManager.AppSettings["FolderPath"]);
        this.lblResult.Text = String.Empty;
        this.btnDuplicate.Visible = false;

        string FileMap = String.Format("{0}//{1}", FolderPath, FileName);
      
        dtExcelRecords = Common.ReadExcelSheet(Extension, FileMap, "'Sample Worksheet$'", true);
        if (dtExcelRecords.Columns[0].ColumnName != "Channel Code" || dtExcelRecords.Columns[1].ColumnName != "Discarded Amount" || dtExcelRecords.Columns[2].ColumnName != "Comments")
        {
            this.lblResult.ForeColor = Color.Red;
            this.lblResult.Text = "Worksheet does not match with recommended TEMPLATE!";
            this.plDataGrid.Visible = false;
            return;
        }

        Common.RemoveNullColumnFromDataTable(dtExcelRecords);

        this.gvLoadData.DataSource = dtExcelRecords;
        this.gvLoadData.DataBind();
        if (dtExcelRecords.Rows.Count > 0)
        {
            this.plDataGrid.Visible = true;
            this.lblResult.ForeColor = Color.SteelBlue;
            this.lblResult.Text = String.Format("Total Records: {0}", gvLoadData.Rows.Count);
        }

    }

    private bool GetExcelSheets(string FilePath, string Extension, string isHDR)
    {
        DataTable schemaTable;
        string conStr = "";
        bool isValidSheetExist = false;
        switch (Extension)
        {
            case ".xls":
                conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                break;
            case ".xlsx":
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

        conn.Close();

        foreach (DataRow row in schemaTable.Rows)
        {
            if (row["TABLE_NAME"].ToString() == "'Sample Worksheet$'")
            {
                isValidSheetExist = true;
                break;
            }
        }



        return isValidSheetExist;
    }

    private void Reset()
    {
        this.lblResult.Text = String.Empty;
        this.lblResult.ForeColor = Color.SteelBlue;
        this.gvLoadData.DataSource = null;
        this.gvLoadData.DataBind();
        this.lblFileName.Text = String.Empty;
        this.plUpload.Visible = true;
        this.plImport.Visible = false;
        this.plDataGrid.Visible = false;
        this.btnDuplicate.Visible = false;
        this.chkHasInput.Enabled = true;
        this.lblOperation.Visible = true;
        this.btnLoad.Visible = false;
        this.btnCancel.Visible = false;
        this.btnSubmit.Text = "Initiate";

    }

    private void SubmitDataToDataBase()
    {
        if (DataLoaded)
        {
            if (this.gvLoadData.Rows.Count > 0)
            {
                if (DuplicateRow == false && NegativeOrInvalid == false)
                {
                    DataTable table = GridToTable(false);
                    List<ClaimMismatchEnt> mismatchData = InitiateClaimDAL.SaveDiscardList(table, ReportCycleId);
                    if (mismatchData.Count == 0)
                    {
                        this.lblResult.ForeColor = Color.SteelBlue;
                        this.lblResult.Text = InitiateClaimDAL.InsertDiscardData(ReportCycleId, lblSetReportName.Text, ReportTypeId, ReportFlow, ReportDuration, CommissionAmount, ClaimAmount < 0 ? 0 : ClaimAmount, LoginInfo.Current.UserId, LoginInfo.Current.UserName, "YES");

                        if (lblResult.Text == "Data Successfully Inserted")
                        {
                            this.plDataGrid.Visible = false;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "refresh", "parent.refreshWindow();", true);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "close", "parent.tb_remove();", true);
                        }
                    }
                    else
                    {
                        gvLoadData.DataSource = mismatchData;
                        gvLoadData.DataBind();
                        this.lblResult.ForeColor = Color.SteelBlue;
                        this.lblResult.Text = String.Format("Total Invalid Records: {0}", gvLoadData.Rows.Count);
                    }
                }
                else if (DuplicateRow == true && NegativeOrInvalid == true)
                {
                    this.lblResult.ForeColor = Color.Red;
                    this.lblResult.Text = "Please Remove Duplicate and Invalid Records Highlighted as 'Cornflower Blue' and 'Burly Wood'!";
                }
                else if (DuplicateRow == true)
                {
                    this.lblResult.ForeColor = Color.Red;
                    this.lblResult.Text = "Please Remove Duplicate Records Highlighted as 'Cornflower Blue'!";
                }
                else if (NegativeOrInvalid == true)
                {
                    this.lblResult.ForeColor = Color.Red;
                    this.lblResult.Text = "Please Remove Invalid Records Highlighted as 'Burly Wood'!";
                }
            }
            else
            {
                this.lblResult.ForeColor = Color.Red;
                this.lblResult.Text = "No data found!";
            }
            this.btnDuplicate.Visible = DuplicateRow;
            DataLoaded = false;
        }
        else if (this.btnSubmit.Text == "Initiate" && this.chkHasInput.Checked == false)
        {
            this.lblResult.ForeColor = Color.SteelBlue;
            this.lblResult.Text = InitiateClaimDAL.InsertDiscardData(ReportCycleId, lblSetReportName.Text, ReportTypeId, ReportFlow, ReportDuration, CommissionAmount, CommissionAmount, LoginInfo.Current.UserId, LoginInfo.Current.UserName, "NO");
            if (lblResult.Text == "Data Successfully Inserted")
            {
                this.plDataGrid.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "refresh", "parent.refreshWindow();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "close", "parent.tb_remove();", true);
            }


        }
        else if (this.btnSubmit.Text == "Initiate" && this.chkHasInput.Checked == true)
        {
            this.lblResult.ForeColor = Color.SteelBlue;
            this.lblResult.Text = "Invalid Attempt!";
            this.plDataGrid.Visible = false;
        }
        else
        {
            if (gvLoadData.Rows.Count > 0)
            {
                this.lblResult.ForeColor = Color.Red;
                this.lblResult.Text = "Invalid Data!";
            }
            else
            {
                this.lblResult.ForeColor = Color.Red;
                this.lblResult.Text = "No data found!";
            }
        }
    }

    protected DataTable GridToTable(bool isDuplicate)
    {
        DataTable table = new DataTable("Discard Amount");
        decimal totalDiscard = 0;

        foreach (TableCell cell in gvLoadData.HeaderRow.Cells)
        {
            table.Columns.Add(cell.Text);
        }

        if (isDuplicate)
        {
            foreach (GridViewRow row in gvLoadData.Rows)
            {
                if (row.ForeColor == Color.White)
                {
                    DataRow NewRow = table.NewRow();

                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        NewRow[i] = Context.Server.HtmlDecode(row.Cells[i].Text);
                    }

                    table.Rows.Add(NewRow);
                }
            }
        }
        else
        {
            foreach (GridViewRow row in gvLoadData.Rows)
            {
                table.Rows.Add();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    table.Rows[row.RowIndex][i] = Context.Server.HtmlDecode(row.Cells[i].Text);
                    if (i == 1)
                        totalDiscard += decimal.Parse(row.Cells[i].Text);
                }
            }

            ClaimAmount = CommissionAmount - totalDiscard;
        }

        return table;
    }

    private void GridViewDataBound(bool fireDataBind)
    {

        if (fireDataBind)
        {
            decimal discardAmount = 0;
            DuplicateRow = NegativeOrInvalid = false;

            for (int i = 0; i < this.gvLoadData.Rows.Count; i++)
            {
                GridViewRow compareRow = gvLoadData.Rows[i];

                if (Decimal.TryParse(compareRow.Cells[1].Text, out discardAmount))
                {
                    if (discardAmount < 0)
                    {
                        NegativeOrInvalid = true;
                        compareRow.BackColor = Color.BurlyWood;
                    }
                }
                else
                {
                    NegativeOrInvalid = true;
                    compareRow.BackColor = Color.BurlyWood;
                }

                for (int j = i + 1; j < gvLoadData.Rows.Count; j++)
                {
                    GridViewRow row = gvLoadData.Rows[j];

                    if (row.ForeColor == Color.White)
                        continue;

                    if (compareRow.Cells[0].Text == row.Cells[0].Text)
                    {
                        if (DuplicateRow == false)
                        {
                            DuplicateRow = true;
                            this.btnDuplicate.Visible = true;
                        }

                        if (compareRow.BackColor != Color.BurlyWood)
                        {
                            compareRow.BackColor = Color.CornflowerBlue;
                        }
                        row.BackColor = Color.CornflowerBlue;
                        row.Font.Bold = compareRow.Font.Bold = true;
                        row.ForeColor = compareRow.ForeColor = Color.White;
                    }

                }

            }
        }
    }

    protected void chkHasInput_CheckedChanged(object sender, EventArgs e)
    {
        if (this.chkHasInput.Checked == true)
        {
            this.fuExcelFiles.Enabled = true;
            this.btnUpload.Enabled = true;
            this.btnSubmit.Visible = false;
            this.lblOperation.Visible = false;
        }
        else
        {
            this.fuExcelFiles.Enabled = false;
            this.btnUpload.Enabled = false;
            this.btnSubmit.Visible = true;
            this.btnSubmit.Text = "Initiate";
            this.lblOperation.Visible = true;
        }
        this.lblResult.Text = String.Empty;
    }


}