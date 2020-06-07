using InsuranceAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApi.Test_MSTest
{
    [TestClass]
    public class AuthTest
    {
        [TestMethod]
        public void GetAuth_GetingUserDataByMail()
        {
            GetAuth_GetingUserDataByMailAsync().Wait();
        }

        [TestMethod]
        public async Task GetAuth_GetingUserDataByMailAsync()
        {
            //Arrange
            string expected = "[{\"Id\":\"a0ece5db-cd14-4f21-812f-966633e7be86\",\"Name\":\"Britney\",\"Email\":\"britneyblankenship@quotezart.com\",\"Role\":\"admin\"}]";

            //Act
            var t1 = AltranDatos.GetClients();
            await Task.WhenAll(t1);
            var rawData = await t1;
            var data = rawData.Clients;

            string actual = JsonConvert.SerializeObject(data.Where(x => x.Email == "britneyblankenship@quotezart.com"));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        
    }
}
