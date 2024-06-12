using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using TestAppWeb.Services;

namespace TestAppWeb.Hubs
{
    public class ChatHub : Hub
    {
        private readonly OpenAIService _openAIService;

        public ChatHub(OpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        public async Task SendMessage(string user, string message)
        {
            var botResponse = await _openAIService.GetBotResponse(message);
            await Clients.All.SendAsync("ReceiveMessage", "Bot", botResponse);
        }
    }
}
