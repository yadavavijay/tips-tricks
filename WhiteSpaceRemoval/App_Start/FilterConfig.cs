using System.Web.Mvc;

namespace WhiteSpaceRemoval
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new GlobalActionFilterAttribute());
        }
    }
}