using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLSplash2019.Models
{
    public class LocationRating
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }       
        public int Rating { get; set; }     
        public string Review { get; set; }
        public Location Location { get; set; }

    }
}
