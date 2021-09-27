using BackEnd.Models;
using BackEnd.Models.Repository.Record;
using BackEnd.Models.Repository.VisitorRepository;
using BackEnd.Models.SaveToFile;
using Microsoft.AspNetCore.Authorization;
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
    public class RecordController : ControllerBase
    {

        private IRecordRepository _context;
        private IVisitorRepository _contextvisitor;
        public RecordController(IRecordRepository context, IVisitorRepository visitorRepository)
        {
            _contextvisitor = visitorRepository;
            _context = context;
        }
        // GET: api/<RecordController>
        [HttpGet("profitableproducts")]
        [Authorize(Roles = "Редактор,Администратор")]
        public IEnumerable Profitable(DateTime? from, DateTime? to, [FromQuery(Name = "genres[]")] string[] genres, [FromQuery(Name = "manufactures[]")] string[] manufactures, [FromQuery(Name = "platforms[]")] string[] platforms, [FromQuery(Name = "localizations[]")] string[] localizations)
        {
            return _context.MostProfitableProduct(from,to, genres, manufactures, platforms, localizations);
        }

        [HttpGet("purcheasableproducts")]
        [Authorize(Roles = "Редактор,Администратор")]
        public IEnumerable Purcheasable(DateTime? from, DateTime? to, [FromQuery(Name = "genres[]")] string[] genres, [FromQuery(Name = "manufactures[]")] string[] manufactures, [FromQuery(Name = "platforms[]")] string[] platforms, [FromQuery(Name = "localizations[]")] string[] localizations)
        {
            return _context.MostPurcheasableProduct(from,to, genres, manufactures, platforms, localizations);
        }

        // GET api/<RecordController>/5
        [HttpGet("visitorcount")]
        [Authorize(Roles = "Редактор,Администратор")]
        public int[] VisitorsCount()
        {
            return _contextvisitor.GetVisitor().Select(d => d.Count).ToArray();
        }

        [HttpGet("ratingproducts")]
        [Authorize(Roles = "Редактор,Администратор")]
        public IEnumerable RatingProducts( [FromQuery(Name = "genres[]")] string[] genres, [FromQuery(Name = "manufactures[]")] string[] manufactures, [FromQuery(Name = "platforms[]")] string[] platforms, [FromQuery(Name = "localizations[]")] string[] localizations)
        {
            return _context.MostProfitableRatingProduct( genres, manufactures, platforms, localizations);
        }


        [HttpPut("ratingproducts/savetoexcel")]
        [Authorize(Roles = "Редактор,Администратор")]
        public StatusCodeResult SaveRatingToExcel([FromQuery(Name = "genres[]")] string[] genres, [FromQuery(Name = "manufactures[]")] string[] manufactures, [FromQuery(Name = "platforms[]")] string[] platforms, [FromQuery(Name = "localizations[]")] string[] localizations)
        {
             FileSave<IEnumerable>.SaveToExcel($"RatingProducts{DateTime.Today.Year}{DateTime.Today.Month}.csv", _context.MostProfitableRatingProduct(genres, manufactures, platforms, localizations));

            return Ok();
        }


        [HttpPut("purcheasableproducts/savetoexcel")]
        [Authorize(Roles = "Редактор,Администратор")]
        public StatusCodeResult SavePurcheasableToExcel(DateTime? from, DateTime? to, [FromQuery(Name = "genres[]")] string[] genres, [FromQuery(Name = "manufactures[]")] string[] manufactures, [FromQuery(Name = "platforms[]")] string[] platforms, [FromQuery(Name = "localizations[]")] string[] localizations)
        {
            FileSave<IEnumerable>.SaveToExcel($"PurcheasableProducts{DateTime.Today.Year}{DateTime.Today.Month}.csv", _context.MostPurcheasableProduct(from, to, genres, manufactures, platforms, localizations));

            return Ok();
        }


        [HttpPut("profitableproducts/savetoexcel")]
        [Authorize(Roles = "Редактор,Администратор")]
        public StatusCodeResult SaveprofitableToExcel(DateTime? from, DateTime? to, [FromQuery(Name = "genres[]")] string[] genres, [FromQuery(Name = "manufactures[]")] string[] manufactures, [FromQuery(Name = "platforms[]")] string[] platforms, [FromQuery(Name = "localizations[]")] string[] localizations)
        {
            FileSave<IEnumerable>.SaveToExcel($"ProfitableProducts{DateTime.Today.Year}{DateTime.Today.Month}.csv", _context.MostProfitableProduct(from, to, genres, manufactures, platforms, localizations));

            return Ok();
        }

    }
}
