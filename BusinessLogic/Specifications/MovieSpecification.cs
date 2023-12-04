using Ardalis.Specification;
using DateAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BusinessLogic.Specifications
{
    public static class MovieSpecification
    {
        public class OrderedAll : Specification<Movie>
        {
            public OrderedAll()
            {
                //Фільми будуть відсортовані
                Query.OrderBy(a => a.Title)
                    .Include(x => x.Ganres)
                    .ThenInclude(x => x.Ganre);
            }

            public class ById : Specification<Movie>
            {
                public ById(int id)
                {
                    Query
                        .Where(x => x.Id == id)
                        .Include(x => x.Ganres);
                }
            }
        }
    }
}
