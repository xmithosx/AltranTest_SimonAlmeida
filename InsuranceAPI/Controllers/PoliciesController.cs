using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using InsuranceAPI.Models;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InsuranceAPI.Controllers
{
    [Route("api/v{version}")]
    [ApiController]
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
            var tp = AltranDatos.GetPolicies();
            await Task.WhenAll(tp);

            var rawData = await tp;

            var data = rawData.Policies.Where(x => x.Id == id);

            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// Get the list of policies linked to a user name
        /// </summary>
        /// <param name="name">User Name</param>
        /// <example></example>
        /// <returns>Json list of values</returns>
        [HttpGet("policiesbyname/{name}")]
        public async Task<string> GetByName(string name)
        {
            var tp = AltranDatos.GetPolicies();
            await Task.WhenAll(tp);

            var rawData = await tp;

            var data = rawData.Policies;//.Where(x => x.Name == name);

            return JsonConvert.SerializeObject(data);
        }

    }
}
