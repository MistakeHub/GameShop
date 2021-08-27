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
        [HttpGet("getAll")]
        public (IEnumerable, int) Get()
        {
            int total;
            var data = _context.GetElements(out total);



            return (data, total);
        }
        // GET: api/<LocalizationController>
        [HttpGet]
        public IEnumerable GetTitles()
        {
            return _context.GetTitles();
        }


        // GET api/<GenresController>/5


        // POST api/<GenresController>
        // POST api/<CountryController>
        [HttpPost("add")]
        public void Post(string title)
        {
            _context.AddElement(title);
        }

        // PUT api/<CountryController>/5
        [HttpPut("edit/{id}")]
        public void Put(int id, string title)
        {
            _context.EditElement(id, title);
        }

        // DELETE api/<GenresController>/5
        [HttpDelete("removeGenre/{id}")]
        public void Delete(int id)
        {
            _context.RemoveElement(id);
        }

        [Route("savetojson")]
        [HttpPost]
        public StatusCodeResult SaveToJson()
        {
            _context.SaveToJson();

            return Ok();

        }

        [Route("loadfromjson")]
        [HttpPost]
        public StatusCodeResult LoadFromJson()
        {
            _context.LoadfromJson();

            return Ok();

        }

    }
}
