﻿using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Web.UI;

public partial class SetupCommissionClaim : System.Web.UI.Page
{
    protected void pager_PreRender(object sender, EventArgs e)
    {
        BindData();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!Permissions.ActivityView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
        }
    }

    private void BindData()
    {
        List<CommissionClaimEnt> list = CommissionClaimDAL.GetItemList(0);
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

    //protected void btnDownload_Click(object sender, EventArgs e)
    //{
    //    Common.Download("ChannelWithdrawal.xlsx", "ImportFileSample/ChannelWithdrawal.xlsx");
    //}
}