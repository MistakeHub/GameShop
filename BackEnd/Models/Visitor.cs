using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Visitor
    {

        public int Id { get; set; }

        public int Count { get; set; }

        public DateTime StartPeriod { get; set; }

        public DateTime EndPeriod { get; set; }
    }
}
