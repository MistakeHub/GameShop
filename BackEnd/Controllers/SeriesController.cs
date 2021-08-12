using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using BackEnd.Models.Repository.GenericRepository;
using BackEnd.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private IGenericRepository<Serie> _context;

        public SeriesController( IGenericRepository<Serie> context)
        {
            _context = context;

        }


        [HttpGet("{page}")]
        public (IEnumerable, int) Get(int page, int pagesize)
        {
            int total;
            var data = _context.GetElementsByPage(page, out total, pagesize);



            return (data, total);
        }
        // GET: api/<SeriesController>
        [HttpGet]
        public IEnumerable Get()
        {
            return _context.GetTitles();
        }

        // GET api/<SeriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SeriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SeriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SeriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
