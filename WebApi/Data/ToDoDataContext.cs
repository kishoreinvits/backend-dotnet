using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
    public class ToDoDataContext: DbContext
    {
        // Install EF core, design(code-first) and sqlite packages
        // Install dotnet ef tool dotnet tool install --global dotnet-ef

        public DbSet<Todo> Todo { get; set; }

        public ToDoDataContext(DbContextOptions<ToDoDataContext> options): base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>()
                .ToTable("Todo")
                .HasData(new()
                    {
                        Id = 1,
                        Description = "Add persistence with database",
                        State = ToDoState.Pending
                    },
                    new()
                    {
                        Id = 2,
                        Description = "Add API version",
                        State = ToDoState.Pending
                    },
                    new()
                    {
                        Id = 3,
                        Description = "Create typed http client",
                        State = ToDoState.Pending
                    });


        }
    }
}
