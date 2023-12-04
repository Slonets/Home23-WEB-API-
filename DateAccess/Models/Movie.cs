using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAccess.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }        
        public string? ImagePath { get; set; }
        public IEnumerable<MovieGanre>? Ganres { get; }
    }
}
