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

        private static HttpContextBase GetPageHttpContext(WebViewPage page)
        {
            return page.ViewContext.HttpContext;
        }
    }
}
