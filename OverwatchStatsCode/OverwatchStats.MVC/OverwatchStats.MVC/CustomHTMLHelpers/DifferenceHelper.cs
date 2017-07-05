using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OverwatchStats.MVC.CustomHTMLHelpers
{
    public static class DifferenceHelper
    {
        public static MvcHtmlString Modifier(this HtmlHelper helper, bool greaterThanZero)
        {
            if (greaterThanZero)
                return new MvcHtmlString("+");
            else
                return new MvcHtmlString(string.Empty);
        }
    }
}