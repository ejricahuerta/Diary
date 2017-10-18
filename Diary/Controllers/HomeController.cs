using Diary.ViewModels;
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
            return View(em.GetArchive());
        }

        public ActionResult Entries(int? id)
        {
            var all = em.GetEntries(id);
            if (all == null) {
                Redirect("Index.cshtml");
            }
            return View(all);
        }

        [HttpPost]
        public ActionResult Create(Entryvm newItem)
        {
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }
            var addedItem = em.AddEntry(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public ActionResult Create() {
            return View();
        }

    }
}