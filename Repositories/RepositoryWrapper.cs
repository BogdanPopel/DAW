﻿using DAW.Data;
using DAW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly Context _context;

        private IUserRepository _user;
        private ILocRepository _location;
        private ISessionTokenRepository _sessionToken;
        private IAttractionRepository _attraction;
        private IAdressRepository _adress;
        public RepositoryWrapper(Context context)
        {
            _context = context;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null) _user = new UserRepository(_context);
                return _user;
            }
        }
        public ILocRepository Location
        {
            get
            {
                if (_location == null) _location = new LocRepository(_context);
                return _location;
            }
        }

        public ISessionTokenRepository SessionToken
        {
            get
            {
                if (_sessionToken == null) _sessionToken = new SessionTokenRepository(_context);
                return _sessionToken;
            }
        }

        public IAttractionRepository Attraction
        {
            get
            {
                if (_attraction == null) _attraction = new AttractionRepository(_context);
                return _attraction;
            }
        }
        public IAdressRepository Adress
        {
            get
            {
                if (_adress == null) _adress = new AdressRepository(_context);
                return _adress;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
