using InsuranceAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApi.Test_MSTest
{
    [TestClass]
    public class ClientsTest
    {
        [TestMethod]
        public void GetClients_GetingCorrectAmountOfElement()
        {
            GetClients_GetingCorrectAmountOfElementAsync().Wait();
        }

        [TestMethod]
        public async Task GetClients_GetingCorrectAmountOfElementAsync()
        {
            //Arrange
            int expected = 194;

            //Act
            var t1 = AltranDatos.GetClients();
            await Task.WhenAll(t1);
            var rawData = await t1;
            var data = rawData.Clients;

            int actual = data.Count();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task GetClients_GetingUserDataByIdAsync()
        {
            //Arrange
            string expected = "[{\"Id\":\"a0ece5db-cd14-4f21-812f-966633e7be86\",\"Name\":\"Britney\",\"Email\":\"britneyblankenship@quotezart.com\",\"Role\":\"admin\"}]";

            //Act
            var t1 = AltranDatos.GetClients();
            await Task.WhenAll(t1);
            var rawData = await t1;
            var data = rawData.Clients;

            string actual = JsonConvert.SerializeObject(data.Where(x => x.Id == "a0ece5db-cd14-4f21-812f-966633e7be86"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task GetClients_GetingUserDataByNameAsync()
        {
            //Arrange
            string expected = "[{\"Id\":\"a0ece5db-cd14-4f21-812f-966633e7be86\",\"Name\":\"Britney\",\"Email\":\"britneyblankenship@quotezart.com\",\"Role\":\"admin\"}]";

            //Act
            var t1 = AltranDatos.GetClients();
            await Task.WhenAll(t1);
            var rawData = await t1;
            var data = rawData.Clients;

            string actual = JsonConvert.SerializeObject(data.Where(x => x.Name == "Britney"));

            //Assert
            Assert.AreEqual(expected, actual);
        }


    }
}
