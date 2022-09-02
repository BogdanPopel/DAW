using DAW.Data;
using DAW.Models.Entities;
using DAW.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    class LocRepository : GenericRepository<Location>, ILocRepository
    {
        public LocRepository(Context context) : base(context) { }//apelam si constructorul de baza

        public async Task<Location> GetByName(string name) 
        {
            return await _context.Locations.Where(l => l.Name.Equals(name)).FirstOrDefaultAsync();
        }
        public async Task<List<Location>> GetAllLocationsWithAdress()
        {
            return await _context.Locations.Include(l => l.Adress).ToListAsync();
        }
    
        public async Task<Location> GetLocationWithAdressById(int id)
        {
            return await _context.Locations.Include(a => a.Adress).Where(a => a.Id == id).FirstOrDefaultAsync();
        }
    }
}
