using InsuranceAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApi.Test_MSTest
{
    [TestClass]
    public class ClientsTest
    {
        [TestMethod]
        public void GetClients_GetingElement()
        {
            GetClients_GetingElementAsync().Wait();
        }

        [TestMethod]
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
            Assert.Equals(expected, actual);
        }

        [TestMethod]
        public void SimpleTest()
        {
            Assert.Equals(1, 1);
        }
    }
}
