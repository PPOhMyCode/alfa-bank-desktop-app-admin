using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using WPFLibrary.JsonModels;

namespace WPFLibrary;

public class ApiServer
{
    public static JModel Get<JModel>(string req)
    {
        string url = "https://localhost:5001/";
        var client = new RestClient(url);
        var request = new RestRequest(req);
        var response = client.Execute(request);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            string rawResponse = response.Content;
            var result = JsonConvert.DeserializeObject<JModel>(response.Content);
            return result;
        }

        return default;
    }
}