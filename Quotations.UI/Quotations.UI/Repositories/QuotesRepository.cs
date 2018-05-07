using Newtonsoft.Json;
using Quotations.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Quotations.UI.Repositories
{
    public class QuotesRepository
    {
        private static HttpClient client;
        public QuotesRepository()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50483/");
        }

        //public async Task<Uri> CreateQuoteAsync(Quote quote)
        //{
        //    var json = JsonConvert.SerializeObject(quote);
        //    var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
        //    client.DefaultRequestHeaders.Add("Accept", "application/json");
        //    var request = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Post,
        //        RequestUri = new Uri(client.BaseAddress + "api/quote"),
        //        Content = stringContent
        //    };

           
        //    HttpResponseMessage response = await client.SendAsync(request);

        //    response.EnsureSuccessStatusCode();

        //    // return URI of the created resource.
        //    return response.Headers.Location;
        //}

        public List<Quote> GetQuoteAsync()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var stringTask = client.GetAsync("http://localhost:50483/api/quote");


            var msg =  Task.Run(() => client.GetAsync("http://localhost:50483/api/quote")).Result;
            var myobject = msg.Content.ReadAsStringAsync();
            var newObject = myobject.Result;
            var ab = JsonConvert.DeserializeObject<List<Quote>>(newObject);

            return ab;
        }

        public void CreateQuoteAsync(Quote quote)
        {
            var json = JsonConvert.SerializeObject(quote);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(client.BaseAddress + "api/quote"),
                Content = stringContent
            };

            var response = Task.Run(() => client.PostAsync("http://localhost:50483/api/quote", stringContent)).Result;
        }

        public static object DeserializeFromStream(Stream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            stream.Seek(0, SeekOrigin.Begin);
            object o = formatter.Deserialize(stream);
            return o;
        }

    }
}
