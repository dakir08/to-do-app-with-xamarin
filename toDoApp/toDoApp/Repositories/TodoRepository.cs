using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toDoApp.Models;

namespace toDoApp.Repositories
{
    class TodoRepository
    {
        private List<Todo> _mockData;
        readonly SQLiteAsyncConnection conn;

        public TodoRepository(string dbPath)
        {
             _mockData = new List<Todo>
            {
                new Todo { Description = "Desp1", Id=1, Name="Name 1"},
                new Todo { Description = "Desp2", Id=2, Name="Name 2"},
                new Todo { Description = "Desp3", Id=3, Name="Name 3"},
                new Todo { Description = "Desp4", Id=4, Name="Name 4"},
                new Todo { Description = "Desp5", Id=5, Name="Name 5"},
                new Todo { Description = "Desp7", Id=6, Name="Name 6"},
                new Todo { Description = "Desp8", Id=7, Name="Name 8"}
            };

            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Todo>().Wait();
        }




        public void AddTodo(Todo todo)
        {
            //todo.Id = _mockData.Count + 1;
            //_mockData.Add(todo);
            if (todo.Id != 0)
            {
                conn.UpdateAsync(todo);
            }
            else
            {
                conn.InsertAsync(todo);
            }
        }
        public Task<int> RemoveTodo(Todo todo) => conn.DeleteAsync(todo);
        public void Update(Todo todo)
        {
            var exisitingTodo = FindById(todo.Id);
            if (exisitingTodo == null)
                return;

            var indexToUpdate = _mockData.FindIndex(aTodo => aTodo.Id == todo.Id);
            _mockData[indexToUpdate] = todo;
        }
        public Task<List<Todo>> FindAll()
            => conn.Table<Todo>().ToListAsync();
        public Todo FindById(int id)
            => _mockData.Where(aTodo => aTodo.Id == id).FirstOrDefault();
    }
}
