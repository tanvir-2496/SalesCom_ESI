using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity.ViewModel
{
    public class ApprovalFlowViewModel
    {
        public int ApprovalLevelId { get; set; }
        public int ApprovalFlowId { get; set; }
        public string ApprovalFlowName { get; set; }
        
        public ApprovalFlowViewModel() { }

        public ApprovalFlowViewModel(DataRow dr)
        {
            if (dr["APPROVALLEVELID"] != DBNull.Value) { this.ApprovalLevelId = Convert.ToInt32(dr["APPROVALLEVELID"]); }
            if (dr["APPROVALFLOWID"] != DBNull.Value) { this.ApprovalFlowId = Convert.ToInt32(dr["APPROVALFLOWID"]); }
            this.ApprovalFlowName = dr["APPROVALLEVELNAME"] as String;

            
            
        }
    }
}
