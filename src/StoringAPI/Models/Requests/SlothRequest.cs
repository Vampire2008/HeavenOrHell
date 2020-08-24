using System;

namespace StoringAPI.Models.Requests
{
    public class SlothRequest : SlothModel, IFrontUuid
    {
        public Guid Uuid { get; set; }
    }
}
