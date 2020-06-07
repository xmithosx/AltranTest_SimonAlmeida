using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InsuranceAPI.Test
{
    public class PoliciesTest
    {
        [Fact]
        public void GetPolicies_GetingElement()
        {
            GetPolicies_GetingElementAsync().Wait();
        }

        [Fact]
        public async Task GetPolicies_GetingElementAsync()
        {
            //Arrange
            int expected = 193;
            //string expeted2 = "a0ece5db-cd14-4f21-812f-966633e7be86";

            //Act
            var t1 = AltranDatos.GetPolicies();
            await Task.WhenAll(t1);
            var rawData = await t1;
            var data = rawData.Policies;

            int actual = data.Count();
            //string actual2 = data.ElementAt.ID;

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
