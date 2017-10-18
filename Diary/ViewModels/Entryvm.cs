using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diary.ViewModels
{
    public class Entryvm
    {
        public Entryvm()
        {
            
        }
        public int Id { get; set; }
        [Required]
        public string Texts { get; set; }
        [Required]
        public string UserName  { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}