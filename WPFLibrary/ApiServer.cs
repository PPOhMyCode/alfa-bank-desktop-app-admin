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
        var request = new RestRequest(req, Method.Get);
        var response = client.Execute(request);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            string rawResponse = response.Content;
            var result = JsonConvert.DeserializeObject<JModel>(response.Content);
            return result;
        }

        return default;
    }
    
    public static RestResponse Delete(string req)
    {
        string url = "https://localhost:5001/";
        var client = new RestClient(url);
        var request = new RestRequest(req, Method.Delete);
        var response = client.Execute(request);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            string rawResponse = response.Content;
        }

        return response;
    }
    
    public static RestResponse Post<JModel>(JModel model,string req)
    {
        string url = "https://localhost:5001/";
        var client = new RestClient(url);
        var request = new RestRequest(req, Method.Post);
        request.AddHeader("Accept", "*/*");
        request.AddHeader("Content-Type", "application/json");
        var body = JsonConvert.SerializeObject(model);
        request.AddJsonBody(body, "application/json");
        RestResponse response = client.Execute(request);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var output = response.Content;
            System.Console.WriteLine(output);
        }

        return response;
    }
}