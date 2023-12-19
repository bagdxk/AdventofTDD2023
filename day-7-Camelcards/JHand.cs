namespace day_7_Camelcards
{
    public class JHand : BaseHand
    {
        public JHand(string labels, int bid)
            : base(labels, bid)
        {
            foreach (var c in labels)
            {
                _cards.Add(new JCard(c));
            }
        }

        protected override HandType GetCustomizedHandType(HandType handType)
        {
            var universalCardsCount = _cards.Count(c => c.IsUniversalCard());
            if (universalCardsCount == 0) return handType;

            var groups = _cards.GroupBy(x => x.Label).OrderByDescending(g => g.Count());

            switch (handType)
            {
                case HandType.FiveOfAKind:
                case HandType.FourOfAKind:
                case HandType.FullHouse:
                   return HandType.FiveOfAKind;

                case HandType.ThreeOfAKind:
                    return HandType.FourOfAKind;

                case HandType.TwoPair:
                    if (universalCardsCount == 2) return HandType.FourOfAKind;
                    else return HandType.FullHouse;

                case HandType.OnePair:
                    return HandType.ThreeOfAKind;

                default:
                    return HandType.OnePair;
            }
        }
    }
}
