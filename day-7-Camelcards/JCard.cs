using day_7_Camelcards.Interfaces;

namespace day_7_Camelcards
{
    public class JCard : ICard
    {
        public static readonly char[] Labels = { 'J', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'Q', 'K', 'A' };

        public static readonly Dictionary<char, int> LabelWeights = Labels.Select((value, index) => new { value, index })
                .ToDictionary(pair => pair.value, pair => pair.index);
        public JCard(char label)
        {
            if (Labels.Contains(label)) Label = label;
            else
                throw new ArgumentOutOfRangeException($"Invalid label: {label}");
        }

        public char Label { get; private set; }

        //public override bool Equals(object? obj)
        //{
        //    var cardBeCompared = obj as Card;

        //    if (cardBeCompared == null) return false;

        //    return string.Equals(this.Label, cardBeCompared.Label);
        //}

        public int CompareTo(object? obj)
        {
            var cardBeCompared = obj as JCard;

            if (cardBeCompared == null) return 1;

            return LabelWeights[Label] - LabelWeights[cardBeCompared.Label];
        }

        public bool IsUniversalCard()
        {
            return Label.Equals('J');
        }
    }
}
