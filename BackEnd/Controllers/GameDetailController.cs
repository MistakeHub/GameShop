using AutoMapper;
using BackEnd.Models;
using BackEnd.Models.Repository.PublicationRepository;
using BackEnd.Models.ViewModels;
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
    public class GameDetailController : ControllerBase
    {
        private IPublicationRepository context;
        private IMapper _mapper;


        public GameDetailController(IPublicationRepository _context, IMapper mapper)
        {

            this.context = _context;
            this._mapper = mapper;
        }

        [HttpGet("{titleofgame}")]
        public PublicationViewModel Get(string titleofgame)
         {


            var data = context.GetPublication(titleofgame);
            var dataViewModel = _mapper.Map<PublicationViewModel>(data);


            return dataViewModel;

        }

        // GET api/<GameDetailController>/5
      
        // POST api/<GameDetailController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GameDetailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GameDetailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
