using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
    public interface ITodoRepository
    {
        Task<List<ToDo>> ListAsync(
            Expression<Func<ToDo, bool>>? filter = null,
            Func<IQueryable<ToDo>, IOrderedQueryable<ToDo>>? orderBy = null);
    }

    public class ToDoRepository : ITodoRepository
    {
        private readonly ToDoDbContext _dbContext;

        public ToDoRepository(ToDoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ToDo>> ListAsync(Expression<Func<ToDo, bool>>? filter = null, Func<IQueryable<ToDo>, IOrderedQueryable<ToDo>>? orderBy = null)
        {
            var todos = _dbContext.Todo.AsQueryable();
            if (filter!=null)
            {
                todos = todos.Where(filter);
            }

            if (orderBy != null)
            {
                todos = orderBy(todos);
            }

            return await todos.ToListAsync().ConfigureAwait(false);
        }
    }
}
