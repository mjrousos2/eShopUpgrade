using eShopLegacy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace eShopLegacyMVC.Controllers
{
    public class AspNetSessionController : Controller
    {
        // GET: AspNetCoreSession
        public ActionResult Index()
        {
            byte[] sessionData;
            if (HttpContext.Session.TryGetValue("DemoItem", out sessionData))
            {
                var model = JsonSerializer.Deserialize<SessionDemoModel>(sessionData);
                return View(model);
            }
            return View();
        }

        // POST: AspNetCoreSession
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SessionDemoModel demoModel)
        {
            var sessionData = JsonSerializer.SerializeToUtf8Bytes(demoModel);
            HttpContext.Session.Set("DemoItem", sessionData);
            return View(demoModel);
        }
    }
}