using AutoMapper;
using SignLingo.API.Filter;
using Microsoft.AspNetCore.Authorization;
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
    public class UserController : ControllerBase
    {
        private readonly IUserInfrastructure _userInfrastructure;
        private readonly IMapper _mapper;
        private readonly IUserDomain _userDomain;

        public UserController(IUserInfrastructure userInfrastructure, IMapper mapper, IUserDomain userDomain)
        {
            _userInfrastructure = userInfrastructure;
            _mapper = mapper;
            _userDomain = userDomain;
        }
        
        // GET: api/User
        [Filter.Authorize("admin")]
        [HttpGet]
        public async Task<IEnumerable<UserResponse>> GetAllAsync()
        {
            var users = await _userInfrastructure.GetAllAsync();
            
            var userResponses = _mapper.Map<List<User>, List<UserResponse>>(users);

            return userResponses;
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<UserResponse> Get(int id)
        {
            var user = await _userInfrastructure.GetByIdAsync(id);

            var userResponse = _mapper.Map<User, UserResponse>(user);

            return userResponse;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserInputLogin userInput)
        {
            try
            {
                var user = _mapper.Map<UserInputLogin, User>(userInput);
                var jwt = await _userDomain.Login(user);
                return Ok(jwt);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> Signup([FromBody] UserRequest userInput)
        {
            try
            {
                var user = _mapper.Map<UserRequest, User>(userInput);
                var userCreated = await _userDomain.SignUp(user);
                var userCreatedResponse = _mapper.Map<User, UserResponse>(userCreated);
                return Created($"api/v1/destinations/signup", userCreatedResponse);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // POST: api/User
        [HttpPost]
        public async Task PostAsync([FromBody] UserRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserRequest, User>(request);

                await _userDomain.SaveAsync(user);
            }
            else
            {
                StatusCode(400);
            }
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] UserRequest request)
        {
            var user = _mapper.Map<UserRequest, User>(request);
            await _userDomain.UpdateAsync(id, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _userDomain.DeleteAsync(id);
        }
    }
}
