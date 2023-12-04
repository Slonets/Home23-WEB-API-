using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IGanreService
    {
        Task<IEnumerable<GanreDto>> GetAllGanre();
        Task<GanreDto?> Get(int? id);
        Task Create(GanreDto ganreDto);
        Task Edit(GanreDto ganreDto);
        Task Delete(int? id);
    }
}
