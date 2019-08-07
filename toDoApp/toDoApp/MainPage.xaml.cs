using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toDoApp.Models;
using toDoApp.Repositories;
using Xamarin.Forms;

namespace toDoApp
{
    public partial class MainPage : ContentPage
    {
        private readonly TodoRepository _todoRepo;
        public MainPage()
        {
            _todoRepo = new TodoRepository(App.DB_PATH);

            InitializeComponent();
            Title = "Todo";

            


        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            

            //using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            //{
            //    conn.CreateTable<Todo>();

            //    var lists = conn.Table<Todo>().ToList();


            //    ListView.ItemsSource = lists;
            //}

            var list = await _todoRepo.FindAll();
            List<Todo> listToDisplay = new List<Todo>();

            foreach (var item in list)
            {
                if(item.isDone)
                {
                    listToDisplay.Add(new Todo
                    {
                        Id = item.Id,
                        Name = item.Name + " (Done)",
                        Description = item.Description,
                        isDone = item.isDone,
                    });
                } else
                {
                    listToDisplay.Add(new Todo
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        isDone = item.isDone,
                    });
                }
            }

            

            ListView.ItemsSource = listToDisplay;



        }
        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new newToDoPage
            {
                BindingContext = new Todo()
            });
        }


        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var todo = (Todo)e.Item;

            if (todo.isDone == true)
                todo.Name = todo.Name.Substring(0, todo.Name.Length - 7);

            
            await Navigation.PushAsync(new newToDoPage
            {
                BindingContext = e.Item as Todo
            });
            
        }

    }
}
