using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetupActivityAdd : System.Web.UI.Page
{
    protected string editMode
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Permissions.ChannelEventBatchAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            editMode = "add";
            Id = -1;

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                ChannelEventBatchEnt ChannelEventBatchInfo = ChannelEventBatchDAL.GetItemList(Id)[0];
                txtBatchSource.Text = ChannelEventBatchInfo.BatchSource;
                txtBatchDate.Text = ChannelEventBatchInfo.BatchDate.ToString("dd-MM-yyyy");
                ddlIsReady.SelectedValue = ChannelEventBatchInfo.IsReady == "SELECT" ? String.Empty : ChannelEventBatchInfo.IsReady;
                txtBatchType.Text = ChannelEventBatchInfo.BatchType;
                btnSave.Visible = Permissions.ChannelEventBatchAdd;
            }

            if (!string.IsNullOrEmpty(Request["mode"]))
            {
                editMode = Request["mode"];
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int ErrorCode = SaveData();
        MsgUtility.msg(editMode, ErrorCode, "Channel Event Batch Information", this, lblMsg, txtBatchSource.Text);
        if (editMode == "add")
        {
            if (ErrorCode >= 0)
            {
                ClearData();
            }
        }
    }

    private void ClearData()
    {
        editMode = "add";
        Id = -1;
        txtBatchDate.Text = txtBatchSource.Text = txtBatchType.Text = String.Empty;
        ddlIsReady.SelectedIndex = -1;
    }

    private int SaveData()
    {

        ChannelEventBatchEnt ChannelEventBatchInfo = new ChannelEventBatchEnt();
        ChannelEventBatchInfo.ChannelEventBatchId = Id;
        ChannelEventBatchInfo.BatchSource = txtBatchSource.Text.Trim();
        ChannelEventBatchInfo.BatchDate = DateTime.Parse(txtBatchDate.Text);
        ChannelEventBatchInfo.IsReady = ddlIsReady.SelectedValue == "SELECT" ? String.Empty : ddlIsReady.SelectedValue;
        ChannelEventBatchInfo.BatchType = txtBatchType.Text;


        if (editMode == "edit")
        {
            return ChannelEventBatchDAL.SaveItem(ChannelEventBatchInfo, "U");
        }
        else
        {
            return ChannelEventBatchDAL.SaveItem(ChannelEventBatchInfo, "I");
        }

    }


}