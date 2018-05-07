using Newtonsoft.Json;
using Quotations.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public async void GetQuoteAsync(Quote quote)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var stringTask = client.GetStringAsync("http://localhost:50483/api/quote");


            var msg = await stringTask;
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

    }
}
