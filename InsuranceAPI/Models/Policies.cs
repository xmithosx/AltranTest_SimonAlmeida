using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceAPI.Models
{
    public class Policies
    {
        public DateTime Date { get; set; }

        public string Id { get; set; }

        public Double AmountInsured { get; set; }

        public string Email { get; set; }

        public DateTime InceptionDate { get; set; }

        public bool InstallmentPayment { get; set; }

        public string ClientId { get; set; }

    }
}
