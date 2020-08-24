using System;

namespace StoringAPI.Models.Requests
{
    public class EnvyRequest : EnvyModel, IFrontUuid
    {
        public Guid Uuid { get; set; }
    }
}
