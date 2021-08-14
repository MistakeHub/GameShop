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
    public class ManufactureController : ControllerBase
    {

        private IGenericRepository<Manufacture> _context;

        public ManufactureController(IGenericRepository<Manufacture> context)
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


        // POST api/<ManufactureController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ManufactureController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ManufactureController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
