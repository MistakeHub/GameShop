using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    [Serializable]
    [Table("gameregionrestricts")]
    public class Gameregionrestrict
    {

      
              
       public int? GameId { get; set; }
     
        public virtual Game Game { get; set; } 

     



        public int? RegionrestrictId { get; set; }
      
        public virtual Country RegionRestrict { get; set; } 

   


    
    }
}
