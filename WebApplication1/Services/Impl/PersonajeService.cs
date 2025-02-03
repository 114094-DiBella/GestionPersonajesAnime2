using WebApplication1.Dtos;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services.Impl
{
    public class PersonajeService : IPersonajeService
    {
        private readonly PersonajeRepository _personajeRepository;

        public PersonajeService(PersonajeRepository personajeRepository)
        {
            _personajeRepository = personajeRepository;
        }

        public async Task<Personaje> AddPersonajeAsync(PersonajeDTO personajeDto)
        {
            var personaje = new Personaje
            {
                IdAnime = personajeDto.IdAnime,
                Nombre = personajeDto.Nombre,
                Descripcion = personajeDto.Descripcion,
                ImagenUrl = personajeDto.ImagenUrl
            };
            return await _personajeRepository.CreateAsync(personaje);
        }

        public async Task<List<Personaje>> GetAllAsync()
        {
            return await _personajeRepository.GetPersonajes();
        }

        public async Task<Personaje> GetByIdAsync(int id)
        {
            return await _personajeRepository.GetByIdAsync(id);
        }

        public async Task<Personaje> UpdatePersonaAsync(int id, PersonajeDTO personajeDto)
        {
            var personaje = await _personajeRepository.GetByIdAsync(id);
            if (personaje == null)
                throw new KeyNotFoundException($"Personaje con id {id} no encontrado");

            personaje.IdAnime = personajeDto.IdAnime;
            personaje.Nombre = personajeDto.Nombre;
            personaje.Descripcion = personajeDto.Descripcion;
            personaje.ImagenUrl = personajeDto.ImagenUrl;

            return await _personajeRepository.UpdateAsync(personaje);
        }
    }
}
