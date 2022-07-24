using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SalesCom.Entity
{
    public class SetupStageEnt
    {
        public int NumId { get; set; }
        public int NumProcessId { get; set; }
        public string StrStageName { get; set; }
        public int NumStageOrder { get; set; }
        public int NumCreateUser { get; set; }
        public DateTime DtCreateDate { get; set; }
        public int NumEditUser { get; set; }
        public DateTime DtEditDate { get; set; }

        public SetupStageEnt() { }

        public SetupStageEnt(DataRow dr)
        {
            if (dr["NUMID"] != DBNull.Value) { this.NumId = Convert.ToInt32(dr["NUMID"]); }
            if (dr["NUMPROCESSID"] != DBNull.Value) { this.NumProcessId = Convert.ToInt32(dr["NUMPROCESSID"]); }
            this.StrStageName = dr["STRSTAGENAME"] as String;
            if (dr["NUMSTAGEORDER"] != DBNull.Value) { this.NumStageOrder = Convert.ToInt32(dr["NUMSTAGEORDER"]); }
            if (dr["NUMCREATEUSER"] != DBNull.Value) { this.NumCreateUser = Convert.ToInt32(dr["NUMCREATEUSER"]); }
            if (dr["DTCREATEDATE"] != DBNull.Value) { this.DtCreateDate = Convert.ToDateTime(dr["DTCREATEDATE"]); }
            if (dr["NUMEDITUSER"] != DBNull.Value) { this.NumEditUser = Convert.ToInt32(dr["NUMEDITUSER"]); }
            if (dr["DTEDITDATE"] != DBNull.Value) { this.DtEditDate = Convert.ToDateTime(dr["DTEDITDATE"]); }
        }
    }

    public class SetupStageViewEnt
    {
        public int NumId { get; set; }
        public string StrProcessName { get; set; }
        public int NumProcessId { get; set; }
        public string StrStageName { get; set; }
        public int NumStageOrder { get; set; }

        public SetupStageViewEnt()
        { }

        public SetupStageViewEnt(DataRow dr)
        {
            if (dr["NUMID"] != DBNull.Value) { this.NumId = Convert.ToInt32(dr["NUMID"]); }
            this.StrProcessName = dr["STRPROCESSNAME"] as String;
            if (dr["NUMPROCESSID"] != DBNull.Value) { this.NumProcessId = Convert.ToInt32(dr["NUMPROCESSID"]); }
            this.StrStageName = dr["STRSTAGENAME"] as String;
            if (dr["NUMSTAGEORDER"] != DBNull.Value) { this.NumStageOrder = Convert.ToInt32(dr["NUMSTAGEORDER"]); }
        }

    }
}

