//using CurrencyConverter.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Wetr.Domainclasses;
//using ProxyDomain = CurrencyConverter.Proxy;

namespace Wetr.APIClient
{
    static class Extensions
    {
        public static string FirstLine(this string str)
        {
            int nlIdx = str.IndexOf("\n");
            return nlIdx < 0 ? str : str.Substring(0, nlIdx);
        }
    }

    class Program
    {
        private const string BASE_URI = "http://localhost:5000";
        private static readonly string CONVERTER_SERVICE_URI = $"{BASE_URI}/api/getallstations";

        private static async Task HttpNetClient(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage resp1 = await httpClient.GetAsync(CONVERTER_SERVICE_URI);
            resp1.EnsureSuccessStatusCode();

            //string body = await resp1.Content.ReadAsStringAsync();
            //Console.WriteLine($"resp1.Content={body}");

            var currList = await resp1.Content.ReadAsAsync<IEnumerable<Stations>>();
            foreach (var curr in currList)
            {
                Console.WriteLine(curr);
            }

            Console.WriteLine("-------------------------------");

            foreach (string symbol in new[] { "USD", "XXX" })
            {
                HttpResponseMessage resp2 = await httpClient.GetAsync($"{CONVERTER_SERVICE_URI}/{symbol}");
                if (resp2.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"currency {symbol} does not exist");
                }
                else
                {
                    Console.WriteLine(await resp2.Content.ReadAsAsync<Stations>());
                }


            }


        }

        //private async static Task SwaggerBasedClient(HttpClient httpClient)
        //{
        //    ConverterProxy converter = new ConverterProxy(httpClient);

        //    foreach (string symbol in new[] { "USD", "XXX" })
        //    {
        //        try
        //        {
        //            SwaggerResponse<ProxyDomain.CurrencyData> data = await converter.GetBySymbolAsync(symbol);
        //            Console.WriteLine($"{data.Result.Symbol}");

        //        } catch (SwaggerException se)
        //        {
        //            Console.WriteLine($"SwaggerException: StatusCode={se.StatusCode}, Message={se.Message.FirstLine()}");
        //        }
        //    }

        //}

        async static Task Main(string[] args)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Console.WriteLine("================ HttpNetClient ==================");
                await HttpNetClient(httpClient);

                Console.WriteLine();

                Console.WriteLine("============== SwaggerBasedClient ===============");
                //await SwaggerBasedClient(httpClient);

                Console.ReadKey();
            }
        }
    }
}
