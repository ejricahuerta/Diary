using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diary_2.ViewModels
{
    public class Uservm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Pass { get; set; }
    }
}