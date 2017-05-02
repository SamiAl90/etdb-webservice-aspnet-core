﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using AutoMapper;
using EntertainmentDatabase.REST.API.Domain.Entities;
using EntertainmentDatabase.REST.API.Misc.Exceptions;
using EntertainmentDatabase.REST.API.Presentation.DataTransferObjects;
using EntertainmentDatabase.REST.ServiceBase.Generics.Base;
using Microsoft.AspNetCore.Mvc;

namespace EntertainmentDatabase.REST.API.Main.Controllers.v1
{
    [Route("api/main/v1/[controller]")]
    public class MoviesController
    {
        private readonly IMapper mapper;
        private readonly IEntityRepository<Movie> movieRepository;

        public MoviesController(IMapper mapper, IEntityRepository<Movie> movieRepository)
        {
            this.mapper = mapper;
            this.movieRepository = movieRepository;
        }

        [HttpGet]
        public IEnumerable<MovieDTO> GetAll()
        {
            return this.mapper.Map<IEnumerable<MovieDTO>>(this.movieRepository.GetAll());
        }

        [HttpGet("{movieId:Guid}")]
        public MovieDTO Get(Guid movieId)
        {
            var movie = this.movieRepository
                .Get(movieId);

            if (movie == null)
            {
                throw new RessourceNotFoundException($"The requested movie with id {movieId} could not be found!");
            }

            return this.mapper.Map<MovieDTO>(movie);
        }
    }
}