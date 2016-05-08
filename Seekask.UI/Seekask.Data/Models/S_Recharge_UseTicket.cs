using System;
using System.Collections.Generic;

namespace Seekask.Data.Models
{
    public partial class S_Recharge_UseTicket
    {
        public int SerialNo { get; set; }
        public string UseTicketPwd { get; set; }
        public string UseTicketType { get; set; }
        public string UseStatus { get; set; }
        public decimal UseTicketAmount { get; set; }
        public decimal UseAmount { get; set; }
        public System.DateTime ValidityStart { get; set; }
        public System.DateTime ValidityEnd { get; set; }
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
