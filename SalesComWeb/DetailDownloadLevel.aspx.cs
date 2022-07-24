using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using ClosedXML.Excel;
using System.IO;

public partial class DetailDownloadLevel : System.Web.UI.Page
{
    public string editMode
    {
        get
        {
            return ViewState["editMode"].ToString();
        }
        set
        {
            ViewState["editMode"] = value;
        }
    }
    protected int Id
    {
        get
        {
            return (int)ViewState["Id"];
        }
        set
        {
            ViewState["Id"] = value;
        }
    }

    protected void pager_PreRender(object sender, EventArgs e)
    {
     
            //BindData(0, string.Empty);
        
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            if (!Permissions.DetailReportDownloadView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            try
            {
                if (!string.IsNullOrEmpty(Request["Id"]))
                {
                    Id = int.Parse(Request["Id"]);
                    BindData(Id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
     
        }

    }


    private void BindData(Int32 GetId)
    {
        List<LevelDetailList> list;

        list = ReportViewDAL.GetDetailLevelDownloadList(GetId);
           
      
        lv.DataSource = list;
        lv.DataBind();

        lblResults.Text = String.Format("Total results: {0}", list.Count);
        pager.Visible = list.Count > pager.PageSize;
    }


    protected void lv_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        string arg = e.CommandArgument.ToString();
        int MasterID = Convert.ToInt32(arg);

        Export export = new Export();

        DataTable dt = CommissionDetailExportDAL.DetailsDataDownload(MasterID);

        try
        {
            Common.ToCSV(dt, String.Format("Detail_Report_Wise_{0}", System.DateTime.Now.ToString("ddMMyyy-HHmmss")));
        }
        catch (Exception ex)
        {
            this.lblResults.Text = ex.Message;
        }
    }
    public static string ValidateColumnData(string input)
    {
        try
        {
            if (input == null)
                return string.Empty;

            bool isQuote = false;
            bool isComma = false;
            int len = input.Length;
            for (int i = 0; i < len && (isComma == false || isQuote == false); i++)
            {
                char ch = input[i];
                if (ch == '"')
                    isQuote = true;
                else if (ch == ',')
                    isComma = true;
            }

            if (isQuote)
                input = input.Replace("\"", "\"\"");

            if (isComma)
                return "\"" + input + "\"";
            else
                return input;
        }
        catch
        {
            throw new Exception(string.Format("Data Parsing Error: Column Data : {0}", input));
        }
    }

    protected void ddlCommissionCycle_SelectedIndexChanged(object sender, EventArgs e)
    {
       
            BindData(0);
       
    }

    protected void ddlPeridType_SelectedIndexChanged(object sender, EventArgs e)
    {
      
        BindData(0);
    }
    protected void lv_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            LinkButton _lbtnDetailsAmount = (LinkButton)e.Item.FindControl("lbtnDetailsAmount");
            PostBackTrigger ti = new PostBackTrigger();
            ti.ControlID = _lbtnDetailsAmount.ClientID;
            //upCycle.Triggers.Add(ti);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(_lbtnDetailsAmount);
        }
        catch (Exception ex)
        {            
             //throw ex
        }
      
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

      

    }

    //protected void btnDownloadReport_Click(object sender, EventArgs e)
    //{
    //    string arg = btnDownloadReport.Text;
    //    int MasterID = Convert.ToInt32(arg);

    //    Export export = new Export();

    //    DataTable dt = CommissionDetailExportDAL.DetailsDataDownload(MasterID);

    //    try
    //    {
    //        Common.ExportToExcel(dt, String.Format("Detail_Report_Wise_{0}", System.DateTime.Now.ToString("ddMMyyy-HHmmss")));

    //    }
    //    catch (Exception ex)
    //    {
    //        this.lblResults.Text = ex.Message;
    //    }
    //}
}