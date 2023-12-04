using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DateAccess.Interfaces;
using DateAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.MovieServices
{
    public class GanreService: IGanreService
    {
        private readonly IRepository<Ganre> _ganreRepo;
        private readonly IMapper _mapper;

        public GanreService(IRepository<Ganre> ganreRepo, IMapper mapper)
        {
            _ganreRepo = ganreRepo;
            _mapper = mapper;
        }

        public async Task Create(GanreDto ganreDto)
        {
            var ganre = _mapper.Map<Ganre>(ganreDto);
            await _ganreRepo.InsertAsync(ganre);
            await _ganreRepo.SaveAsync();
        }

        public async Task Delete(int? id)
        {
            var movie = _ganreRepo.GetByIDAsync(id);
            await _ganreRepo.DeleteAsync(movie);
            await _ganreRepo.SaveAsync();
        }

        public async Task Edit(GanreDto ganreDto)
        {
            var value = _mapper.Map<Ganre>(ganreDto);

            var ganre = _ganreRepo.GetByIDAsync(value.Id).Result;
            await _ganreRepo.UpdateAsync(ganre);
            await _ganreRepo.SaveAsync();

        }

        public async Task<GanreDto?> Get(int? id)
        {
            var ganre = await _ganreRepo.GetByIDAsync(id);

            return _mapper.Map<GanreDto>(ganre);
        }

        public async Task<IEnumerable<GanreDto>> GetAllGanre()
        {
            var ganre = _ganreRepo.GetAsync().Result.ToList();          

            return _mapper.Map<List<GanreDto>>(ganre);
        }
    }
}
