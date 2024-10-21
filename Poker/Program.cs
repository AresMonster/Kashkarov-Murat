namespace Poker
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Колода Джона: ♦️6 ♥️2 ♠️3 ♦️5 ♠️J ♣️Q ♠️K ♣️7 ♦️2 ♣️5 ♥️5 ♥️10 ♠️A");
            string john = "♦️6 ♥️2 ♠️3 ♦️5 ♠️J ♣️Q ♠️K ♣️7 ♦️2 ♣️5 ♥️5 ♥️10 ♠️A";
            Console.WriteLine("Колода дяди: ♠️2 ♠️3 ♠️5 ♥️J ♥️Q ♥️K ♣️8 ♣️9 ♣️10 ♦️4 ♦️5 ♦️6 ♦️7");
            string uncle = "♠️2 ♠️3 ♠️5 ♥️J ♥️Q ♥️K ♣️8 ♣️9 ♣️10 ♦️4 ♦️5 ♦️6 ♦️7";
            string result = SortCards(john, uncle);
            Console.WriteLine("Отсортированные карты Джона: ");
            Console.WriteLine(result);
        }

        static string SortCards(string john, string uncle)
        {
            var johnCards = john.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var uncleCards = uncle.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var suitOrder = new Dictionary<char, int>();
            for (int i = 0; i < uncleCards.Count; i++)
            {
                char suit = uncleCards[i][0];
                if (!suitOrder.ContainsKey(suit))
                {
                    suitOrder[suit] = i;
                }
            }

            foreach (var card in johnCards)
            {
                char suit = card[0];
                if (!suitOrder.ContainsKey(suit))
                {
                    suitOrder[suit] = int.MaxValue;
                }
            }

            var sortedJohnCards = johnCards.OrderBy(card => suitOrder[card[0]])
                                            .ThenBy(card => GetCardRank(card[1..].Trim()))
                                            .ToList();

            return string.Join(" ", sortedJohnCards);
        }

        static int GetCardRank(string card)
        {
            switch (card)
            {
                case "2": return 2;
                case "3": return 3;
                case "4": return 4;
                case "5": return 5;
                case "6": return 6;
                case "7": return 7;
                case "8": return 8;
                case "9": return 9;
                case "10": return 10;
                case "J": return 11;
                case "Q": return 12;
                case "K": return 13;
                case "A": return 14;
                default: return 0;
            }
        }
    }
}
