using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.Entities
{
    public class Adress
    {
        public int Id { get; set; }
        public string StreetNumber { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public int LocationId { get; set; }
    public Location Location { get; set; }
    }
}
