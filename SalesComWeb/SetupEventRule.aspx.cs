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
            BindData(int.Parse(ddlEvent.SelectedValue), 0);
        }
        else
        {
            BindData(0, 0);
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
            Common.PopulateCommissionReportId(ddlReportname);
            Common.AddSelectOne(ddlReportname);
        }
    }

    private void BindData(int eventId, int reportId)
    {
        List<EventRuleEnt> list;

        if (eventId > 0 && reportId == 0)
        {
            list = EventRuleDAL.GetItemList(0, eventId, 0);
        }
        else if (reportId > 0)
        {
            list = EventRuleDAL.GetItemList(0, 0, reportId);
        }
        else
        {
            list = new List<EventRuleEnt>();
        }
        lv.DataSource = list;
        lv.DataBind();
        lblResults.Text = String.Format("Total results: {0}", list.Count);
        pager.Visible = list.Count > pager.PageSize;


    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {

        if (ddlEvent.SelectedIndex > 0)
        {
            BindData(int.Parse(ddlEvent.SelectedValue), 0);
        }
        else
        {
            BindData(0, 0);
        }
        pager.SetPageProperties(0, pager.MaximumRows, false);

    }
    protected void ddlEvent_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEvent.SelectedIndex > 0)
        {
            BindData(int.Parse(ddlEvent.SelectedValue), 0);
        }
        else
        {
            BindData(0, 0);
        }
    }

    protected void ddlReportname_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlReportname.SelectedIndex > 0)
        {
            Common.PopulateEventByReportId(ddlEvent, int.Parse(ddlReportname.SelectedValue));
            Common.AddSelectOne(ddlEvent);
            BindData(0, int.Parse(ddlReportname.SelectedValue));
        }
        else
        {
            ddlEvent.Items.Clear();
        }
    }
}