using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Entity.ViewModel
{
    public class ConditionViewModel
    {
        public int Condition_id { get; set; }
        public int Kpi_id { get; set; }
        public int SubKpi_id { get; set; }
        public int Kpi_Configuration_Id { get; set; }
        public string Condition_Name { get; set; }
        public string Display_Name { get; set; }
        public string Procedure_Name { get; set; }
        public int Is_Report_Field { get; set; }
        public int Is_Active { get; set; }
        public string Remarks { get; set; }
        public int Is_Process_Required { get; set; }
        public int Condition_Type { get; set; }
        public int Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public int Updated_By { get; set; }
        public DateTime Updated_Date { get; set; }
    }
}
