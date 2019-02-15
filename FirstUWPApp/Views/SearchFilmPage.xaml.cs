using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using FirstUWPApp.Views;
using FirstUWPApp.Views.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace FirstUWPApp
{
    public sealed partial class SearchFilmPage : Page
    {
        public SearchFilmPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = (DataContext as SearchFilmViewModel);
            if(vm != null)
            {
                if(vm.FilmInfo != null)
                {
                    Frame.Navigate(typeof(FilmInfoPage), vm.FilmInfo);
                }
            }
        }
    }
}
