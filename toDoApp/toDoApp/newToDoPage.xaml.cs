using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toDoApp.Models;
using toDoApp.Repositories;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace toDoApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class newToDoPage : ContentPage
	{
        private readonly TodoRepository _todoRepo;
        public newToDoPage ()
		{
            _todoRepo = new TodoRepository(App.DB_PATH);

            var item = new Todo();

            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "Name");

            var descriptionEntry = new Entry();
            descriptionEntry.SetBinding(Entry.TextProperty, "Description");

            var doneSwitch = new Switch();
            doneSwitch.SetBinding(Switch.IsToggledProperty, "isDone");


            InitializeComponent ();
		}

        private async void onSave(object sender, EventArgs e)
        {


            //using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            //{
            //    conn.CreateTable<Todo>();
            //    var numberOfRows = conn.Insert(list);


            //    if (numberOfRows > 0 )
            //        DisplayAlert("Success", "Your task is inserted", "OK!");
            //    else
            //        DisplayAlert("Failure", "Your task cannot inserted", "Try again");
            //}



            var task = (Todo)BindingContext;

            _todoRepo.AddTodo(task);

            await DisplayAlert("Success", "Your task is inserted", "OK!");

            await Navigation.PushAsync(new MainPage());


        }

        private async void onDelete(object sender, EventArgs e)
        {

            var task = (Todo)BindingContext;

            await _todoRepo.RemoveTodo(task);

            await DisplayAlert("Success", "Your task is deleted", "OK!");

            await Navigation.PushAsync(new MainPage());
        }
    }
}