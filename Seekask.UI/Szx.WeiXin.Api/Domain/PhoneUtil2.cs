using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Szx.WeiXin.Api.Domain
{
    /// <summary>
    /// 
    /// 作者：石忠孝   
    /// 文件名：PhoneUtil2
    /// 创建时间：2016/5/7 11:08:05
    /// 修改人：石忠孝
    /// 修改时间：2016/5/7 11:08:05
    /// 说明：
    /// 
    /// </summary>
    public class PhoneUtil2 : IDisposable
    {
        CookieContainer cookie = null;

        /// <summary>
        /// 根据手机号码获取号码属地
        /// </summary>
        /// <param name="_PhoneNum"></param>
        /// <returns></returns>
        public async Task<PhoneSearchGetBak> GetProvByPhoneNum(string _PhoneNum)
        {
            if (string.IsNullOrWhiteSpace(_PhoneNum))
                return null;
            string _url = "http://shop.10086.cn/i/v1/res/numarea/" + _PhoneNum;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url);
                request.Method = "GET";
                request.KeepAlive = true;

                request.CookieContainer = new CookieContainer();

                using (HttpWebResponse mResponse = (HttpWebResponse)request.GetResponse())
                {
                    cookie = request.CookieContainer;//如果用不到Cookie，删去即可  

                    using (Stream mStream = mResponse.GetResponseStream())
                    {
                        using (StreamReader myStreamReader =
                            new StreamReader(mStream, Encoding.GetEncoding("utf-8")))
                        {
                            string retString = await myStreamReader.ReadToEndAsync();
                            return JsonConvert.DeserializeObject<PhoneSearchGetBak>(retString);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return null;
        }

        /// <summary>
        /// 获取图片验证码
        /// </summary>
        /// <returns></returns>
        public byte[] GetCheckedCode(bool _IsSave = false)
        {
            string _url = "http://shop.10086.cn/i/authImg?t=" + DateTime.Now.Second;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url);
                request.Method = "GET";
                request.KeepAlive = true;

                request.CookieContainer = new CookieContainer();

                using (HttpWebResponse mResponse = (HttpWebResponse)request.GetResponse())
                {
                    cookie = request.CookieContainer;//如果用不到Cookie，删去即可  

                    using (Stream mStream = mResponse.GetResponseStream())
                    {
                        Image mImage = Image.FromStream(mStream);

                        if (_IsSave)
                        {
                            string imgSave = AppDomain.CurrentDomain.BaseDirectory + "imgCheckedCode\\"
                                            + Guid.NewGuid().ToString("N") + ".jpg";
                            mImage.Save(imgSave, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }

                        using (System.IO.MemoryStream Ms = new MemoryStream())
                        {
                            mImage.Save(Ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            byte[] img = new byte[Ms.Length];
                            Ms.Position = 0;
                            Ms.Read(img, 0, Convert.ToInt32(Ms.Length));
                            return img;
                        }
                    }
                }
            }
            catch (Exception)
            {
                
            }
            return null;
        }

        /// <summary>
        /// 验证
        /// </summary>
        public async Task<PhoneSearchGetBak> PreCheck(string phoneNum, string captchaval,
            string jsessionid)
        {
            if (string.IsNullOrWhiteSpace(phoneNum))
                return null;
            string _url = "http://shop.10086.cn/i/v1/res/precheck/" + phoneNum +
                "?captchaVal=" + captchaval;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url);
                request.Method = "GET";
                request.KeepAlive = true;
                request.Host = "shop.10086.cn";
                request.Headers["Cache-Control"] = "no-store, must-revalidate";
                request.Headers["pragma"] = "no-cache";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.122 Safari/537.36 SE 2.X MetaSr 1.0";
                request.ContentType = "*";
                request.Accept = "application/json, text/javascript, */*; q=0.01";
                request.Headers["X-Requested-With"] = "XMLHttpRequest";
                request.IfModifiedSince = DateTime.Now;
                request.Headers["expires"] = "0";
                request.Referer = "http://shop.10086.cn/i/?f=rechargecredit";
                request.Headers["Accept-Encoding"] = "gzip,deflate,sdch";
                request.Headers["Accept-Language"] = "zh-CN,zh;q=0.8";

                if (cookie != null)
                    request.CookieContainer = cookie;
                else
                    request.CookieContainer = new CookieContainer();

                //request.CookieContainer.Add(new Cookie("jsessionid-echd-cpt-cmcc-jt", jsessionid));
                request.CookieContainer.SetCookies(new Uri("http://shop.10086.cn"),
                    "jsessionid-echd-cpt-cmcc-jt=" + jsessionid + ";");

                using (HttpWebResponse mResponse = (HttpWebResponse)request.GetResponse())
                {
                    cookie = request.CookieContainer;//如果用不到Cookie，删去即可  
                    using (Stream mStream = mResponse.GetResponseStream())
                    {
                        using (StreamReader myStreamReader =
                            new StreamReader(mStream, Encoding.GetEncoding("utf-8")))
                        {
                            string retString = await myStreamReader.ReadToEndAsync();
                            return JsonConvert.DeserializeObject<PhoneSearchGetBak>(retString);
                        }
                    }
                }
            }
            catch (Exception)
            {
                
            }

            return null;
        }

        string PostPayCardnMisKey()
        {
            var h = "";
            var a = new string[]{"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", 
                "o", "p", "q","r", "s", "t", "u", "v", "w", "x", "y", "z"};
            Random rd = new Random();
            for (int i = 0; 10 > i; i++)
            {
                var c = Convert.ToInt32(Math.Ceiling(25 * rd.NextDouble()));
                var v = a[c];
                h += v;
            }
            return h;
        }
        string PostPayCardnEcrypt(string a, string h)
        {
            var c = "";
            var v = a.ToCharArray();
            var g = h.ToCharArray();
            for (int i = 0; i < v.Length; i++)
            {
                var C = (int)v[i];
                var y = i;
                if (i >= g.Length) { y = i % g.Length; };

                var A = (int)g[y] - 97;
                if (C >= 97 && 122 >= C) { C = 97 + (C - 97 + A) % 26; }
                if (C >= 65 && 90 >= C) { C = 65 + (C - 65 + A) % 26; }
                if (C >= 48 && 57 >= C) { if (A >= 10) { A = 10; }; C = 48 + (C - 48 + A) % 10; };
                var M = (char)C;
                c += M;
            }
            return c;
        }

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="ppcm"></param>
        /// <param name="captchaVal"></param>
        /// <returns></returns>
        public async Task<PostPayCardBak> PostPayCard(PostPayCardModel ppcm, string captchaVal)
        {
            if (string.IsNullOrWhiteSpace(captchaVal) || ppcm == null)
                return null;
            string _url = "http://shop.10086.cn/i/v1/pay/card/" + ppcm.chargedNum +
                "?captchaVal=" + captchaVal;

            try
            {
                ppcm.longliveLolita = PostPayCardnMisKey();
                ppcm.cardPwd = PostPayCardnEcrypt(ppcm.cardPwd, ppcm.longliveLolita);

                string postDataStr = JsonConvert.SerializeObject(ppcm); 

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url);
                request.Method = "POST";
                request.KeepAlive = true;
                request.Host = "shop.10086.cn";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.122 Safari/537.36 SE 2.X MetaSr 1.0";
                request.ContentType = "application/json";
                request.Accept = "application/json, text/javascript, */*; q=0.01";
                request.Headers["Origin"] = "http://shop.10086.cn";
                request.Headers["X-Requested-With"] = "XMLHttpRequest";
                request.Referer = "http://shop.10086.cn/i/?f=rechargecredit";
                request.Headers["Accept-Encoding"] = "gzip,deflate";
                request.Headers["Accept-Language"] = "zh-CN,zh;q=0.8";

                if (cookie != null)
                    request.CookieContainer = cookie;
                else
                    request.CookieContainer = new CookieContainer();

                Encoding encoding = Encoding.UTF8;//根据网站的编码自定义  

                byte[] postData = encoding.GetBytes(postDataStr);//postDataStr即为发送的数据，格式还是和上次说的一样  
                request.ContentLength = postData.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(postData, 0, postData.Length); 

                using (HttpWebResponse mResponse = (HttpWebResponse)request.GetResponse())
                {
                    cookie = request.CookieContainer;//如果用不到Cookie，删去即可  
                    using (Stream mStream = mResponse.GetResponseStream())
                    {
                        using (StreamReader myStreamReader =
                            new StreamReader(mStream, Encoding.GetEncoding("utf-8")))
                        {
                            string retString = await myStreamReader.ReadToEndAsync();
                            return JsonConvert.DeserializeObject<PostPayCardBak>(retString);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

            return null;
        }


        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {

        }

    }
}
