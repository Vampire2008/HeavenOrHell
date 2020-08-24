using System;

namespace StoringAPI.Models.Requests
{
    public class WrathRequest : WrathModel, IFrontUuid
    {
        public Guid Uuid { get; set; }
    }
}
