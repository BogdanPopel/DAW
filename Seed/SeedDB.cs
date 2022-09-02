using DAW.Data;
using DAW.Models.Constants;
using DAW.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Seed
{
    public class SeedDB
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly Context _context;

        public SeedDB(RoleManager<Role> roleManager, Context context)
        {
            _roleManager = roleManager;
            _context = context;
        }

        public async Task SeedRoles()
        {
            if (_context.Roles.Any()) return; // daca avem deja roluri in DB, nu mai adaugam nimic          

            string[] roleNames = {
                UserRoleType.Admin,
                UserRoleType.User
            };
            IdentityResult roleResult;
            foreach (var rolename in roleNames)
            {
                var roleExists = await _roleManager.RoleExistsAsync(rolename);

                if (!roleExists)
                {
                    roleResult = await _roleManager.CreateAsync(new Role
                    {
                        Name = rolename
                    });
                }
                await _context.SaveChangesAsync();
            }
        }

    }
}
