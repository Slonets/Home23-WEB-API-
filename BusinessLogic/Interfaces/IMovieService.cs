using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IMovieService
    {
        Task <IEnumerable<MovieDto>> GetAllMovie();
        Task<MovieDto?> Get(int? id);
        Task Create(MovieDto movieDto);
        Task Edit(MovieDto movieDto);
        Task Delete(int? id);
    }
}
