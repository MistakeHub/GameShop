using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.ViewModels
{
    public class PublicationViewModel
    {
        public int Id { get; set; }

        public string Titleofgame { get; set; }

        public string Description { get; set; }

        public string[] Localizations { get; set; }

        public string[] Manufactures { get; set; }
        
        public string[] Genres { get; set; }

        public string[] RegionRestricts { get; set; }

        public string[] Platforms { get; set; }
        
        public string Series { get; set; }

        public double Price { get; set; }

        public int[] Marks { get; set; }

        public double Rating { get; set; }

        public string DateRealese  { get; set; }

        public string[] Images { get; set; }

        public List<Comment> Comments { get; set; }
    
    }
}
