using System.Text.Json.Serialization;

namespace ChessAnalytics.Models;


public class ChessGame
{
    [JsonPropertyName("time_control")]
    public required string TimeControl { get; set; }
    
    [JsonPropertyName("tcn")]
    public required string Tcn {get; set;}
    
    [JsonPropertyName("rated")]
    public required bool Rated {get; set;}
    
    [JsonPropertyName("time_class")]
    public required string TimeClass {get; set;}
    
    [JsonPropertyName("rules")]
    public required string Rules {get; set;}
    
    [JsonPropertyName("white")]
    public required ChessPlayer WhitePlayer {get; set;}
    
    [JsonPropertyName("black")]
    public required ChessPlayer BlackPlayer {get; set;}
    
    [JsonPropertyName("eco")]
    public required string EcoLink {get; set;}
}