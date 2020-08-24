using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StoringAPI.Data;
using StoringAPI.Models;
using StoringAPI.Models.Enums;
using System;
using System.Linq;

namespace StoringAPI.Services
{
    public class HohService : IHohService
    {
        private readonly HohContext _context;
        private ILogger _logger;

        public HohService(HohContext context, ILogger<HohService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public SurveyResult GetSurvey(Guid uuid)
        {
            return _context.SurveyResults.AsNoTracking().Single(s => s.FrontUuid == uuid);
        }

        public void SavePersonal(Guid uuid, PersonModel model)
        {
            var survey = _context.SurveyResults.SingleOrDefault(s => s.FrontUuid == uuid);
            if (survey == null)
            {
                survey = new SurveyResult
                {
                    FrontUuid = uuid
                };
                _context.SurveyResults.Add(survey);
            }

            survey.Person = model;
            survey.Step = 1;
            _context.SaveChanges();
        }

        public void SaveGluttony(Guid uuid, GluttonyModel model)
        {
            var survey = _context.SurveyResults.Single(s => s.FrontUuid == uuid);
            survey.Gluttony = model;
            survey.Step = 2;
            _context.SaveChanges();
        }

        public void SaveGreed(Guid uuid, GreedModel model)
        {
            var survey = _context.SurveyResults.Single(s => s.FrontUuid == uuid);
            survey.Greed = model;
            survey.Step = 3;
            _context.SaveChanges();
        }

        public void SaveSloth(Guid uuid, SlothModel model)
        {
            var survey = _context.SurveyResults.Single(s => s.FrontUuid == uuid);
            survey.Sloth = model;
            survey.Step = 4;
            _context.SaveChanges();
        }

        public void SaveWrath(Guid uuid, WrathModel model)
        {
            var survey = _context.SurveyResults.Single(s => s.FrontUuid == uuid);
            survey.Wrath = model;
            survey.Step = 5;
            _context.SaveChanges();
        }

        public void SaveEnvy(Guid uuid, EnvyModel model)
        {
            var survey = _context.SurveyResults.Single(s => s.FrontUuid == uuid);
            survey.Envy = model;
            survey.Step = 6;
            _context.SaveChanges();
        }

        public void SavePride(Guid uuid, PrideModel model)
        {
            var survey = _context.SurveyResults.Single(s => s.FrontUuid == uuid);
            survey.Pride = model;
            survey.Step = 7;
            _context.SaveChanges();
        }

        public void SaveLust(Guid uuid, LustModel model)
        {
            var survey = _context.SurveyResults.Single(s => s.FrontUuid == uuid);
            survey.Lust = model;
            survey.Step = 8;
            _context.SaveChanges();
        }

        public AfterLifeType GetResult(Guid uuid)
        {
            var survey = _context.SurveyResults.Single(s => s.FrontUuid == uuid);

            if (survey.IsFinished)
                return survey.AfterLife;

            var heavenPoints = 0;
            var hellPoints = 0;
            var valhallaPoints = 0;
            var helPoints = 0;

            if (survey.Gluttony.Cookies)
            {
                heavenPoints += 10;
                helPoints += 10;
            }
            else
            {
                helPoints += 10;
                valhallaPoints += 10;
            }

            if (survey.Gluttony.FastFood)
            {
                hellPoints += 10;
            }
            else
            {
                heavenPoints += 10;
            }

            if (survey.Gluttony.EatingInDay == 3)
            {
                heavenPoints += 10;
            }
            else if (survey.Gluttony.EatingInDay > 3)
            {
                hellPoints += survey.Gluttony.EatingInDay / 3 * 10;
                helPoints += survey.Gluttony.EatingInDay / 5 * 10;
            }
            else if (survey.Gluttony.EatingInDay < 3)
            {
                hellPoints += 5;
            }

            valhallaPoints += (survey.Gluttony.EatingInDay >= 3 && survey.Gluttony.EatingInDay <= 5) ? 10 : 0;

            var most3types = survey.Gluttony.MostImportantType.HasFlag(FoodTime.Breakfast) &&
                survey.Gluttony.MostImportantType.HasFlag(FoodTime.Lunch) &&
                survey.Gluttony.MostImportantType.HasFlag(FoodTime.Dinner);

            heavenPoints += most3types ? 10 : 0;
            valhallaPoints += most3types ? 10 : 0;
            valhallaPoints += survey.Gluttony.MostImportantType.HasFlag(FoodTime.BeforeBattle) ? 10 : 0;

            if (survey.Greed.Hoard)
            {
                if (survey.Greed.AreYouDragon)
                {
                    heavenPoints += 10;
                    valhallaPoints += 10;
                }
                else
                {
                    hellPoints += 10;
                }
            }
            else
            {
                heavenPoints += 10;
                valhallaPoints += 10;
            }

            switch (survey.Greed.Collections)
            {
                case CollectionType.NoCollection:
                    helPoints += 10;
                    break;
                case CollectionType.Small:
                    valhallaPoints += 5;
                    heavenPoints += 10;
                    break;
                case CollectionType.Big:
                    hellPoints += 5;
                    valhallaPoints += 10;
                    break;
                case CollectionType.Passion:
                    hellPoints += 10;
                    break;
            }

            if (survey.Greed.Collections != CollectionType.NoCollection)
            {
                if (survey.Greed.TouchebleCollection)
                {
                    heavenPoints += 10;
                    valhallaPoints += 10;
                }
                else
                {
                    hellPoints += 10;
                    helPoints += 10;
                }
            }

            if (survey.Sloth.PassiveRest)
            {
                helPoints += 20;
                hellPoints += 10;
            }
            else
            {
                valhallaPoints += 10;
                heavenPoints += 10;
            }

            switch (survey.Sloth.ReactionOnAccident)
            {
                case ReactionOnAccidentType.Help:
                    heavenPoints += 20;
                    valhallaPoints += 20;
                    break;
                case ReactionOnAccidentType.StartRecording:
                    hellPoints += 5;
                    break;
                case ReactionOnAccidentType.GoAway:
                    hellPoints += 10;
                    helPoints += 10;
                    break;
                case ReactionOnAccidentType.AtHome:
                    hellPoints += 10;
                    helPoints += 20;
                    break;
            }

            switch (survey.Sloth.Servants)
            {
                case ServantsType.DoMyself:
                    heavenPoints += 20;
                    valhallaPoints += 20;
                    break;
                case ServantsType.Greed:
                    hellPoints += 5;
                    break;
                case ServantsType.Yes:
                    helPoints += 5;
                    hellPoints += 10;
                    break;
                case ServantsType.OnlyMaid:
                    hellPoints += 10;
                    break;
            }

            if ((survey.Sloth.LazyDescription ?? string.Empty).Length > 20)
            {
                heavenPoints += 5;
            }
            else
            {
                hellPoints += 10;
                helPoints += 5;
            }

            if (survey.Wrath.EasyToAnger)
            {
                if (survey.Wrath.TryingToControl)
                {
                    heavenPoints += 5;
                }
                else
                {
                    hellPoints += 10;

                    if (survey.Wrath.GodOfWar)
                    {
                        hellPoints += 10;
                        valhallaPoints += 10;
                    }
                }
                valhallaPoints += 10;
            }

            hellPoints += survey.Wrath.BrokenItems / 10 * 10;
            valhallaPoints += survey.Wrath.BrokenItems / 10 * 10;

            if (survey.Envy.EnvyToFriend)
            {
                hellPoints += 10;
                helPoints += 10;
                if (survey.Envy.TryToAnnoy)
                {
                    hellPoints += 10;
                    helPoints += 10;
                }
            }
            else
            {
                heavenPoints += 10;
                valhallaPoints += 10;
            }

            if (survey.Envy.ProudOfTheLeader)
            {
                heavenPoints += 10;
                valhallaPoints += 10;
            }
            else
            {
                hellPoints += 10;
            }

            if (survey.Pride.AcceptFail)
            {
                heavenPoints += 10;
            }
            else
            {
                hellPoints += 10;
            }

            switch (survey.Pride.WhoFail)
            {
                case WhoFail.Me:
                    heavenPoints += 20;
                    break;
                case WhoFail.Other:
                    hellPoints += 10;
                    helPoints += 10;
                    break;
                case WhoFail.Both:
                    heavenPoints += 10;
                    valhallaPoints += 10;
                    break;
            }

            if (survey.Pride.BetterThanOther)
            {
                hellPoints += 10;
            }
            else
            {
                heavenPoints += 10;
            }

            if (survey.Lust.PassionDream)
            {
                hellPoints += 10;
                if (survey.Lust.IllegalActions)
                {
                    hellPoints += 10;
                }
            }
            else
            {
                heavenPoints += 10;
                helPoints += 10;
            }

            if (survey.Lust.WasInOrgies)
            {
                hellPoints += 10;
                helPoints += 10;
            }
            else
            {
                valhallaPoints += 10;
                heavenPoints += 10;
            }

            if (survey.Lust.HowManyPartners > 1)
            {
                hellPoints += survey.Lust.HowManyPartners / 4 * 10;
            }
            else
            {
                heavenPoints += 10;
            }

            var results = new (AfterLifeType type, int score)[4]
                {
                    (AfterLifeType.Heaven,heavenPoints),
                    (AfterLifeType.Hell,hellPoints),
                    (AfterLifeType.Valhalla,valhallaPoints),
                    (AfterLifeType.Hel,helPoints)
                };

            var result = results.OrderByDescending(r => r.score).First();

            survey.IsFinished = true;
            survey.HeavenPoints = heavenPoints;
            survey.HellPoints = hellPoints;
            survey.HelPoints = helPoints;
            survey.ValhallaPoints = valhallaPoints;
            survey.AfterLife = result.type;
            _context.SaveChanges();

            return result.type;
        }

    }
}
