using System.Web.Mvc;

namespace Seekask.UI.Areas.Wx
{
    public class WxAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Wx";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Wx_default",
                "Wx/{controller}/{action}/{id}",
                new { controller = "WxHome", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}