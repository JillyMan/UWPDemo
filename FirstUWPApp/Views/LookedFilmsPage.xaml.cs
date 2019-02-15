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
            var vm = DataContext as LoockedFilmsViewModel;
            Frame.Navigate(typeof(FilmInfoPage), vm.Films[Films.SelectedIndex]);
        }
    }
}