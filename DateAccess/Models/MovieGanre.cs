using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAccess.Models
{
    public class MovieGanre
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int GanreId { get; set; }

        public Movie? Movie { get;}

        public Ganre? Ganre { get; }
    }
}
