using DAW.Models.Entities;
using DAW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    public interface ILocRepository : IGenericRepository<Location>
    {
        Task<Location> GetByName(string name);
        Task<List<Location>> GetAllLocationsWithAdress();

        Task<Location> GetLocationWithAdressById(int id);
    }
}
