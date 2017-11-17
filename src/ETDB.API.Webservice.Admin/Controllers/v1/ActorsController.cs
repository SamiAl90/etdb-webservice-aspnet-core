using System.Collections.Generic;
using AutoMapper;
using ETDB.API.ServiceBase.Generics.Base;
using ETDB.API.WebService.Domain.Entities;
using ETDB.API.WebService.Presentation.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace ETDB.API.WebService.Admin.Controllers.v1
{
    [Route("api/admin/v1/[controller]")]
    public class ActorsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IEntityRepository<Actor> actorRepository;

        public ActorsController(IMapper mapper, IEntityRepository<Actor> actorRepository)
        {
            this.mapper = mapper;
            this.actorRepository = actorRepository;
        }

        [HttpGet]
        public IEnumerable<ActorDTO> Get()
        {
            return this.mapper.Map<IEnumerable<ActorDTO>>(this.actorRepository.GetAll());
        }
    }
}
