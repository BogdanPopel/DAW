using DAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repositories
{               
    public interface IAttractionRepository : IGenericRepository<Attraction>
    {
        Task<Attraction> GetAttractionById(int id);
        Task<Attraction> GetAttractionByName(string name);
        Task<List<Attraction>> GetAllAttractions();
    }
}
