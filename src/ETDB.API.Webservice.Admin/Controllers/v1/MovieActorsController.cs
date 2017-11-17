using AutoMapper;
using ETDB.API.ServiceBase.Generics.Base;
using ETDB.API.WebService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ETDB.API.WebService.Admin.Controllers.v1
{
    [Route("api/admin/v1/[controller]")]
    public class MovieActorsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IEntityRepository<MovieActor> actorMovieRepository;

        public MovieActorsController(IMapper mapper, IEntityRepository<MovieActor> actorMovieRepository)
        {
            this.mapper = mapper;
            this.actorMovieRepository = actorMovieRepository;
        }
    }
}
