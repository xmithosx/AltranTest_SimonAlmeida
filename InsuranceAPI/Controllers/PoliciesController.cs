using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InsuranceAPI.Controllers
{
    [Route("api/v{version}/policies")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        /// <summary>
        /// Get the list of policies linked to a user name
        /// </summary>
        /// <param name="name">User Name</param>
        /// <returns>Json list of values</returns>
        [HttpGet("{name}")]
        public IEnumerable<string> GetByName(string name)
        {
            return new string[] { "valueName" };
        }

        /// <summary>
        /// Get the user linked to a policy number - Assuming the police number is the Id
        /// </summary>
        /// <param name="id">police number</param>
        /// <returns>Json list of values</returns>
        [HttpGet("{id:int}")]
        public string GetById(int id)
        {
            return "valueID";
        }

    }
}
