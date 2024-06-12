using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestAppWeb.Services
{
    public class OpenAIService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public OpenAIService(string apiKey)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
        }

        public async Task<string> GetBotResponse(string message)
        {
            try
            {
                var request = new
                {
                    prompt = message,
                    max_tokens = 150,
                    temperature = 0.7,
                    stop = "\n",
                };

                var requestJson = JsonSerializer.Serialize(request);

                var content = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");

                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

                var response = await _httpClient.PostAsync("https://api.openai.com/v1/completions", content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to get response from OpenAI API.");
                }

                var responseContent = await response.Content.ReadAsStringAsync();

                var responseObject = JsonSerializer.Deserialize<OpenAIResponse>(responseContent);

                return responseObject.choices[0].text.Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting bot response: {ex.Message}");
                return "Sorry, I couldn't process your request.";
            }
        }

        private class OpenAIResponse
        {
            public OpenAIChoice[] choices { get; set; }
        }

        private class OpenAIChoice
        {
            public string text { get; set; }
        }
    }
}

