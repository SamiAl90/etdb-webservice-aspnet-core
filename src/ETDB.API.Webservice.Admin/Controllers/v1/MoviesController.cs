using System;
using System.Threading.Tasks;
using AutoMapper;
using ETDB.API.ServiceBase.Generics.Base;
using ETDB.API.WebService.Domain.Entities;
using ETDB.API.WebService.Domain.Enums;
using ETDB.API.WebService.Presentation.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ETDB.API.WebService.Admin.Controllers.v1
{
    [Route("api/admin/v1/[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMapper mapper;
        private readonly ILogger<MoviesController> logger;
        private readonly IEntityRepository<Movie> movieRepository;

        public MoviesController(IMapper mapper, 
            ILogger<MoviesController> logger, 
            IEntityRepository<Movie> movieRepository)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.movieRepository = movieRepository;
        }

        [HttpPost]
        public MovieDTO Post([FromBody] MovieDTO movieDTO)
        {
            var movie = this.mapper.Map<Movie>(movieDTO);
            movie.ConsumerMediaType = ConsumerMediaType.Movie;
            var type = movie.ReleasedOn.Value.Kind;
            this.movieRepository.Add(movie);
            this.movieRepository.EnsureChanges();

            return this.mapper.Map<MovieDTO>(movie);
        }

        [HttpPut("{id:Guid}")]
        public async Task<MovieDTO> Put(Guid id, [FromBody] MovieDTO movieDTO)
        {
            var movie = this.movieRepository.Get(id);
            this.mapper.Map(movieDTO, movie);
            await this.movieRepository.EnsureChangesAsync();

            return this.mapper.Map<MovieDTO>(movie);
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            var movie = this.movieRepository.Get(id);
            this.movieRepository.Delete(movie);

            return Ok();
        }
    }
}

