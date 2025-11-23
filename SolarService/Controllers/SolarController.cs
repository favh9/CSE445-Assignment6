using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace SolarService.Controllers
{
    public class SolarController : ApiController
    {
        
        //function that will be called to calculate solar energy generated based on location and roof area
        [HttpGet]
        [Route("api/solar/calculate")]
        public async Task<IHttpActionResult> GetSolarEnergy(string zip, double roofArea)
        {
            // Set up Solar API Key
            var apiKey = ConfigurationManager.AppSettings["Solar:ApiKey"];

            // Convert ZIP to lat/lon
            var coords = await GetLatLon(zip);
            if (coords == null) return BadRequest("Invalid ZIP code.");

            double lat = coords.Item1;
            double lon = coords.Item2;

            string url = $"https://developer.nrel.gov/api/solar/solar_resource/v1.json?api_key={apiKey}&lat={lat}&lon={lon}";

            //use api for solar energy along with some arbitrary values to obtain solar energy generated
            using (HttpClient client = new HttpClient())
            {
                var json = JObject.Parse(await client.GetStringAsync(url));
                double avgSun = (double)json["outputs"]["avg_dni"]["annual"]; // W/m²/day
                double efficiency = 0.18;
                double annualEnergy = roofArea * efficiency * avgSun * 365 / 1000; // kWh/year approx
                return Ok(Math.Round(annualEnergy, 2));
            }
        }
        //function to obtain lat/lon from zip ode
        private async Task<Tuple<double, double>> GetLatLon(string zip)
        {
            using (HttpClient client = new HttpClient())
            {
                var geo = await client.GetStringAsync($"https://api.zippopotam.us/us/{zip}");
                if (string.IsNullOrWhiteSpace(geo)) return null;

                var obj = JObject.Parse(geo);
                double lat = double.Parse((string)obj["places"][0]["latitude"]);
                double lon = double.Parse((string)obj["places"][0]["longitude"]);
                return Tuple.Create(lat, lon);
            }
        }
    }
}