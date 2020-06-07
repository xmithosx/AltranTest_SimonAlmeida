using InsuranceAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            //string expeted2 = "a0ece5db-cd14-4f21-812f-966633e7be86";

            //Act
            var t1 = AltranDatos.GetPolicies();
            await Task.WhenAll(t1);
            var rawData = await t1;
            var data = rawData.Policies;

            int actual = data.Count();
            //string actual2 = data.ElementAt.ID;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
