using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InsuranceAPI.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InsuranceAPI.Controllers
{
    [Route("api/v{version}")]
    [ApiController]
    [Authorize(Roles = "admin, user")]
    public class ClientsController : ControllerBase
    {
        /// <summary>
        /// Get user data filterd by user name
        /// </summary>
        /// <param name="name">user name</param>
        /// <example>https://localhost:44305/api/v1/clientsbyname/Britney</example>
        /// <returns>Json list of values</returns>
        [HttpGet("clientsbyname/{name}")]
        public async Task<string> GetByName(string name)
        {
            //TODO: Autorization
            var data = new LClientes().Clients;
            try
            {
                var t1 = AltranDatos.GetClients();
                await Task.WhenAll(t1);

                var rawData = await t1;

                data = rawData.Clients.Where(x => x.Name == name);
            }
            catch (Exception ex)
            {
                //TODO: Log Exeption
            }
            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// Get user data filtered by user id
        /// </summary>
        /// <param name="id">user id</param>
        /// <example>https://localhost:44305/api/v1/clientsbyid/a0ece5db-cd14-4f21-812f-966633e7be86</example>
        /// <returns>Json list of values</returns>
        [HttpGet("clientsbyid/{id}")]
        public async Task<string> GetById(string id)
        {
            var data = new LClientes().Clients;
            try
            {
                var t1 = AltranDatos.GetClients();
                await Task.WhenAll(t1);

                var rawData = await t1;

                data = rawData.Clients.Where(x => x.Id == id);
            }
            catch (Exception ex)
            {
                //TODO: Log Exeption
            }
            return JsonConvert.SerializeObject(data);
        }
    }
}
