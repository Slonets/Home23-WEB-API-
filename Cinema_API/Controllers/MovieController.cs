using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using BusinessLogic.MovieServices;
using DateAccess.Interfaces;
using DateAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public readonly IMovieService _movieService;        
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("/movies")]
        public async Task <IActionResult> Index()
        {           
            return Ok(await _movieService.GetAllMovie());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            return Ok(await _movieService.Get(id));
        }

        //HttpPost метод створення даних
        [HttpPost("Create")]
        public async Task<IActionResult> Create(MovieDto movieDto)
        {
           
            await _movieService.Create(movieDto);           

            return Ok();
        }

        //HttpPost метод для редагування
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(MovieDto movieDto)
        {
            await _movieService.Edit(movieDto);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            await _movieService.Delete(id);

            return Ok();
        }
    }
}
