using StoringAPI.Data;
using StoringAPI.Models;
using StoringAPI.Models.Enums;
using System;

namespace StoringAPI.Services
{
    public interface IHohService
    {
        AfterLifeType GetResult(Guid uuid);
        SurveyResult GetSurvey(Guid uuid);
        void SaveEnvy(Guid uuid, EnvyModel model);
        void SaveGluttony(Guid uuid, GluttonyModel model);
        void SaveGreed(Guid uuid, GreedModel model);
        void SaveLust(Guid uuid, LustModel model);
        void SavePersonal(Guid uuid, PersonModel model);
        void SavePride(Guid uuid, PrideModel model);
        void SaveSloth(Guid uuid, SlothModel model);
        void SaveWrath(Guid uuid, WrathModel model);
    }
}