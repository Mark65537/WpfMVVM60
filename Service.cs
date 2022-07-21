using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserWebAPI21.Models;

namespace WpfMVVM60
{
    internal class Service
    {
        public static async Task<List<User>?> LoadDataAsync()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://localhost:44340/api/values");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            HttpResponseMessage response = client.Send(request);
            response.EnsureSuccessStatusCode();

            var respContent = await response.Content.ReadAsStringAsync();
            
            try
            {
                List<User> json = JsonConvert.DeserializeObject<List<User>>(respContent);
                return json;
            }
            catch (JsonReaderException)
            {
                Console.WriteLine("Invalid JSON.");
            }
            return null;
        }
    }
}
