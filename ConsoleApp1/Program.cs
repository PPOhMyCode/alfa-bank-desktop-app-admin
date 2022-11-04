// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using RestSharp;

public class Program
{
    static void Main(string[] args)
    {
        string? name = Console.ReadLine();
        Load();
    }
    public static void Load()
    {
        string url = "https://localhost:5001/";
        var client = new RestClient(url);
        var request = new RestRequest("Dish");
        var response = client.Execute(request);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Content;
            List<Datum> result = JsonConvert.DeserializeObject<List<Datum>>(rawResponse);
            System.Console.WriteLine(result[0]);
        }
    }

    public class RootObject
    {
        public string status { get; set; }
        public Datum[] data { get; set; }
    }
    
    public class Datum
    {
        public string name { set; get; }
        public string discription { set; get; }
        public double cost { set; get; }
        public double weight { set; get; }
        public double calories { set; get; }
        public string id { set; get; }
    }
}