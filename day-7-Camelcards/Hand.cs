namespace day_7_Camelcards
{
    public class Hand : BaseHand
    {
        public Hand(string labels, int bid)
            : base(labels, bid)
        {
            foreach (var c in labels)
            { 
                _cards.Add(new Card(c));
            }
        }

        protected override HandType GetCustomizedHandType(HandType handType)
        {
            return handType;
        }
    }
}
