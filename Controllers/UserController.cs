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
    public class UserController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public UserController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        //[AllowAnonymous] default daca nu specifici nimic
        //daca nu ma intereseaza rolul, dar vreau ca utilizatorul sa fie logat,
        //puneam doar authorize
        [HttpGet]
        [Authorize(Roles = "Admin")] //restrictionez accesul doar pentru Admini
        public async Task<IActionResult> GetAllUsers()
        {    
            var users = await _repository.User.GetAllUsers();
            return Ok(new { users });
        }
        
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            User user = new User();

            user = await _repository.User.GetByIdAsync(id);

            _repository.User.Delete(user);

            await _repository.SaveAsync();

            return Ok(new UserDTO(user));
        }
    }
}
