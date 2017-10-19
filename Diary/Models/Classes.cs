using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diary.Models
{
    public class Entry
    {
        public Entry()
        {
            Id = int.Parse(DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString());
            DateAdded = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Texts  { get; set; }
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
        public int ArchiveId { get; set; }
        [Required]
        public Archive Archive { get; set; }
        public DateTime DateAdded { get; set; }
    }
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Pass { get; set; }
    }
    public class Archive
    {
        public Archive()
        {
            Id =  int.Parse(DateTime.Now.Year+"" +DateTime.Now.Month);
            Name = DateTime.Now.ToString("MMMM") + " " + DateTime.Now.Year.ToString();
            DateAdded = DateTime.Now;
            Entries = new List<Entry>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public ICollection<Entry> Entries { get; set; }
    }
}