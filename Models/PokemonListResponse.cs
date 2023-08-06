using System.Collections.Generic;

namespace Ejercicio.Models
{
    public class PokemonListResponse
    {
        public List<PokemonResult> Results { get; set; }
        public int Count { get; set; }
    }

    public class PokemonResult
    {
        public string Name { get; set; }
    }
}
