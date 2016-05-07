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
    /// 文件名：Enums
    /// 创建时间：2015/1/1 11:49:15
    /// 修改人：石忠孝
    /// 修改时间：2015/1/1 11:49:15
    /// 说明：


    /// </summary>
    /// <summary>
    /// 请求类型
    /// </summary>
    public enum Action
    {
        post,
        get,
        socket
    }
    /// <summary>
    /// response数据格式
    /// </summary>
    public enum Format
    {
        json,
        xml
    }

    /// <summary>
    /// 传输数据格式，默认为url方式
    /// </summary>
    public enum TransType
    {
        text,
        json
    }

    /// <summary>
    /// 消息加解密方式
    /// </summary>
    public enum EncodingAESType
    {
        明文模式 = 0,
        兼容模式 = 1,
        安全模式 = 2
    }

    /// <summary>
    /// 微信号类型
    /// </summary>
    public enum WechatType
    {
        订阅号 = 0,
        服务号 = 1,
        企业号 = 2
    }

    /// <summary>
    /// 微信号认证情况
    /// </summary>
    public enum Authenticate
    {
        未认证 = 0,
        已认证 = 1
    }

    /// <summary>
    /// 移动各地区电话省份代码
    /// </summary>
    public enum ProvEnum
    {
        全国 = 99,
        北京 = 100,
        广东 = 200,
        上海 = 210,
        天津 = 220,
        重庆 = 230,
        河北 = 311,
        山西 = 351,
        河南 = 371,
        辽宁 = 240,
        吉林 = 431,
        黑龙江 = 451,
        内蒙古 = 471,
        江苏 = 250,
        山东 = 531,
        安徽 = 551,
        浙江 = 571,
        福建 = 591,
        湖北 = 270,
        湖南 = 731,
        广西 = 771,
        江西 = 791,
        四川 = 280,
        贵州 = 851,
        云南 = 871,
        西藏 = 891,
        陕西 = 290,
        甘肃 = 931,
        宁夏 = 951,
        海南 = 898,
        青海 = 971,
        新疆 = 991
    };
}
