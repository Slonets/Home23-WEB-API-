using AutoMapper;
using BusinessLogic.DTOs;
using DateAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mappers
{
    public class AppProfile:Profile
    {
        public AppProfile()
        {

            CreateMap<Ganre, GanreDto>().ReverseMap();
            CreateMap<Movie, MovieDto>().ForMember(movieDTO => movieDTO.Ganres, opt => opt.MapFrom(movie => movie.Ganres.Select(a => a.Ganre)));
            CreateMap<MovieDto, Movie>();
        }
    }
}
