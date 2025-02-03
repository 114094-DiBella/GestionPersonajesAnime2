using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Anime
{
    public int IdAnime { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Personaje> Personajes { get; set; } = new List<Personaje>();
}
