using InsuranceAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApi.Test_MSTest
{
    [TestClass]
    public class PoliciesTest
    {
        [TestMethod]
        public void GetPolicies_GetingCorrectAmountOfElement()
        {
            GetPolicies_GetingCorrectAmountOfElementAsync().Wait();
        }

        [TestMethod]
        public async Task GetPolicies_GetingCorrectAmountOfElementAsync()
        {
            //Arrange
            int expected = 193;

            //Act
            var t1 = AltranDatos.GetPolicies();
            await Task.WhenAll(t1);
            var rawData = await t1;
            var data = rawData.Policies;

            int actual = data.Count();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task GetPolicies_GetingPoliciByIDAsync()
        {
            //Arrange
            string expected = "[{\"Date\":\"0001-01-01T00:00:00\",\"Id\":\"64cceef9-3a01-49ae-a23b-3761b604800b\",\"AmountInsured\":1825.89,\"Email\":\"inesblankenship@quotezart.com\",\"InceptionDate\":\"2016-06-01T03:33:32Z\",\"InstallmentPayment\":true,\"ClientId\":\"e8fd159b-57c4-4d36-9bd7-a59ca13057bb\"}]";

            //Act
            var t1 = AltranDatos.GetPolicies();
            await Task.WhenAll(t1);
            var rawData = await t1;
            var data = rawData.Policies;

            string actual = JsonConvert.SerializeObject(data.Where(x => x.Id == "64cceef9-3a01-49ae-a23b-3761b604800b"));

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
