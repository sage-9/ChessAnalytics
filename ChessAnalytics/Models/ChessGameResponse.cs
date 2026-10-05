using System.Text.Json.Serialization;

namespace ChessAnalytics.Models;

public class ChessGameResponse
{
    [JsonPropertyName("games")]
    public ChessGame[] Games { get; set; }
}