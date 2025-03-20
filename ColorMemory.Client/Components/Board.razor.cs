using System.Diagnostics;
using ColorMemory.Client.Service;
using ColorMemory.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace ColorMemory.Client.Components;
public partial class Board
{
    [Inject] public required IGameService GameService { get; set; }

    private bool _displayStatistics;
    private Stopwatch _gameTimer = new Stopwatch();
    private bool _disableClick;

    private Player _player = new Player()
    {
        Id = 1,
        Name = "First player",
        Rank = 0,
        Points = 0,
    };

    private async Task FlipCard(int id)
    {
        _disableClick = true;
        await Task.Delay(2000);
        _disableClick = false;

        GameService.FlipCard(id);
        _player.Points = GameService.Points;

        if (GameService.MatchedCards.Count == 16)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        _displayStatistics = true;
        _gameTimer.Stop();
        _player.Time = _gameTimer.Elapsed.Seconds;
        _player.Rank++;
    }

    private void StartGame()
    {
        GameService.StartGame();
        _gameTimer.Restart();
        _player.Points = 0;
        _displayStatistics = false;
    }
}