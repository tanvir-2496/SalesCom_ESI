using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

public partial class SetupReportApproval : System.Web.UI.Page
{
    protected void pager_PreRender(object sender, EventArgs e)
    {
        BindData();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["SortDirection"] = "";
            if (!Permissions.ReportApprovalView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
        }
    }

    private void BindData()
    {
        //string asy = (string)ViewState["SortDirection"];

        lv.DataSource = null;
        lv.DataBind();
        List<ReportApprovalEnt> list = ReportApprovalDAL.GetItemList(0);
        if (search_textbox.Text.Trim().ToString() == "")
        {
            if ((string)ViewState["SortDirection"] == "DESC")
                list = list.OrderByDescending(x => x.effective_date).ToList();
            else if ((string)ViewState["SortDirection"] == "ASC")
                list = list.OrderBy(x => x.effective_date).ToList();

            lv.DataSource = list;
            lv.DataBind();
            lblResults.Text = String.Format("Total results: {0}", list.Count);
        }
        else
        {
            var records = list.Where(t => t.report_name.ToLower().Contains(search_textbox.Text.Trim().ToString().ToLower())).ToList();
            if ((string)ViewState["SortDirection"] == "DESC")
                records = records.OrderByDescending(x => x.effective_date).ToList();
            else if ((string)ViewState["SortDirection"] == "ASC")
                records = records.OrderBy(x => x.effective_date).ToList();

            lv.DataSource = records;
            lv.DataBind();
            lblResults.Text = String.Format("Total results: {0}", records.Count);
        }
        pager.Visible = list.Count > pager.PageSize;
    }

    //private void BindData()
    //{
    //    List<ReportApprovalEnt> list = ReportApprovalDAL.GetItemList(0);        
    //    lv.DataSource = list;
    //    lv.DataBind();
    //    lblResults.Text = String.Format("Total results: {0}", list.Count);
    //    pager.Visible = list.Count > pager.PageSize;
    //}

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        BindData();
        pager.SetPageProperties(0, pager.MaximumRows, false);
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindData();
        }
        catch (Exception)
        {
            throw;
        }
    }

    //private string SortDirection = "";
    protected void lvEffectiveDate_Sorting(object sender, ListViewSortEventArgs e)
    {
        LinkButton lbEffectiveDate = lv.FindControl("lbeffectiveDate") as LinkButton;

        string SortDirection = "ASC";


        if (ViewState["SortExpression"] != null)
        {
            if (ViewState["SortExpression"].ToString() == e.SortExpression)
            {
                ViewState["SortExpression"] = null;
                SortDirection = "DESC";
            }
            else
            {
                ViewState["SortExpression"] = e.SortExpression;
            }
        }
        else
        {
            ViewState["SortExpression"] = e.SortExpression;
        }

        ViewState["SortDirection"] = SortDirection;
        //BindData(" order by " + e.SortExpression + " " + SortDirection);
    }
}
