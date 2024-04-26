using Microsoft.EntityFrameworkCore;

namespace ToDo.Infra.DataContext
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }

        public DbSet<ToDoItem> ToDoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToDoDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ToDoItem>()
                .Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<ToDoItem>()
                .Property(t => t.IsCompleted)
                .IsRequired();
        }
    }
}