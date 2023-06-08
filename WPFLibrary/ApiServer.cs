using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;
using RestSharp;
using WPFLibrary.JsonModels;

namespace WPFLibrary;



public class ApiServer
{
    public static string Base64Encode(string plainText) {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }
    
    public static string Base64Decode(string base64EncodedData) {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }
    
    private static string URL { get; set; }
    
    public static JModel Get<JModel>(string req)
    {
        var client = new RestClient(URL);
        var request = new RestRequest(req, Method.Get);
        var response = client.Execute(request);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            string rawResponse = response.Content;
            var a = rawResponse;
            var b = JsonConvert.SerializeObject(new ReceiptCardInput());
            Console.WriteLine(b);
            var m = b.Length;
            var result = JsonConvert.DeserializeObject<JModel>(response.Content);
            return result;
        }

        return default;
    }
    
    public static BitmapImage GetImage(string req)
    {
        var c = new WebClient();
        byte[] bytes;
        try
        {
            bytes = c.DownloadData("https://storage.yandexcloud.net/systemimg/"+ req +".png");
        }
        catch
        {
            bytes = c.DownloadData("https://storage.yandexcloud.net/systemimg/-1.png");
        }
        var ms = new MemoryStream(bytes);
        var image = new Image();
        BitmapImage bitmap = new BitmapImage();
        bitmap.BeginInit();
        bitmap.StreamSource =ms;
        bitmap.EndInit();
        
        return bitmap;
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
        request.AddJsonBody(Base64Encode(body), "application/json");
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
        request.AddJsonBody(Base64Encode(body), "application/json");
        RestResponse response = client.Execute(request);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var a = JsonConvert.DeserializeObject<AuthData>(response.Content);
            URL = a.url;
            System.Console.WriteLine(URL);
            return response;
        }
            
        return null;
    }
}