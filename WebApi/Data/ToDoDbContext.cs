using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
    public class ToDoDbContext: DbContext
    {
        // Install EF core, design(code-first) and sqlite packages
        // Install dotnet ef tool dotnet tool install --global dotnet-ef

        public DbSet<ToDo> Todo { get; set; }

        public ToDoDbContext(DbContextOptions<ToDoDbContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>().ToTable("Todo");
        }
    }
}
