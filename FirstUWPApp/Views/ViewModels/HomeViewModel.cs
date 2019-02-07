using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUWPApp.Views.ViewModels
{
	public class HomeViewModel : AbstractViewModel
	{
		private string _syncText;
		public string SyncText
		{
			get { return _syncText; }
			set
			{
				_syncText = value;
				OnPropertyChanged(nameof(SyncText));
			}
		}

		public HomeViewModel()
        {
            MainText = "Welcome to Home page";//(string)App.Current.Resources["TitleHomePage"];
        }
    }
}
