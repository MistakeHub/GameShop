using AutoMapper;
using BackEnd.Models.Repository.CartRepository;
using BackEnd.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private ICartRepository _context;
        private IMapper _mapper;

        public CartController(ICartRepository context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }

        // GET: api/<CartController>
        [HttpGet("{user}")]
        public CartViewModel Get(string user)

        {
    

            var data = _context.GetCart(user);
            var cartviewwmodel = _mapper.Map<CartViewModel>(data);

            return cartviewwmodel;
        }

        [HttpGet("count")]
        public int Countof(string user)

        {

            var data = _context.GetCart(user);


            return data.Publications.Count();
        }



        // POST api/<CartController>
        [HttpPost]
        public StatusCodeResult Post([FromQuery] string username,[FromQuery] string game )
        {

            _context.AddToCart(username, game);
            return StatusCode(200);

        }

        // PUT api/<CartController>/5
       
        // DELETE api/<CartController>/5
        [HttpDelete("{user}")]
        public void Delete(string user,string game)
        {
            _context.RemoveFromCart(user,game);

        }

        [HttpDelete("purchase/{id}")]

        public StatusCodeResult Purchase(int id)
        {

            _context.Purchase(id);
            return Ok();
        }
    }
}
