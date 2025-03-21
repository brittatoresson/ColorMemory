using ColorMemory.Client.Models;

namespace ColorMemory.Client.Service
{
    public interface IGameService
    {
        List<Card> Cards { get; }
        List<Card> MatchedCards { get; }
        int Points { get; set; }
        bool IsGameActive { get; }
        void StartGame();
        void FlipCard(int id);
    }
    public class GameService : IGameService
    {
        public List<Card> Cards { get; private set; } = [];
        public List<Card> MatchedCards { get; } = [];
        public int Points { get; set; } = 0;
        public bool IsGameActive { get; private set; }

        public void StartGame()
        {
            Cards = Shuffle(GenerateCards());
            MatchedCards.Clear();
            Points = 0;
            IsGameActive = true;
        }

        public void FlipCard(int id)
        {
            var selectedCard = Cards.FirstOrDefault(c => c.Id == id);
            if (selectedCard == null || selectedCard.IsFlipped) return;

            selectedCard.IsFlipped = true;

            var flippedCards = Cards.Where(c => c.IsFlipped && !c.IsMatch).ToList();
            if (flippedCards.Count == 2)
            {
                CheckMatchAndUpdateCardList(flippedCards);

                if (Cards.All(c => c.IsMatch))
                {
                    IsGameActive = false;
                }
            }
        }
        private void CheckMatchAndUpdateCardList(List<Card> flippedCards)
        {
            if (flippedCards[0].PairId == flippedCards[1].PairId)
            {
                flippedCards.ForEach(c => c.IsMatch = true);
                MatchedCards.AddRange(flippedCards);
                Points++;
            }
            else
            {
                flippedCards.ForEach(c => c.IsFlipped = false);
                Points--;
            }
        }

     

        private List<Card> GenerateCards()
        {
            return new List<Card>
        {
            new Card { Id = 1, PairId = 1, Color = "red", BgColor = "bg-danger", IsFlipped = false, IsMatch = false },
            new Card { Id = 2, PairId = 1, Color = "red", BgColor = "bg-danger", IsFlipped = false, IsMatch = false },
            new Card { Id = 3, PairId = 2, Color = "blue", BgColor = "bg-primary", IsFlipped = false, IsMatch = false },
            new Card { Id = 4, PairId = 2, Color = "blue", BgColor = "bg-primary", IsFlipped = false, IsMatch = false },
             new Card { Id = 5, PairId = 3, Color = "green", BgColor = "bg-success", IsFlipped = false, IsMatch = false },
             new Card { Id = 6, PairId = 3, Color = "green", BgColor = "bg-success", IsFlipped = false, IsMatch = false },
             new Card { Id = 7, PairId = 4, Color = "yellow", BgColor = "bg-warning", IsFlipped = false, IsMatch = false },
             new Card { Id = 8, PairId = 4, Color = "yellow", BgColor = "bg-warning", IsFlipped = false, IsMatch = false },
             new Card { Id = 9, PairId = 5, Color = "purple", BgColor = "bg-purple", IsFlipped = false, IsMatch = false },
             new Card { Id = 10, PairId = 5, Color = "purple", BgColor = "bg-purple", IsFlipped = false, IsMatch = false },
             new Card { Id = 11, PairId = 6, Color = "orange", BgColor = "bg-warning", IsFlipped = false, IsMatch = false },
             new Card { Id = 12, PairId = 6, Color = "orange", BgColor = "bg-warning", IsFlipped = false, IsMatch = false },
             new Card { Id = 13, PairId = 7, Color = "pink", BgColor = "bg-pink", IsFlipped = false, IsMatch = false },
             new Card { Id = 14, PairId = 7, Color = "pink", BgColor = "bg-pink", IsFlipped = false, IsMatch = false },
             new Card { Id = 15, PairId = 8, Color = "cyan", BgColor = "bg-info", IsFlipped = false, IsMatch = false },
             new Card { Id = 16, PairId = 8, Color = "cyan", BgColor = "bg-info", IsFlipped = false, IsMatch = false }
        };
        }

        private List<Card> Shuffle(List<Card> cards)
        {
            var currentIndex = cards.Count;
            var random = new Random();

            while (currentIndex != 0)
            {
                int randomIndex = random.Next(currentIndex);
                currentIndex--;

                // And swap it with the current element using destructuring ( a temporary variable)
                (cards[currentIndex], cards[randomIndex]) = (cards[randomIndex], cards[currentIndex]);
            }
            return cards;
        }
    }

}
