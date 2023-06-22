using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SignLingo.API.Request;
using SignLingo.API.Response;
using SignLingo.Domain.Interfaces;
using SignLingo.Infrastructure.Interfaces;
using SignLingo.Infrastructure.Models;

namespace SignLingo.API.Controllers{

    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private IModuleInfrastructure _moduleInfrastructure;
        private IMapper _mapper;
        private IModuleDomain _moduleDomain;

        // GET: api/User
        public ModuleController(IModuleInfrastructure moduleInfrastructure, IMapper mapper, IModuleDomain moduleDomain)
        {
            _moduleInfrastructure = moduleInfrastructure;
            _mapper = mapper;
            _moduleDomain = moduleDomain;
        }

        [HttpGet]
        public async Task<IEnumerable<ModuleResponse>> GetAllAsync()
        {
            var modules = await _moduleInfrastructure.GetAllAsync();

            var moduleResponses = _mapper.Map<List<Module>, List<ModuleResponse>>(modules);

            return moduleResponses;
        }

        // GET: api/Module/5
        [HttpGet("{id}", Name = "GetModule")]
        public async Task<ModuleResponse> Get(int id)
        {
            var module = await _moduleInfrastructure.GetByIdAsync(id);

            var moduleResponse = _mapper.Map<Module, ModuleResponse>(module);

            return moduleResponse;
        }

        // POST: api/Module
        [HttpPost]
        public async Task PostAsync([FromBody] ModuleRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<ModuleRequest, Module>(request);

                await _moduleDomain.SaveAsync(user);
            }
            else
            {
                StatusCode(400);
            }
        }

        // PUT: api/Module/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] ModuleRequest request)
        {
            var user = _mapper.Map<ModuleRequest, Module>(request);
            await _moduleDomain.UpdateAsync(id, user);
        }

        // DELETE: api/Module/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _moduleDomain.DeleteAsync(id);
        }
    }
}