using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HtmlHelpers.Utils
{
    public static class TableHelper
    {
        public static HtmlString CreateTable(this IHtmlHelper helper, IEnumerable<object> list)
        {
            if (list.Count() == 0)
            {
                return new HtmlString("<table></table>");
            }

            StringBuilder str = new StringBuilder();
            str.Append("<table>");
            str.Append("<tr>");
            PropertyInfo[] props = list.First().GetType().GetProperties();
            foreach(PropertyInfo pi in props)
            {
                str.Append("<th>");
                str.Append(pi.Name.ToUpperInvariant());
                str.Append("</th>");
            }
            str.Append("</tr>");
            foreach(object item in list) // ID Title Year
            {
                str.Append("<tr>");
                foreach (PropertyInfo pi in props)
                {
                    str.Append("<td>");
                    str.Append(pi.GetValue(item));
                    str.Append("</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");

            return new HtmlString(str.ToString());
        }
    }
}
