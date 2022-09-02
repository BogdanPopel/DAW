using DAW.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
/*
 Idee:
Cand se trimite un request, se verifica daca in request daca avem un token care are un JTI in payload,
daca are:
 ->ii luam valoarea
 ->il cautam in BD
 ->daca exista si expira in viitor e ok
daca nu are:

 ->nu validam requestul, deci nu ajunge in controller;
 */
namespace DAW.Helpers
{
    public class SessionTokenValidator
    {
        public static async Task ValidateSessionToken(TokenValidatedContext context)
        {
            var repository = context.HttpContext.RequestServices.GetRequiredService<IRepositoryWrapper>();
            
            //verificam daca are un claim de tipul jti (cum adaugat noi in user service)
            if(context.Principal.HasClaim(c => c.Type.Equals(JwtRegisteredClaimNames.Jti)))
            {
                //daca are, ii luam valoarea
                var jti = context.Principal.Claims.FirstOrDefault(c => c.Type.Equals(JwtRegisteredClaimNames.Jti)).Value;

                //verificam daca e in BD
                var tokenInDb = await repository.SessionToken.GetByJti(jti);   
                
                if(tokenInDb != null && tokenInDb.ExpirationDate > DateTime.Now)
                {
                    return;
                }
                context.Fail("");
            }
        }
    }
}
