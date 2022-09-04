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

        public async Task<Attraction> GetAttractionByName(string name)
        {
            return await _context.Attractions.Where(a => a.Name.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<List<Attraction>> GetAllAttractions()
        {
            return await _context.Attractions.ToListAsync();
        }
    }
}
