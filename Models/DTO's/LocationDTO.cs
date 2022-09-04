using DAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.DTO_s
{
    public class LocationDTO
    {   
        public int Id { get; set; }
        public string Name { get; set; }

        public Adress Adress { get; set; }
        public List<PublicEvent> PublicEvents { get; set; }

        public LocationDTO(Location location)
        {
            this.Id = location.Id;
            this.Name = location.Name;
            this.Adress = new Adress();
            this.PublicEvents = new List<PublicEvent>();
        }
    }
}
