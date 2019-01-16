using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wetr.Domainclasses;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Wetr.Simulator{

    public class JSONInterpreter
    {        
        private static async Task<T> Get<T>(string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));    
            var result = await client.GetAsync(url).ConfigureAwait(false);
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadAsJsonAsync<T>().ConfigureAwait(false);
        }

        public static async Task<List<Stations>> GetAllStations()
        {
            return await Get<List<Stations>>("http://localhost:5000/api/getallstations");

        }
    }
}

            /*
            static HttpClient client = new HttpClient();

        //static void ShowProduct(Product product)
        //{
        //    Console.WriteLine($"Name: {product.Name}\tPrice: " +
        //        $"{product.Price}\tCategory: {product.Category}");
        //}

        //static async Task<Uri> CreateProductAsync(Product product)
        //{
        //    HttpResponseMessage response = await client.PostAsJsonAsync(
        //        "api/products", product);
        //    response.EnsureSuccessStatusCode();

        //    // return URI of the created resource.
        //    return response.Headers.Location;
        //}

        static async Task<Stations> GetAllStationsAsync(string path)
        {
            Stations stations = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                stations = await response.Content.ReadAsAsync<Stations>();
            }
            return stations;
        }

        //static async Task<Product> UpdateProductAsync(Product product)
        //{
        //    HttpResponseMessage response = await client.PutAsJsonAsync(
        //        $"api/products/{product.Id}", product);
        //    response.EnsureSuccessStatusCode();

        //    // Deserialize the updated product from the response body.
        //    product = await response.Content.ReadAsAsync<Product>();
        //    return product;
        //}

        //static async Task<HttpStatusCode> DeleteProductAsync(string id)
        //{
        //    HttpResponseMessage response = await client.DeleteAsync(
        //        $"api/products/{id}");
        //    return response.StatusCode;
        //}

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}*/
