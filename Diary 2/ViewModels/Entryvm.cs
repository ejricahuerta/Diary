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
        public Entryvm()
        {

        }
        public int Id { get; set; }
        [Required, Display(Name = "Entry")]
        public string Texts { get; set; }
        [Required, Display(Name = "Name")]
        public string UserName { get; set; }
        public User User { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMMM-dd-yyyy}")]
        public DateTime DateAdded { get; set; }
        public Archive Archive { get; set; }

        public List<string> DiaryPhotos = new List<string>() {
                 "~/images/blog-images/1.jpg",
                 "~/images/blog-images/2.jpg",
                 "~/images/blog-images/3.jpg"
       };
        public string GenerateDiaryPhoto()
        {
            Random ran = new Random();
            return DiaryPhotos.ElementAt(ran.Next(3));
        }
    }
}