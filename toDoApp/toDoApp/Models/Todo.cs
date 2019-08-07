using SQLite;

namespace toDoApp.Models
{
    class Todo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isDone { get; set; }
    }
}
