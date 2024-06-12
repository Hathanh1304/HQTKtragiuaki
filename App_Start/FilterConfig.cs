using System.Web;
using System.Web.Mvc;

namespace tvt_baikemtragiuaki
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
