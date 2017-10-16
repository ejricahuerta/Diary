using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diary.Controllers
{
    public class HomeController : Controller
    {
        private EntryManager em = new EntryManager();
        public ActionResult Index()
        {

            return View(em.GetArchives());
        }

        public ActionResult Entries(string id)
        {
            var all = em.GetEntries(id);
            if (all == null) {
                RedirectToAction("Index");
            }
            
            return View(all);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}