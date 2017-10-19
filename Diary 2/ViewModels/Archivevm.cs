using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diary2.ViewModels
{
    public class Archivevm
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private List<string> HomePhotos = new List<string>()
        {
                "~/images/home-images/1.jpg",
                "~/images/home-images/2.jpg",
                "~/images/home-images/3.jpg",
                "~/images/home-images/4.jpg",
                "~/images/home-images/5.jpg",
                "~/images/home-images/6.jpg",
                "~/images/home-images/7.jpg",
                "~/images/home-images/8.jpg",
                "~/images/home-images/9.jpg",
                "~/images/home-images/10.jpg",
                "~/images/home-images/11.jpg",
                "~/images/home-images/12.jpg",
        };
        public string GenerateArchivePhotos() {
            Random r = new Random();
            return HomePhotos.ElementAt(r.Next(12));
        }

    }
}