using SalesCom.DAL;
using SalesCom.Entity;
using System;

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
            if (!Permissions.PeriodTypeAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            editMode = "add";
            Id = -1;


            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                PeriodTypeEnt PeriodTypeInfo = PeriodTypeDAL.GetItemList(Id)[0];
                txtPeriodTypeName.Text = PeriodTypeInfo.PeriodTypeName;
                btnSave.Visible = Permissions.PeriodTypeAdd;
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
        MsgUtility.msg(editMode, ErrorCode, "Channel Type Information", this, lblMsg, txtPeriodTypeName.Text);
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
        txtPeriodTypeName.Text = String.Empty;
    }

    private int SaveData()
    {

        PeriodTypeEnt PeriodTypeInfo = new PeriodTypeEnt();
        PeriodTypeInfo.PeriodTypeId = Id;
        PeriodTypeInfo.PeriodTypeName = txtPeriodTypeName.Text.Trim();

        if (editMode == "edit")
        {
            return PeriodTypeDAL.SaveItem(PeriodTypeInfo, "U");
        }
        else
        {
            return PeriodTypeDAL.SaveItem(PeriodTypeInfo, "I");
        }

    }


}