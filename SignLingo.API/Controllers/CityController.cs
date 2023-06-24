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
    public class CityController : ControllerBase
    {
        private readonly ICityInfrastructure _cityInfrastructure;
        private readonly ICityDomain _cityDomain;
        private readonly IMapper _mapper;
        
        public CityController(ICityInfrastructure cityInfrastructure, IMapper mapper, ICityDomain cityDomain)
        {
            _cityInfrastructure = cityInfrastructure;
            _cityDomain = cityDomain;
            _mapper = mapper;
        }
        
        // GET: api/City
        [HttpGet]
        public async Task<IEnumerable<CityResponse>> Get()
        {
            var cities = await _cityInfrastructure.GetAllAsync();
            var cityResponses = _mapper.Map<List<City>, List<CityResponse>>(cities);
            return cityResponses;
        }

        // GET: api/City/5
        [HttpGet("{id}", Name = "GetAllCity")]
        public async Task<CityResponse> Get(int id)
        {
            var city = await _cityInfrastructure.GetByIdAsync(id);
            var cityResponse = _mapper.Map<City, CityResponse>(city);
            return cityResponse;
        }

        // POST: api/City
        [HttpPost]
        public async Task Post([FromBody] CityRequest cityRequest)
        {
            if (ModelState.IsValid)
            {
                var city = _mapper.Map<CityRequest, City>(cityRequest);
                await _cityDomain.SaveAsync(city);
            }
            else
            {
                StatusCode(400);
            }
        }

        // PUT: api/City/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] CityRequest cityRequest)
        {
            var city = _mapper.Map<CityRequest, City>(cityRequest);
            await _cityDomain.UpdateAsync(id, city);
        }

        // DELETE: api/City/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _cityDomain.DeleteAsync(id);
        }
    }
}
