using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUWPApp.Views.ViewModels
{
    public class HomeVM : AbstractVM
    {
        public HomeVM()
        {
            MainText = "Welcome to Home page";//(string)App.Current.Resources["TitleHomePage"];
        }
    }
}
