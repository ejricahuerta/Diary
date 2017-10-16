using Diary.Models;
using Diary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diary.Controllers
{
    public class EntryManager
    {
        private ModelEntities m = new ModelEntities();
        public EntryManager()
        {

        }
        public List<Entryvm> GetEntries(string id)
        {
            var a = m.Archives.Find(id);
            var entries = m.Entries.Include("User").Where(x=> x.Archive == a).OrderByDescending(x => x.DateAdded);
            var entriesvm = new List<Entryvm>();
            foreach (var i in entries)
            {
                entriesvm.Add(new Entryvm
                {
                    Texts = i.Texts,
                    User = i.User.Name
                });
            }
            return entriesvm;
        }
        public List<Archivevm> GetArchives()
        {
            var archives = m.Archives.OrderByDescending(x => x.DateAdded);
            var archivesvm = new List<Archivevm>();
            foreach (var i in archives)
            {
                archivesvm.Add(new Archivevm
                {
                    Name = i.Name
                });
            }
            return archivesvm;
        }
        public bool AddEntry(Entryvm entry)
        {
            try
            {
                var add = new Entry
                {
                    Texts = entry.Texts,
                    Archive = m.Archives.SingleOrDefault(x => x.DateAdded.Month == DateTime.Now.Month),
                    DateAdded = DateTime.Now,
                    User = m.User.Find(entry.User),
                };
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
    }
}