using Ejercicio.Models;
using Ejercicio.Services;
using Ejercicio.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ejercicio.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class List : Page
    {
        private PokemonViewModel _viewModel;
        private Frame rootFrame = Window.Current.Content as Frame;
        private PokeApiService pokeApiService = new PokeApiService();

        public List()
        {
            InitializeComponent();
            _viewModel = new PokemonViewModel(pokeApiService);
            _ = _viewModel.InitializeViewModel();
            DataContext = _viewModel;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PokemonModel selected = (PokemonModel)ListViewPokemon.SelectedItem;
            _viewModel.SelectedPokemon = selected;
            rootFrame.Navigate(typeof(Details));
        }
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as AppBarToggleButton;
            if (button != null)
            {
                button.Command?.Execute(null);
                button.IsChecked = false;
            }
        }

    }
}
