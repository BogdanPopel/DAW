using DAW.Models.DTO_s;
using DAW.Models.Entities;
using DAW.Repositories;
using Microsoft.AspNetCore.Authorization;
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
    public class AttractionController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public AttractionController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAttractions()
        {
            var attractions = await _repository.Attraction.GetAllAttractions();

            var attractionsToReturn = new List<AttractionDTO>();
            foreach (var attraction in attractions)
            {
                attractionsToReturn.Add(new AttractionDTO(attraction));
            }
            return Ok(attractionsToReturn);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttractionById(int id)
        {
            var att = await _repository.Attraction.GetByIdAsync(id);
            return Ok(new AttractionDTO(att));
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAttraction(AttractionCreateDTO dto)
        {
            Attraction NewAttraction = new Attraction();

            NewAttraction.Name = dto.Name;
            NewAttraction.Mail = dto.Mail;
            NewAttraction.Descriere = dto.Descriere;

            _repository.Attraction.Create(NewAttraction);

            await _repository.SaveAsync();

            return Ok(new AttractionDTO(NewAttraction));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAttractionById(int id)
        {
            var att = await _repository.Attraction.GetByIdAsync(id);
            if (att == null)
            {
                return NotFound("Attraction doesn't exist");
            }
            _repository.Attraction.Delete(att);

            await _repository.SaveAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAttraction(int id, UpdateAttractionDTO dto)
        {
            Attraction attraction = new Attraction();

            attraction = await _repository.Attraction.GetByIdAsync(id);
            attraction.Name = dto.Name;
            attraction.Mail = dto.Mail;
            attraction.Descriere = dto.Descriere;

            _repository.Attraction.Update(attraction);

            await _repository.SaveAsync();

            return Ok(new AttractionDTO(attraction));
        }
    }
}
