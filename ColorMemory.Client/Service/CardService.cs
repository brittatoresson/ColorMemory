using System.Net.Http.Json;
using System.Text.Json;
using ColorMemory.Client.Models;

namespace ColorMemory.Client.Service
{
    public interface ICardService
    {
        Task<List<Card>> GetCardsAsync();
    }
    public class CardService : ICardService
    {
        private readonly HttpClient _httpClient;

        public CardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Card>> GetCardsAsync()
        {
      
        var json = await _httpClient.GetFromJsonAsync<List<Card>>("/Cards.json");
        //var json = await _httpClient.GetStringAsync("/Cards.json");
            //var cards = JsonSerializer.Deserialize<List<Card>>(json);
            return json;
        }
    }

}
