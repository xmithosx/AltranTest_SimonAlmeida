using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using InsuranceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NLog.Fluent;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InsuranceAPI.Controllers
{
    [Route("api/v{version}")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> logger;
        private readonly IConfiguration configuration;

        public AuthController(ILogger<AuthController> logger, IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }


        /// <summary>
        /// Autenticación por email - omitido Password por data manejada
        /// </summary>
        /// <param name="mail">user mail</param>
        /// <example>https://localhost:44305/api/v1/authbymail/britneyblankenship%40quotezart.com</example>
        /// <returns>JWT with data to Autorize</returns>
        [HttpGet("authbymail/{mail}")]
        public async Task<string> GetAuth(string mail)
        {
            Log.Info().Message("AuthConroller Begin");
            var data = new Cliente();
            var dataAuth = new AuthData();
            try
            {
                var t1 = AltranDatos.GetClients();
                await Task.WhenAll(t1);

                var rawData = await t1;

                data = rawData.Clients.Where(x => x.Email == mail).SingleOrDefault();
                dataAuth.email = data.Email;
                dataAuth.role = data.Role;
                dataAuth.validuntil = DateTime.Now.AddHours(8);
            }
            catch (Exception ex)
            {
                Log.Error().Exception(ex);
                Log.Error().Message(ex.StackTrace);
            }
            
            return GenerarTokenJWT(dataAuth);
        }

        private string GenerarTokenJWT(AuthData usuarioInfo)
        {
            // HEADER //
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JWT:ClaveSecreta"])
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            // CLAIMS //
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("validuntil", usuarioInfo.validuntil.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.email),
                new Claim(ClaimTypes.Role, usuarioInfo.role)
            };

            // PAYLOAD //
            var _Payload = new JwtPayload(
                    issuer: configuration["JWT:Issuer"],
                    audience: configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: usuarioInfo.validuntil.AddHours(-8),
                    expires: usuarioInfo.validuntil
                );

            // TOKEN //
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
    }
}
