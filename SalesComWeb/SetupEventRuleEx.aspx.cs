using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;

public partial class SetupEventRule : System.Web.UI.Page
{
    protected void pager_PreRender(object sender, EventArgs e)
    {
        if (ddlEvent.SelectedIndex > 0)
        {
            BindData(int.Parse(ddlEvent.SelectedValue));
        }
        else
        {
            BindData(0);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.EventRuleView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            Common.PopulateCommissionReportId(ddlReportName);
            Common.AddSelectOne(ddlReportName);

        }
    }

    private void BindData(int eventId)
    {
        List<EventRuleExEnt> list = EventRuleExDAL.GetItemList(0, eventId, 0);

        lv.DataSource = list;
        lv.DataBind();
        lblResults.Text = String.Format("Total results: {0}", list.Count);
        pager.Visible = list.Count > pager.PageSize;
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {

        if (ddlEvent.SelectedIndex > 0)
        {
            BindData(int.Parse(ddlEvent.SelectedValue));
        }
        else
        {
            BindData(0);
        }
        pager.SetPageProperties(0, pager.MaximumRows, false);

    }
    protected void ddlEvent_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEvent.SelectedIndex > 0)
        {
            BindData(int.Parse(ddlEvent.SelectedValue));
        }
        else
        {
            BindData(0);
        }
    }
    protected void ddlReportName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlReportName.SelectedIndex > 0)
        {
            Common.PopulateEventByReportId(ddlEvent, int.Parse(ddlReportName.SelectedValue));
            Common.AddSelectOne(ddlEvent);
        }
        else
        {
            ddlReportName.Items.Clear();
        }
    }
}