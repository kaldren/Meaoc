using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Meaoc_API.Services;
using Meaoc_API.Helpers;
using Meaoc_API.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Meaoc_API.Domain.Dtos;

namespace Meaoc_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUserService _userRepository;
        private readonly IMapper _mapper;
        public ValuesController(IUserService userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserDto createUserDto)
        {
            var userToCreate = _mapper.Map<User>(createUserDto);
            await _userRepository.Create(userToCreate, createUserDto.Password);
            return Ok(createUserDto);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
