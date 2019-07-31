using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace toDoApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class newToDoPage : ContentPage
	{
		public newToDoPage ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Success", "Event handled !", "Wow");
        }
    }
}