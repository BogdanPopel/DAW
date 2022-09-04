using DAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    public interface IPublicEventRepository : IGenericRepository<PublicEvent>
    {
        Task<PublicEvent> GetByName(string name);
        Task<List<PublicEvent>> GetPublicEventsWithLocation();
        Task<PublicEvent> GetPublicEventsWithLocationById(int id);
    }
}
