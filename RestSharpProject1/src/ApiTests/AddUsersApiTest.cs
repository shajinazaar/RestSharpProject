using API_AUTOMATION.src.Models;
using AventStack.ExtentReports;
using Newtonsoft.Json;
using RestSharp;
using RestSharpProject1.src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace API_AUTOMATION.src.ApiTests
{
    [TestFixture]
    internal class AddUsersApiTest
    {
       private ApiClient _apiClient;
        private const string BearerToken = "eyJraWQiOiIzRHFXVWNjWFNxOVgySE93XC9YVVp3OGlJR2lWSWVxbHlFOTlPYnoxWU9laz0iLCJhbGciOiJSUzI1NiJ9.eyJzdWIiOiIzYTc3NjcxMS01NmM2LTQxNjctYjY5Ny0yNTg5ZTU5ZTRmN2MiLCJyb2xlIjoidXNlciIsImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJpc3MiOiJodHRwczpcL1wvY29nbml0by1pZHAuYXAtc291dGhlYXN0LTEuYW1hem9uYXdzLmNvbVwvYXAtc291dGhlYXN0LTFfWFpBclpEc3c0Iiwic2Vzc2lvbl9pZCI6ImE2MGQ3MmYxLWMzNTktNDJkYi05NDI1LTkwYjIwM2FjMGUxZiIsImNvZ25pdG86dXNlcm5hbWUiOiIzYTc3NjcxMS01NmM2LTQxNjctYjY5Ny0yNTg5ZTU5ZTRmN2MiLCJvcmlnaW5fanRpIjoiNTM4YmMwZDYtY2MzNS00YTdhLTljN2ItZTRjNDJkZGYwZGI1IiwiYXVkIjoiN3Nhazkxc3N0dXNiMGZqdmtzbTIwcW9yaWYiLCJldmVudF9pZCI6ImYzZTA0NThmLTdkYzgtNDQ1OS1hNjE2LWNkZjhlZjlkMDdjMyIsInVzZXJfaWQiOiI0MzUzNTAiLCJ0b2tlbl91c2UiOiJpZCIsImF1dGhfdGltZSI6MTcyMjE1MjM0NywibWZhVmVyaWZpZWQiOiIwIiwiZXhwIjoxNzIyMTgyMDMxLCJpYXQiOjE3MjIxNzg0MzEsImp0aSI6ImVhYmY4OGVlLWI0ZjItNGIwMC05YjlkLWVhN2Y5NWZhMzhlOCIsImVtYWlsIjoic2hhamluYXphckBvdXRsb29rLmNvbSJ9.1aZRximVSxFwgAYc8Md617ZyBfLpiJaWuMe0cBfn2ucX4LPy3-85D2y598wEGqy2IukUdumFml6MOQE1u3Vbn3mmLE6bpZIP8F1xJT7JsBLfYikH2z8LDizTw2EQ07hr2JIVPrxCKOPTCnZOqYa-QzLvauQhKUHraZrtJBcSeon2ftTDEDEUoXXDEVpoLd4qkprxBGJzt0MBaIm_EubsxTTi5Bj9Y3tMM1I-cFxs0_-M58oHfRprlb-dBKsRR0WL3nVYg6OcX6AShVnu_WcyfrVgtvO5tYeqbosSQBkV9nrhdHQ08M85Ypo117r15lrbWZ2eIEs6HUFZdfder1h93w";

        [SetUp]
        public void Setup()
        {
        
            _apiClient = new ApiClient();
           
        }

        [Test]
        public void CreateUser_ShouldReturnSuccess()
        {
        
            var createUserRequest = TestDataHelper.GetCreateUserRequest();

            var response = _apiClient.ExecuteRequest("workspace/collaborator/invite", Method.Post, createUserRequest, BearerToken);

                Assert.AreEqual(201, (int)response.StatusCode);

                var createUserResponse = JsonConvert.DeserializeObject<CreateUserResponse>(response.Content);

                Assert.IsNotNull(createUserResponse);
                Assert.AreEqual("success", createUserResponse.Status);
                Assert.AreEqual("User has been invited to workspace", createUserResponse.Message);
     
        }
    }
}
