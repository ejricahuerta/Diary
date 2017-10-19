using Diary2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diary2.ViewModels
{
    public class Entryvm
    {
        public int Id { get; set; }
        [Required,Display(Name ="Entry")]
        public string Texts { get; set; }
        [Required,Display(Name="Name")]
        public string UserName  { get; set; }
        public User User { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMMM-dd-yyyy}")]
        public DateTime DateAdded { get; set; }
        public Archive Archive { get; set; }
    }
}