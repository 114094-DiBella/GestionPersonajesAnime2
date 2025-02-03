using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using static Azure.Core.HttpHeader;

namespace WebApplication1.Repositories
{
    public class AnimeRepository
    {
        private readonly GestionAnimeContext _context;

        public AnimeRepository(GestionAnimeContext context)
        {
            _context = context;
        }

        public async Task<Anime> GetByIdAsync(int id)
        {
            return await _context.Animes.FindAsync(id);
        }

        public async Task<List<Anime>> GetAllAsync()
        {
            return await _context.Animes.ToListAsync();
        }

        public async Task<Anime> CreateAsync(Anime anime)
        {
            _context.Animes.Add(anime);
            await _context.SaveChangesAsync();
            return anime;
        }

        public async Task UpdateAsync(Anime anime)
        {
            _context.Entry(anime).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var anime = await _context.Animes.FindAsync(id);
            if (anime != null)
            {
                _context.Animes.Remove(anime);
                await _context.SaveChangesAsync();
            }
        }
    }
}
