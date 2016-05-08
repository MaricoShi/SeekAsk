using System;
using System.Collections.Generic;

namespace Seekask.Data.Models
{
    public partial class S_Recharge_CardList
    {
        public S_Recharge_CardList()
        {
            this.S_Recharge_Order = new List<S_Recharge_Order>();
        }

        public int SerialNo { get; set; }
        public string SerialNumber { get; set; }
        public string RechargeCardPwd { get; set; }
        public System.DateTime ExpirationDate { get; set; }
        public string RechargeStatus { get; set; }
        public int RechargeBillsNo { get; set; }
        public string RechargeType { get; set; }
        public int Bills { get; set; }
        public decimal SalesAmount { get; set; }
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
        public virtual S_Recharge_Bills S_Recharge_Bills { get; set; }
        public virtual ICollection<S_Recharge_Order> S_Recharge_Order { get; set; }
    }
}
