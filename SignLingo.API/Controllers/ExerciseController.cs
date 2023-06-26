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
    public class ExerciseController : ControllerBase
    {
        private IExerciseInfrastructure _exerciseInfrastructure;
        private IMapper _mapper;
        private IExerciseDomain _exerciseDomain;

        // GET: api/Answer
        public ExerciseController(IExerciseInfrastructure exerciseInfrastructure, IMapper mapper,
            IExerciseDomain exerciseDomain)
        {
            _exerciseInfrastructure = exerciseInfrastructure;
            _mapper = mapper;
            _exerciseDomain = exerciseDomain;
        }

        [HttpGet]
        public async Task<IEnumerable<ExerciseResponse>> GetAllAsync()
        {
            var exercises = await _exerciseInfrastructure.GetAllAsync();

            var exerciseResponses = _mapper.Map<List<Exercise>, List<ExerciseResponse>>(exercises);

            return exerciseResponses;
        }
        
        [Filter.Authorize("client,admin")]
        [HttpGet("module-exercise")]
        public async Task<IActionResult> GetExercisesByModuleNameAsync([FromQuery(Name = "module")]string moduleName)
        {
            var exercises = await _exerciseInfrastructure.GetExercisesByModuleNameAsync(moduleName);
            var exercisesResponse = _mapper.Map<List<Exercise>, List<ExerciseResponse>>(exercises);
            return Ok(exercisesResponse);
        }

        // GET: api/Exercise/5
        [HttpGet("{id}", Name = "GetExercise")]
        public async Task<ExerciseResponse> Get(int id)
        {
            var exercise = await _exerciseInfrastructure.GetByIdAsync(id);

            var exerciseResponse = _mapper.Map<Exercise, ExerciseResponse>(exercise);

            return exerciseResponse;
        }

        // GET: api/Exercise/Module/1
        [HttpGet("Exercise/{id}", Name = "GetByModule")]
        public async Task<IEnumerable<ExerciseResponse>> GetByModule(int id)
        {
            var exercises = await _exerciseInfrastructure.GetByModuleIdAsync(id);

            var exerciseResponses = _mapper.Map<List<Exercise>, List<ExerciseResponse>>(exercises);

            return exerciseResponses;
        }

        // POST: api/Exercise
        [HttpPost]
        public async Task PostAsync([FromBody] ExerciseRequest request)
        {
            if (ModelState.IsValid)
            {
                var exercise = _mapper.Map<ExerciseRequest, Exercise>(request);

                await _exerciseDomain.SaveAsync(exercise);
            }
            else
            {
                StatusCode(400);
            }
        }

        // PUT: api/Exercise/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] ExerciseRequest request)
        {
            var exercise = _mapper.Map<ExerciseRequest, Exercise>(request);

            await _exerciseDomain.UpdateAsync(id, exercise);
        }

        // DELETE: api/Exercise/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _exerciseDomain.DeleteAsync(id);
        }
    }
}