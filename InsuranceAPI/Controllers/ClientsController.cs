using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InsuranceAPI.Controllers
{
    [Route("api/v{version}/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        /// <summary>
        /// Get user data filterd by user name
        /// </summary>
        /// <param name="name">user name</param>
        /// <returns>Json list of values</returns>
        [HttpGet("{name}")]
        public string GetByName(string name)
        {
            return "valueName";
        }

        /// <summary>
        /// Get user data filtered by user id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>Json list of values</returns>
        [HttpGet("{id:int}")]
        public string GetById(int id)
        {
            return "valueId";
        }
    }
}
