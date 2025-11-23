using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ChatBotService.Controllers
{
    public class ChatBotController : ApiController
    {
        [RoutePrefix("api/chatbot/ask")]
        public class SummaryController : ApiController
        {
            HttpClient http = new HttpClient();

            [HttpGet, Route("")]
            public async Task<IHttpActionResult> Get(string inputTxt)
            {

                var text = inputTxt?.Trim() ?? "";

                // Check word count
                var wordCount = text.Split(' ').Length;
                if (wordCount > 100)
                    return Ok("INPUT_TOO_LONG");


                // Detect email-related queries
                if (text.ToLower().Contains("email"))
                    return Ok("EMAIL_SERVICE");

                // Basic solar topic validation
                var keywords = new[]
                {
                    "solar", "panel", "panels", "roof", "sun", "energy",
                    "pv", "photovoltaic", "efficiency", "kwh", "system size"
                };

                bool isSolarRelated = keywords.Any(k => text.ToLower().Contains(k));

                if (!isSolarRelated)
                    return Ok("UNRELATED_TOPIC");


                // Set up OpenAI API request
                var apiKey = ConfigurationManager.AppSettings["OpenAI:ApiKey"];
                var model = ConfigurationManager.AppSettings["OpenAI:Model"] ?? "gpt-4o-mini";

                http.DefaultRequestHeaders.Clear();
                http.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                // Gives instructions to the model
                var payload = new
                {
                    model,
                    messages = new[] {
                new {
                    role="system",
                    content=
                    "You are a Solar Energy Expert specializing in rooftop assessment," +
                    " photovoltaic performance, financial savings estimation, and energy-efficiency consulting. " +
                    "Ask for another question if the topic is unrelated to solar." +
                    "Reply back in a short 1-2 sentence answer containing nothing but text."
                },
                new { role="user", content=text }
            }
                };

                var body = new StringContent(JsonConvert.SerializeObject(payload),
                                             Encoding.UTF8, "application/json");

                var resp = await http.PostAsync("https://api.openai.com/v1/chat/completions", body);
                var json = await resp.Content.ReadAsStringAsync();

                var content = JObject.Parse(json)["choices"]?[0]?["message"]?["content"]?.ToString()
                               ?? "Summary unavailable.";

                return Ok(new { message = content.Trim() });
            }
        }
    }
}