using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignLingo.API.Response;
using SignLingo.Infrastructure;
using SignLingo.Infrastructure.Models;

namespace SignLingo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserInfrastructure _userInfrastructure;
        private IMapper _mapper;

        public UserController(IUserInfrastructure userInfrastructure, IMapper mapper)
        {
            _userInfrastructure = userInfrastructure;
            _mapper = mapper;
        }
        
        // GET: api/User
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

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
