public class ToDoItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }

    // Construtor sem parâmetros necessário para o Entity Framework Core
    public ToDoItem()
    {
    }

    // Construtor com todos os parâmetros, incluindo o 'id'
    public ToDoItem(int id, string title, bool isCompleted)
    {
        Id = id;
        Title = title;
        IsCompleted = isCompleted;
    }
}