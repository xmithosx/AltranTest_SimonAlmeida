using InsuranceAPI.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace InsuranceAPI
{
    public static class AltranDatos
    {
        
        public static async Task<LPolizas> GetPolicies()
        {
            string responseBody = string.Empty;
            try
            {
                HttpClient client = new HttpClient();
                responseBody = await client.GetStringAsync("http://www.mocky.io/v2/580891a4100000e8242b75c5");
               
            }
            catch (Exception ex) 
            {
                Log.Error().Exception(ex);
            }
            return JsonConvert.DeserializeObject<LPolizas>(responseBody);
        }

        public static async Task<LClientes> GetClients()
        {
            string responseBody = string.Empty;
            try
            {
                HttpClient client = new HttpClient();
                responseBody = await client.GetStringAsync("http://www.mocky.io/v2/5808862710000087232b75ac");
            }
            catch (Exception ex)
            {
                Log.Error().Exception(ex);
            }
            return JsonConvert.DeserializeObject<LClientes>(responseBody);
        }
    }
}
