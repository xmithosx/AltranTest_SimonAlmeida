using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceAPI.Models
{
    public class AuthData
    {
        public string email { get; set; }

        public string role { get; set; }

        public DateTime validuntil { get; set; }
    }
}
