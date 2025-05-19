using CinemaBooking.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace CinemaBooking.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        Task<bool> CreateAsync(Category category);
        bool Update(Category category);
        bool Delete(Category category);

        Category? GetOne(Expression<Func<Category, bool>>? expression = null, Expression<Func<Category, object>>[]? includes = null, bool tracked = true);

        IEnumerable<Category> Get(Expression<Func<Category, bool>>? expression = null, Expression<Func<Category, object>>[]? includes = null, bool tracked = true);
        Task<bool> CommitAsync();
         
        
    }
}
