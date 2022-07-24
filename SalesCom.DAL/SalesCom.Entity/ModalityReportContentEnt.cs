using System;
using System.Data;

namespace SalesCom.Entity
{
    public class ModalityReportContentEnt
    {
        public int Id { get; set; }
        public string ReportName { get; set; }
        public bool IsActive { get; set; }
        public byte[] FileContent { get; set; }
        public string FileType { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public ModalityReportContentEnt() { }

        public ModalityReportContentEnt(DataRow dr)
        {
            if (dr["Id"] != DBNull.Value) { this.Id = Convert.ToInt32(dr["Id"]); }
            this.ReportName = dr["ReportName"] as String;
            this.IsActive = Convert.ToInt32(dr["IsActive"]) == 0 ? false : true;
           // if (dr["FileContent"] != DBNull.Value) { this.FileContent = dr["FileContent"] as Byte[]; };
            this.FileType = dr["FileType"] as String;
            if (dr["CreateDate"] != DBNull.Value) { this.CreateDate = Convert.ToDateTime(dr["CreateDate"]); }
            this.CreateBy = dr["CreateBy"] as String;
            this.UpdateBy = dr["UpdateBy"] as String;
            if (dr["UpdateDate"] != DBNull.Value) { this.UpdateDate = Convert.ToDateTime(dr["UpdateDate"]); }
        }

    }
}
