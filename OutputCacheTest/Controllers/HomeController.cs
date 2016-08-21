using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace OutputCacheTest.Controllers
{
    [OutputCache(Duration = int.MaxValue, Location = OutputCacheLocation.Server, VaryByParam = "None")]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Response.Cache.AddValidationCallback(ValidateCache, null);
            return View(DateTime.Now);
        }

        private void ValidateCache(HttpContext context, object data, ref HttpValidationStatus validationstatus)
        {
            if(context.Request.QueryString.AllKeys.Contains("f"))
                validationstatus = HttpValidationStatus.Invalid;
        }
    }
}