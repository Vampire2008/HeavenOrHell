using StoringAPI.Models.Enums;
using System;

namespace StoringAPI.Models
{
    public class PersonModel
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Color { get; set; }
        public Gender Gender { get; set; }
    }
}
