namespace day_7_Camelcards.Tests
{
    public class JHandTests
    {
        [Fact]
        public void JHand_Returns_Correct_HandType()
        {
            var hand = new JHand("KKKKK", 0);
            Assert.Equal(HandType.FiveOfAKind, hand.Type);

            hand = new JHand("JJJJJ", 0);
            Assert.Equal(HandType.FiveOfAKind, hand.Type);

            hand = new JHand("K8888", 0);
            Assert.Equal(HandType.FourOfAKind, hand.Type);

            hand = new JHand("KJJJJ", 0);
            Assert.Equal(HandType.FiveOfAKind, hand.Type);

            hand = new JHand("J8888", 0);
            Assert.Equal(HandType.FiveOfAKind, hand.Type);

            hand = new JHand("K88K8", 0);
            Assert.Equal(HandType.FullHouse, hand.Type);

            hand = new JHand("KJJKJ", 0);
            Assert.Equal(HandType.FiveOfAKind, hand.Type);

            hand = new JHand("J88J8", 0);
            Assert.Equal(HandType.FiveOfAKind, hand.Type);

            hand = new JHand("K89KK", 0);
            Assert.Equal(HandType.ThreeOfAKind, hand.Type);

            hand = new JHand("J89JJ", 0);
            Assert.Equal(HandType.FourOfAKind, hand.Type);

            hand = new JHand("K8JKK", 0);
            Assert.Equal(HandType.FourOfAKind, hand.Type);

            hand = new JHand("K899K", 0);
            Assert.Equal(HandType.TwoPair, hand.Type);

            hand = new JHand("J899J", 0);
            Assert.Equal(HandType.FourOfAKind, hand.Type);

            hand = new JHand("KJ99K", 0);
            Assert.Equal(HandType.FullHouse, hand.Type);

            hand = new JHand("K8K97", 0);
            Assert.Equal(HandType.OnePair, hand.Type);

            hand = new JHand("J8J97", 0);
            Assert.Equal(HandType.ThreeOfAKind, hand.Type);

            hand = new JHand("K8KJ7", 0);
            Assert.Equal(HandType.ThreeOfAKind, hand.Type);

            hand = new JHand("62345", 0);
            Assert.Equal(HandType.HighCard, hand.Type);

            hand = new JHand("J2345", 0);
            Assert.Equal(HandType.OnePair, hand.Type);
        }


        [Fact]
        public void JHand_With_Same_Type_Comparison_Returns_Correct_Result()
        {
            var hand1 = new JHand("KKKKK", 0);
            var hand2 = new JHand("JKKKK", 0);

            var hand4 = new JHand("K89KK", 0);
            var hand5 = new JHand("89KKK", 0);

            var hand6 = new JHand("6J345", 0);
            var hand7 = new JHand("J2347", 0);

            Assert.True(hand1.CompareTo(hand2) > 0);
            Assert.True(hand4.CompareTo(hand5) > 0);
            Assert.True(hand7.CompareTo(hand6) < 0);
        }
    }
}
