using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAccess.Models
{
    public class Ganre
    {
        public int? Id { get; set; }
        public string? GanreName { get; set; }
        public ICollection<MovieGanre>? Movies { get; }
    }
}
