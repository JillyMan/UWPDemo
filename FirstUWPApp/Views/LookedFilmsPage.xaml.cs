using FirstUWPApp.Views.ViewModels;
using Windows.UI.Xaml.Controls;

namespace FirstUWPApp.Views
{
    public sealed partial class LookedFilmsPage : Page
    {
        public LookedFilmsPage()
        {
            this.InitializeComponent();
        }

        private void ListImages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DataContext is LookedFilmsViewModel vm)
            {
                //TODO: ?????
                if(vm.LookedFilms != null && FilmsView.SelectedIndex != -1)
                {
                    Frame.Navigate(typeof(FilmInfoPage), vm.LookedFilms[FilmsView.SelectedIndex]);
                }
            }
        }
    }
}