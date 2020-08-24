using System;

namespace StoringAPI.Models.Requests
{
    public class LustRequest : LustModel, IFrontUuid
    {
        public Guid Uuid { get; set; }
    }
}
