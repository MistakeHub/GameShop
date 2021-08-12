﻿using BackEnd.Models;
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
    

        [HttpGet("{page}")]
        public (IEnumerable, int) Get(int page, int pagesize)
        {
            int total;
            var data = context.GetElementsByPage(page, out total, pagesize);
            


            return (data, total);
        }
        // GET api/<StatuseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
