﻿using AutoMapper;
using ETDB.API.WebService.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace ETDB.API.WebService.Presentation.DataTransferObjects.Resolver
{
    public class MovieCoverImageResolver : IValueResolver<Movie, MovieDTO, string>
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public MovieCoverImageResolver(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string Resolve(Movie source, MovieDTO destination, string destMember, ResolutionContext context)
        {
            return "FUCK YOU";
        }
    }
}
