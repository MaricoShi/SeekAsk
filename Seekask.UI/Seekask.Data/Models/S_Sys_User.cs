using System;
using System.Collections.Generic;

namespace Seekask.Data.Models
{
    public partial class S_Sys_User
    {
        public string UserCode { get; set; }
        public string UserPwd { get; set; }
        public string UserStatus { get; set; }
        public int UserLevel { get; set; }
        public string Remark { get; set; }
        public string CreateEmpCode { get; set; }
        public string CreateEmpName { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreateIP { get; set; }
        public string ModifyEmpCode { get; set; }
        public string ModifyEmpName { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string ModifyIP { get; set; }
        public bool IsDeleted { get; set; }
    }
}
