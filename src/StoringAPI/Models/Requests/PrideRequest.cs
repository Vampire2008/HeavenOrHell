using System;

namespace StoringAPI.Models.Requests
{
    public class PrideRequest : PrideModel, IFrontUuid
    {
        public Guid Uuid { get; set; }
    }
}
