using System.Text.Json;
using ChessAnalytics.Models;
using Microsoft.AspNetCore.Mvc;
namespace ChessAnalytics.Controllers;

[ApiController]
[Route("[controller]")]
public class ChessGameController: ControllerBase
{

    private string _jsonString;
    private string GamesFilePath = "08.json";
    private ChessGame[] _chessGames;

    ActionResult<ChessGame[]> PopulateChessGames()
    {
        try
        {
            _jsonString = System.IO.File.ReadAllText(GamesFilePath);
        }
        catch (FileNotFoundException)
        {
            return NotFound($"Games file '{GamesFilePath}' was not found.");
        }
        catch (IOException ex)
        {
            return StatusCode(500, $"Error reading games file: {ex.Message}");
        }

        try
        {
            var response = JsonSerializer.Deserialize<ChessGameResponse>(_jsonString);
            if (response is null)
            {
                return BadRequest("Games file parsed to an empty result.");
            }
            return response.Games;
        }
        catch (JsonException ex)
        {
            return BadRequest($"Games file was not valid JSON: {ex.Message}");
        }
    }

    [HttpGet(Name = "GetChessGames")]
    public ActionResult<ChessGame[]> GetChessGames()
    {
        var chessGames = PopulateChessGames();

        if (chessGames.Result is not null)
        {
            return chessGames.Result;
        }
 
        return Ok(chessGames.Value);
    }
    
    
}