using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Configuration;
using System.IO;
using System.Web;

public partial class SetupModalityReportContentAdd : System.Web.UI.Page
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
            if (!Permissions.ModalityReportContentAdd)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }

            editMode = "add";
            Id = -1;

            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                Id = int.Parse(Request["Id"]);
                ModalityReportContentEnt modelityContent = ModalityReportContentDAL.GetItemList(Id)[0];
                txtReportName.Text = modelityContent.ReportName;
                chkIsActive.Checked = modelityContent.IsActive;
                btnSave.Visible = Permissions.ModalityReportContentAdd;
            }

            if (!string.IsNullOrEmpty(Request["mode"]))
            {
                editMode = Request["mode"];
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!ImageTypeFileUpLoad.HasFile)
        {
            lblMsg.Text = "Data Can not Add !!";
            return;
        }
        int ErrorCode = SaveData();
        MsgUtility.msg(editMode, ErrorCode, "Segment Type Information", this, lblMsg, txtReportName.Text);
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
        txtReportName.Text = String.Empty;
        chkIsActive.Checked = false;
    }

    private int SaveData()
    {
        int result = 0;

        string currentUser = (HttpContext.Current.Session["LoginInfo"] as LoginInfo).UserName;
        string ext = System.IO.Path.GetExtension(ImageTypeFileUpLoad.PostedFile.FileName);

        if (ImageTypeFileUpLoad.HasFile)
        {
            ModalityReportContentEnt modalityContent = new ModalityReportContentEnt();
            modalityContent.Id = Id;
            modalityContent.ReportName = txtReportName.Text.Trim();
            modalityContent.IsActive = chkIsActive.Checked;
            modalityContent.FileType = ext.Replace(".", String.Empty);
            modalityContent.FileContent = ImageTypeFileUpLoad.FileBytes;


            if (editMode == "edit")
            {
                modalityContent.UpdateBy = currentUser;
                result = ModalityReportContentDAL.SaveItem(modalityContent, "U");
            }
            else
            {
                modalityContent.CreateBy = currentUser;
                result = ModalityReportContentDAL.SaveItem(modalityContent, "I");
            }
        }

        return result;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string currentUser = (HttpContext.Current.Session["LoginInfo"] as LoginInfo).UserName;
        string ext = System.IO.Path.GetExtension(ImageTypeFileUpLoad.PostedFile.FileName);
        ModalityReportContentEnt modalityContent = new ModalityReportContentEnt();
        modalityContent.Id = Id;
        modalityContent.ReportName = txtReportName.Text.Trim();
        modalityContent.IsActive = chkIsActive.Checked;
        modalityContent.FileType = ext;
        modalityContent.CreateBy = currentUser;
        modalityContent.FileContent = ImageTypeFileUpLoad.FileBytes;
        // modalityContent.FileContent = File.ReadAllBytes(ImageTypeFileUpLoad.PostedFile.FileName);

        int ErrorCode = ModalityReportContentDAL.SaveItem(modalityContent, "I");
        if (ErrorCode <= -1)
            lblMsg.Text = "Data Can not Add !!";
        else
        {
            lblMsg.Text = "Data Add Successful!!";
        }
    }


}