using BackEnd.Models;
using BackEnd.Models.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private IGenericRepository<Platform> _context;

        public PlatformController( IGenericRepository<Platform> context)
        {
            _context = context;

        }
        // GET: api/<PlatformController>
        [HttpGet]
        public IEnumerable Get()
        {
            return _context.GetTitles();
        }

        // GET api/<PlatformController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PlatformController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PlatformController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PlatformController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
