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
    public class LocalizationController : ControllerBase
    {
        private IGenericRepository<Localization> _context;

        public LocalizationController(  IGenericRepository<Localization> context)
        {
            _context = context;
        }
        // GET: api/<LocalizationController>
        [HttpGet]
        public IEnumerable Get()
        {
            return _context.GetTitles();
        }

        // GET api/<LocalizationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LocalizationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LocalizationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LocalizationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
