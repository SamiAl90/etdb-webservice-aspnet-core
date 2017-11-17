using System;
using ETDB.API.WebService.Domain.Base;
using ETDB.API.WebService.Domain.Enums;

namespace ETDB.API.WebService.Domain.Entities
{
    public class MovieFile : IMediaFile
    {
        public Guid MovieId
        {
            get;
            set;
        }

        public Movie Movie
        {
            get;
            set;
        }

        public Guid Id
        {
            get;
            set;
        }

        public byte[] RowVersion
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Extension
        {
            get;
            set;
        }

        public MediaFileType MediaFileType
        {
            get;
            set;
        }

        public byte[] File
        {
            get;
            set;
        }

        public bool IsCover
        {
            get;
            set;
        }
    }
}
