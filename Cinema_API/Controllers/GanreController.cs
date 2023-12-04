using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GanreController : ControllerBase
    {
        public readonly IGanreService _ganreService;
        public GanreController(IGanreService ganreService)
        {
            _ganreService = ganreService;
        }

        [HttpGet("/ganre")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _ganreService.GetAllGanre());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await _ganreService.Get(id));
        }

        //HttpPost метод створення даних
        [HttpPost("Create")]
        public async Task<IActionResult> Create(GanreDto ganreDto)
        {

            await _ganreService.Create(ganreDto);

            return Ok();
        }

        //HttpPost метод для редагування
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(GanreDto ganreDto)
        {
            await _ganreService.Edit(ganreDto);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            await _ganreService.Delete(id);

            return Ok();
        }
    }
}
