using AutoMapper;
using BackEnd.Models;
using BackEnd.Models.Repository.PublicationRepository;
using BackEnd.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {

        private IPublicationRepository _context;
        private IMapper _mapper;
        private IWebHostEnvironment _appEnvironment;

        // GET: api/<CatalogController>

        public CatalogController(IPublicationRepository context, IMapper mapper, IWebHostEnvironment appEnvironment)
        {

            this._context = context;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
        }

        [Route("getImage/{titleofgame}/{titleimage}")]
        [HttpGet]
        public IActionResult getImage(string titleofgame,string titleimage)
        {

            byte[] b = System.IO.File.ReadAllBytes(@$"wwwroot\images\{titleofgame}\{titleimage}");   // You can use your own method over here.
                                                                    
            return File(b, "image/png");

        }

        [Route("getAll")]
        [HttpGet]
        public (IEnumerable, int) GetAll()
        {
            int total;
            var data = _context.GetAll(out total);
            var dataViewModel = _mapper.Map<List<PublicationViewModel>>(data);


            return (dataViewModel, total);
        }


        [HttpGet("{page}")]
        public (IEnumerable, int) Get(int page, int pagesize)
        {
            int total;
            var data = _context.GetPublications(page, out total, pagesize );
            var dataViewModel = _mapper.Map<List<PublicationViewModel>>(data);


            return (dataViewModel, total);
        }

        [Route("filter")]
        [HttpGet]
        public (IEnumerable, int) Filter([FromQuery(Name ="genres[]")]string[] genres, [FromQuery(Name = "manufactures[]")] string[ ] manufactures, [FromQuery(Name = "platforms[]")] string[] platforms, [FromQuery(Name = "localizations[]")] string[] localizations)
        {

            var data = _context.GetManyPublication(genres, manufactures, platforms, localizations);
            var dataViewModel = _mapper.Map<List<PublicationViewModel>>(data);
            int total=data.Count();

            return (dataViewModel, total);
        }


        [Route("sortbydaterealese")]
        [HttpGet]
        public (IEnumerable, int) SortByDateRealese([FromQuery(Name = "genres[]")] string[] genres, [FromQuery(Name = "manufactures[]")] string[] manufactures, [FromQuery(Name = "platforms[]")] string[] platforms, [FromQuery(Name = "localizations[]")] string[] localizations)
        {
            var data = _context.GetManyPublication(genres, manufactures, platforms, localizations).OrderByDescending(d=>d.Game.DateRelese);
            var dataViewModel = _mapper.Map<List<PublicationViewModel>>(data);

            int total = data.Count();

            return (dataViewModel, total);

        }


        [Route("sortbytitle")]
        [HttpGet]
        public (IEnumerable, int) SortByTitle([FromQuery(Name = "genres[]")] string[] genres, [FromQuery(Name = "manufactures[]")] string[] manufactures, [FromQuery(Name = "platforms[]")] string[] platforms, [FromQuery(Name = "localizations[]")] string[] localizations)
        {
            var data = _context.GetManyPublication(genres, manufactures, platforms, localizations).OrderBy(d => d.Game.Titleofgame);
            var dataViewModel = _mapper.Map<List<PublicationViewModel>>(data);

            int total = data.Count();

            return (dataViewModel, total);

        }


        [Route("sortbyprice")]
        [HttpGet]
        public (IEnumerable, int) SortByPrice([FromQuery(Name = "genres[]")] string[] genres, [FromQuery(Name = "manufactures[]")] string[] manufactures, [FromQuery(Name = "platforms[]")] string[] platforms, [FromQuery(Name = "localizations[]")] string[] localizations)
        {
            var data = _context.GetManyPublication(genres, manufactures, platforms, localizations).OrderByDescending(d => d.Price);
            var dataViewModel = _mapper.Map<List<PublicationViewModel>>(data);

            int total = data.Count();

            return (dataViewModel, total);

        }


        [Route("sortbyrating")]
        [HttpGet]
        public (IEnumerable, int) SortByRating([FromQuery(Name = "genres[]")] string[] genres, [FromQuery(Name = "manufactures[]")] string[] manufactures, [FromQuery(Name = "platforms[]")] string[] platforms, [FromQuery(Name = "localizations[]")] string[] localizations)
        {
            var data = _context.GetManyPublication(genres, manufactures, platforms, localizations).OrderByDescending(d => d.Rating);
            var dataViewModel = _mapper.Map<List<PublicationViewModel>>(data);

            int total = data.Count();

            return (dataViewModel, total);

        }

        [Route("getpublication/{id}")]
        [HttpGet]

        public Publication GetPublication(int id)
        {

            return _context.GetPublicationbyId(id);

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


        [Route("editpublication/{id}")]
        [HttpPost]
        public StatusCodeResult EditPublication(int id, [FromForm(Name = "images")] IList<IFormFile> images, string titleofgame, string description, DateTime dateRealese, [FromQuery(Name = "genres[]")] string[] genres, [FromQuery(Name = "manufactures[]")] string[] manufactures, [FromQuery(Name = "platforms[]")] string[] platforms, [FromQuery(Name = "localizations[]")] string[] localizations, [FromQuery(Name = "regionrestricts[]")] string[] regionrestricts, string series, double price)
        {


            _context.EditPublication(id,images,_appEnvironment.WebRootPath, titleofgame, description, dateRealese, platforms, localizations, genres, manufactures, regionrestricts, series, price);

            return Ok();

        }


        [Route("file")]
        [HttpPost]

        public StatusCodeResult AddPublications(FormFile images)
        {

            //  _context.AddPublication(_context.Uploads(images,_appEnvironment,$"/images/{titleofgame}/"), titleofgame, description, dateRealese, platforms, localizations, genres, manufactures, regionrestricts, series, price);

            return Ok();

        }

        [Route("addPublication")]
        [HttpPost]

        public StatusCodeResult AddPublication([FromForm(Name = "images")] IList<IFormFile> images,string titleofgame,string description,DateTime dateRealese,[FromQuery(Name = "genres[]")] string[] genres, [FromQuery(Name = "manufactures[]")] string[] manufactures, [FromQuery(Name = "platforms[]")] string[] platforms, [FromQuery(Name = "localizations[]")] string[] localizations, [FromQuery(Name = "regionrestricts[]")] string[] regionrestricts, string series, double price)
        {

           _context.AddPublication(images,_appEnvironment.WebRootPath, titleofgame, description, dateRealese, platforms, localizations, genres, manufactures, regionrestricts, series, price);

            return Ok();

        }

        [Route("removePublication/{id}")]
        [HttpDelete]

        public StatusCodeResult removePublicatio(int id)
        {

            _context.RemovePublication(id);

            return Ok();

        }


    }
    
}
