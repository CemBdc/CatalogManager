using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManager.Benchmark
{
    public class RESTClient
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<string> GetPayloadAsync()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await client.GetStringAsync("http://localhost:5000/api/v1/product");
        }
        
    }
}
