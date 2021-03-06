﻿using System;
using ETDB.API.WebService.Presentation.Base;

namespace ETDB.API.WebService.Presentation.DataTransferObjects
{
    public class MovieFileDTO : IDataTransferObject
    {
        public Guid Id
        {
            get;
            set;
        }

        public byte[] ConcurrencyToken
        {
            get;
            set;
        }

        public string Href
        {
            get;
            set;
        }

        public string File
        {
            get;
            set;
        }
    }
}
