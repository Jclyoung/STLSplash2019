
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLSplash2019.Models
{
    public class LocationCategory
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
