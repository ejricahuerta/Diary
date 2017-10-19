using AutoMapper;
using Diary2.Controllers;
using Diary2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diary_2.Controllers
{
    public class DiaryController : Controller
    {
        private EntryManager m = new EntryManager();
        // GET: Diary
        public ActionResult All(int? id)
        {

            var a = m.GetArchive().FirstOrDefault(x => x.Id == id);
            if (a != null)
            {
                ViewData["Archive"] = a.Name;
            }
            else
            {
                ViewData["Archive"] = "All Diary Entry";
            }
            return View(m.GetEntries(id));
        }

        // GET: Diary/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Diary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diary/Create
        [HttpPost]
        public ActionResult Create(Entryvm entry)
        {
            if (!ModelState.IsValid)
            {
                return View(entry);
            }
            var addedItem = m.AddEntry(entry);

            if (addedItem == null)
            {
                return View(entry);
            }
            else
            {
                return RedirectToAction("All", "Diary", new { id = addedItem.Archive.Id });
            }
        }
        [HttpPost]
        public ActionResult Edit(int? id, Entryvm entry)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("edit", new { id = entry.Id });
            }
            if (id.GetValueOrDefault() != entry.Id)
            {

                return RedirectToAction("Home/Index");
            }

            var edited = m.EditEntry(entry);

            if (edited == null)
            {
                return RedirectToAction("edit", new { id = entry.Id });
            }
            else {
                return RedirectToAction("All");
            }

        }
       
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var edit = m.GetEntryById(id.GetValueOrDefault());
            if (edit == null)
            {
                return HttpNotFound();

            }
            else
            {
                var form = Mapper.Map<Entryvm>(edit);
                return View(form);
            }
        }

        // GET: Diary/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Diary/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
