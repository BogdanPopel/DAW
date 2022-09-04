using DAW.Models.Entities;
using DAW.Models.DTO_s;
using DAW.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

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
            [AllowAnonymous]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateLocation(LocationCreateDTO dto)
        {
            Location NewLoc = new Location();
            
            NewLoc.Name = dto.Name;
            NewLoc.Adress = dto.Address;
            
            _repository.Location.Create(NewLoc);
            
            await _repository.SaveAsync();

            return Ok(new LocationDTO(NewLoc));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
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

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateLocation(int id, UpdateLocationDTO dto)
        {
            Location location = new Location();

            location = await _repository.Location.GetByIdAsync(id);
            location.Name = dto.Name;
            location.Adress = dto.Adress;

            _repository.Location.Update(location);

            await _repository.SaveAsync();

            return Ok(new LocationDTO(location));
        }
    }



}

