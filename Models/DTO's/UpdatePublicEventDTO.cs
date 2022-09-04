using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.DTO_s
{
    public class UpdatePublicEventDTO
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int TicketPrice { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
    }
}
