using System;
using System.ComponentModel.DataAnnotations;

namespace Specification.Data.Models
{
    public class Movie
    {
        [Key]
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime ReleaseDate { get; set; }
        public virtual MpaaRating MpaaRating { get; set; }
        public virtual string Genre { get; set; }
        public virtual double Rating { get; set; }
        // public virtual Director Director { get; }

    }

    public enum MpaaRating
    {
        G = 1,
        PG = 2,
        PG13 = 3,
        R = 4
    }
}
