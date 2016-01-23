using System;
using System.Collections.Generic;

namespace Seekask.Data.Models
{
    public partial class Szx_Sys_Log
    {
        public string LogID { get; set; }
        public string LogName { get; set; }
        public string Source { get; set; }
        public int LevelCode { get; set; }
        public string RequestUrl { get; set; }
        public System.DateTime LogDate { get; set; }
        public string Message { get; set; }
        public string Remark { get; set; }
        public string Create_Id { get; set; }
        public string Create_Name { get; set; }
        public Nullable<System.DateTime> Create_Time { get; set; }
        public string Create_IP { get; set; }
        public string Modify_Id { get; set; }
        public string Modify_Name { get; set; }
        public Nullable<System.DateTime> Modify_Time { get; set; }
        public string Modify_IP { get; set; }
        public bool Is_Deleted { get; set; }
    }
}
