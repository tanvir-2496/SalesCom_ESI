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

public partial class ReportWiseRedisburseInitiation : System.Web.UI.Page
{
    protected int _ReportCycleId
    {
        get { return (int)ViewState["ReportCycleId"]; }
        set { ViewState["ReportCycleId"] = value; }
    }
    protected string _ReportDuration
    {
        get { return (string)ViewState["ReportDuration"]; }
        set { ViewState["ReportDuration"] = value; }
    }
    protected int _FlowId
    {
        get { return (int)ViewState["FlowId"]; }
        set { ViewState["FlowId"] = value; }
    }
    protected int _CurrentOrderId
    {
        get { return (int)ViewState["CurrentOrderId"]; }
        set { ViewState["CurrentOrderId"] = value; }
    }

    protected decimal _CurrentWithheldAmount
    {
        get { return (decimal)ViewState["CurrentWithheldAmount"]; }
        set { ViewState["CurrentWithheldAmount"] = value; }
    }

    protected int _CurrentDisburseNumber
    {
        get { return (int)ViewState["CurrentDisburseNumber"]; }
        set { ViewState["CurrentDisburseNumber"] = value; }
    }

    protected bool _DuplicateRow
    {
        get { return (bool)ViewState["DuplicateRow"]; }
        set { ViewState["DuplicateRow"] = value; }
    }
    protected bool _FireDataBind
    {
        get { return (bool)ViewState["FireDataBind"]; }
        set { ViewState["FireDataBind"] = value; }
    }
    protected bool _DataLoaded
    {
        get { return (bool)ViewState["DataLoaded"]; }
        set { ViewState["DataLoaded"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!Permissions.RedisburseInitiation)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            _ReportCycleId = -1;
            _DataLoaded = false;
            _FireDataBind = false;
            _DuplicateRow = false;

            if (!string.IsNullOrEmpty(Request["RCID"]))
            {
                _ReportCycleId = int.Parse(Request.QueryString["RCID"]);
                _ReportDuration = Request.QueryString["RD"];
                lblSetReportname.Text = Request.QueryString["RN"];
                _CurrentWithheldAmount = decimal.Parse(Request.QueryString["CWA"]);
                lblWithheldAmount.Text = Request.QueryString["CWA"];
                _FlowId = int.Parse(Request.QueryString["DFLOW"]);
                _CurrentOrderId = int.Parse(Request.QueryString["CORD"]);
                _CurrentDisburseNumber = int.Parse(Request.QueryString["CDNum"]);
            }
            else
            {
                Response.Redirect("ReportWiseWithheldList.aspx", true);
            }
        }
    }
    protected void btnDownloadSample_Click(object sender, EventArgs e)
    {
        Common.Download("Withheld Redisburse Sample.xlsx", "ImportFileSample/Withheld Redisburse Sample.xlsx");
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        _FireDataBind = true;
        _DataLoaded = true;
        UploadFile();
    }
    protected void gvLoadData_DataBound(object sender, EventArgs e)
    {
        GridViewDataBound(_FireDataBind);
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        _FireDataBind = false;
        SubmitDataToDataBase();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Reset();
    }
    protected void btnLoad_Click(object sender, EventArgs e)
    {
        _FireDataBind = true;
        _DataLoaded = true;
        LoadDataToGrid();
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
                    this.btnLoad.Visible = true;
                    this.btnSubmit.Visible = true;
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
            if (row["TABLE_NAME"].ToString() == "Redisburse$")
            {
                isValidSheetExist = true;
                break;
            }
        }
        return isValidSheetExist;
    }
    private void SubmitDataToDataBase()
    {
        if (_DataLoaded)
        {
            if (this.gvLoadData.Rows.Count > 0)
            {
                if (_DuplicateRow == false)
                {
                    DataTable table = GridToTable(false);
                    List<ClaimMismatchEnt> mismatchData = ReportWiseRedisburseInitiationDAL.SaveRedisburseList(table, _ReportCycleId);
                    if (mismatchData.Count == 0)
                    {
                        this.lblResult.ForeColor = Color.SteelBlue;
                        this.lblResult.Text = ReportWiseRedisburseInitiationDAL.SetRedisburseInitiation(new ReportWiseDisburseInitiationEnt()
                        {
                            ReportCycleId = _ReportCycleId,
                            CurrentRedisburseNumber = _CurrentDisburseNumber,
                            RedisburseFlowId = _FlowId,
                            CurrentOrderId = _CurrentOrderId,
                            ReportName = lblSetReportname.Text,
                            ReportDuration = _ReportDuration,
                            CurrentWithheldAmount = _CurrentWithheldAmount,
                            UserId = LoginInfo.Current.UserId,
                            UserName = LoginInfo.Current.UserName
                        });

                        if (lblResult.Text == "Data Successfully Updated")
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
                        this.lblResult.ForeColor = Color.Red;
                        this.lblResult.Text = String.Format("Total Invalid Records: {0}", gvLoadData.Rows.Count);
                    }
                }

                else if (_DuplicateRow == true)
                {
                    this.lblResult.ForeColor = Color.Red;
                    this.lblResult.Text = "Please Remove Duplicate Records Highlighted as 'Cornflower Blue'!";
                }

            }
            else
            {
                this.lblResult.ForeColor = Color.Red;
                this.lblResult.Text = "No data found!";
            }
            this.btnDuplicate.Visible = _DuplicateRow;
            _DataLoaded = false;
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
        DataTable table = new DataTable("Disburse");

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

                }
            }
        }

        return table;
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
        this.btnLoad.Visible = false;
        this.btnCancel.Visible = false;
        this.btnSubmit.Visible = false;
    }
    private void GridViewDataBound(bool fireDataBind)
    {

        if (fireDataBind)
        {

            _DuplicateRow = false;

            for (int i = 0; i < this.gvLoadData.Rows.Count; i++)
            {
                GridViewRow compareRow = gvLoadData.Rows[i];


                for (int j = i + 1; j < gvLoadData.Rows.Count; j++)
                {
                    GridViewRow row = gvLoadData.Rows[j];

                    if (row.ForeColor == Color.White)
                        continue;

                    if (compareRow.Cells[0].Text == row.Cells[0].Text)
                    {
                        if (_DuplicateRow == false)
                        {
                            _DuplicateRow = true;
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
    private void LoadDataToGrid()
    {
        DataTable dtExcelRecords = new DataTable(); ;
        string FileName = lblFileName.Text;
        string Extension = Path.GetExtension(FileName);
        string FolderPath = Server.MapPath(ConfigurationManager.AppSettings["FolderPath"]);
        this.lblResult.Text = String.Empty;
        this.btnDuplicate.Visible = false;

        string FileMap = String.Format("{0}//{1}", FolderPath, FileName);

        dtExcelRecords = Common.ReadExcelSheet(Extension, FileMap, "Redisburse$", true);
        if (dtExcelRecords.Columns[0].ColumnName != "Channel Code" || dtExcelRecords.Columns[1].ColumnName != "Comments")
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

    protected void Page_UnLoad(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "refresh", "parent.refreshWindow();", true);  
    }


}