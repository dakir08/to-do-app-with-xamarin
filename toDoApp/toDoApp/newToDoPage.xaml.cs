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
            List list = new List()
            {
                Name = nameEntry.Text,
                Description = descriptionEntry.Text
                
            };

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<List>();
                var numberOfRows = conn.Insert(list);
                

                if (numberOfRows > 0 )
                    DisplayAlert("Success", "Your task is inserted", "OK!");
                else
                    DisplayAlert("Failure", "Your task cannot inserted", "Try again");
            }


        }
    }
}