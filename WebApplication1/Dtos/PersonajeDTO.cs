using WebApplication1.Models;

namespace WebApplication1.Dtos
{
    public class PersonajeDTO
    {
        public int? IdAnime { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public string? ImagenUrl { get; set; }

    }
}
