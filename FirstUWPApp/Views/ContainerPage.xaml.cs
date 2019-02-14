using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace FirstUWPApp.Views
{
    public sealed partial class ContainerPage : Page
    {
        public ContainerPage()
        {
            this.InitializeComponent();
            ChildFrame.Navigate(typeof(LookedFilmsPage));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            SplitPanel.IsPaneOpen = !SplitPanel.IsPaneOpen;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LookedFilms.IsSelected)
            {
                ChildFrame.Navigate(typeof(LookedFilmsPage));
            }
            else if (SearchFilm.IsSelected)
            {
                ChildFrame.Navigate(typeof(SearchFilmPage));
            }

            SplitPanel.IsPaneOpen = !SplitPanel.IsPaneOpen;
        }
    }
}
