using System;
using System.Collections.Generic;

namespace Seekask.Data.Models
{
    public partial class Weixin_Sys_Info
    {
        public int WxId { get; set; }
        public Nullable<int> Wx_Status { get; set; }
        public string Wx_AccountId { get; set; }
        public string Wx_HeadImage { get; set; }
        public string Wx_QRCode { get; set; }
        public string Wx_AccountName { get; set; }
        public string Wx_WechatNumber { get; set; }
        public Nullable<int> Wx_WechatType { get; set; }
        public string Wx_Introduces { get; set; }
        public Nullable<int> Wx_Authenticate { get; set; }
        public string Wx_PlaceAddress { get; set; }
        public string Wx_SubjectInfo { get; set; }
        public string Wx_LoginEmail { get; set; }
        public string Wx_AppId { get; set; }
        public string Wx_AppSecret { get; set; }
        public string Wx_URL { get; set; }
        public string Wx_Token { get; set; }
        public string Wx_EncodingAESKey { get; set; }
        public Nullable<int> Wx_EncodingAESType { get; set; }
        public string Wx_Access_Token { get; set; }
        public Nullable<int> Wx_Access_Token_Time { get; set; }
        public Nullable<System.DateTime> Wx_Access_Token_Update { get; set; }
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
