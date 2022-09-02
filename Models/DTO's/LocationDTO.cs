using DAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.DTO_s
{
    public class LocationDTO
    {   
        public LocationDTO(Location location)
        {
            this.Id = location.Id;
            this.Name = location.Name;
            this.AdressId = location.AdressId;
            this.Adress = location.Adress;
            this.PublicEvents = new List<PublicEvent>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public int AdressId { get; set; }
        public virtual Adress Adress { get; set; }
        public virtual List<PublicEvent> PublicEvents { get; set; }
    }
}
