using DAW.Data;
using DAW.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    public class PublicEventRepository : GenericRepository<PublicEvent>, IPublicEventRepository
    {
        public PublicEventRepository(Context context) : base(context) { }
        public async Task<PublicEvent> GetByName(string name)
        {
            return await _context.PublicEvents.Where(pe => pe.Name.Equals(name)).FirstOrDefaultAsync();
        }
        
        public async Task<List<PublicEvent>> GetPublicEventsWithLocation()
        {
            return await _context.PublicEvents.Include(pe => pe.Location).ToListAsync();
        }

        public async Task<PublicEvent> GetPublicEventsWithLocationById(int id)
        {
            return await _context.PublicEvents
            .Include(pe => pe.Location).Where(pe => pe.Id == id).FirstOrDefaultAsync();
        }
    }

}
