using Ivony.Html;
using Ivony.Html.Parser;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Szx.WeiXin.Api.Models;

namespace Szx.WeiXin.Api.Domain
{
    /// <summary>
    /// 
    /// 作者：石忠孝   
    /// 文件名：SmartBindUtil
    /// 创建时间：2015/1/1 11:57:40
    /// 修改人：石忠孝
    /// 修改时间：2015/1/1 11:57:40
    /// 说明：
    ///     智能绑定核心类 
    /// </summary>
    public class PhoneUtil : IDisposable
    {
        #region 模拟请求所用的参数设置
        public readonly static string COOKIE_H = "Cookie";

        public readonly static string HOST_H = "Host";
        public readonly static string HOST = "shop.10086.cn";

        public readonly static string CONNECTION_H = "Connection";
        public readonly static string CONNECTION = "keep-alive";

        public readonly static string CACHE_CONTROL_H = "Cache-Control";
        public readonly static string CACHE_CONTROL = "no-store, must-revalidate";

        public readonly static string PRAGMA_H = "pragma";
        public readonly static string PRAGMA = "no-cache";
        
        public readonly static string USER_AGENT_H = "User-Agent";
        public readonly static string USER_AGENT = " Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.122 Safari/537.36 SE 2.X MetaSr 1.0";

        public readonly static string CONTENT_TYPE_H = "Content-Type";
        public readonly static string CONTENT_TYPE = "*";

        public readonly static string ACCEPT_H = "Accept";
        public readonly static string ACCEPT = "application/json, text/javascript, */*; q=0.01";

        public readonly static string XMLHTTP_REQUEST_H = "X-Requested-With";
        public readonly static string XMLHTTP_REQUEST = "XMLHttpRequest";

        public readonly static string IF_MODIFIED_SINCE_H = "If-Modified-Since";
        public readonly static string IF_MODIFIED_SINCE = "0";

        public readonly static string EXPIRES_H = "expires";
        public readonly static string EXPIRES = "0";
        
        public readonly static string REFERER_H = "Referer";
        public readonly static string REFERER = "http://shop.10086.cn/i/?f=rechargecredit";

        public readonly static string ACCEPT_ENCODEING_H = "Accept-Encoding";
        public readonly static string ACCEPT_ENCODEING = "gzip,deflate,sdch";

        public readonly static string ACCEPT_LANGUAGE_H = "Accept-Language";
        public readonly static string ACCEPT_LANGUAGE = "zh-CN,zh;q=0.8";
        
        public readonly static string UTF_8 = "UTF-8";
        #endregion

        public HttpClientHandler handler = null;
        private HttpClient _httpClient;
        private bool isLogin = false;
        private string cookiestr;
        private string loginUser;
        private string loginPwd;
        private string token;
        private PostBackModel loginBack;

        CookieContainer cookies;

        public PhoneUtil() {
            if (handler == null)
            {
                handler = new HttpClientHandler();
                handler.UseCookies = true;
            }
        }
        public PhoneUtil(HttpClientHandler _handler)
        {
            this.handler = _handler;
            if (handler == null)
            {
                handler = new HttpClientHandler();
                handler.UseCookies = true;
            }
        }

        public PhoneUtil(string loginUser, string loginPwd)
        {
            this.loginUser = loginUser;
            this.loginPwd = loginPwd;

            if (handler == null)
            {
                handler = new HttpClientHandler();
                handler.UseCookies = true;
            }
        }

        /// <summary>
        /// 根据手机号码获取号码属地
        /// </summary>
        /// <param name="_PhoneNum"></param>
        /// <returns></returns>
        public async Task<PhoneSearchGetBak> GetProvByPhoneNum(string _PhoneNum) {
            if (string.IsNullOrWhiteSpace(_PhoneNum))
                return null;
            string _url = "http://shop.10086.cn/i/v1/res/numarea/" + _PhoneNum;
            HttpResponseMessage response = null;
            try
            {
                //return await Senparc.Weixin.CommonAPIs.CommonJsonSend
                //    .SendAsync<PhoneSearchGetBak>(null, _url, null,Senparc.Weixin.CommonJsonSendType.GET);


                _httpClient = new HttpClient();
                SetHeader();

                response = _httpClient.GetAsync(_url).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {   //已经连接，正在接收数据

                    string result = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<PhoneSearchGetBak>(result);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (response != null)
                    response.Dispose();
            }
        }

        /// <summary>
        /// 获取图片验证码
        /// </summary>
        /// <returns></returns>
        public async Task<byte[]> GetCheckedCode()
        {
            string _url = "http://shop.10086.cn/i/authImg?t=" + DateTime.Now.Second;
            HttpResponseMessage response = null;
            try
            {
                //HttpWebRequest mRequest = (HttpWebRequest)WebRequest.Create(_url);
                //mRequest.Method = "GET";
                //mRequest.Timeout = 200;

                //mRequest.CookieContainer = new CookieContainer(); //暂存到新实例

                //HttpWebResponse mResponse = (HttpWebResponse)mRequest.GetResponse();

                //cookies = mRequest.CookieContainer; //保存cookies
                
                //Stream mStream = mResponse.GetResponseStream();
                //Image mImage = Image.FromStream(mStream);
                //mStream.Close();

                //string imgSave = AppDomain.CurrentDomain.BaseDirectory + "imgCheckedCode\\"
                //                + Guid.NewGuid().ToString("N") + ".jpg";
                //mImage.Save(imgSave, System.Drawing.Imaging.ImageFormat.Jpeg);

                //using (System.IO.MemoryStream Ms = new MemoryStream())
                //{
                //    mImage.Save(Ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                //    byte[] img = new byte[Ms.Length];
                //    Ms.Position = 0;
                //    Ms.Read(img, 0, Convert.ToInt32(Ms.Length));
                //    Ms.Close();

                //    return img;
                //}

                


               //byte[] result = await Senparc.Weixin.CommonAPIs.CommonJsonSend
               //     .SendAsync<byte[]>(null, _url, null, Senparc.Weixin.CommonJsonSendType.GET);

                //string returnText = await Senparc.Weixin.HttpUtility.RequestUtility
                //    .HttpGetAsync(_url, null);
                //byte[] result = Encoding.UTF8.GetBytes(returnText); 
                _httpClient = new HttpClient(handler);
                SetHeader();

                response = _httpClient.GetAsync(_url).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {   //已经连接，正在接收数据

                    byte[] result = response.Content.ReadAsByteArrayAsync().Result;

                    //using (MemoryStream ms = new MemoryStream(result))
                    //{
                    //    var img = new Bitmap((Image)new Bitmap(ms));
                    //    var cracker = new Cracker();
                    //    var rs = cracker.Read(img);
                    //}
                    //UnCodeYiDong unCodeYiDong = new UnCodeYiDong(result, 90, 40);
                    //string sc = unCodeYiDong.GetPicnum();

                    using (MemoryStream ms = new MemoryStream(result))
                    {
                        using (Image image = System.Drawing.Image.FromStream(ms))
                        {
                            string imgSave = AppDomain.CurrentDomain.BaseDirectory + "imgCheckedCode\\"
                                + Guid.NewGuid().ToString("N") + ".jpg";
                            image.Save(imgSave, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                    }

                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (response != null)
                    response.Dispose();
            }
        }

        /// <summary>
        /// 验证
        /// </summary>
        public PhoneSearchGetBak PreCheck(string phoneNum, string captchaval, 
            string jsessionid)
        {
            if (string.IsNullOrWhiteSpace(phoneNum))
                return null;
            string _url = "http://shop.10086.cn/i/v1/res/precheck/" + phoneNum +
                "?captchaVal=" + captchaval;
            HttpResponseMessage response = null;
            try
            {
                //HttpWebRequest mRequest = (HttpWebRequest)WebRequest.Create(_url);
                //mRequest.Method = "GET";
                //mRequest.Timeout = 200;
                //mRequest.Host = "shop.10086.cn";
                ////mRequest.Connection = "keep-alive";
                //mRequest.KeepAlive = true;
                //mRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.122 Safari/537.36 SE 2.X MetaSr 1.0";
                //mRequest.ContentType = "*";
                //mRequest.Accept = "application/json, text/javascript, */*; q=0.01";
                //mRequest.IfModifiedSince = DateTime.Now;
                //mRequest.Referer = "http://shop.10086.cn/i/?f=rechargecredit";

                //var cookies = new CookieContainer();
                //cookies.SetCookies(new Uri("http://shop.10086.cn"), 
                //    "jsessionid-echd-cpt-cmcc-jt=" + jsessionid + ";");
                //mRequest.CookieContainer = cookies;
                //mRequest.CookieContainer = cookies; 

                //HttpWebResponse mResponse = (HttpWebResponse)mRequest.GetResponse();

                //using (Stream responseStream = mResponse.GetResponseStream())
                //{
                //    using (StreamReader myStreamReader = new StreamReader(responseStream, 
                //        Encoding.GetEncoding("utf-8")))
                //    {
                //        string retString = myStreamReader.ReadToEnd();
                //    }
                //}

                this.cookiestr = "jsessionid-echd-cpt-cmcc-jt=" + jsessionid + ";";

                _httpClient = new HttpClient(handler);
                _httpClient.DefaultRequestHeaders.Add(HOST_H, "shop.10086.cn");
                _httpClient.DefaultRequestHeaders.Add(CONNECTION_H, "keep-alive");
                _httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-store, must-revalidate");
                _httpClient.DefaultRequestHeaders.Add("pragma", "no-cache");
                _httpClient.DefaultRequestHeaders.Add(USER_AGENT_H, "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.122 Safari/537.36 SE 2.X MetaSr 1.0");
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(CONTENT_TYPE_H, "*");
                _httpClient.DefaultRequestHeaders.Add(ACCEPT_H, "application/json, text/javascript, */*; q=0.01");
                _httpClient.DefaultRequestHeaders.Add(XMLHTTP_REQUEST_H, XMLHTTP_REQUEST);
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(IF_MODIFIED_SINCE_H, IF_MODIFIED_SINCE);
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(EXPIRES_H, EXPIRES);
                _httpClient.DefaultRequestHeaders.Add(REFERER_H, "http://shop.10086.cn/i/?f=rechargecredit");
                _httpClient.DefaultRequestHeaders.Add(ACCEPT_ENCODEING_H, "gzip,deflate,sdch");
                _httpClient.DefaultRequestHeaders.Add(ACCEPT_LANGUAGE_H, "zh-CN,zh;q=0.8");

                if (this.cookiestr != null && this.cookiestr.Length > 0)
                {
                    _httpClient.DefaultRequestHeaders.Add(COOKIE_H, this.cookiestr);
                }

                response = _httpClient.GetAsync(_url).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {   //已经连接，正在接收数据

                    string result = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<PhoneSearchGetBak>(result);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (response != null)
                    response.Dispose();
            }
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

        public PhoneSearchGetBak PostPayCard(PostPayCardModel ppcm, string captchaVal)
        {
            if (string.IsNullOrWhiteSpace(captchaVal) || ppcm == null)
                return null;
            string _url = "http://shop.10086.cn/i/v1/pay/card/" + ppcm.chargedNum +
                "?captchaVal=" + captchaVal;
            HttpResponseMessage response = null;
            try
            {
                //this.cookiestr = "jsessionid-echd-cpt-cmcc-jt=" + jsessionid + ";";

                _httpClient = new HttpClient(handler);
                _httpClient.DefaultRequestHeaders.Add(HOST_H, "shop.10086.cn");
                _httpClient.DefaultRequestHeaders.Add(CONNECTION_H, "keep-alive");
                _httpClient.DefaultRequestHeaders.Add(ACCEPT_H, "application/json, text/javascript, */*; q=0.01");
                _httpClient.DefaultRequestHeaders.Add("Origin", "http://shop.10086.cn");
                _httpClient.DefaultRequestHeaders.Add(XMLHTTP_REQUEST_H, XMLHTTP_REQUEST);
                _httpClient.DefaultRequestHeaders.Add(USER_AGENT_H, "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.122 Safari/537.36 SE 2.X MetaSr 1.0");
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(CONTENT_TYPE_H, "application/json");
                _httpClient.DefaultRequestHeaders.Add(REFERER_H, "http://shop.10086.cn/i/?f=rechargecard");
                _httpClient.DefaultRequestHeaders.Add(ACCEPT_ENCODEING_H, "gzip,deflate");
                _httpClient.DefaultRequestHeaders.Add(ACCEPT_LANGUAGE_H, "zh-CN,zh;q=0.8");

                var longliveLolita = PostPayCardnMisKey();

                ////使用FormUrlEncodedContent做HttpContent
                //var content = new FormUrlEncodedContent(new Dictionary<string, string>()       
                //{    {"cardPwd",PostPayCardnEcrypt(ppcm.cardPwd,longliveLolita)},
                //     {"chargedNum", ppcm.chargedNum},
                //     {"longliveLolita", longliveLolita}
                // });

                List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<String, String>>();
                paramList.Add(new KeyValuePair<string, string>("cardPwd", 
                    PostPayCardnEcrypt(ppcm.cardPwd, longliveLolita)));
                paramList.Add(new KeyValuePair<string, string>("chargedNum", ppcm.chargedNum));
                paramList.Add(new KeyValuePair<string, string>("longliveLolita", longliveLolita));
                var content = new FormUrlEncodedContent(paramList);

                response = _httpClient.PostAsync(_url, content).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {   //已经连接，正在接收数据

                    string result = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<PhoneSearchGetBak>(result);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (response != null)
                    response.Dispose();
            }
        }

        /// <summary>
        /// 登陆移动网上营业厅
        /// </summary>
        /// <returns></returns>
        public int Login(string validcode)
        {
            if (isLogin)
            {
                return (int)HttpStatusCode.OK;
            }

            HttpResponseMessage response = null;
            //正在登陆微信公众平台...
            try
            {
                _httpClient = new HttpClient(handler);
                SetPostHeader(); //设置httpClient头

                //java DigestUtils.md5Hex(this.loginPwd.getBytes())
                //c#  Md5Helper.Md5Hex(this.loginPwd); 

                List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<String, String>>();
                paramList.Add(new KeyValuePair<string, string>("telno", Md5Helper.Md5Hex(this.loginUser)));
                paramList.Add(new KeyValuePair<string, string>("password", Md5Helper.Md5Hex(this.loginPwd)));
                paramList.Add(new KeyValuePair<string, string>("authLevel", "2"));
                paramList.Add(new KeyValuePair<string, string>("validcode", validcode));
                paramList.Add(new KeyValuePair<string, string>("ctype", "1"));
                paramList.Add(new KeyValuePair<string, string>("decode", "1"));
                paramList.Add(new KeyValuePair<string, string>("source", "wsyyt"));

                var uri = new Uri("https://sh.ac.10086.cn/loginex?act=2");
                response = _httpClient.PostAsync(uri,
                    new FormUrlEncodedContent(paramList)).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //登陆成功
                    string result = response.Content.ReadAsStringAsync().Result;

                    loginBack = JsonConvert.DeserializeObject<PostBackModel>(result);

                    if (loginBack.base_resp.ret == 0)
                    {  //微信验证成功
                        StringBuilder cookie = new StringBuilder();

                        CookieCollection getCookies = handler.CookieContainer.GetCookies(uri);
                        foreach (Cookie c in getCookies)
                        {
                            cookie.Append(c.Name).Append("=")
                                .Append(c.Value).Append(";");
                        }
                        this.cookiestr = cookie.ToString();
                        //正在获取token
                        #region 正在获取token
                        if (!string.IsNullOrWhiteSpace(loginBack.redirect_url))
                        {
                            string[] ss = loginBack.redirect_url.Split('?');
                            string[] ps = null;
                            if (ss.Length == 2)
                            {
                                if (!string.IsNullOrWhiteSpace(ss[1])
                                        && ss[1].IndexOf("&") != -1)
                                    ps = ss[1].Split('&');
                            }
                            else if (ss.Length == 1)
                            {
                                if (!string.IsNullOrWhiteSpace(ss[0])
                                        && ss[0].IndexOf("&") != -1)
                                    ps = ss[0].Split('&');
                            }
                            if (ps != null)
                            {
                                foreach (var p in ps)
                                {
                                    if (string.IsNullOrWhiteSpace(p))
                                        continue;
                                    string[] tk = p.Split('=');
                                    if (!string.IsNullOrWhiteSpace(tk[0])
                                        && "token".Equals(tk[0].Trim().ToLower()))
                                    {
                                        if (!string.IsNullOrEmpty(tk[1]))
                                            token = tk[1].Trim();
                                        break;
                                    }
                                }
                            }
                            //获取token成功.. 
                        }
                        #endregion

                        //进入首页
                        return Index();
                    }
                    else
                    {  //验证错误
                        string err_msg = loginBack.base_resp.err_msg;
                    }
                }

            }
            catch (Exception e)
            {
                return -1;
            }
            finally
            {
                if (response != null)
                    response.Dispose();
            }
            return 0;
        }

        /// <summary>
        /// 进入首页
        /// </summary>
        /// <returns></returns>
        private int Index()
        {
            if (loginBack == null)
                return -1;

            HttpResponseMessage response = null;
            try
            {
                _httpClient = new HttpClient(handler);
                SetHeader();

                response = _httpClient.GetAsync(WeChatUrl.HOST_URL + loginBack.redirect_url).Result;
                //if (response.StatusCode == HttpStatusCode.OK)
                //{   //已经连接，正在接收数据

                //    string result = response.Content.ReadAsStringAsync().Result;
                //}
                return (int)response.StatusCode;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                if (response != null)
                    response.Dispose();
            }
        }
        

        /// <summary>
        /// 设置http get头
        /// </summary>
        private void SetHeader()
        {
            _httpClient.DefaultRequestHeaders.Add(HOST_H, HOST);
            _httpClient.DefaultRequestHeaders.Add(CONNECTION_H, CONNECTION);
            _httpClient.DefaultRequestHeaders.Add(CACHE_CONTROL_H, CACHE_CONTROL);
            _httpClient.DefaultRequestHeaders.Add(PRAGMA_H, PRAGMA);
            _httpClient.DefaultRequestHeaders.Add(USER_AGENT_H, USER_AGENT);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(CONTENT_TYPE_H, CONTENT_TYPE);
            _httpClient.DefaultRequestHeaders.Add(ACCEPT_H, ACCEPT);
            _httpClient.DefaultRequestHeaders.Add(XMLHTTP_REQUEST_H, XMLHTTP_REQUEST);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(IF_MODIFIED_SINCE_H, IF_MODIFIED_SINCE);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(EXPIRES_H, EXPIRES);
            _httpClient.DefaultRequestHeaders.Add(REFERER_H, REFERER);
            _httpClient.DefaultRequestHeaders.Add(ACCEPT_ENCODEING_H, ACCEPT_ENCODEING);
            _httpClient.DefaultRequestHeaders.Add(ACCEPT_LANGUAGE_H, ACCEPT_LANGUAGE);

            if (this.cookiestr != null && this.cookiestr.Length > 0)
            {
                _httpClient.DefaultRequestHeaders.Add(COOKIE_H, this.cookiestr);
            }
        }

        /// <summary>
        /// 设置http post头
        /// </summary>
        private void SetPostHeader()
        {
            _httpClient.DefaultRequestHeaders.Add(HOST_H, "sh.ac.10086.cn");
            _httpClient.DefaultRequestHeaders.Add(CONNECTION_H, "keep-alive");
            _httpClient.DefaultRequestHeaders.Add(USER_AGENT_H, "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.122 Safari/537.36 SE 2.X MetaSr 1.0");
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(CONTENT_TYPE_H, 
                "application/x-www-form-urlencoded; charset=UTF-8");
            _httpClient.DefaultRequestHeaders.Add(ACCEPT_H, "application/json, text/javascript, */*; q=0.01");
            _httpClient.DefaultRequestHeaders.Add(XMLHTTP_REQUEST_H, XMLHTTP_REQUEST);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(IF_MODIFIED_SINCE_H, IF_MODIFIED_SINCE);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(EXPIRES_H, EXPIRES);
            _httpClient.DefaultRequestHeaders.Add("Origin", "https://sh.ac.10086.cn");
            _httpClient.DefaultRequestHeaders.Add(REFERER_H, "https://sh.ac.10086.cn/login");
            _httpClient.DefaultRequestHeaders.Add(ACCEPT_ENCODEING_H, "gzip,deflate");
            _httpClient.DefaultRequestHeaders.Add(ACCEPT_LANGUAGE_H, "zh-CN,zh;q=0.8");

            if (this.cookiestr != null && this.cookiestr.Length > 0)
            {
                _httpClient.DefaultRequestHeaders.Add(COOKIE_H, this.cookiestr);
            }
        }

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {

            if (handler != null)
                handler.Dispose();
            if (_httpClient != null)
                _httpClient.Dispose();

        }
        

    }

    public class PostPayCardModel {
        public string cardPwd { get; set; }
        public string chargedNum { get; set; }
        public string longliveLolita { get; set; }
    }

    public class PhoneSearchGetBak {
        public string retCode { get; set; }
        public string retMsg { get; set; }
        public PhoneSearchGetBakData data { get; set; }

        public class PhoneSearchGetBakData {
            public string remark { get; set; }
            public ProvEnum prov_cd { get; set; }
            public string id_area_cd { get; set; }
            public string id_name_cd { get; set; }
            public string msisdn_area_id { get; set; }
            public string imsi_type { get; set; }
            public string effc_tm { get; set; }
            public string expired_tm { get; set; }
            public string num_type { get; set; }
        }
    }

    public class PostPayCardBak {
        public string retCode { get; set; }
        public string retMsg { get; set; }
        public object data { get; set; }
    }
}
