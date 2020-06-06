using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InsuranceAPI.Models
{
    public class Poliza
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("amountInsured")]
        public Double AmountInsured { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("inceptionDate")]
        public DateTime InceptionDate { get; set; }

        [JsonPropertyName("installmentPayment")]
        public bool InstallmentPayment { get; set; }

        [JsonPropertyName("clientId")]
        public string ClientId { get; set; }
    }

    public class LPolizas
    {
        [JsonPropertyName("policies")]
        public IEnumerable<Poliza> Policies { get; set; }
    }
}
