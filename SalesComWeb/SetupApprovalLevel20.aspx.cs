using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;

public partial class SetupApprovalLevel20 : System.Web.UI.Page
{
    protected void pager_PreRender(object sender, EventArgs e)
    {
        BindDataToGrid();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.ApprovalLevelView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
            Common.PopulateApprovalFlow(ddlApprovalFlowName,String.Empty);
            Common.AddSelectAll(ddlApprovalFlowName);
            Common.BindProcessStageOrder(ddlApprovalOrder);
        }
    }

    private void BindData(DataFetchType dataFetchType)
    {
        List<ApprovalLevel20Ent> list = new List<ApprovalLevel20Ent>(); ;

        if (dataFetchType == DataFetchType.All)
        {
            list = ApprovalLevel20DAL.GetApprovalLevelByFlowId(0, 0, 0);
        }
        else if (dataFetchType == DataFetchType.Flow)
        {
            list = ApprovalLevel20DAL.GetApprovalLevelByFlowId(0, Convert.ToInt32(ddlApprovalFlowName.SelectedValue), 0);
        }
        else if (dataFetchType == DataFetchType.Order)
        {
            list = ApprovalLevel20DAL.GetApprovalLevelByFlowId(0, 0, Convert.ToInt32(ddlApprovalOrder.SelectedValue));
        }
        else if (dataFetchType == DataFetchType.FlowOrder)
        {
            list = ApprovalLevel20DAL.GetApprovalLevelByFlowId(0, Convert.ToInt32(ddlApprovalFlowName.SelectedValue), Convert.ToInt32(ddlApprovalOrder.SelectedValue));
        }

        lv.DataSource = list;
        lv.DataBind();
        lblResults.Text = String.Format("Total results: {0}", list.Count);
        pager.Visible = list.Count > pager.PageSize;
    }

    protected void ddlApprovalFlowName_SelectedIndexChanged(object sender, EventArgs e)
    {
        pager.SetPageProperties(0, pager.MaximumRows, false);
        BindDataToGrid();
    }

    protected void lblApprovalOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        pager.SetPageProperties(0, pager.MaximumRows, false);
        BindDataToGrid();
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        BindDataToGrid();
    }

    protected void BindDataToGrid()
    {
        if (this.ddlApprovalFlowName.SelectedIndex > 0 && this.ddlApprovalOrder.SelectedIndex > 0)
        {
            BindData(DataFetchType.FlowOrder);
        }
        else if (this.ddlApprovalFlowName.SelectedIndex > 0)
        {
            BindData(DataFetchType.Flow);
        }
        else if (this.ddlApprovalOrder.SelectedIndex > 0)
        {
            BindData(DataFetchType.FlowOrder);
        }
        else
        {
            BindData(DataFetchType.All);
        }
    }

    protected enum DataFetchType { All, Flow, Order, FlowOrder };

}