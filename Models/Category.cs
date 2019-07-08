using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLSplash2019.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<LocationCategory> LocationCategories { get; set; }

    }
}
