using DAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.DTO_s
{
    public class UserDTO 
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserDTO(User user)
        {
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
        }
    }
}
