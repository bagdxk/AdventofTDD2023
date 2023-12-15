namespace day_7_Camelcards.Interfaces
{
    public interface IHand : IComparable
    {
        IList<ICard> Cards { get; }

        int Bid { get; }

        HandType Type { get; }
    }
}
