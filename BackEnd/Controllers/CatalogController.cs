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
    public class CatalogController : ControllerBase
    {

        private IPublicationRepository context;
        private IMapper _mapper;
       
        // GET: api/<CatalogController>

        public CatalogController(IPublicationRepository _context, IMapper mapper)
        {

            context = _context;
            _mapper = mapper;
          
        }
        [HttpGet("{id}")]
        public IEnumerable Get(int id)
        {

            var data = context.GetPublications(id);
            var dataViewModel = _mapper.Map<List<PublicationViewModel>>(data);


            return dataViewModel;
        }

        [Route("filter")]
        [HttpGet]
        public IEnumerable Filter([FromQuery(Name ="genres[]")]string[] genres, [FromQuery(Name = "manufactures[]")] string[ ] manufactures, [FromQuery(Name = "platforms[]")] string[] platforms, [FromQuery(Name = "localizations[]")] string[] localizations)
        {

            var data = context.GetManyPublication(genres, manufactures, platforms, localizations);
            var dataViewModel = _mapper.Map<List<PublicationViewModel>>(data);


            return  dataViewModel;
        }


        [Route("sortbydaterealese")]
        [HttpGet]
        public IEnumerable SortByDateRealese([FromQuery(Name = "genres[]")] string[] genres, [FromQuery(Name = "manufactures[]")] string[] manufactures, [FromQuery(Name = "platforms[]")] string[] platforms, [FromQuery(Name = "localizations[]")] string[] localizations)
        {
            var data = context.GetManyPublication(genres, manufactures, platforms, localizations).OrderByDescending(d=>d.Game.DateRelese);
            var dataViewModel = _mapper.Map<List<PublicationViewModel>>(data);

            return dataViewModel;

        }


        [Route("sortbytitle")]
        [HttpGet]
        public IEnumerable SortByTitle([FromQuery(Name = "genres[]")] string[] genres, [FromQuery(Name = "manufactures[]")] string[] manufactures, [FromQuery(Name = "platforms[]")] string[] platforms, [FromQuery(Name = "localizations[]")] string[] localizations)
        {
            var data = context.GetManyPublication(genres, manufactures, platforms, localizations).OrderBy(d => d.Game.Titleofgame);
            var dataViewModel = _mapper.Map<List<PublicationViewModel>>(data);

            return dataViewModel;

        }


        [Route("sortbyprice")]
        [HttpGet]
        public IEnumerable SortByPrice([FromQuery(Name = "genres[]")] string[] genres, [FromQuery(Name = "manufactures[]")] string[] manufactures, [FromQuery(Name = "platforms[]")] string[] platforms, [FromQuery(Name = "localizations[]")] string[] localizations)
        {
            var data = context.GetManyPublication(genres, manufactures, platforms, localizations).OrderByDescending(d => d.Price);
            var dataViewModel = _mapper.Map<List<PublicationViewModel>>(data);

            return dataViewModel;

        }


        [Route("sortbyrating")]
        [HttpGet]
        public IEnumerable SortByRating([FromQuery(Name = "genres[]")] string[] genres, [FromQuery(Name = "manufactures[]")] string[] manufactures, [FromQuery(Name = "platforms[]")] string[] platforms, [FromQuery(Name = "localizations[]")] string[] localizations)
        {
            var data = context.GetManyPublication(genres, manufactures, platforms, localizations).OrderByDescending(d => d.Rating);
            var dataViewModel = _mapper.Map<List<PublicationViewModel>>(data);

            return dataViewModel;

        }

        // GET api/<CatalogController>/5


        // POST api/<CatalogController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CatalogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CatalogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
