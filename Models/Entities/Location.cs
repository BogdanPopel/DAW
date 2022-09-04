using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Adress Adress { get; set; }
        public ICollection<PublicEvent> PublicEvents { get; set; }
    }
}
