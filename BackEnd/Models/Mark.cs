using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    [Serializable]
    [Table("marks")]
    public class Mark
    {

        public int Id { get; set; }
        [Range(0,5)]
        public double Numberofmark { get; set; }

    

        public int? idpublication { get; set; }

        public Publication Publication { get; set; }

        public int? iduser { get; set; }

        public User User { get; set; }
    }
}
