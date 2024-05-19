using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject1
{
    
    public class TestResponse
    {
        RestSharpTest test;
        private const string URL = "https://simple-books-api.glitch.me/books";
        [SetUp]
        public void Setup()
        {
            test = new RestSharpTest();
        }

        [Test]
        public async Task TestResult()
        {
            await test.TestStatusCode(URL);
            await test.TestResponseBodyProperties(URL);
        }




    }
}
