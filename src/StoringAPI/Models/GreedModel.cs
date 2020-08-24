using StoringAPI.Models.Enums;

namespace StoringAPI.Models
{
    public class GreedModel
    {
        public bool Hoard { get; set; }
        public bool AreYouDragon { get; set; }
        public CollectionType Collections { get; set; }
        public bool TouchebleCollection { get; set; }
        public bool CanLendMoney { get; set; }
    }
}
