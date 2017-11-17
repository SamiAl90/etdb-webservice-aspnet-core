using System;
using ETDB.API.WebService.Presentation.Base;

namespace ETDB.API.WebService.Presentation.DataTransferObjects
{
    public class ActorDTO : IDataTransferObject
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

        public string Name
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string FullName
        {
            get;
            set;
        }
    }
}
