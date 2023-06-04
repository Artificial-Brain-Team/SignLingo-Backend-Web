using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignLingo.API.Request;
using SignLingo.API.Response;
using SignLingo.Domain;
using SignLingo.Infrastructure;
using SignLingo.Infrastructure.Models;

namespace SignLingo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryInfrastructure _countryInfrastructure;
        private readonly ICountryDomain _countryDomain;
        private readonly IMapper _mapper;

        public CountryController(ICountryInfrastructure countryInfrastructure, ICountryDomain countryDomain ,IMapper mapper)
        {
            _countryInfrastructure = countryInfrastructure;
            _countryDomain = countryDomain;
            _mapper = mapper;
        }
        
        // GET: api/Country
        [HttpGet(Name = "GetAllCountries")]
        public async Task<IEnumerable<CountryResponse>> GetAllAsync()
        {
            var countries = await _countryInfrastructure.GetAllAsync();
            var countryResponses = _mapper.Map<List<Country>, List<CountryResponse>>(countries);
            return countryResponses;
        }

        // GET: api/Country/5
        [HttpGet("{id}", Name = "GetCountry")]
        public async Task<CountryResponse> Get(int id)
        {
            var country = await _countryInfrastructure.GetByIdAsync(id);
            var countryResponse = _mapper.Map<Country, CountryResponse>(country);
            return countryResponse;
        }

        // POST: api/Country
        [HttpPost]
        public async Task Post([FromBody] CountryRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<CountryRequest, Country>(request);

                await _countryDomain.SaveAsync(user);
            }
            else
            {
                StatusCode(400);
            }
        }

        // PUT: api/Country/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] CountryRequest request)
        {
            var country = _mapper.Map<CountryRequest, Country>(request);
            await _countryDomain.UpdateAsync(id, country);
        }

        // DELETE: api/Country/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _countryDomain.DeleteAsync(id);
        }
    }
}
