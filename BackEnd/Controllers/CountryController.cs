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
    public class CountryController : ControllerBase
    {

        private IGenericRepository<Country> _context;

        public CountryController(IGenericRepository<Country> context)
        {

            _context = context;

        }
        // GET: api/<CountryController>
        [HttpGet("{page}")]
        public (IEnumerable, int) Get(int page, int pagesize)
        {
            int total;
            var data = _context.GetElementsByPage(page, out total, pagesize);



            return (data, total);
        }

        // GET api/<CountryController>/5
        [HttpGet]
        public IEnumerable GetTitles()
        {
            return _context.GetTitles();
        }

        // POST api/<CountryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
