using DAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.DTO_s
{
    public class UpdateLocationDTO
    {
        public string Name { get; set; }
        public Adress Adress { get; set; }
    }
}
