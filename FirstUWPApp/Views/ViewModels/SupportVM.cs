using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUWPApp.Views.ViewModels
{
    public class SupportVM : AbstractVM
    {
        public SupportVM()
        {
            MainText = "Welcomet to Support page";//(string)App.Current.Resources["TitleSupportPage"];
        }
    }
}
