using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoweatherApp
{
    class Program
    {
        static async Task Main(string[] args)
        {

            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync("https://goweather.herokuapp.com/weather/Kyiv");
                response.EnsureSuccessStatusCode();
                string responseT = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseT);
                CityInfo ci = JsonConvert.DeserializeObject<CityInfo>(responseT);
                Console.WriteLine($"Температура в Киеве: {ci.Temperature}");


                response = await client.GetAsync("https://goweather.herokuapp.com/weather/Odesa");
                response.EnsureSuccessStatusCode();
                responseT = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseT);
                ci = JsonConvert.DeserializeObject<CityInfo>(responseT);
                Console.WriteLine($"Температура в Одессе: {ci.Temperature}");

                Console.ReadKey();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException");
                Console.WriteLine("Message :{0} ", e.Message);
            }

        }
    }
}
