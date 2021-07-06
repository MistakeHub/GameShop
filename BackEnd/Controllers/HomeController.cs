using AutoMapper;
using BackEnd.Models;
using BackEnd.Models.Repository.PublicationRepository;
using BackEnd.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class HomeController : ControllerBase
    {
        private IPublicationRepository context;
        private IMapper _mapper;
        private shopContext Context;

        public HomeController(IPublicationRepository _context, IMapper mapper,shopContext con)
        {
            this.Context = con;
            this.context = _context;
            this._mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        public IEnumerable Get()
        {

           
            var data = context.GetPublications(1);
            var dataViewModel = _mapper.Map<List<PublicationViewModel>>(data);
            

            return dataViewModel;
            
        }

        [HttpPost("{id}")]
       public void Remove(int id)
        {

            context.RemovePublication(id);

        }

        // GET api/<CountryController>/5
     
        
    }
}
