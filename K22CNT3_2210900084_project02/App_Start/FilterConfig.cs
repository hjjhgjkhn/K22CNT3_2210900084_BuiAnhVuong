using System.Web;
using System.Web.Mvc;

namespace K22CNT3_2210900084_project02
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
