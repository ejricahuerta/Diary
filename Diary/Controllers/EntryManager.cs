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

            foreach (var item in m.Archives)
            {
                if (item.DateAdded.Month < DateTime.Now.Month)
                {
                    m.Archives.Add(
                        new Archive
                        {
                            Name = DateTime.Now.ToString("MMMM") + " " + DateTime.Now.Year.ToString(),
                            DateAdded = DateTime.Now
                        });
                    m.SaveChanges();
                }
            }
        }
        public IEnumerable<Entryvm> GetEntries(int? id)
        {
            var entries = m.Entries.Include("User").Where(x => x.ArchiveId == id);

            return (entries == null) ? null : Mapper.Map<IEnumerable<Entry>, IEnumerable<Entryvm>>(entries);
        }
        public IEnumerable<Archivevm> GetArchive()
        {
            return Mapper.Map<IEnumerable<Archive>, IEnumerable<Archivevm>>(m.Archives);
        }
        public Entryvm AddEntry(Entryvm entry)
        {
            if (entry.Date == null)
            {
                entry.Date = DateTime.Now;
            }
            var user = m.User.SingleOrDefault(x => x.Name == entry.UserName);
            foreach (var item in m.Archives)
            {
                if (entry.Date.Month > item.DateAdded.Month)
                {
                    m.Archives.Add(new Archive());
                }
            }
            entry.User = user;

            var archive = m.Archives.FirstOrDefault(x => x.DateAdded.Month == entry.Date.Month);
            entry.Archive = archive;

            var adddeditem = m.Entries.Add(Mapper.Map<Entryvm, Entry>(entry));
            m.SaveChanges();
            return (adddeditem == null) ? null : Mapper.Map<Entry, Entryvm>(adddeditem);
        }



        #region DummyData
        public bool RemoveDatabase()
        {
            try
            {
                return m.Database.Delete();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DummyData()
        {
            bool success = false;
            if (m.User.Count() == 0)
            {
                m.User.Add(new User { Name = "Edmel", Pass = "Jihyeislove" });
                m.SaveChanges();
                success = true;
            }
            if (m.Archives.Count() == 0) {
                m.Archives.Add(new Archive());
                m.SaveChanges();
                success = true;
            }

            //var user = m.User.Find(0);
            //var archive = m.Archives.FirstOrDefault(x => x.DateAdded.Month == DateTime.Now.Month);
            //if (m.Entries.Count() == 0) {
            //    m.Entries.Add(new Entry { Texts = " Lorem ipsum dolor sit amet, sea simul prodesset eu, nulla aeterno consequuntur eu cum. Te facer dicant mandamus nam. Ut insolens efficiendi mea, error semper erroribus in pri, vix timeam molestie periculis et. Sit at scripta aperiri propriae, ne quo atomorum concludaturque. Movet voluptua ut est, mutat ignota adipisci eos at.", DateAdded = DateTime.Now, User = user, Archive = archive });
            //    m.Entries.Add(new Entry { Texts = " Lorem ipsum dolor sit amet, sea simul prodesset eu, nulla aeterno consequuntur eu cum. Te facer dicant mandamus nam. Ut insolens efficiendi mea, error semper erroribus in pri, vix timeam molestie periculis et. Sit at scripta aperiri propriae, ne quo atomorum concludaturque. Movet voluptua ut est, mutat ignota adipisci eos at.", DateAdded = DateTime.Now, User = user, Archive = archive });
            //    m.Entries.Add(new Entry { Texts = " Lorem ipsum dolor sit amet, sea simul prodesset eu, nulla aeterno consequuntur eu cum. Te facer dicant mandamus nam. Ut insolens efficiendi mea, error semper erroribus in pri, vix timeam molestie periculis et. Sit at scripta aperiri propriae, ne quo atomorum concludaturque. Movet voluptua ut est, mutat ignota adipisci eos at.", DateAdded = DateTime.Now, User = user, Archive = archive });
            //    m.Entries.Add(new Entry { Texts = " Lorem ipsum dolor sit amet, sea simul prodesset eu, nulla aeterno consequuntur eu cum. Te facer dicant mandamus nam. Ut insolens efficiendi mea, error semper erroribus in pri, vix timeam molestie periculis et. Sit at scripta aperiri propriae, ne quo atomorum concludaturque. Movet voluptua ut est, mutat ignota adipisci eos at.", DateAdded = DateTime.Now, User = user, Archive = archive });
            //    m.SaveChanges();
            //    success = true;
            //}
            return success;
        }
        #endregion
    }
}