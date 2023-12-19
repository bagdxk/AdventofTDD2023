using day_7_Camelcards.Interfaces;

namespace day_7_Camelcards
{
    public abstract class BaseHand : IHand
    {
        protected readonly IList<ICard> _cards = new List<ICard>();

        protected readonly Lazy<HandType> _handType;

        public HandType Type { get { return _handType.Value; } }

        public int Bid { get; private set; }

        public BaseHand(string labels, int bid)
        {
            var charLabels = labels.ToCharArray();
            if (charLabels.Length != 5) throw new ArgumentException($"Invalid Camel Card: {labels}");

            Bid = bid;

            _handType = new Lazy<HandType>(GetHandType);
        }

        public IList<ICard> Cards { get { return _cards; } }

        protected abstract HandType GetCustomizedHandType(HandType handType);

        protected HandType GetHandType()
        {
            var handType = GetBaseHandType();

            return GetCustomizedHandType(handType);
        }

        private HandType GetBaseHandType()
        {
            var groups = _cards.GroupBy(x => x.Label).OrderByDescending(g => g.Count());

            var groupCount = groups.Count();
            switch (groupCount)
            {
                case 1:
                    return HandType.FiveOfAKind;
                case 2:
                    if (groups.First().Count() == 4)
                    {
                        return HandType.FourOfAKind;
                    }
                    else return HandType.FullHouse;

                case 3:
                    if (groups.First().Count() == 3)
                    {
                        return HandType.ThreeOfAKind;
                    }
                    else return HandType.TwoPair;

                case 4:
                    return HandType.OnePair;

                default:
                    return HandType.HighCard;
            }
        }

        public int CompareTo(object? obj)
        {
            var handBeCompared = obj as IHand;

            if (handBeCompared == null) return 1;

            if (Type == handBeCompared.Type)
            {
                var i = 0;

                var compareResult = 0;
                while (i < 5 && compareResult == 0)
                {
                    compareResult = Cards[i].CompareTo(handBeCompared.Cards[i]);

                    i++;

                    if (compareResult == 0) continue;

                    return compareResult;
                }

                return compareResult;
            }

            return (int)Type - (int)handBeCompared.Type;
        }


        //public override string ToString()
        //{
        //    return string.Concat(_cards.Select(x => x.Label).ToArray());
        //}
    }
}
