using RestSharp;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using RestSharpProject1;

public class ApiClient
{
    private readonly string _baseUrl;
    private readonly RestClient _client;
    private readonly string _configPath;
    private readonly JObject _config;
    public ApiClient()
    {
        // Correct path resolution for AppConfig.json
        _configPath = Path.Combine(AppContext.BaseDirectory, "src", "Config", "AppConfig.json");
        // Ensure the file exists
        if (!File.Exists(_configPath))
        {
            throw new FileNotFoundException("AppConfig.json not found", _configPath);
        }

        var configJson = File.ReadAllText(_configPath);
        _config = JObject.Parse(configJson);
        _baseUrl = _config["BaseUrl"].ToString();
        _client = new RestClient(_baseUrl);
    }

    public RestResponse ExecuteRequest(string resource, Method method, object body = null, string bearerToken = null)
    {
        var request = new RestRequest(resource, method);
        if (!string.IsNullOrEmpty(bearerToken))
        {
            request.AddHeader("Authorization", $"Bearer {bearerToken}");
            request.AddHeader("orgid","237976");
        }
        if (request == null)
        {
            throw new NullReferenceException("RestRequest instance is null");
        }

 
        return _client.Execute(request);
    }
}
