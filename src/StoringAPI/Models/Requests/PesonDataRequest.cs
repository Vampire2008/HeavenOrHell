using System;

namespace StoringAPI.Models.Requests
{
    public class PesonDataRequest : PersonModel, IFrontUuid
    {
        public Guid Uuid { get; set; }
    }
}
