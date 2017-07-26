using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using DTOs.Api;

public partial class CityControllerTest
{
    [TestClass]
    public class CityControllerIntegrationTests
    {
        private int _testCityId;
        private RestClient _client = new RestClient("http://localhost:42877/");

        [TestMethod]
        public void PostGetDeleteFlow()
        {
            var postCity = new RestRequest("api/City/", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            postCity.AddBody(new CityApiDto
            {
                Name = "CityController integration test",
                CountryId = 1
            });
            var postCityResult = _client.Execute<CityApiDto>(postCity);

            _testCityId = postCityResult.Data.Id;

            Assert.AreEqual(postCityResult.ResponseStatus, ResponseStatus.Completed);
            Assert.AreEqual((int)postCityResult.StatusCode, 201);

            var getCity = new RestRequest("api/City/{id}", Method.GET);
            getCity.AddParameter("id", _testCityId);
            var getCityResult = _client.Execute<CityApiDto>(getCity);

            Assert.AreEqual(getCityResult.ResponseStatus, ResponseStatus.Completed);
            Assert.AreEqual((int)getCityResult.StatusCode, 200);
            Assert.AreEqual(getCityResult.Data.Name, "CityController integration test");

            var deleteCity = new RestRequest("api/City/{id}", Method.DELETE);
            deleteCity.AddParameter("id", _testCityId);
            var deleteCityResult = _client.Execute<CityApiDto>(deleteCity);

            Assert.AreEqual(deleteCityResult.ResponseStatus, ResponseStatus.Completed);
            Assert.AreEqual((int)deleteCityResult.StatusCode, 204);

            var getDeletedCityResult = _client.Execute<CityApiDto>(getCity);

            Assert.AreEqual(getDeletedCityResult.ResponseStatus, ResponseStatus.Completed);
            Assert.AreEqual((int)getDeletedCityResult.StatusCode, 404);
        }

        //[TestMethod]
        //public void PutCity()
        //{
        //    var putCity = new RestRequest("api/City/", Method.PUT)
        //    {
        //        RequestFormat = DataFormat.Json
        //    };
        //    putCity.AddBody(new CityApiDto
        //    {
        //        Id = _testCityId,
        //        Name = "CityController integration test check put",
        //        CountryId = 2
        //    });
        //    var putCityResult = _client.Execute<CityApiDto>(putCity);

        //    Assert.AreEqual(putCityResult.ResponseStatus, ResponseStatus.Completed);
        //    Assert.AreEqual((int)putCityResult.StatusCode, 204);

        //    var getCity = new RestRequest("api/City/{id}", Method.GET);
        //    getCity.AddParameter("id", _testCityId);
        //    var getCityResult = _client.Execute<CityApiDto>(getCity);

        //    Assert.AreEqual(getCityResult.ResponseStatus, ResponseStatus.Completed);
        //    Assert.AreEqual((int)getCityResult.StatusCode, 200);
        //    Assert.AreEqual(getCityResult.Data.Name, "CityController integration test check put");
        //    Assert.AreEqual(getCityResult.Data.CountryId, 2);
        //}
    }
}
