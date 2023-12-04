using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using BusinessLogic.Specifications;
using DateAccess.Interfaces;
using DateAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.MovieServices
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepo;
        private readonly IMapper _mapper;

        public MovieService(IRepository<Movie> movieRepo, IMapper mapper)
        {
            _movieRepo = movieRepo;
            _mapper = mapper;
        }

        public async Task Create(MovieDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            await _movieRepo.InsertAsync(movie);
            await _movieRepo.SaveAsync();
        }

        public async Task Delete(int? id)
        {
            var movie = _movieRepo.GetByIDAsync(id);
            await _movieRepo.DeleteAsync(movie);
            await _movieRepo.SaveAsync();
        }

        public async Task Edit(MovieDto movieDto)
        {
            var value = _mapper.Map<Movie>(movieDto);

            var movie = _movieRepo.GetByIDAsync(value.Id).Result;
            await _movieRepo.UpdateAsync(movie);
            await _movieRepo.SaveAsync();

        }

        public async Task<MovieDto?> Get(int? id)
        {
            var movie = await _movieRepo.GetByIDAsync(id);

            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<IEnumerable<MovieDto>> GetAllMovie()
        {
            
            var movies = _movieRepo.GetAsync(includeProperties: new[] { "Ganres" }).Result.ToList();
                       

            //var movie = _movieRepo.GetListBySpec(new MovieSpecification.OrderedAll()).Result.ToList();

           return _mapper.Map<List<MovieDto>>(movies);
        }
    }
}
