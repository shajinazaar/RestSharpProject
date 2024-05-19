using Newtonsoft.Json;
using RestSharp;
using System.Net;

public class RestSharpTest
{
  
    public async Task<RestResponse> SendGetRequest(string url)
    {
        var client = new RestClient(url);
        var request = new RestRequest();

        return await client.ExecuteAsync(request);
    }

    
    public async Task TestStatusCode(string url)
    {
        RestResponse response = await SendGetRequest(url);

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Status code is not 200");
    }

    public async Task TestResponseBodyProperties(string url)
    {
        RestResponse response = await SendGetRequest(url);

        if (response.IsSuccessful)
        {
            var responseBody = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(response.Content);

            foreach (var item in responseBody)
            {
                Assert.True(item.ContainsKey("id"), "Response body item missing 'id' property");
                Assert.True(item.ContainsKey("name"), "Response body item missing 'name' property");
            }
        }
        else
        {
            // Handle unsuccessful response (e.g., log error)
            Console.WriteLine($"Request failed with status code: {response.StatusCode}");
        }
    }
}
