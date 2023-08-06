using System;
using System.Net.Http;
using System.Threading.Tasks;
using Ejercicio.Models;

namespace Ejercicio.Services
{
    public class PokeApiService: IPokeApiService
    {
        private const string BaseUrl = "https://pokeapi.co/api/v2/";

        public async Task<PokemonResponse> GetPokemonInfo(string pokemonName)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    HttpResponseMessage response = await client.GetAsync($"pokemon/{pokemonName.ToLower()}");
                    response.EnsureSuccessStatusCode(); 
                    string data = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<PokemonResponse>(data);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                return null;
            }
        }

        public async Task<PokemonListResponse> GetPokemonList(int pOffset, int pLimit)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    string url = string.Concat("pokemon?offset=", pOffset, "&limit=", pLimit);
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string data = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<PokemonListResponse>(data);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                return null;
            }
        }
    }
}
