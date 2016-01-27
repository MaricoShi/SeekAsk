using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Szx.WeiXin.Api;
using Szx.WeiXin.Api.Domain;
using Szx.WeiXin.Api.Models;

using Seekask.Data.Models;
using System.Net;
using Seekask.UI.Areas.Wx.Models;
using Seekask.UI.Help;

namespace Seekask.UI.Areas.Wx.Controllers
{
    public class WxHomeController : Controller
    {
        // GET: Wx/WxHome

        /// <summary>
        /// 微信公众号智能绑定
        /// </summary>
        /// <returns></returns>
        public ActionResult AutoAdd() {

            return View();
        }

        [HttpPost]
        public ActionResult BindWeiXinByAccount(string wxUserID, string wxUserPwd)
        {
            StatusBackModel errBack = new StatusBackModel();
            try
            {
                using (SmartBindUtil smartBind = new SmartBindUtil(wxUserID, wxUserPwd))
                {
                    //登录成功后，在开发者中心获取开发者信息
                    WechatDevInfo devInfo = smartBind.GetWechatDev();

                    WechatAccountInfo accountInfo = smartBind.GetAccount();
                    //无法获取用户信息，结束操作并跳出
                    if (accountInfo == null) {
                        errBack.ErrMsg = "无法获取用户信息，结束操作并跳出";
                        return Json(errBack); 
                    }

                    if (devInfo != null && !string.IsNullOrWhiteSpace(devInfo.AppSecret))
                    {
                        devInfo.AppSecret = devInfo.AppSecret.Replace("重置", "").Trim();
                        if (devInfo.AppSecret.Contains("显示密钥"))
                            devInfo.AppSecret = null;
                    }

                    Weixin_Sys_Info info = null;

                    using (SeekAskContext context = new SeekAskContext())
                    {
                        #region 更新微信号管理
                        info = context.Weixin_Sys_Info.FirstOrDefault(p => p.Wx_AccountId == accountInfo.AccountId
                            && p.Wx_WechatNumber == accountInfo.WechatNumber
                            && p.Wx_AppId == devInfo.AppId);

                        if (info == null)
                        {
                            info = new Weixin_Sys_Info();
                            info.Create_Id = "Sys";
                            info.Create_Name = "系统管理员";
                            info.Create_IP = WebSiteTools.GetRequestIP();
                            info.Create_Time = DateTime.Now;
                            info = context.Weixin_Sys_Info.Add(info);
                        }
                        info.Wx_Status = 0;

                        info.Wx_AccountId = accountInfo.AccountId;
                        info.Wx_AccountName = accountInfo.AccountName;
                        info.Wx_WechatNumber = accountInfo.WechatNumber;
                        info.Wx_WechatType = (int)accountInfo.WechatType;
                        info.Wx_Introduces = accountInfo.Introduces;
                        info.Wx_Authenticate = (int)accountInfo.Authenticate;
                        info.Wx_PlaceAddress = accountInfo.PlaceAddress;
                        info.Wx_SubjectInfo = accountInfo.SubjectInfo;
                        info.Wx_LoginEmail = accountInfo.LoginEmail;
                        info.Wx_AppId = devInfo.AppId;
                        info.Wx_AppSecret = devInfo.AppSecret;
                        info.Wx_URL = devInfo.URL;
                        info.Wx_EncodingAESKey = devInfo.EncodingAESKey;
                        info.Wx_EncodingAESType = (int)devInfo.EncodingAESType;

                        info.Modify_Id = "Sys";
                        info.Modify_Name = "系统管理员";
                        info.Modify_IP = WebSiteTools.GetRequestIP();
                        info.Modify_Time = DateTime.Now;
                        info.Is_Deleted = false;

                        context.SaveChanges();
                        #endregion

                        #region 下载头像及设置开发模式
                        //下载头像
                        if (!string.IsNullOrWhiteSpace(accountInfo.HeadImage))
                        {
                            string fileName = "weixinImg/headImg_" + info.WxId + ".jpg";
                            int downStatus = smartBind.DownloadImg(accountInfo.HeadImage, Server.MapPath("~/") + fileName, true);
                            if (downStatus == (int)HttpStatusCode.OK)
                            {
                                info.Wx_HeadImage = "/" + fileName;
                            }
                        }
                        //下载二维码
                        if (!string.IsNullOrWhiteSpace(accountInfo.HeadImage))
                        {
                            string fileName = "weixinImg/qrCode_" + info.WxId + ".jpg";
                            int downStatus = smartBind.DownloadImg(accountInfo.QRCode, Server.MapPath("~/") + fileName, true);
                            if (downStatus == (int)HttpStatusCode.OK)
                            {
                                info.Wx_QRCode = "/" + fileName;
                            }
                        }

                        //info.Wx_URL = "http://sjianshang.xicp.net/seekask.ui/weixin?appid=" + info.WxId;
                        info.Wx_URL = "http://www.seekask.cn/weixin?appid=" + info.WxId;
                        info.Wx_Token = WeChatTools.GetRandomStr(20);
                        info.Wx_EncodingAESKey = WeChatTools.GetRandomStr(43);
                        info.Wx_EncodingAESType = 2;

                        context.SaveChanges();

                        //设置启用开发模式
                        int status = smartBind.EnabledDev(1, 2);
                        //启用开发模式失败，结束操作并跳出
                        if (status != 0) return Content("启用开发模式失败，结束操作并跳出");
                        // 验证服务器接口回调，此处修改服务器配置中的URL和Token
                        status = smartBind.SetDevServiceUrl(
                            info.Wx_URL,
                            info.Wx_Token,
                            info.Wx_EncodingAESKey,
                            info.Wx_EncodingAESType.ToString());

                        #endregion

                        errBack.BackData = info.WxId;
                        if (status == 0)
                        {
                            errBack.ErrCode = 1;
                            errBack.ErrMsg = "接入成功！";
                        }else
                            errBack.ErrMsg = "用户信息获取成功，接入失败！";
                    }

                };
            }
            catch (Exception)
            {
                errBack.ErrMsg = "执行异常";
            }
            
            return Json(errBack);
        }

    }
}