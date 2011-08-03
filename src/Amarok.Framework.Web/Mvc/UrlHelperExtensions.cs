using System;
using System.Text;
using System.Web.Mvc;

namespace Amarok.Framework.Web.Mvc
{
    public static class UrlHelperExtensions
    {
        public static string ToFriendlyUrl(this UrlHelper helper, string urlToEncode)
        {
            urlToEncode = (urlToEncode ?? String.Empty).Trim().ToLower();

            StringBuilder url = new StringBuilder();

            foreach (char ch in urlToEncode)
            {
                string textToAppend = string.Empty;
                switch (ch)
                {
                    case ' ':
                        textToAppend = "-";
                        break;
                    case '&':
                        textToAppend = "and";
                        break;
                    case '\'':                    
                        continue;
                    default:
                        textToAppend = (ch >= '0' && ch <= '9') || (ch >= 'a' && ch <= 'z') ?
                            ch.ToString() : "-";
                        break;
                }
                url.Append(textToAppend);
            }
            return url.ToString();
        }
    }
}