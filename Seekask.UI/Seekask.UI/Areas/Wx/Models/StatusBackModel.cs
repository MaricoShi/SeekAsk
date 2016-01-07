using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seekask.UI.Areas.Wx.Models
{
    public class StatusBackModel
    {
        /// <summary>
        /// 异常代码
        /// </summary>
        public int ErrCode { get; set; }
        /// <summary>
        /// 异常信息
        /// </summary>
        public string ErrMsg { get; set; }
        /// <summary>
        /// 返回的数据
        /// </summary>
        public object BackData { get; set; }
    }
}