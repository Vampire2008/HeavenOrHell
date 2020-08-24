using System;

namespace StoringAPI.Models.Requests
{
    public class GluttonyRequest : GluttonyModel, IFrontUuid
    {
        public Guid Uuid { get; set; }
    }
}
