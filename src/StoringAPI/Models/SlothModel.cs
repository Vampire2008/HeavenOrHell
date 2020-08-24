using StoringAPI.Models.Enums;

namespace StoringAPI.Models
{
    public class SlothModel
    {
        public bool PassiveRest { get; set; }
        public ReactionOnAccidentType ReactionOnAccident { get; set; }
        public ServantsType Servants { get; set; }
        public string LazyDescription { get; set; }
    }
}
