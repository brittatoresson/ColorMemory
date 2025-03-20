
using ColorMemory.Client.Service;

namespace ColorMemory.Test.ServiceTest;

public class GameServiceTests
{
    private readonly GameService _gameService;

    public GameServiceTests()
    {
        _gameService = new GameService();
    }

    [Fact]
    public void StartGame_ShouldInitializeGame()
    {
        // Act
        _gameService.StartGame();

        // Assert
        Assert.True(_gameService.IsGameActive);
        Assert.Equal(16, _gameService.Cards.Count);
        Assert.Empty(_gameService.MatchedCards);
        Assert.Equal(0, _gameService.Points);
    }

    [Fact]
    public void FlipCard_ShouldFlipCard()
    {
        // Arrange
        _gameService.StartGame();
        var cardId = _gameService.Cards.First().Id;

        // Act
        _gameService.FlipCard(cardId);

        // Assert
        var flippedCard = _gameService.Cards.First(c => c.Id == cardId);
        Assert.True(flippedCard.IsFlipped);
    }

    [Fact]
    public void FlipCard_ShouldMatchCards()
    {
        // Arrange
        _gameService.StartGame();
        var firstCard = _gameService.Cards.First();
        var matchingCard = _gameService.Cards.First(c => c.PairId == firstCard.PairId && c.Id != firstCard.Id);

        // Act
        _gameService.FlipCard(firstCard.Id);
        _gameService.FlipCard(matchingCard.Id);

        // Assert
        Assert.True(firstCard.IsMatch);
        Assert.True(matchingCard.IsMatch);
        Assert.Contains(firstCard, _gameService.MatchedCards);
        Assert.Contains(matchingCard, _gameService.MatchedCards);
        Assert.Equal(1, _gameService.Points);
    }

    [Fact]
    public void FlipCard_ShouldNotMatchDifferentCards()
    {
        // Arrange
        _gameService.StartGame();
        var firstCard = _gameService.Cards.First();
        var nonMatchingCard = _gameService.Cards.First(c => c.PairId != firstCard.PairId);

        // Act
        _gameService.FlipCard(firstCard.Id);
        _gameService.FlipCard(nonMatchingCard.Id);

        // Assert
        Assert.False(firstCard.IsMatch);
        Assert.False(nonMatchingCard.IsMatch);
        Assert.False(firstCard.IsFlipped);
        Assert.False(nonMatchingCard.IsFlipped);
        Assert.Equal(-1, _gameService.Points);
    }

    [Fact]
    public void Points_ShouldUpdateCorrectly()
    {
        // Arrange
        _gameService.StartGame();
        var firstCard = _gameService.Cards.First();
        var matchingCard = _gameService.Cards.First(c => c.PairId == firstCard.PairId && c.Id != firstCard.Id);
        var nonMatchingCard = _gameService.Cards.First(c => c.PairId != firstCard.PairId);

        // Act & Assert
        // Flip matching cards
        _gameService.FlipCard(firstCard.Id);
        _gameService.FlipCard(matchingCard.Id);
        Assert.Equal(1, _gameService.Points);

        // Flip non-matching cards
        _gameService.FlipCard(firstCard.Id);
        _gameService.FlipCard(nonMatchingCard.Id);
        Assert.Equal(-1, _gameService.Points);
    }


    [Fact]
    public void Cards_ShouldBe16()
    {
        // Arrange
        _gameService.StartGame();

        // Act
        var numberOfCards = _gameService.Cards.Count;

        // Assert
        Assert.Equal(16, numberOfCards);
    }

}
