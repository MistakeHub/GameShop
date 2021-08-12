using BackEnd.Models;
using BackEnd.Models.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private IGenericRepository<Genre> _context;

        public GenreController(IGenericRepository<Genre> context)
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
        // GET: api/<GenresController>
        [HttpGet]
        public IEnumerable Get()
        {
            return _context.GetTitles();
        }

        // GET api/<GenresController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GenresController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GenresController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GenresController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
