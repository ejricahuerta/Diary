﻿using Diary2.Models;
using Diary2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Diary_2.Controllers;

namespace Diary2.Controllers
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
            var last = m.Archives.Single(x => x.DateAdded.Month + 1 == (DateTime.Now.Month));
             if (last == null)
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
        public IEnumerable<Entryvm> GetEntries(int? id)
        {
            var entries = m.Entries.Include("User").Where(x => x.ArchiveId == id).OrderByDescending(x => x.DateAdded.Day);
            return (id == null) ? Mapper.Map<IEnumerable<Entry>, IEnumerable<Entryvm>>(m.Entries.Include("User")).OrderByDescending(x => x.DateAdded.Day).OrderByDescending(x => x.DateAdded.Month) : Mapper.Map<IEnumerable<Entry>, IEnumerable<Entryvm>>(entries);
        }


        public Entryvm GetEntryById(int id)
        {
            var o = m.Entries.Include("User").SingleOrDefault(e => e.Id == id);
            return (o == null) ? null : Mapper.Map<Entry, Entryvm>(o);
        }

        public Entryvm EditEntry(Entryvm entry)
        {
            var user = m.User.SingleOrDefault(x => x.Name == entry.UserName);
            var archive = m.Archives.SingleOrDefault(x => x.DateAdded.Month == entry.DateAdded.Month);
            var o = m.Entries.Find(entry.Id);
            o.Archive = archive;
            o.User = user;
            if (o == null)
            {
                return null;
            }
            else
            {
                m.Entry(o).CurrentValues.SetValues(entry);
                m.SaveChanges();
            }
            return Mapper.Map<Entry, Entryvm>(o);

        }
        public IEnumerable<Archivevm> GetArchive()
        {
            return Mapper.Map<IEnumerable<Archive>, IEnumerable<Archivevm>>(m.Archives);
        }

        public Archivevm GetArchiveId(int id)
        {
            var a = m.Archives.SingleOrDefault(e => e.Id == id);
            return Mapper.Map<Archive, Archivevm>(a);
        }
        public Entryvm AddEntry(Entryvm entry)
        {
            if (entry.DateAdded == null)
            {
                entry.DateAdded = DateTime.Now;
            }
            var user = m.User.SingleOrDefault(x => x.Name == entry.UserName);
            if (m.Archives.SingleOrDefault(x => x.DateAdded.Month == DateTime.Now.Month) == null)
            {
                m.Archives.Add(new Archive());
            }

            entry.User = user;

            var archive = m.Archives.FirstOrDefault(x => x.DateAdded.Month == entry.DateAdded.Month);
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
            if (m.Archives.Count() == 0)
            {
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