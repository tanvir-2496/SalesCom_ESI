using SalesCom.DAL;
using SalesCom.Entity;
using System;
using System.Collections.Generic;
using System.Web.UI;

public partial class SetupActivity : System.Web.UI.Page
{

    protected void pager_PreRender(object sender, EventArgs e)
    {
        BindData();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            if (!Permissions.ModalityReportContentView)
            {
                MsgUtility.showNotPermittedMsg(this.Page);
                return;
            }
        }
    }

    private void BindData()
    {
        List<ModalityReportContentEnt> list = ModalityReportContentDAL.GetItemList(0);

        lv.DataSource = list;
        lv.DataBind();
        lblResults.Text = String.Format("Total results: {0}", list.Count);
        pager.Visible = list.Count > pager.PageSize;


    }

    public void StreamFileToBrowser(string sFileExt, byte[] fileBytes)
    {
        // System.Web.HttpContext context = System.Web.HttpContext.Current;
        Response.Clear();
        Response.ClearHeaders();
        Response.ClearContent();
        Response.AppendHeader("content-length", fileBytes.Length.ToString());
        Response.ContentType = GetMimeTypeByFileName(sFileExt);
        Response.AppendHeader("content-disposition", "attachment; filename=" + sFileExt);
        //System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        //System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        Response.BinaryWrite(fileBytes);

        Response.End();
        //context.ApplicationInstance.CompleteRequest();
    }

    public string GetMimeTypeByFileName(string sFileName)
    {
        string sMime = "application/octet-stream";

        string sExtension = "." + sFileName;
        if (!string.IsNullOrEmpty(sExtension))
        {
            sExtension = sExtension.Replace(".", "");
            sExtension = sExtension.ToLower();

            if (sExtension == "xls" || sExtension == "xlsx")
            {
                sMime = "application/ms-excel";
            }
            else if (sExtension == "doc" || sExtension == "docx")
            {
                sMime = "application/msword";
            }
            else if (sExtension == "ppt" || sExtension == "pptx")
            {
                sMime = "application/ms-powerpoint";
            }
            else if (sExtension == "rtf")
            {
                sMime = "application/rtf";
            }
            else if (sExtension == "zip")
            {
                sMime = "application/zip";
            }
            else if (sExtension == "mp3")
            {
                sMime = "audio/mpeg";
            }
            else if (sExtension == "bmp")
            {
                sMime = "image/bmp";
            }
            else if (sExtension == "gif")
            {
                sMime = "image/gif";
            }
            else if (sExtension == "jpg" || sExtension == "jpeg")
            {
                sMime = "image/jpeg";
            }
            else if (sExtension == "png")
            {
                sMime = "image/png";
            }
            else if (sExtension == "tiff" || sExtension == "tif")
            {
                sMime = "image/tiff";
            }
            else if (sExtension == "txt")
            {
                sMime = "text/plain";
            }
        }

        return sMime;
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        BindData();
        pager.SetPageProperties(0, pager.MaximumRows, false);

    }

    string fileType;
    byte[] fileContent;

    
    static byte[] GetBytes(string str)
    {
        byte[] bytes = new byte[str.Length * sizeof(char)];
        System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
        return bytes;
    }
    
    protected void lv_ItemCommand(object sender, System.Web.UI.WebControls.ListViewCommandEventArgs e)
    {
        String[] arguments = e.CommandArgument.ToString().Split(new char[] { ',' });
        if (arguments.Length == 2)
        {
            fileType = arguments[1].ToString();
            fileContent = GetBytes(arguments[0]);
        }

        StreamFileToBrowser(fileType, fileContent);
    }
}