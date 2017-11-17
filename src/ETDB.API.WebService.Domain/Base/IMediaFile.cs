using ETDB.API.ServiceBase.Generics.Base;
using ETDB.API.WebService.Domain.Enums;

namespace ETDB.API.WebService.Domain.Base
{
    public interface IMediaFile : IEntity
    {
        string Name
        {
            get;
            set;
        }

        string Extension
        {
            get;
            set;
        }

        MediaFileType MediaFileType
        {
            get;
            set;
        }

        byte[] File
        {
            get;
            set;
        }
    }
}
