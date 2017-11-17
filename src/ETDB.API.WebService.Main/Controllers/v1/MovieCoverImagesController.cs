using System;
using ETDB.API.ServiceBase.Generics.Base;
using ETDB.API.WebService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace ETDB.API.WebService.Main.Controllers.v1
{
    [Route("api/main/v1/movies/{movieId:Guid}/[controller]")]
    public class MovieCoverImagesController : Controller
    {
        private readonly IEntityRepository<MovieCoverImage> movieCoverImageRepo;

        public MovieCoverImagesController(IEntityRepository<MovieCoverImage> movieCoverImageRepo)
        {
            this.movieCoverImageRepo = movieCoverImageRepo;
        }

        [HttpGet("download/{movieCoverImageId:Guid}")]
        public IActionResult Download(Guid movieId, Guid movieCoverImageId)
        {
            var movieCoverImage = this.movieCoverImageRepo.Get(movieCoverImageId);
            return new FileContentResult(movieCoverImage.File, new MediaTypeHeaderValue("application/octet"))
            {
                FileDownloadName = movieCoverImage.Name,
            };
        }
    }
}
