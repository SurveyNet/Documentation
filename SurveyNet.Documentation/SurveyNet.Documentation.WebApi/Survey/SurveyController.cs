using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SurveyNet.Documentation.DataLayer.Repositories;

namespace SurveyNet.Documentation.WebApi.Survey {
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyController : ControllerBase {
        private readonly ISurveyRepository repository;

        public SurveyController(ISurveyRepository repository) {
            this.repository = repository;
        }

        [HttpPost("NewSurvey")]
        public IActionResult NewSurvey() {
            IEnumerable<Domain.Survey> e = repository.Surveys;
            return Ok();
        }
    }
}