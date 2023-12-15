namespace day_7_Camelcards.Interfaces
{
    public interface ICard : IComparable
    {
        char Label { get; }

        bool IsUniversalCard();
    }
}
