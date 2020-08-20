using System;

namespace StoringAPI.Models.Enums
{
    [Flags]
    public enum FoodTime
    {
        Breakfast,
        Brunch,
        Lunch,
        AfternoonSnack = 4,
        Dinner = 8,
        LateSupper = 16,
        BeforeBattle = 32
    }
}
