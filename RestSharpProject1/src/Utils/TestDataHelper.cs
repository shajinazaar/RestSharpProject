using API_AUTOMATION.src.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject1.src.Utils
{
    internal class TestDataHelper
    {
        private static readonly string _configPath;
        private static readonly JObject _testData;

        static TestDataHelper()
        {
            // Correct path resolution for AppConfig.json
            _configPath = Path.Combine(AppContext.BaseDirectory, "src", "Config", "AppConfig.json");


            // Ensure the file exists
            if (!File.Exists(_configPath))
            {
                throw new FileNotFoundException("AppConfig.json not found", _configPath);
            }

            var configJson = File.ReadAllText(_configPath);
            _testData = JObject.Parse(configJson);
        }
            public static string GetEmail()
            {
                return _testData["Credentials"]["Email"].ToString();
            }

            public static string GetPassword()
            {
                return _testData["Credentials"]["Password"].ToString();
            }

             public static CreateUserRequest GetCreateUserRequest()
            {
                return new CreateUserRequest
                {
                    Ownership = _testData["Users"]["ownership"].ToString(),
                    Permissions = _testData["Users"]["permissions"].ToObject<List<string>>(),
                    Email = _testData["Users"]["email"].ToString()
                };
            }





    }
    }



