using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using InsuranceAPI.Models;
using System.Data;
using System;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InsuranceAPI.Controllers
{
    [Route("api/v{version}")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class PoliciesController : ControllerBase
    {
        /// <summary>
        /// Get the user linked to a policy number - Assuming the police number is the Id
        /// </summary>
        /// <param name="id">police number</param>
        /// <example>https://localhost:44305/api/v1/policiesbyid/64cceef9-3a01-49ae-a23b-3761b604800b</example>
        /// <returns>Json list of values</returns>
        [HttpGet("policiesbyid/{id}")]
        public async Task<string> GetById(string id)
        {
            //TODO: Autorization
            var data = new LPolizas().Policies;
            try
            {
                var t1 = AltranDatos.GetPolicies();
                await Task.WhenAll(t1);

                var rawData = await t1;

                data = rawData.Policies.Where(x => x.Id == id);
            }
            catch (Exception ex)
            {
                //TODO: Log Exeption
            }
            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// Get the list of policies linked to a user name
        /// </summary>
        /// <param name="name">User Name</param>
        /// <example>https://localhost:44305/api/v1/policiesbyname/Britney</example>
        /// <returns>Json list of values</returns>
        [HttpGet("policiesbyname/{name}")]
        public async Task<string> GetByName(string name)
        {
            //TODO: Autorization
            var data = new LPolizas().Policies;
            try
            {
                var t0 = AltranDatos.GetClients();
                var t1 = AltranDatos.GetPolicies();
                
                await Task.WhenAll(t0, t1);
                
                var rawData0 = await t0;
                var rawData = await t1;

                string _cliendId = rawData0.Clients.Where(x => x.Name == name).SingleOrDefault().Id;
                data = rawData.Policies.Where(x => x.ClientId == _cliendId);
            }
            catch (Exception ex)
            {
                //TODO: Log Exeption
            }
            return JsonConvert.SerializeObject(data);
        }

    }
}
