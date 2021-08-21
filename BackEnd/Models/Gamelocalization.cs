using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Gamelocalization
    {

        public int? GameId { get; set; }

        public virtual Game Game { get; set; }




        public int? LocalizationId { get; set; }

        public virtual Localization Localization { get; set; }
    }
}
