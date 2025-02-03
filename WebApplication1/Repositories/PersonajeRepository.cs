using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class PersonajeRepository
    {
        private readonly GestionAnimeContext _context;

        public PersonajeRepository(GestionAnimeContext context)
        {
            _context = context;
        }

        public async Task<Personaje> GetByIdAsync(int id)
        {
            return await _context.Personajes.FindAsync(id);
        }

        public async Task<List<Personaje>> GetPersonajes()
        {
            return await _context.Personajes.ToListAsync();
        }
        public async Task<Personaje> CreateAsync(Personaje personaje)
        {
            _context.Personajes.Add(personaje);
            await _context.SaveChangesAsync();
            return personaje;
        }
        public async Task<Personaje> UpdateAsync(Personaje personaje)
        {
            _context.Entry(personaje).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return personaje;
        }

        public async Task DeleteAsync(int id)
        {
            var personaje = await _context.Personajes.FindAsync(id);
            if (personaje != null)
            {
                _context.Personajes.Remove(personaje);
                await _context.SaveChangesAsync();
            }
        }
    }
}
