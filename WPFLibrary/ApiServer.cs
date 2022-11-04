using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using WPFLibrary.JsonModels;

namespace WPFLibrary;

public class ApiServer
{
    public static void Load<JModel>(string req) where JModel : BaseModel
    {
        string url = "https://localhost:5001/";
        var client = new RestClient(url);
        System.Console.WriteLine(typeof(JModel).ToString());
        var request = new RestRequest(req);
        var response = client.Execute(request);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Content;
            var result = JsonConvert.DeserializeObject<JModel>(response.Content);
            System.Console.WriteLine(result);
        }
    }
}