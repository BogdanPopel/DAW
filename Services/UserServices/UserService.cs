using DAW.Models.Constants;
using DAW.Models.DTO_s;
using DAW.Models.Entities;
using DAW.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAW.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IRepositoryWrapper _repository;
        public UserService(UserManager<User> userManager, IRepositoryWrapper repository)
        {
            _userManager = userManager;
            _repository = repository;
        }
        public async Task<bool> RegisterUserAsync(RegisterUserDTO dto)
        {
            var newUser = new User();
            newUser.UserName = dto.Email;
            newUser.Email = dto.Email;
            newUser.FirstName = dto.FirstName;
            newUser.LastName = dto.LastName;

            var result = await _userManager.CreateAsync(newUser, dto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoleType.Admin);
                //if( newUser.UserRoles != null)
                    return true;
            }

            return false;
        }

        public async Task<string> LoginUser(LoginUserDTO dto)
        {
            User user = await _userManager.FindByEmailAsync(dto.Email);
            if (user != null)
            {
                //generam token de autentificare pt user
                user = await _repository.User.GetByIdWithRoles(user.Id);

                //rolurile utilizatorului
                List<string> roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();
                //System.Diagnostics.Debug.WriteLine(roles);
               
                //generally unique id -> un id unic general de dotnet
                var newJti = Guid.NewGuid().ToString();

                //handler -> controller pentru token
                var tokenHandler = new JwtSecurityTokenHandler();
                //semnatura (your 256 bit secret -> ca pe jwt.yo)
                var signinkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKey12345678910#$% customizabil"));

                var token = GenerateJwtToken(signinkey, user, roles, tokenHandler, newJti);

                var passwordMatch = await _userManager.CheckPasswordAsync(user, dto.Password);

                if (passwordMatch == false)
                {
                    return "Wrong password!";
                }

                _repository.SessionToken.Create(new SessionToken(newJti, user.Id, token.ValidTo));
                await _repository.SaveAsync();

                return tokenHandler.WriteToken(token);
            }
            return null;
        }

        private SecurityToken GenerateJwtToken(SymmetricSecurityKey signinKey, User user, List<string> roles, JwtSecurityTokenHandler tokenHandler, string jti)
        {
            var subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, jti)
                });

            foreach (var role in roles)
            {
                subject.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            //tine toate info despre token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //toate datele despre token -> email, id, rol
                Subject = subject,
                //expira in 2 ore
                Expires = DateTime.Now.AddDays(3),
                //semnatura decodata
                SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return token;
        }
         
    }
}

