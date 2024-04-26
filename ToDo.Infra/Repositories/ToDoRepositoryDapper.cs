using Npgsql;
using Dapper;
using ToDo.Domain.Repositorios;

namespace ToDo.Infra.Repositories
{
    public class ToDoRepositoryDapper : IToDoRepositorio
    {
        private readonly string _connectionString;

        public ToDoRepositoryDapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<ToDoItem> GetByIdAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                const string sql = $@"SELECT * FROM ""ToDoItems"" WHERE ""Id"" = @Id";
                return await connection.QuerySingleOrDefaultAsync<ToDoItem>(sql, new { Id = id });
            }
        }

        public async Task<List<ToDoItem>> GetAllAsync()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                const string sql = @"SELECT * FROM ""ToDoItems""";
                return (List<ToDoItem>)await connection.QueryAsync<ToDoItem>(sql);
            }
        }

        public async Task AddAsync(ToDoItem entity)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                const string sql = @"INSERT INTO ""ToDoItems"" (""Title"", ""IsCompleted"") VALUES (@Title, @IsCompleted)";
                await connection.ExecuteAsync(sql, new { entity.Title, entity.IsCompleted });
            }
        }

        public async Task UpdateAsync(ToDoItem entity)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                const string sql = @"UPDATE ""ToDoItems"" SET ""Title"" = @Title, ""IsCompleted"" = @IsCompleted WHERE ""Id"" = @Id";
                await connection.ExecuteAsync(sql, new { entity.Id, entity.Title, entity.IsCompleted });
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                const string sql = @"DELETE FROM ""ToDoItems"" WHERE ""Id"" = @Id";
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }
    }
}
