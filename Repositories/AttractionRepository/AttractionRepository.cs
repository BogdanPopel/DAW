using DAW.Data;
using DAW.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    public class AttractionRepository : GenericRepository<Attraction>, IAttractionRepository
    {
        public AttractionRepository(Context context) : base(context) { }

        public async Task<Attraction> GetAttractionById(int id)
        {
            return await _context.Attractions.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Attraction> GetAttractionByName(string name)
        {
            return await _context.Attractions.FirstOrDefaultAsync(a => a.Name.Equals(name));
        }

        public async Task<List<Attraction>> GetAllAttractions()
        {
            return await _context.Attractions.ToListAsync();
        }
    }
}
