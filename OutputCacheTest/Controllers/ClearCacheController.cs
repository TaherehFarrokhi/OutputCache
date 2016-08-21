using System.Net.Http;
using System.Web.Mvc;

namespace OutputCacheTest.Controllers
{
    public class ClearCacheController : Controller
    {
        // GET: ClearCache
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ClearCache()
        {
            ClearCacheData();

            return RedirectToAction("Index", "Home");
        }

        private void ClearCacheData()
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.GetStringAsync("http://localhost:52163/?f=").Result;
            }
        }
    }
}