using DAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    public interface IAdressRepository : IGenericRepository<Adress>
    {
        Task<Adress> GetAdressById(int id);
        Task<List<Adress>> GetAllAdresses();
    }
}
