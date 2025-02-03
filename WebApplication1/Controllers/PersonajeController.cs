
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Models;
using WebApplication1.Response;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PersonajeController : ControllerBase
    {
        private readonly IPersonajeService _personajeService;

        public PersonajeController(IPersonajeService personajeService)
        {
            _personajeService = personajeService;
        }
        [Authorize]
        [HttpGet("getAll")]
        public async Task<ActionResult<ApiResponse<List<Personaje>>>> GetAll()
        {
            try
            {
                var personajes = await _personajeService.GetAllAsync();
                return Ok(personajes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno al obtener personajes");
            }
        }
        [Authorize]
        [HttpPost("create")]
        public async Task<ActionResult<Personaje>> Create([FromBody] PersonajeDTO personaje)
        {
            try
            {
                var person = await _personajeService.AddPersonajeAsync(personaje);
                return CreatedAtAction(nameof(GetById), new { id = person.IdPersonaje }, person);
            }
            catch (Exception ex)
            {
                return BadRequest("Error al crear el personaje");
            }
        }
        [Authorize]
        [HttpGet("getById/{id}")]
        public async Task<ActionResult<Personaje>> GetById(int id)
        {
            var personaje = await _personajeService.GetByIdAsync(id);
            if (personaje == null)
                return NotFound($"Personaje con id {id} no encontrado");

            return Ok(personaje);
        }
        [Authorize]
        [HttpPut("update/{id}")]
        public async Task<ActionResult<Personaje>> Update(int id, [FromBody] PersonajeDTO personaje)
        {
            try
            {
                var pers = await _personajeService.UpdatePersonaAsync(id, personaje);
                return Ok(pers);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Error al actualizar el personaje");
            }
        }
    }
}
