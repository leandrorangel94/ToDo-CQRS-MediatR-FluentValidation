using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Repositorios;
using ToDo.Infra.DataContext;

namespace ToDo.Infra.Repositories
{
    public class ToDoRepository : IToDoRepositorio
    {
        private readonly ToDoDbContext _context;

        public ToDoRepository(ToDoDbContext context)
        {
            _context = context;
        }

        public async Task<ToDoItem> GetByIdAsync(int id)
        {
            return await _context.ToDoItems.FindAsync(id);
        }

        public async Task<List<ToDoItem>> GetAllAsync()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        public async Task AddAsync(ToDoItem entity)
        {
            _context.ToDoItems.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ToDoItem entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.ToDoItems.FindAsync(id);

            if (entity == null)
                throw new ApplicationException("Id não encontrado.");

            _context.ToDoItems.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}