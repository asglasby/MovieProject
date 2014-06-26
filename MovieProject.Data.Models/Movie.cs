using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Data.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ImageUrl { get; set; }
    }
}
 