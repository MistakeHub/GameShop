using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int? Idpublication { get; set; }

        public Publication Publication { get; set; }

     

        public List<User> Users { get; set; }

    }
}
