using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.Entities
{
    public class EventAttraction
    {

        public int PublicEventId;
        public PublicEvent PublicEvent { get; set; }
        
        public int AttractionId;
       
        public Attraction Attraction { get; set; }

    }
}
