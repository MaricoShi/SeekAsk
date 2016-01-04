using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szx.WeiXin.Api
{
    /// <summary>
    /// 
    /// 作者：石忠孝   
    /// 文件名：WeChatTools
    /// 创建时间：2015/1/1 11:51:01
    /// 修改人：石忠孝
    /// 修改时间：2015/1/1 11:51:01
    /// 说明：
    /// 
    /// </summary>
    public static class WeChatTools
    {
        /// <summary>
        /// 对象的属性转换成Url参数
        /// </summary>
        /// <typeparam name="T">设置的对象</typeparam>
        /// <param name="ent"></param>
        /// <returns>Url参数字符串</returns>
        public static string GetUrlParam<T>(this T ent)
        {
            var eType = ent.GetType();
            var ePro = eType.GetProperties();
            List<string> args = new List<string>();
            foreach (var p in ePro)
            {
                var value = p.GetValue(ent, null);
                args.Add(p.Name + "=" + (value == null ? "" : value.ToString()));
            }
            return string.Join("&", args);
        }


        #region  unix时间转换为datetime
        /// <summary>      
        /// unix时间转换为datetime     
        /// </summary>      
        /// <param name="timeStamp">string</param>     
        /// <returns>DateTime</returns>      
        public static DateTime UnixTimeToTime(this string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }
        #endregion

        #region datetime转换为unixtime
        /// <summary>
        /// datetime转换为unixtime     
        /// </summary>      
        /// <param name="time">DateTime</param>     
        /// <returns>int</returns>      
        public static int ConvertDateTimeInt(this System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
        #endregion

        #region 产生指定长度的随机字符串 A-Z，a-z，0-9
        /// <summary>
        /// 产生指定长度的随机字符串 A-Z，a-z，0-9
        /// </summary>
        /// <param name="strLength">长度</param>
        /// <returns></returns>
        public static string GetRandomStr(int strLength)
        {
            List<char[]> lc = new List<char[]>() {
                new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' },
                new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' },
                new char[] { '1','2','3','4','5','6','7','8','9','0'}
            };
            List<char> lStr = new List<char>();

            Random rd = new Random();
            for (int i = 0; i < strLength; i++)
            {
                int lcNum = rd.Next(0, 3);

                char[] c = lc[lcNum];

                int maxNum = 0;
                switch (lcNum)
                {
                    case 0:
                    case 1:
                        maxNum = 26;
                        break;
                    case 2:
                        maxNum = 10;
                        break;
                    default:
                        break;
                }
                lStr.Add(c[rd.Next(0, maxNum)]);
            }

            return string.Join("", lStr);
        }
        #endregion


    }
}
