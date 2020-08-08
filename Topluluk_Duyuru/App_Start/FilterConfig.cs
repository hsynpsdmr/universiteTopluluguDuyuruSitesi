using System.Web;
using System.Web.Mvc;

namespace Topluluk_Duyuru
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
