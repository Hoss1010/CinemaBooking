using CinemaBooking.Data;
using CinemaBooking.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using CinemaBooking.Repositories.IRepositories;

namespace CinemaBooking.Repositories
{
    public class CinemaRepository:ICinemaRepository
    {
        private readonly ApplicationDbContext _context = new();

        // CRUD
        public async Task<bool> CreateAsync(Cinemas cinemas)
        {
            try
            {
                await _context.AddAsync(cinemas);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");

                return false;
            }
        }

        public bool Update(Cinemas cinemas)
        {
            try
            {
                _context.Update(cinemas);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");

                return false;
            }
        }

        public bool Delete(Cinemas cinemas)
        {
            try
            {
                _context.Remove(cinemas);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");

                return false;
            }
        }

        public Cinemas? GetOne(Expression<Func<Cinemas, bool>>? expression = null, Expression<Func<Cinemas, object>>[]? includes = null, bool tracked = true)
        {
            return Get(expression, includes, tracked).FirstOrDefault();
        }


        public IEnumerable<Cinemas> Get(Expression<Func<Cinemas, bool>>? expression = null, Expression<Func<Cinemas, object>>[]? includes = null, bool tracked = true)
        {
            IQueryable<Cinemas> cinemas = _context.Cinema;

            // Filter
            if (expression is not null)
            {
                cinemas = cinemas.Where(expression);
            }

            if (includes is not null)
            {
                foreach (var item in includes)
                {
                    cinemas = cinemas.Include(item);
                }
            }

            if (!tracked)
            {
                cinemas = cinemas.AsNoTracking();
            }

            return cinemas.ToList();
        }

        public async Task<bool> CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");

                return false;
            }
        }
    }
}
   

