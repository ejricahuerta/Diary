using Diary.Models;
using Diary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
namespace Diary.Controllers
{
    public class EntryManager
    {
        private ModelEntities m = new ModelEntities();

        public EntryManager()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<Entry, Entryvm>();
                x.CreateMap<Entryvm, Entry>();
                x.CreateMap<Archive, Archivevm>();
            });

        }
        public IEnumerable<Entryvm> GetEntries(int? id)
        {
            var entries = m.Entries.Include("User").Where(x => x.ArchiveId == id);

            return entries == null ? null : Mapper.Map<IEnumerable<Entry>, IEnumerable<Entryvm>>(entries);
        }
        public IEnumerable<Archivevm> GetArchive()
        {
            return Mapper.Map<IEnumerable<Archive>, IEnumerable<Archivevm>>(m.Archives);
        }
        public Entryvm AddEntry(Entryvm entry)
        {
            foreach (var item in m.Archives)
            {
                if (entry.Date.Month > item.DateAdded.Month) {
                    m.Archives.Add(new Archive());
                    m.SaveChanges();
                }
            }

            var adddeditem = m.Entries.Add(Mapper.Map<Entryvm, Entry>(entry));
            m.SaveChanges();
            return (adddeditem == null) ? null : Mapper.Map<Entry, Entryvm>(adddeditem);
        }
    }
}