using DAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.DTO_s
{
    public class PublicEventDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int TicketPrice { get; set; }
        public string Description { get; set; }

        public Location Location { get; set; }
        public List<EventAttraction> EventAttractions { get; set; }
    
        public PublicEventDTO(PublicEvent pe)
        {
            this.Id = pe.Id;
            this.Name = pe.Name;
            this.Date = pe.Date;
            this.Time = pe.Time;
            this.TicketPrice = pe.TicketPrice;
            this.Description = pe.Description;
            this.Location = new Location();
            this.EventAttractions = new List<EventAttraction>();
        }
    }
}
