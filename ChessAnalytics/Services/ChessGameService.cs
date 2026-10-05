using System.Net.Http.Headers;
using ChessAnalytics.Models;

namespace ChessAnalytics.Services;

public class ChessGameService
{
    private readonly HttpClient _httpClient;
    
    public ChessGameService()
    {
        _httpClient = new HttpClient();
        SetupClient();
    }

    private void SetupClient()
    {
        _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("ChessAnalytics", "1.0"));
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.BaseAddress = new Uri($"https://api.chess.com/pub/");
        
    }

    public async Task<ChessGameResponse?> GetRecentGames(string username, string year, string month)
    {
        var response =
            await _httpClient.GetFromJsonAsync<ChessGameResponse>(
                $"https://api.chess.com/pub/player/{username}/games/{year}/{month}");
        return response;

    }
}