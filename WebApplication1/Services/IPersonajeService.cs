
using WebApplication1.Models;
using WebApplication1.Dtos;
namespace WebApplication1.Services
{
    public interface IPersonajeService
    {
        Task<Personaje> AddPersonajeAsync(PersonajeDTO personajeDto);
        Task<List<Personaje>> GetAllAsync();
        Task<Personaje> GetByIdAsync(int id);
        Task<Personaje> UpdatePersonaAsync(int id, PersonajeDTO personajeDto);
    }
}
