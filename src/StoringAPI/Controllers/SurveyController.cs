using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StoringAPI.Models.Requests;
using StoringAPI.Services;
using System;

namespace StoringAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(Cors.FrontendAppPolicy)]
    public class SurveyController : ControllerBase
    {
        private readonly IHohService _hohService;

        public SurveyController(IHohService hohService)
        {
            _hohService = hohService;
        }

        [HttpGet]
        public IActionResult Get(Guid uuid)
        {
            try
            {
                return Ok(_hohService.GetSurvey(uuid));
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpPost("[action]")]
        public IActionResult SavePersonal(PesonDataRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _hohService.SavePersonal(model.Uuid, model);
            return Ok();
        }

        [HttpPost("[action]")]
        public IActionResult SaveGluttony([FromBody] GluttonyRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _hohService.SaveGluttony(model.Uuid, model);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost("[action]")]
        public IActionResult SaveGreed([FromBody] GreedRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _hohService.SaveGreed(model.Uuid, model);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost("[action]")]
        public IActionResult SaveSloth([FromBody] SlothRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _hohService.SaveSloth(model.Uuid, model);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost("[action]")]
        public IActionResult SaveWrath([FromBody] WrathRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _hohService.SaveWrath(model.Uuid, model);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost("[action]")]
        public IActionResult SaveEnvy([FromBody] EnvyRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _hohService.SaveEnvy(model.Uuid, model);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost("[action]")]
        public IActionResult SavePride([FromBody] PrideRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _hohService.SavePride(model.Uuid, model);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost("[action]")]
        public IActionResult SaveLust([FromBody] LustRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _hohService.SaveLust(model.Uuid, model);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult GetResult(Guid uuid)
        {
            try
            {
                return Ok(new
                {
                    Result = _hohService.GetResult(uuid)
                });
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}
