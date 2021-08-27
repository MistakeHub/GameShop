using BackEnd.Models.Repository.Record;
using BackEnd.Models.Repository.VisitorRepository;
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
        public IEnumerable Profitable()
        {
            return _context.MostProfitableProduct();
        }

        [HttpGet("purcheasableproducts")]
        public IEnumerable Purcheasable()
        {
            return _context.MostPurcheasableProduct();
        }

        // GET api/<RecordController>/5
        [HttpGet("visitorcount")]
        public int[] VisitorsCount()
        {
            return _contextvisitor.GetVisitor().Select(d => d.Count).ToArray();
        }

        // POST api/<RecordController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RecordController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecordController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
