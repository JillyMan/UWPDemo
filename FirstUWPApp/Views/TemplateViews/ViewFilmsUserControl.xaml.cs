using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using FilmFindService.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FirstUWPApp.Views.TemplateViews
{
    public sealed partial class ViewFilmsUserControl : UserControl
    {
        public IList<FilmInfoDTO> Films { get { return this.DataContext as IList<FilmInfoDTO>; } }

        public ViewFilmsUserControl()
        {
            this.InitializeComponent();
        }

        private void ListImages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         //   var vm = DataContext as LoockedFilmsViewModel;
            //Frame.Navigate(typeof(FilmInfoPage), vm.Films[FilmsView.SelectedIndex]);
        }
    }
}
