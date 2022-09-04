using DAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.DTO_s
{
    public class AttractionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Descriere { get; set; }
        public List<EventAttraction> EventAttractions { get; set; }

        public AttractionDTO(Attraction attraction)
        {
            this.Id = attraction.Id;
            this.Name = attraction.Name;
            this.Mail = attraction.Mail;
            this.Descriere = attraction.Descriere;
            this.EventAttractions = new List<EventAttraction>();
        }
    }
}
