using StoringAPI.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace StoringAPI.Data
{
    public partial class SurveyResult
    {
        [StringLength(200)]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Color { get; set; }
        public Gender Gender { get; set; }
    }
}
