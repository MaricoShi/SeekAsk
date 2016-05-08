using System;
using System.Collections.Generic;

namespace Seekask.Data.Models
{
    public partial class S_Recharge_Order
    {
        public S_Recharge_Order()
        {
            this.S_Recharge_Debit = new List<S_Recharge_Debit>();
        }

        public int SerialNo { get; set; }
        public string RechargeTime { get; set; }
        public string OrderType { get; set; }
        public string OrderStatus { get; set; }
        public int RechargeCardNo { get; set; }
        public int RechargeBillsNo { get; set; }
        public string RechargePhoneNo { get; set; }
        public string RechargeProv { get; set; }
        public string RechargeCity { get; set; }
        public decimal BillsAmount { get; set; }
        public decimal SalesAmount { get; set; }
        public decimal ActualSalesAmount { get; set; }
        public decimal ActualPaymentAmount { get; set; }
        public string DebitNo { get; set; }
        public string ApiDebitNo { get; set; }
        public string RechargeBackInfo { get; set; }
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
        public virtual S_Recharge_CardList S_Recharge_CardList { get; set; }
        public virtual ICollection<S_Recharge_Debit> S_Recharge_Debit { get; set; }
    }
}
