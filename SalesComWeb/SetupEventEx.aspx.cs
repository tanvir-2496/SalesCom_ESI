using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Web.UI;

public partial class SetupActivity : System.Web.UI.Page
{
    protected void pager_PreRender(object sender, EventArgs e)
    {
        BindData(String.Empty, 0, 0);
        lblNotFound.Text = String.Empty;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!Permissions.EventView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            Common.PopulateChannelType(ddlChannelType);
            Common.AddSelectOne(ddlChannelType);
            Common.PopulateCommissionReportId(ddlReportName);
            Common.AddSelectOne(ddlReportName);
        }
    }

    //private void BindData(string eventName, int channelTypeId)
    //{
    //    List<EventExEnt> list = new List<EventExEnt>(); ;
    //    if (channelTypeId == 0 && String.IsNullOrEmpty(eventName))
    //    {
    //        list = EventExDAL.GetItemList(0, 0, String.Empty);
    //    }
    //    else if (channelTypeId > 0 && String.IsNullOrEmpty(eventName) == false)
    //    {
    //        list = EventExDAL.GetItemList(0, channelTypeId, eventName);
    //    }
    //    else if (channelTypeId > 0)
    //    {
    //        list = EventExDAL.GetItemList(0, channelTypeId, String.Empty);
    //    }
    //    else if (!String.IsNullOrEmpty(eventName))
    //    {
    //        list = EventExDAL.GetItemList(0, 0, eventName);
    //    }

    //    lv.DataSource = list;
    //    lv.DataBind();
    //    lblResults.Text = String.Format("Total results: {0}", list.Count);
    //    pager.Visible = list.Count > pager.PageSize;
    //}


    private void BindData(string eventName, int channelTypeId, int reportId)
    {
        List<EventExEnt> list = new List<EventExEnt>(); ;
        if (channelTypeId == 0 && String.IsNullOrEmpty(eventName) && reportId == 0)
        {
            list = EventExDAL.GetItemList(0, 0, String.Empty, 0);
        }
        else
        {
            list = EventExDAL.GetItemList(0, channelTypeId, eventName, reportId);
        }

        lv.DataSource = list;
        lv.DataBind();
        lblResults.Text = String.Format("Total results: {0}", list.Count);
        pager.Visible = list.Count > pager.PageSize;
    }



    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        BindData(String.Empty, 0, 0);
        pager.SetPageProperties(0, pager.MaximumRows, false);
        lblNotFound.Text = String.Empty;

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(txtEventName.Text))
        {
            BindData(txtEventName.Text.ToLower().Trim(), int.Parse(ddlChannelType.SelectedValue), int.Parse(ddlReportName.SelectedValue));
        }
        else
        {
            lv.DataSource = null;
            lv.DataBind();
            lblResults.Text = String.Format("Total results: {0}", 0);
            pager.Visible = false;
            lblNotFound.Text = "Event Name required";
        }
    }
    protected void ddlChannelType_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlChannelType.SelectedIndex > 0)
        {
            BindData(String.Empty, int.Parse(ddlChannelType.SelectedValue), int.Parse(ddlReportName.SelectedValue));
            lblNotFound.Text = String.Empty;
        }
        else
        {
            BindData(String.Empty, 0, 0);
            lblNotFound.Text = String.Empty;
        }

    }


    protected void ddlReportName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlReportName.SelectedIndex > 0)
        {
            BindData(String.Empty, int.Parse(ddlChannelType.SelectedValue), int.Parse(ddlReportName.SelectedValue));
            lblNotFound.Text = String.Empty;
        }
        else
        {
            BindData(String.Empty, 0, 0);
            lblNotFound.Text = String.Empty;
        }
    }

}