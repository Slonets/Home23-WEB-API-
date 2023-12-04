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

            CreateMap<MovieDto, Movie>()
                .ForMember(movie => movie.Ganres, options => options.MapFrom(movieDto => movieDto.Ganres.Select(x => x.Ganre)));

            //.ForMember(movie => movie.Id, options => options.Ignore())
            //.ForMember(movie => movie.Ganre, options => options.Ignore());
            //
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<GanreDto, Ganre>().ReverseMap();
            CreateMap<MovieGanre, MovieGanreDto>().ReverseMap();
        }
    }
}
