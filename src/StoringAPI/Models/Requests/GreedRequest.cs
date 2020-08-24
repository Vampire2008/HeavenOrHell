using System;

namespace StoringAPI.Models.Requests
{
    public class GreedRequest : GreedModel, IFrontUuid
    {
        public Guid Uuid { get; set; }
    }
}
