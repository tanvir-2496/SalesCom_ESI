using SalesCom.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class viewFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != null)
        {
           byte [] b= ModalityReportContentDAL.GetFile(int.Parse(Request["id"].ToString()));

           Response.Clear();
           Response.ClearHeaders();
           Response.ClearContent();
           Response.ContentType = GetMimeTypeByFileName(Request["fileex"].ToString());
           //Response.AppendHeader(String.Format("content-disposition", "attachment; filename={0}.{1}", Request["Fname"].ToString() ,Request["fileex"].ToString());
            Response.AppendHeader("content-disposition", String.Format("attachment; filename={0}.{1}", Request["Fname"].ToString() ,Request["fileex"].ToString()));
           Response.BinaryWrite(b);

           Response.End();
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
        }

        return sMime;
    }

}