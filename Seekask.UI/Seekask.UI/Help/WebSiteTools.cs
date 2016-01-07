﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seekask.UI.Help
{
    public class WebSiteTools
    {
        /// 获取IP
        /// </summary>
        /// <returns></returns>
        public static string GetRequestIP()
        {
            string ip = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(HttpContext.Current.Request.ServerVariables["HTTP_VIA"]))
                    ip = Convert.ToString(HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
                if (string.IsNullOrEmpty(ip))
                    ip = Convert.ToString(HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
            }
            catch (Exception) { }
            return ip;
        }
    }
}