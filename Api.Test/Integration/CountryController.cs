using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using DTOs.Api;
using Newtonsoft.Json;

public partial class CountryControllerTest
{
    [TestClass]
    public class CountryControllerIntegrationTests
    {
        private int _testCountryId;
        private RestClient _client = new RestClient("http://localhost:42877/");

        [TestMethod]
        public void CountryPostGetDeleteFlow()
        {
            var postCountry = new RestRequest("api/Country/", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            postCountry.AddBody(new CountryApiDto
            {
                Name = "CountryController integration test",
            });
            var postCountryResult = _client.Execute<CountryApiDto>(postCountry);
            var postedCountry = JsonConvert.DeserializeObject<CountryApiDto>(postCountryResult.Content);
            _testCountryId = postedCountry.Id;

            Assert.AreEqual((int)postCountryResult.StatusCode, 201);


            var getCountry = new RestRequest("api/Country/{id}", Method.GET);
            getCountry.AddParameter("id", _testCountryId);
            var getCountryResult = _client.Execute<CountryApiDto>(getCountry);
            var receivedСountry = JsonConvert.DeserializeObject<CountryApiDto>(getCountryResult.Content);
            Assert.AreEqual((int)getCountryResult.StatusCode, 200);
            Assert.AreEqual(receivedСountry.Name, "CountryController integration test");


            var deleteCountry = new RestRequest("api/Country/{id}", Method.DELETE);
            deleteCountry.AddParameter("id", _testCountryId);
            var deleteCountryResult = _client.Execute<CountryApiDto>(deleteCountry);

            Assert.AreEqual(deleteCountryResult.ResponseStatus, ResponseStatus.Completed);
            Assert.AreEqual((int)deleteCountryResult.StatusCode, 204);

            var getDeletedCountryResult = _client.Execute<CityApiDto>(getCountry);

            Assert.AreEqual(getDeletedCountryResult.ResponseStatus, ResponseStatus.Completed);
            Assert.AreEqual((int)getDeletedCountryResult.StatusCode, 404);
        }
    }
}