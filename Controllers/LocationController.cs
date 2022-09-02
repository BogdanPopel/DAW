﻿using DAW.Models.Entities;
using DAW.Models.DTO_s;
using DAW.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
            private readonly IRepositoryWrapper _repository;

            public LocationController(IRepositoryWrapper repository)
            {
                _repository = repository;
            }

            [HttpGet]
            public async Task<IActionResult> GetAllLocations()
            {
                var locations = await _repository.Location.GetAllLocationsWithAdress();

                var locationsToReturn = new List<LocationDTO>();
                foreach (var location in locations)
                {
                    locationsToReturn.Add(new LocationDTO(location));
                }
                return Ok(locationsToReturn);
            }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocById(int id)
        {
            var loc = await _repository.Location.GetLocationWithAdressById(id);
            return Ok(new LocationDTO(loc));
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(LocationCreateDTO dto)
        {
            Location NewLoc = new Location();
            
            NewLoc.Name = dto.Name;
            
            _repository.Location.Create(NewLoc);
            
            await _repository.SaveAsync();

            return Ok(new LocationDTO(NewLoc));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocationById(int id)
        {
            var loc = await _repository.Location.GetByIdAsync(id);
            if (loc == null)
            {
                return NotFound("Location doesn't exist");
            }
            _repository.Location.Delete(loc);

            await _repository.SaveAsync();
            return NoContent();
        }
    }

        
 }
