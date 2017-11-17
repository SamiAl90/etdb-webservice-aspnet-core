using AutoMapper;
using ETDB.API.WebService.Domain.Entities;

namespace ETDB.API.WebService.Presentation.DataTransferObjects.Mappings
{
    public class ActorDTOMapping : Profile
    {
        public ActorDTOMapping()
        {
            this.CreateMap<Actor, ActorDTO>()
                .ForMember(destination => destination.ConcurrencyToken,
                    option => option.MapFrom(source => source.RowVersion))
                .ForMember(destination => destination.FullName,
                    option => option.MapFrom(source => $"{source.Name} {source.LastName}"))
                .ReverseMap();
        }
    }
}
