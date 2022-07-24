using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;

public partial class SetupActivity : System.Web.UI.Page
{

    List<ChannelEventEnt> ChannelEvents;

    protected void pager_PreRender(object sender, EventArgs e)
    {
        DateTime importDate = String.IsNullOrEmpty(txtImportDate.Text) ? default(DateTime) : DateTime.Parse(txtImportDate.Text);
        if (CheckInput())
        {
            BindGetData(0, int.Parse(ddlEventType.SelectedValue), int.Parse(ddlChannelEvetBatch.SelectedValue), String.Empty, importDate, false);
        }
        else
        {
            BindGetData(0, 0, 0, String.Empty, importDate, true);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.ImportCommissionTargetView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            Common.PopulateCommissionReportId(ddlReportName);
            Common.AddSelectOne(ddlReportName);
            Common.PopulateChannelType(ddlChannelType);
            Common.AddSelectOne(ddlChannelType);
        }
    }

    private void BindGetData(int channelEventId, int eventTypeId, int channelEventBatchId, string importBy, DateTime importDate, bool isBlank)
    {
        if (!isBlank)
        {
            ChannelEvents = ChannelEventDAL.GetChannelEvent(channelEventId, eventTypeId, channelEventBatchId, importBy, importDate);
            lvImportedData.Visible = true;
            lvImportedData.DataSource = ChannelEvents;
            lvImportedData.DataBind();
            lblResult.Text = String.Format("Total results: {0}", ChannelEvents.Count);
            dpImportedData.Visible = ChannelEvents.Count > dpImportedData.PageSize;
        }
        else
        {
            ChannelEvents = new List<ChannelEventEnt>();
            lvImportedData.Visible = false;
            lvImportedData.DataSource = ChannelEvents;
            lvImportedData.DataBind();
            //lblResult.Text = String.Format("Total results: {0}", commissionReportTargets.Count);
            dpImportedData.Visible = false;
        }

    }

    protected void ddlReportName_SelectedIndexChanged(object sender, EventArgs e)
    {
        Common.PopulateEventTypeByReportId(ddlEventType, int.Parse(ddlReportName.SelectedValue));
        Common.AddSelectOne(ddlEventType);
        Common.PopulateChannelEventBatch(ddlChannelEvetBatch, int.Parse(ddlReportName.SelectedValue));
        Common.AddSelectOne(ddlChannelEvetBatch);
    }
    protected void btnShowPreviousImportData_Click(object sender, EventArgs e)
    {

        DateTime importDate = String.IsNullOrEmpty(txtImportDate.Text) ? default(DateTime) : DateTime.Parse(txtImportDate.Text);

        if (CheckInput())
        {
            BindGetData(0, int.Parse(ddlEventType.SelectedValue), int.Parse(ddlChannelEvetBatch.SelectedValue), String.Empty, importDate, false);
        }
        else
        {
            BindGetData(0, 0, 0, String.Empty, importDate, true);
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Redirect("ImportChannelEventData.aspx", true);
    }

    private bool CheckInput()
    {

        if (ddlReportName.SelectedIndex == 0)
        {

            lblResult.Text = "Report Name Required!";
            this.ddlReportName.Focus();
            return false;

        }
        else if (ddlChannelType.SelectedIndex == 0)
        {

            lblResult.Text = "Channel type Required!";
            this.ddlReportName.Focus();
            return false;

        }
        else if (ddlEventType.SelectedIndex == 0)
        {

            lblResult.Text = "Event Type Required!";
            this.ddlEventType.Focus();
            return false;

        }
        else if (ddlChannelEvetBatch.SelectedIndex == 0)
        {

            lblResult.Text = "Channel event batch Required!";
            this.ddlEventType.Focus();
            return false;

        }
        else
        {
            return true;
        }


    }

}