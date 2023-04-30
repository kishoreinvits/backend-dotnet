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
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>()
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
