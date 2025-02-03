using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Personaje
{
    public int IdPersonaje { get; set; }

    public int? IdAnime { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? ImagenUrl { get; set; }

    public virtual Anime? IdAnimeNavigation { get; set; }
}
