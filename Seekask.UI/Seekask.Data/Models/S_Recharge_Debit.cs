using System;
using System.Collections.Generic;

namespace Seekask.Data.Models
{
    public partial class S_Recharge_Debit
    {
        public string DebitWay { get; set; }
        public string DebitNo { get; set; }
        public int OrderNo { get; set; }
        public string DebitStatus { get; set; }
        public string DebitApiInfo { get; set; }
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
        public virtual S_Recharge_Order S_Recharge_Order { get; set; }
    }
}
