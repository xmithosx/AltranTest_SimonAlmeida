using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceAPI;
using Xunit;

namespace InsuranceAPI.Test
{
    public class ClientsTest
    {
        [Fact]
        public void GetClients_GetingElement()
        {
            GetClients_GetingElementAsync().Wait();
        }

        [Fact]
        public async Task GetClients_GetingElementAsync()
        {
            //Arrange
            int expected = 194;
            //string expeted2 = "a0ece5db-cd14-4f21-812f-966633e7be86";

            //Act
            var t1 = AltranDatos.GetClients();
            await Task.WhenAll(t1);
            var rawData = await t1;
            var data = rawData.Clients;

            int actual = data.Count();
            //string actual2 = data.ElementAt.ID;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SimpleTest()
        {
            Assert.Equal(1, 1);
        }
    }
}
