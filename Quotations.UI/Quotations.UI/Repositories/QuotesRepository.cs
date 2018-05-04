using Newtonsoft.Json;
using Quotations.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            client.BaseAddress = new Uri("http://localhost:32772/");
        }

        public async Task<Uri> CreateQuoteAsync(Quote quote)
        {
            var json = JsonConvert.SerializeObject(quote);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost:32772/api/quote"),
                Content = stringContent
            };

           
            HttpResponseMessage response = Task.Run(() => client.SendAsync(request)).Result;

            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

    }
}
