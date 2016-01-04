using System;
using System.Collections.Generic;

namespace Seekask.Data.Models
{
    public partial class Weixin_Msg_Request
    {
        public int WxId { get; set; }
        public string MsgId { get; set; }
        public string MsgType { get; set; }
        public string FromUserName { get; set; }
        public string ToUserName { get; set; }
        public string Encrypt { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string XmlDocument { get; set; }

    }
}
