using SalesCom.DAL;
using SalesCom.Entity;
using System;

public partial class SetupProductChannelAdd : System.Web.UI.Page
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
            if (!Permissions.ActivityAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            editMode = "add";
            Id = -1;

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                ProductChannelEnt productChannelInfo = ProductChannelDAL.GetItemList(Id)[0];
                txtProductChannelName.Text = productChannelInfo.ProdChhName;
                txtEffectiveDate.Text = productChannelInfo.EffectiveDate.ToString("dd-MM-yyyy");
                txtExpiryDate.Text = productChannelInfo.ExpireDate.ToString("dd-MM-yyyy");
                txtProcedure.Text = productChannelInfo.ProcedureName;
                chkIsActive.Checked = productChannelInfo.IsActive == 1 ? true : false;
                chkIsDynamic.Checked = productChannelInfo.IsDynamic == "Y" ? true : false;
                btnSave.Visible = Permissions.ActivityAdd;
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
        MsgUtility.msg(editMode, ErrorCode, "Activity Information", this, lblMsg, txtProductChannelName.Text);
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
        txtEffectiveDate.Text = txtExpiryDate.Text = txtProcedure.Text = txtProductChannelName.Text = String.Empty;
        chkIsDynamic.Checked = chkIsActive.Checked = false;
    }

    private int SaveData()
    {
        ProductChannelEnt productChannel = new ProductChannelEnt();
        productChannel.ProductChannelId = Id;
        productChannel.ProdChhName = txtProductChannelName.Text;
        productChannel.EffectiveDate = String.IsNullOrEmpty(txtEffectiveDate.Text) ? default(DateTime) : DateTime.Parse(txtEffectiveDate.Text);
        productChannel.ExpireDate = String.IsNullOrEmpty(txtExpiryDate.Text) ? default(DateTime) : DateTime.Parse(txtExpiryDate.Text);
        productChannel.ProcedureName = txtProcedure.Text;
        productChannel.IsActive = chkIsActive.Checked == true ? 1 : 0;
        productChannel.IsDynamic = chkIsDynamic.Checked == true ? "Y" : "N";

        if (editMode == "edit")
        {
            return ProductChannelDAL.SaveItem(productChannel, "U");
        }
        else
        {
            return ProductChannelDAL.SaveItem(productChannel, "I");
        }
    }

}