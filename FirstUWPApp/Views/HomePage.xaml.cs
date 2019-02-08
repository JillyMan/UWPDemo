using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using FirstUWPApp.Views.ViewModel.Locator;
using FirstUWPApp.Views.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FirstUWPApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
            Init();
        }
        private void Init()
        {
            //HomeViewModel viewmodel = DataContext as HomeViewModel;
            //if(viewmodel != null)
            //{
            //    foreach(string imageUri in viewmodel.Images)
            //    {
            //       //FilmsPosters.Items.Add(new BitmapImage(new Uri(imageUri)));
            //    }
            //}
        }
    }
}
