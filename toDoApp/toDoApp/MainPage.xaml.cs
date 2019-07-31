using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace toDoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<List>();

                var lists = conn.Table<List>().ToList();

                Console.WriteLine("ASDKLAJDLASJKD" + lists);

                ListView.ItemsSource = lists;
            }
        }
        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new newToDoPage());
        }
    }
}
