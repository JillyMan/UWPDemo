using FirstUWPApp.Views;
using FirstUWPApp.Views.ViewModels;
using Windows.UI.Xaml.Controls;

namespace FirstUWPApp
{
    public sealed partial class SearchFilmPage : Page
    {
        public SearchFilmPage()
        {
            this.InitializeComponent();
        }

        private void ListImages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is SearchFilmViewModel vm)
            {
                if(vm.FoundFilms != null)
                {
                    Frame.Navigate(typeof(FilmInfoPage), vm.FoundFilms[FilmsView.SelectedIndex]);
                }
            }
        }
    }
}
