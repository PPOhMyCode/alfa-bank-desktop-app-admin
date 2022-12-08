using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using WPFLibrary.JsonModels;

namespace WPFLibrary;



public class ApiServer
{
    private static string URL { get; set; }
    
    public static JModel Get<JModel>(string req)
    {
        var client = new RestClient(URL);
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
    
    public static JModel GetImage<JModel>(string req)
    {
        var client = new RestClient("https://storage.yandexcloud.net/systemimg/");
        var request = new RestRequest("pasta.png", Method.Get);
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
        var client = new RestClient(URL);
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
        var client = new RestClient(URL);
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
    
    public static RestResponse Autorization<JModel>(JModel model)
    {
        string url = "https://d5dr8ccmms8urkspiqc2.apigw.yandexcloud.net";
        var client = new RestClient(url);
        var request = new RestRequest("authorization", Method.Post);
        request.AddHeader("Accept", "*/*");
        request.AddHeader("Content-Type", "application/json");
        var body = JsonConvert.SerializeObject(model);
        request.AddJsonBody(body, "application/json");
        RestResponse response = client.Execute(request);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var a = JsonConvert.DeserializeObject<AuthData>(response.Content);
            URL = a.url;
            System.Console.WriteLine(URL);
        }
            
        return response;
    }
}