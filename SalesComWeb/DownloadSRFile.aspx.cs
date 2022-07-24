using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SalesCom.DAL;

public partial class DownloadSRFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != null && string.IsNullOrEmpty(Request["fileex"]) == false)
        {
            byte[] srContent;

            if (Request["Type"] != null)
            {
                srContent = ModalityReportContentDAL.GetHRReportApproval(int.Parse(Request["id"].ToString()));
            }
            else
            {
                srContent = ModalityReportContentDAL.GetSR(int.Parse(Request["id"].ToString()));
            }

            Response.Clear();
            Response.ClearHeaders();
            Response.ClearContent();
            Response.Buffer = true;
            Response.ContentType = GetMimeTypeByFileName(Request["fileex"].ToString());
            //Response.AppendHeader("content-disposition", String.Format("attachment; filename={0}.{1}", Request["Fname"].ToString(), Request["fileex"].ToString()));
            Response.AppendHeader("content-disposition", String.Format("inline; filename={0}{1}.{2}", "hrFile", System.DateTime.Now.ToString("ddMMyyy-HHmmss"), Request["fileex"].ToString()));
            Response.BinaryWrite(srContent);
            Response.Flush();
            Response.End();
        }
        else
        {
            Response.Redirect("KPIApproval.aspx");

        }
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
            else if (sExtension == "pdf")
            {
                sMime = "application/pdf";
            }
            else if (sExtension == "eml")
            {
                sMime = "application/eml";
            }
        }

        return sMime;
    }
}