using System.Text.Json.Serialization;

namespace ChessAnalytics.Models;

public class ChessPlayer
{
    [JsonPropertyName("rating")]
    public int Rating { get; set; }
    
    [JsonPropertyName("result")]
    public string? Result { get; set; }
    
    [JsonPropertyName("username")]
    public required string UserName { get; set; }
}