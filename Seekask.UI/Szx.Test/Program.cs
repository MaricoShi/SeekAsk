using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szx.WeiXin.Api;
using Szx.WeiXin.Api.Domain;
using Szx.WeiXin.Api.Models;

using System.Threading;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Szx.Test
{
    public class SelectAddr { 
        
    }

    class Program
    {
        public static void GetIpAddr(string ip) {
            if (string.IsNullOrWhiteSpace(ip)) return;

            var _url = "http://int.dpool.sina.com.cn/iplookup/iplookup.php?format=js&ip=" + ip;
            var rq = (HttpWebRequest)WebRequest.Create(_url);
            rq.Method = "GET";
            rq.Timeout = 1000 * 2;
            using (var rs = rq.GetResponse())
            {
                using (var sr = new StreamReader(rs.GetResponseStream(), Encoding.UTF8))
                {
                    string resultStr = sr.ReadToEnd();
                    if (resultStr != null && resultStr.Contains("var remote_ip_info =")) {
                        resultStr = resultStr.Replace("var remote_ip_info =", "").Trim();
                        //System.Web.HttpUtility.UrlDecode(resultStr);
                        //JsonConvert.DeserializeObject<SelectAddr>(resultStr);
                    }
                }
            }
            rq.Abort();
            rq = null;
        }
        static void Main(string[] args)
        {
            //GetIpAddr("222.44.31.146");

            //GetWeChatInfo();

            GetPhoneInfo();

            Console.Read();
        }

        static async void GetPhoneInfo() {
            using (PhoneUtil2 phone2 = new PhoneUtil2())
            {
                phone2.GetCheckedCode(true);

                string checkCode = Console.ReadLine();
                await phone2.PreCheck("15800830052", checkCode, "AA13F2159FA58F094B7C484D4C94904F");

                await phone2.PostPayCard(new PostPayCardModel() {
                    cardPwd = "393606924290641043",
                    chargedNum = "15800830052"
                }, checkCode);
            }

            //using (PhoneUtil phone = new PhoneUtil("15800830052","081493"))
            //{
                

            //    await phone.GetCheckedCode();
            //    //phone.Login();
            //    string checkCode = Console.ReadLine();
            //    phone.PreCheck("15800830052", checkCode, "AA13F2159FA58F094B7C484D4C94904F");


            //    phone.PostPayCard(new PostPayCardModel() 
            //    { cardPwd = "222222222222222222", chargedNum = "15800830052" }, checkCode);

            //    phone.Login(checkCode);

            //    PhoneSearchGetBak psgb = await phone.GetProvByPhoneNum("15800830052");
            //    if (psgb == null || psgb.retCode != "000000" || psgb.data == null)
            //    {
            //        Console.WriteLine(psgb == null ? "异常" : psgb.retMsg);
            //    }
            //    else {
            //        Console.WriteLine(psgb.data.prov_cd + " " + psgb.data.id_name_cd);
            //    }
            //}
        }

        private static void GetWeChatInfo()
        {
            string _RandomStr = WeChatTools.GetRandomStr(43);

            using (SmartBindUtil smartBind = new SmartBindUtil("784478682@qq.com", "shizhongxiao93"))
            {
                //登录成功后，在开发者中心获取开发者信息
                WechatDevInfo devInfo = smartBind.GetWechatDev();

                WechatAccountInfo accountInfo = smartBind.GetAccount();
                //无法获取用户信息，结束操作并跳出
                if (accountInfo == null) return;

                //下载头像
                if (!string.IsNullOrWhiteSpace(accountInfo.HeadImage))
                {
                    string fileName = AppDomain.CurrentDomain.BaseDirectory + "img\\headImg.jpg";
                    int downStatus = smartBind.DownloadImg(accountInfo.HeadImage, fileName, true);
                }
                //下载二维码
                if (!string.IsNullOrWhiteSpace(accountInfo.HeadImage))
                {
                    string fileName = AppDomain.CurrentDomain.BaseDirectory + "img\\qrCode.jpg";
                    int downStatus = smartBind.DownloadImg(accountInfo.QRCode, fileName, true);
                }

                //设置启用开发模式
                int status = smartBind.EnabledDev(1, 2);
                //启用开发模式失败，结束操作并跳出
                if (status != 0) return;

                // 验证服务器接口回调，此处修改服务器配置中的URL和Token
                int i = 2;
                while (i > 0)
                {
                    status = smartBind.SetDevServiceUrl(
                        "http://sjianshang.xicp.net/seekask.ui/weixin",
                        "SeekAsk2015WeiXin", "T9538lolqhzjEQokpni6xSfYQ0LpJChwLvJiohLu4oV",
                        ((int)EncodingAESType.安全模式).ToString());
                    if (status == 0) break;

                    Thread.Sleep(2000);
                    i--;
                }
                if (status == 0)
                {
                    //修改成功！
                }

            };
        }
    }
}
