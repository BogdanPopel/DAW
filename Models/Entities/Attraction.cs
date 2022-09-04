using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.Entities
{
    public class Attraction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Descriere { get; set; }
        public ICollection<EventAttraction> EventAttractions { get; set; }
    }
}
