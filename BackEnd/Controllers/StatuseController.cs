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
    public class StatuseController : ControllerBase
    {

        private IGenericRepository<Statuse> context;
        
        public StatuseController(IGenericRepository<Statuse> _context)
        {

            context = _context;

        }
        // GET: api/<StatuseController>

        [HttpGet("getAll")]
        public (IEnumerable, int) Get()
        {
            int total;
            var data = context.GetElements(out total);



            return (data, total);
        }
        // GET: api/<LocalizationController>
        [HttpGet]
        public IEnumerable GetTitles()
        {
            return context.GetTitles();
        }


        // POST api/<StatuseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StatuseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StatuseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
