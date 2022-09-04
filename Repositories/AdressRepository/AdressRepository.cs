using DAW.Data;
using DAW.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    public class AdressRepository : GenericRepository<Adress>, IAdressRepository
    {
        public AdressRepository(Context context) : base(context) { }
        public async Task<Adress> GetAdressById(int id)
        {
            return await _context.Adresses.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<List<Adress>> GetAllAdresses()
        {
            return await _context.Adresses.ToListAsync();
        }

    }
}
