using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace InsuranceAPI.Models
{
    public static class AltranDatos
    {

        public static async Task<LPolizas> GetPolicies()
        {
            HttpClient client = new HttpClient();
            string responseBody = await client.GetStringAsync("http://www.mocky.io/v2/580891a4100000e8242b75c5");
            return JsonConvert.DeserializeObject<LPolizas>(responseBody);
        }

        public static async Task<LClientes> GetClients()
        {
            HttpClient client = new HttpClient();
            string responseBody = await client.GetStringAsync("http://www.mocky.io/v2/5808862710000087232b75ac");
            return JsonConvert.DeserializeObject<LClientes>(responseBody);
        }
    }
}
