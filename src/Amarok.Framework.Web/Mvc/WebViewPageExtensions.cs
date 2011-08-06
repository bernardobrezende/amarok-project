using System.Web;
using System.Web.Mvc;

namespace Amarok.Framework.Web.Mvc
{
    public static class WebViewPageExtensions
    {
        public static T GetLocalResource<T>(this WebViewPage page, string resourceKey)
        {
            var context = GetPageHttpContext(page);
            return (T)context.GetLocalResourceObject(page.VirtualPath, resourceKey);
        }

        public static T GetGlobalResource<T>(this WebViewPage page, string resourceName, string resourceKey)
        {
            var context = GetPageHttpContext(page);
            return (T)context.GetGlobalResourceObject(resourceName, resourceKey);
        }       

        public static MvcHtmlString GetLocalResource(this WebViewPage page, string resourceKey)
        {
            string htmlString = GetLocalResource<string>(page, resourceKey);
            return new MvcHtmlString(htmlString);
        }

        public static MvcHtmlString GetGlobalResource(this WebViewPage page, string resourceName, string resourceKey)
        {
            string htmlString = GetGlobalResource<string>(page, resourceName, resourceKey);
            return new MvcHtmlString(htmlString);
        }

        private static HttpContextBase GetPageHttpContext(WebViewPage page)
        {
            return page.ViewContext.HttpContext;
        }
    }
}
