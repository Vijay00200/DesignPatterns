using System;
using Microsoft.EntityFrameworkCore;
using Specification.Data.Models;

namespace Specification.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
        : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
