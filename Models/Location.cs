using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLSplash2019.Models
{
    public class Location
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }
        public string Description { get; set; }
        public int AverageRating { get; set; }
        public List<LocationRating> LocationRatings { get; set; }
        
        public IList<LocationCategory> LocationCategories { get; set; }
    }
}
