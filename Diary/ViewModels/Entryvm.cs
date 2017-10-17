using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diary.ViewModels
{
    public class Entryvm
    {
        public string Texts { get; set; }
        public string User  { get; set; }
        public DateTime Date { get; set; }
    }
}