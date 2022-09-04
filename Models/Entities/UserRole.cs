using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.Entities
{
    public class UserRole : IdentityUserRole<int>
    {  
        public Role Role { get; set; }
        public User User { get; set; }


    }
}
