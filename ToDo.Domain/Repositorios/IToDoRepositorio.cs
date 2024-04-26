namespace ToDo.Domain.Repositorios
{
    public interface IToDoRepositorio
    {
        Task<ToDoItem> GetByIdAsync(int id);
        Task<List<ToDoItem>> GetAllAsync();
        Task AddAsync(ToDoItem entity);
        Task UpdateAsync(ToDoItem entity);
        Task DeleteAsync(int id);
    }
}
