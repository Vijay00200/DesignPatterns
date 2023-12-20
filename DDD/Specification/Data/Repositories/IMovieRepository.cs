using System;
using Specification.Data.Models;
using Specification.Data.Specifications;

namespace Specification.Data.Repositories
{
    public interface IMovieRepository
    {
        Movie Find(int id);

        IReadOnlyList<Movie> FindAll(Specification<Movie> specification);
    }
}
