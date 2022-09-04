using DAW.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        ISessionTokenRepository SessionToken { get;}
        ILocRepository Location { get; }
        IAttractionRepository Attraction { get; }
        IAdressRepository Adress { get; }
            
        Task SaveAsync();
    }
}
