using Ejercicio.Services;
using Ejercicio.ViewModels;
using Windows.UI.Xaml.Controls;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ejercicio.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Details : Page
    {
        private PokeApiService pokeApiService = new PokeApiService();
        private PokemonViewModel _viewModel;
        public Details()
        {
            InitializeComponent();
            _viewModel = new PokemonViewModel(pokeApiService);
            _ = _viewModel.InitializeViewModel();
            DataContext = _viewModel;
        }

    }
}
