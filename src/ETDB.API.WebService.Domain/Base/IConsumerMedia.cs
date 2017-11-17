using System;
using ETDB.API.WebService.Domain.Enums;

namespace ETDB.API.WebService.Domain.Base
{
    public interface IConsumerMedia
    {
        ConsumerMediaType ConsumerMediaType
        {
            get;
            set;
        }

        string Title
        {
            get;
            set;
        }

        DateTime? ReleasedOn
        {
            get;
            set;
        }
    }
}
