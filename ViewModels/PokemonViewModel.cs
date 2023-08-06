using Ejercicio.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicio.Services;
using System.Windows.Input;
using Ejercicio.Library;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Ejercicio.Views;

namespace Ejercicio.ViewModels
{
    public class PokemonViewModel: PokemonModel
    {
        private ICommand _command;
        private Frame rootFrame = Window.Current.Content as Frame;

        #region DependencyInjection
        private readonly IPokeApiService _pokeApiService;

        public PokemonViewModel(IPokeApiService pokeApiService)
        {
            _pokeApiService = pokeApiService;
        }
        #endregion

        public async Task InitializeViewModel()
        {
            if(SelectedPokemon == null)
            {
               await ListAsync(0, 10);
            }
            else
            {
               await DetailsAsync();
            }
        }

        public ICommand ReturnCommand
        {
            get
            {
                return _command ?? (_command = new CommandHandler(() =>
                {
                    SelectedPokemon = null;
                    rootFrame.Navigate(typeof(List));
                }));
            }
        }

        public ICommand FirstPageCommand
        {
            get
            {
                return new CommandHandler(async () =>
                {
                    await ListAsync(0, 10);
                });
            }
        }

        public ICommand PreviousPageCommand
        {
            get
            {
                return new CommandHandler(async () =>
                {
                    int paginator = ActualPage - 2 > 0 ? (ActualPage - 2) * 10 : 0;
                    await ListAsync(paginator, 10);
                });
            }
        }

        public ICommand NextPageCommand
        {
            get
            {
                return new CommandHandler(async () =>
                {
                    int paginator = ActualPage + 1 < TotalPages ? ActualPage * 10 : (TotalPages - 1) * 10;
                    await ListAsync(paginator, 10);
                });
            }
        }

        public ICommand LastPageCommand
        {
            get
            {
                return new CommandHandler(async () =>
                {
                    int paginator = (TotalPages - 1) * 10;
                    await ListAsync(paginator, 10);
                });
            }
        }

        private async Task ListAsync(int pOffset, int pLimit)
        {
            List<PokemonModel> listPokemons = new List<PokemonModel>();
            PokemonListResponse pokemonListResponse = await _pokeApiService.GetPokemonList(pOffset, pLimit);
            ActualPage = (pOffset + pLimit) / 10;
            TotalPages = pokemonListResponse.Count / 10 + 1;
            if(pokemonListResponse.Results != null)
            {
                listPokemons = pokemonListResponse.Results.Select(x => new PokemonModel
                {
                    Name = FirstLetterToUpper(x.Name)
                }).ToList();
            };
            ListPokemons = listPokemons;
        }

        private async Task DetailsAsync()
        {
            PokemonResponse pokemon = await _pokeApiService.GetPokemonInfo(SelectedPokemon.Name.ToLower());
            if (pokemon != null)
            {
                SelectedPokemon.Height = pokemon.Height;
                SelectedPokemon.Weight = pokemon.Weight;
                SelectedPokemon.BaseExperience = pokemon.Base_experience;
                SelectedPokemon.Attack = pokemon.Stats.Where(x => x.Stat.Name.Equals("attack")).Select(x => x.Base_stat).FirstOrDefault();
                SelectedPokemon.Defense = pokemon.Stats.Where(x => x.Stat.Name.Equals("defense")).Select(x => x.Base_stat).FirstOrDefault();
                SelectedPokemon.SpecialAttack = pokemon.Stats.Where(x => x.Stat.Name.Equals("special-attack")).Select(x => x.Base_stat).FirstOrDefault();
                SelectedPokemon.SpecialDefense = pokemon.Stats.Where(x => x.Stat.Name.Equals("special-defense")).Select(x => x.Base_stat).FirstOrDefault();
                SelectedPokemon.Speed = pokemon.Stats.Where(x => x.Stat.Name.Equals("speed")).Select(x => x.Base_stat).FirstOrDefault();
                SelectedPokemon.HP = pokemon.Stats.Where(x => x.Stat.Name.Equals("hp")).Select(x => x.Base_stat).FirstOrDefault();
                ListMoves = pokemon.Moves.Select(x => x.Move).ToList();
            }
        }

        private static string FirstLetterToUpper(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1);
        }

    }
}
