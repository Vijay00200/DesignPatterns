using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Specification.Data.Dto;
using Specification.Data.Models;
using Specification.Data.Repositories;
using Specification.Data.Specifications;

namespace Specification.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {

        private IMapper _mapper;
        private IMovieRepository _movieRepository;
        private Specification<Movie> spec;

        public MovieController(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            spec = Specification<Movie>.All;
        }

        [HttpGet("GetMovieById/{id}", Name = "GetMovieById")]
        public ActionResult<MovieDto> GetMovieById(int id)
        {
            var movie = _movieRepository.Find(id);

            if (movie == null)
                return NotFound();

            return _mapper.Map<MovieDto>(movie);
        }

        [HttpGet("GetMovies/{forKids}&{hasCD}", Name = "GetMovies")]
        public ActionResult<IReadOnlyList<MovieDto>> GetMovies(bool forKids, bool hasCD)
        {
            //use to store the domain knowledge in sepearate specificaton file and use AND, OR, NOT operators to use multiple spec
            if (forKids)
                spec = spec.And(new MovieForKidsSpecification());

            if (hasCD)
                spec = spec.And(new AvailableOnCDSpecification());

            var movies = _movieRepository.FindAll(spec);

            if (movies == null)
                return NotFound();

            return _mapper.Map<IReadOnlyList<MovieDto>>(movies).ToList();
        }
    }
}
