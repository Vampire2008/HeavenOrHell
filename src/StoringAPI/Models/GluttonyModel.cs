using StoringAPI.Models.Enums;

namespace StoringAPI.Models
{
    public class GluttonyModel
    {
        public int EatingInDay { get; set; }
        public bool Cookies { get; set; }
        public FoodTime MostImportantType { get; set; }
        public bool FastFood { get; set; }
    }
}
