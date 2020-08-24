using StoringAPI.Models;
using StoringAPI.Models.Enums;
using System;

namespace StoringAPI.Data
{
    public class SurveyResult
    {
        public int Id { get; set; }
        public Guid FrontUuid { get; set; }
        public int Step { get; set; }
        public bool IsFinished { get; set; }
        public PersonModel Person { get; set; }
        public GluttonyModel Gluttony { get; set; }
        public EnvyModel Envy { get; set; }
        public GreedModel Greed { get; set; }
        public LustModel Lust { get; set; }
        public PrideModel Pride { get; set; }
        public SlothModel Sloth { get; set; }
        public WrathModel Wrath { get; set; }
        public int HeavenPoints { get; set; }
        public int HellPoints { get; set; }
        public int ValhallaPoints { get; set; }
        public int HelPoints { get; set; }
        public AfterLifeType AfterLife { get; set; }
    }
}
