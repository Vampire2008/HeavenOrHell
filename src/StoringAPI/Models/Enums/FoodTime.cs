using System;

namespace StoringAPI.Models.Enums
{
    [Flags]
    public enum FoodTime
    {
        No,
        Breakfast,
        Brunch,
        Lunch = 4,
        AfternoonSnack = 8,
        Dinner = 16,
        LateSupper = 32,
        BeforeBattle = 64
    }
}
