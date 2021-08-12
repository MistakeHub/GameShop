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
    public class RoleController : ControllerBase
    {

        private IGenericRepository<Role> _context;

        public RoleController(IGenericRepository<Role> context)
        {
            _context = context;

        }

        [HttpGet]
        public IEnumerable Get()
        {
          
            var data = _context.GetElements();

            _context.SaveToXml("genre.xml", data);

            return data;
        }
        // GET: api/<RoleController>
        [HttpGet("{page}")]
        public (IEnumerable, int) Get(int page, int pagesize)
        {
            int total;
            var data = _context.GetElementsByPage(page, out total, pagesize);



            return (data, total);
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RoleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
