using Diary.Models;
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
            Date = DateTime.Now;
        }
        public int Id { get; set; }
        [Required,Display(Name ="Entry")]
        public string Texts { get; set; }
        [Required,Display(Name="Name")]
        public string UserName  { get; set; }
        public User User { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Date { get; set; }
        public Archive Archive { get; set; }
    }
}