using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;

public partial class SetupActivity : System.Web.UI.Page
{
    protected void pager_PreRender(object sender, EventArgs e)
    {
        //BindData(0, 0, 0, 0);
        //ddlReport.SelectedIndex = 0;
        //ddlSegment.SelectedIndex = 0;
        if (ddlReport.SelectedIndex > 0)
        {
            if (ddlSegment.SelectedIndex > 0)
            {
                BindData(int.Parse(ddlReport.SelectedValue), int.Parse(ddlSegment.SelectedValue), 0, 0);
            }
            else
            {
                BindData(int.Parse(ddlReport.SelectedValue), 0, 0, 0);
            }
        }
        //else
        //{
        //    BindData(0, 0, 0, 0);
        //}
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!Permissions.CommsiionReportSegmentsView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            Common.PopulateCommissionReportId(ddlReport);
            Common.AddSelectOne(ddlReport);
            Common.PopulateSegment(ddlSegment);
            Common.AddSelectAll(ddlSegment);
        }

    }

    private void BindData(int id, int segmentId, int eventId, int minP)
    {
        List<CommissionReportSegmentsEnt> list = CommissionReportSegmentsDAL.GetItemList(id, segmentId, eventId, minP);

        lv.DataSource = list;
        lv.DataBind();
        lblResults.Text = String.Format("Total results: {0}", list.Count);
        pager.Visible = list.Count > pager.PageSize;
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        //BindData(0, 0, 0, 0);
        //ddlReport.SelectedIndex = 0;
        //ddlSegment.SelectedIndex = 0;
        //pager.SetPageProperties(0, pager.MaximumRows, false);
        if (ddlReport.SelectedIndex > 0)
        {
            if (ddlSegment.SelectedIndex > 0)
            {
                BindData(int.Parse(ddlReport.SelectedValue), int.Parse(ddlSegment.SelectedValue), 0, 0);
            }
            else
            {
                BindData(int.Parse(ddlReport.SelectedValue), 0, 0, 0);
            }
        }

    }
    protected void ddlReport_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlReport.SelectedIndex > 0)
        {
            if (ddlSegment.SelectedIndex > 0)
            {
                BindData(int.Parse(ddlReport.SelectedValue), int.Parse(ddlSegment.SelectedValue), 0, 0);
            }
            else
            {
                BindData(int.Parse(ddlReport.SelectedValue), 0, 0, 0);
            }
        }
        //else
        //{
        //    BindData(0, 0, 0, 0);
        //}
    }
    protected void ddlSegment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSegment.SelectedIndex > 0)
        {
            if (ddlReport.SelectedIndex > 0)
            {
                BindData(int.Parse(ddlReport.SelectedValue), int.Parse(ddlSegment.SelectedValue), 0, 0);
            }
            else
            {
                BindData(0, int.Parse(ddlSegment.SelectedValue), 0, 0);
            }
        }
        else
        {
            //BindData(0, 0, 0, 0);
            BindData(int.Parse(ddlReport.SelectedValue), 0, 0, 0);
        }
    }
}