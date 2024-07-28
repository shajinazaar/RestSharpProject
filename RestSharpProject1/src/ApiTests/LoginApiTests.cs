using AventStack.ExtentReports;
using Newtonsoft.Json;
using RestSharp;
using RestSharpProject1.src.Models;
using RestSharpProject1.src.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using NUnit.Framework;



namespace RestSharpProject1.src.ApiTests
{
    [TestFixture]
    internal class LoginApiTests 
    {
        private ApiClient _apiClient;
   
        private ExtentReport rep;

       [SetUp]
        public void Setup()
        {
            rep = new ExtentReport();
            rep.StartReport();
            _apiClient = new ApiClient();
             rep.CreateTest("LoginWithValidCredentials_ShouldReturnToken");
        }

        [Test]
        public void LoginWithValidCredentials_ShouldReturnToken()
        {
           
            var loginDetails = new
            {
                email = TestDataHelper.GetEmail(),
                password = TestDataHelper.GetPassword()
            };

            var response = _apiClient.ExecuteRequest("auth/login", Method.Post, loginDetails);
           Assert.AreEqual(200, (int)response.StatusCode);

            var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(response.Content);
            Assert.IsNotNull(loginResponse.Data.IdToken);
            rep.Log(Status.Pass, "IdToken is not null");
        }

        [Test]
        public void LoginWithInvalidCredentials_ShouldReturnUnauthorized()
        {
            var loginDetails = new
            {
                email = "invalid",
                password = "invalid"
            };

            var response = _apiClient.ExecuteRequest("auth/login", Method.Post, loginDetails);
            Assert.AreEqual(400, (int)response.StatusCode);
            rep.Log(Status.Pass, "Test case Fail");
        }

        [TearDown]
        public void TearDown()
        {
            rep.EndReport();
        }

    }
}
