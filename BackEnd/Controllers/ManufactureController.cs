﻿using BackEnd.Models;
using BackEnd.Models.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.AspNetCore.Authorization;

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


        // POST api/<CountryController>
        [HttpPost("add")]
        [Authorize(Roles = "Редактор,Администратор")]
        public void Post(string title)
        {
            _context.AddElement(title);
        }

        // PUT api/<CountryController>/5
        [HttpPut("edit/{id}")]
        [Authorize(Roles = "Редактор,Администратор")]
        public void Put(int id, string title)
        {
            _context.EditElement(id, title);
        }
        // DELETE api/<ManufactureController>/5
        [HttpDelete("removeManufacture/{id}")]
        public void Delete(int id)
        {
            _context.RemoveElement(id);
        }


        [Route("savetojson")]
        [HttpPost]
        [Authorize(Roles = "Редактор,Администратор")]
        public StatusCodeResult SaveToJson()
        {
            _context.SaveToJson();

            return Ok();

        }

        [Route("loadfromjson")]
        [HttpPost]
        [Authorize(Roles = "Редактор,Администратор")]
        public StatusCodeResult LoadFromJson()
        {
            _context.LoadfromJson();

            return Ok();

        }

        [Route("removeall")]
        [HttpDelete]
        [Authorize(Roles = "Редактор,Администратор")]
        public StatusCodeResult RemoveAll()
        {
            _context.RemoveAll();

            return Ok();

        }
    }
}
