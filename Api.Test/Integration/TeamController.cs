using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using DTOs.Api;

public partial class TeamControllerTest
{
    [TestClass]
    public class TeamControllerIntegrationTests
    {
        private int _testTeamId;
        private RestClient _client = new RestClient("http://localhost:42877/");

        [TestMethod]
        public void TeamPostGetPutDeleteFlow()
        {
            var postTeam = new RestRequest("api/Team/", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            postTeam.AddBody(new TeamApiDto
            {
                Name = "TeamController integration test",
                CityId = 1
            });
            var postTeamResult = _client.Execute<TeamApiDto>(postTeam);

            _testTeamId = postTeamResult.Data.Id;

            Assert.AreEqual(postTeamResult.ResponseStatus, ResponseStatus.Completed);
            Assert.AreEqual((int)postTeamResult.StatusCode, 201);


            var getTeam = new RestRequest("api/Team/{id}", Method.GET);
            getTeam.AddParameter("id", _testTeamId);
            var getTeamResult = _client.Execute<TeamApiDto>(getTeam);

            Assert.AreEqual(getTeamResult.ResponseStatus, ResponseStatus.Completed);
            Assert.AreEqual((int)getTeamResult.StatusCode, 200);
            Assert.AreEqual(getTeamResult.Data.Name, "TeamController integration test");


            var putTeam = new RestRequest("api/Team/", Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };
            putTeam.AddBody(new TeamApiDto
            {
                Id = _testTeamId,
                Name = "TeamController integration test check put",
                CityId = 2
            });
            var putTeamResult = _client.Execute<TeamApiDto>(putTeam);

            Assert.AreEqual(putTeamResult.ResponseStatus, ResponseStatus.Completed);
            Assert.AreEqual((int)putTeamResult.StatusCode, 204);

            var getTeamResultAfterPut = _client.Execute<TeamApiDto>(getTeam);

            Assert.AreEqual(getTeamResultAfterPut.ResponseStatus, ResponseStatus.Completed);
            Assert.AreEqual((int)getTeamResultAfterPut.StatusCode, 200);
            Assert.AreEqual(getTeamResultAfterPut.Data.Name, "TeamController integration test check put");
            Assert.AreEqual(getTeamResultAfterPut.Data.CityId, 2);


            var deleteTeam = new RestRequest("api/Team/{id}", Method.DELETE);
            deleteTeam.AddParameter("id", _testTeamId);
            var deleteTeamResult = _client.Execute<TeamApiDto>(deleteTeam);

            Assert.AreEqual(deleteTeamResult.ResponseStatus, ResponseStatus.Completed);
            Assert.AreEqual((int)deleteTeamResult.StatusCode, 204);

            var getDeletedTeamResult = _client.Execute<TeamApiDto>(getTeam);

            Assert.AreEqual(getDeletedTeamResult.ResponseStatus, ResponseStatus.Completed);
            Assert.AreEqual((int)getDeletedTeamResult.StatusCode, 404);
        }
    }
}
