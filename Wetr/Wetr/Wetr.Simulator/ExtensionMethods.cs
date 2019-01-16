using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Wetr.Simulator
{
    public static class ExtensionMethods
    {
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            var dataAsString = await content.ReadAsStringAsync().ConfigureAwait(false);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(dataAsString);
        }

        
    }
}
