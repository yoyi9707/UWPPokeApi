using Ejercicio.Models;
using System.Threading.Tasks;

namespace Ejercicio.Services
{
    public interface IPokeApiService
    {
        Task<PokemonListResponse> GetPokemonList(int pOffset, int pLimit);

        Task<PokemonResponse> GetPokemonInfo(string pokemonName);
    }

}
