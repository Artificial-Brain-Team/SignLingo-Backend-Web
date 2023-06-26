using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SignLingo.API.Request;
using SignLingo.API.Response;
using SignLingo.Domain.Interfaces;
using SignLingo.Infrastructure.Interfaces;
using SignLingo.Infrastructure.Models;

namespace SignLingo.API.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerInfrastructure _answerInfrastructure;
        private readonly IMapper _mapper;
        private readonly IAnswerDomain _answerDomain;

        public AnswerController(IAnswerInfrastructure answerInfrastructure, IMapper mapper, IAnswerDomain answerDomain)
        {
            _answerInfrastructure = answerInfrastructure;
            _mapper = mapper;
            _answerDomain = answerDomain;
        }

        // GET: api/Answer
        [HttpGet]
        public async Task<IEnumerable<AnswerResponse>> GetAllAsync()
        {
            var answers = await _answerInfrastructure.GetAllAsync();

            var answerResponses = _mapper.Map<List<Answer>, List<AnswerResponse>>(answers);

            return answerResponses;
        }

        // GET: api/Answer/Exercise/1
        [Filter.Authorize("client,admin")]
        [HttpGet("exercise-answer")]
        public async Task<IEnumerable<AnswerResponse>> Get([FromQuery(Name = "exerciseId")]int id)
        {
            var answers = await _answerInfrastructure.GetByExerciseIdAsync(id);

            var answerResponses = _mapper.Map<List<Answer>, List<AnswerResponse>>(answers);

            return answerResponses;
        }

        // POST: api/Answer
        [HttpPost]
        public async Task PostAsync([FromBody] AnswerRequest request)
        {
            if (ModelState.IsValid)
            {
                var answer = _mapper.Map<AnswerRequest, Answer>(request);

                await _answerDomain.SaveAsync(answer);
            }
            else
            {
                StatusCode(400);
            }
        }

        // PUT: api/Answer/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] AnswerRequest request)
        {
            var user = _mapper.Map<AnswerRequest, Answer>(request);
            await _answerDomain.UpdateAsync(id, user);
        }

        // DELETE: api/Answer/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _answerDomain.DeleteAsync(id);
        }
    }
}