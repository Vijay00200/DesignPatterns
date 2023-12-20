using Specification.Data.Models;
using Specification.Data.Specifications;

namespace Specification.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private ApplicationDbContext _dbContext { get; }
        
        public MovieRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Movie Find(int id)
        {
            return _dbContext.Movies.SingleOrDefault(x=> x.Id == id);
        }

        public IReadOnlyList<Movie> FindAll(Specification<Movie> specification)
        {
            return _dbContext.Movies.Where(specification.ToExpression()).ToList();
        }
    }
}
