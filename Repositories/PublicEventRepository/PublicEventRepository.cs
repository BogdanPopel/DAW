using DAW.Data;
using DAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    public class PublicEventRepository : GenericRepository<PublicEvent>, IPublicEventRepository
    {
        public PublicEventRepository(Context context) : base(context) { }
    }
}
