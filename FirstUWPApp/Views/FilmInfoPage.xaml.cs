using FilmFindService.Models;
using FirstUWPApp.Views.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FirstUWPApp.Views
{
    public sealed partial class FilmInfoPage : Page
    {
        public FilmInfoPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(e.Parameter != null)
            {
                var film = e.Parameter as FilmInfoDTO;
                var viewmodel = (DataContext as FilmInfoViewModel);

                if (viewmodel != null)
                {
                    viewmodel.FilmInfo = film;
                }
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
