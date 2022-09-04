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
    public class PublicEventController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        public PublicEventController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPublicEvents()
        {
            var pes = await _repository.PublicEvent.GetPublicEventsWithLocation();

            var peToReturn = new List<PublicEventDTO>();
            foreach (var pe in pes)
            {
                peToReturn.Add(new PublicEventDTO(pe));
            }
            return Ok(peToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublicEventById(int id)
        {
            var pe = await _repository.PublicEvent.GetPublicEventsWithLocationById(id);
            return Ok(new PublicEventDTO(pe));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreatePublicEvent(PublicEventCreateDTO dto)
        {
            PublicEvent NewPE = new PublicEvent();

            NewPE.Name = dto.Name;
            NewPE.TicketPrice = dto.TicketPrice;
            NewPE.Time = dto.Time;
            NewPE.Date = dto.Date;
            NewPE.Description = dto.Description;
            NewPE.Location = dto.Location;

            _repository.PublicEvent.Create(NewPE);

            await _repository.SaveAsync();

            return Ok(new PublicEventDTO(NewPE));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePublicEventById(int id)
        {
            var pe = await _repository.PublicEvent.GetByIdAsync(id);
            if (pe == null)
            {
                return NotFound("Public Event doesn't exist");
            }
            _repository.PublicEvent.Delete(pe);

            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePublicEvent(int id, UpdatePublicEventDTO dto)
        {
            PublicEvent pe = new PublicEvent();

            pe = await _repository.PublicEvent.GetByIdAsync(id);
            pe.Name = dto.Name;
            pe.TicketPrice = dto.TicketPrice;
            pe.Time = dto.Time;
            pe.Date = dto.Date;
            pe.Description = dto.Description;
            pe.Location = dto.Location;

            _repository.PublicEvent.Update(pe);

            await _repository.SaveAsync();

            return Ok(new PublicEventDTO(pe));
        }
    }
}
