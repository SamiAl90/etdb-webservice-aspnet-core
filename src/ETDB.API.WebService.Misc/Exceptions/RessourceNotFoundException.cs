using System;

namespace ETDB.API.WebService.Misc.Exceptions
{
    public class RessourceNotFoundException : Exception
    {
        public RessourceNotFoundException(string message) : base(message){}
    }
}
