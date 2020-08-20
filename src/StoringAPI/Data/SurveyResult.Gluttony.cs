using StoringAPI.Models.Enums;

namespace StoringAPI.Data
{
    public partial class SurveyResult
    {
        public int EatingInDay { get; set; }
        public bool Cookies { get; set; }
        public FoodTime MostImportantType { get; set; }
        public bool FastFood { get; set; }
    }
}
