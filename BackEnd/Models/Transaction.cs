using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Transaction
    {

        public int Id { get; set; }

        public int? PublicationId { get; set; }

        public Publication? Publication { get; set; }

        public int? UserId { get; set; }

        public User? User { get; set; }

        public DateTime DateOfOperation { get; set; }
    }
}
