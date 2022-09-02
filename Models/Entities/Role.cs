﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Models.Entities
{
    public class Role : IdentityRole<int>
    { 
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
