﻿using System;
using ETDB.API.WebService.Domain.Enums;
using ETDB.API.WebService.Presentation.Base;

namespace ETDB.API.WebService.Presentation.DataTransferObjects
{
    public class MovieDTO : IDataTransferObject
    {
        public byte[] ConcurrencyToken
        {
            get;
            set;
        }

        public Guid Id
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public ConsumerMediaType ConsumerMediaType
        {
            get;
            set;
        }

        public DateTime? ReleasedOn
        {
            get;
            set;
        }

        public string MovieCoverImageUrl
        {
            get;
            set;
        }
    }
}
    