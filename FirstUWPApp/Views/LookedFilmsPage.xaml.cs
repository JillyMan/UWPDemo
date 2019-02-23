using System.Windows;
using FirstUWPApp.Views.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace FirstUWPApp.Views
{
    public sealed partial class LookedFilmsPage : Page
    {
        private double offset = 500.0;
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

        private void ChevronRightButton(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (ScrollerFilms.HorizontalScrollMode == ScrollMode.Enabled)
            {
                (RightBottomBtn?.Resources["rotateRightYButtonAnimation"] as Storyboard)?.Begin();
                HorizontalScroll(offset);
            }
            else
            {
                (RightBottomBtn?.Resources["rotateDownXButtonAnimation"] as Storyboard)?.Begin();
                VerticalScroll(offset);
            }
        }

        private void ChevronLeftButton(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (ScrollerFilms.HorizontalScrollMode == ScrollMode.Enabled)
            {
                (LeftUpBtn?.Resources["rotateLeftYButtonAnimation"] as Storyboard)?.Begin();
                HorizontalScroll(-offset);
            }
            else
            {
                (LeftUpBtn?.Resources["rotateUpXButtonAnimation"] as Storyboard)?.Begin();
                VerticalScroll(-offset);
            }
        }

        private void VerticalScroll(double offset)
        {
            ScrollerFilms.ChangeView(null, ScrollerFilms.VerticalOffset + offset, null);
        }

        private void HorizontalScroll(double offset)
        {
            ScrollerFilms.ChangeView(ScrollerFilms.HorizontalOffset + offset, null, null);
        }
    }
}