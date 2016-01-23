using Seekask.Data.Models;
using Seekask.UI.Help;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MvcExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Szx.WeiXin.Api.MessageHandlers.CustomMessageHandler;

namespace Seekask.UI.Controllers
{
    public class WeixinController : Controller
    {
        /// <summary>
        /// 微信后台验证地址（使用Get），微信后台的“接口配置信息”的Url
        /// </summary>
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get(PostModel postModel, string echostr,string appId)
        {
            int wxId = 0;
            if (string.IsNullOrWhiteSpace(appId) && !int.TryParse(appId, out wxId)) return Content("未知平台接入！");
            wxId = Convert.ToInt32(appId);
            Weixin_Sys_Info wxInfo = null;
            using (SeekAskContext context = new SeekAskContext())
            {
                wxInfo = context.Weixin_Sys_Info.FirstOrDefault(p => p.WxId == wxId);

                if (wxInfo == null) return Content("平台未新增管理代号(" + appId + ")！");

                bool isCheckSignature = CheckSignature.Check(postModel.Signature, postModel.Timestamp, 
                    postModel.Nonce, wxInfo.Wx_Token);

                #region 记录接入日志
                try
                {
                    Szx_Sys_Log log = new Szx_Sys_Log()
                    {
                        LogID = Guid.NewGuid().ToString("N"),
                        LogName = "微信接入验证",
                        Source = "01",
                        LevelCode = 0,
                        RequestUrl = HttpContext.Request.Url.ToString(),
                        LogDate = DateTime.Now,
                        Message = "验证结果:" + isCheckSignature,
                        Create_Id = "wxjk",
                        Create_Name = "微信接口",
                        Create_Time = DateTime.Now,
                        Create_IP = WebSiteTools.GetRequestIP()
                    };
                    context.Szx_Sys_Log.Add(log);
                    context.SaveChanges();
                }
                catch (Exception) { }
                #endregion

                if (isCheckSignature)
                {
                    try
                    {
                        wxInfo.Wx_Status = 1;   //状态改为已对接
                        context.SaveChanges();
                    }
                    catch (Exception) { }

                    return Content(echostr); //返回随机字符串则表示验证通过
                }
                else
                {
                    return Content("failed:" + postModel.Signature + "," +
                        CheckSignature.GetSignature(postModel.Timestamp, postModel.Nonce, wxInfo.Wx_Token) + "。" +
                        "如果你在浏览器中看到这句话，说明此地址可以被作为微信公众账号后台的Url，请注意保持Token一致。");
                }
            }
        }

        /// <summary>
        /// 用户发送消息后，微信平台自动Post一个请求到这里，并等待响应XML。
        /// PS：此方法为简化方法，效果与OldPost一致。
        /// v0.8之后的版本可以结合Senparc.Weixin.MP.MvcExtension扩展包，使用WeixinResult，见MiniPost方法。
        /// </summary>
        [HttpPost]
        [ActionName("Index")]
        public ActionResult Post(PostModel postModel,string appId)
        {

            int wxId = 0;
            if (string.IsNullOrWhiteSpace(appId) && !int.TryParse(appId, out wxId)) return Content("未知平台接入！");
            wxId = Convert.ToInt32(appId);
            Weixin_Sys_Info wxInfo = null;
            using (SeekAskContext context = new SeekAskContext())
            {
                wxInfo = context.Weixin_Sys_Info.FirstOrDefault(p => p.WxId == wxId);

                if (wxInfo == null) return Content("平台未新增管理代号(" + appId + ")！");

                if (!CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, wxInfo.Wx_Token))
                {
                    return Content("参数错误！");
                }

                postModel.Token = wxInfo.Wx_Token;//根据自己后台的设置保持一致
                postModel.EncodingAESKey = wxInfo.Wx_EncodingAESKey;//根据自己后台的设置保持一致
                postModel.AppId = wxInfo.Wx_AppId;//根据自己后台的设置保持一致

                var maxRecordCount = 10;

                //自定义MessageHandler，对微信请求的详细判断操作都在这里面。
                var messageHandler = new CustomMessageHandler(Request.InputStream, postModel, maxRecordCount);
                try
                {
                    /* 如果需要添加消息去重功能，只需打开OmitRepeatedMessage功能，SDK会自动处理。
                     * 收到重复消息通常是因为微信服务器没有及时收到响应，会持续发送2-5条不等的相同内容的RequestMessage*/
                    messageHandler.OmitRepeatedMessage = true;

                    //执行微信处理过程
                    messageHandler.Execute();

                    #region 记录微信操作日志
                    try
                    {
                        Weixin_Msg_Request msgRequest = new Weixin_Msg_Request();
                        msgRequest.WxId = wxInfo.WxId;
                        msgRequest.MsgId = messageHandler.RequestMessage.MsgId.ToString();
                        msgRequest.MsgType = messageHandler.RequestMessage.MsgType.ToString();
                        msgRequest.FromUserName = messageHandler.RequestMessage.FromUserName;
                        msgRequest.ToUserName = messageHandler.RequestMessage.ToUserName;
                        msgRequest.Encrypt = null;
                        msgRequest.CreateTime = messageHandler.RequestMessage.CreateTime;
                        msgRequest.XmlDocument = messageHandler.RequestDocument.ToString();
                        context.Weixin_Msg_Request.Add(msgRequest);
                        context.SaveChanges();
                    }
                    catch (Exception) { }
                    #endregion

                    //return Content(messageHandler.ResponseDocument.ToString());//v0.7-
                    //return new FixWeixinBugWeixinResult(messageHandler);//为了解决官方微信5.0软件换行bug暂时添加的方法，平时用下面一个方法即可
                    return new WeixinResult(messageHandler);//v0.8+
                }
                catch (Exception)
                {

                }
            }

            return Content("参数错误！");
        }
    }
}