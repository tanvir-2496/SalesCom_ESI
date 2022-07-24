﻿using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Linq;
using System.Collections.Generic;

public partial class SetupReportApprovalProcess : System.Web.UI.Page
{
    protected void pager_PreRender(object sender, EventArgs e)
    {
        BindData();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.ReportApprovalAct)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
        }
    }

    private void BindData()
    {
        List<PendingtReportApprovalEnt> list = ReportApprovalDAL.PendingReportAprList(LoginInfo.Current.UserId).OrderByDescending(x => x.effective_date).ToList();
        list = list.Where(t => t.report_name.ToLower().Contains(search_textbox.Text.Trim().ToString().ToLower())).ToList();
        if ((string)ViewState["SortDirection"] == "DESC")
            list = list.OrderByDescending(x => x.effective_date).ToList();
        else if ((string)ViewState["SortDirection"] == "ASC")
            list = list.OrderBy(x => x.effective_date).ToList();

        lv.DataSource = list;
        lv.DataBind();
        lblResults.Text = String.Format("Total results: {0}", list.Count);
        pager.Visible = list.Count > pager.PageSize;
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        BindData();
        pager.SetPageProperties(0, pager.MaximumRows, false);

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        List<PendingtReportApprovalEnt> list = ReportApprovalDAL.PendingReportAprList(LoginInfo.Current.UserId).OrderByDescending(x => x.effective_date).ToList();
        list = list.Where(t => t.report_name.ToLower().Contains(search_textbox.Text.Trim().ToString().ToLower())).ToList();

        if ((string)ViewState["SortDirection"] == "DESC")
            list = list.OrderByDescending(x => x.effective_date).ToList();
        else if ((string)ViewState["SortDirection"] == "ASC")
            list = list.OrderBy(x => x.effective_date).ToList();

        lv.DataSource = list;
        lv.DataBind();
        lblResults.Text = String.Format("Total results: {0}", list.Count);
        pager.Visible = list.Count > pager.PageSize;
    }
}