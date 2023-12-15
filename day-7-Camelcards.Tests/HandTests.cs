using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day_7_Camelcards.Tests
{
    public class HandTests
    {
        [Theory]
        [InlineData("32T3K1")]
        [InlineData("32T3")]
        public void OutOfRange_Labels_Throws_ArgumentException_In_Constructor(string labels)
        {
            Assert.Throws<ArgumentException>(() => new Hand(labels, 0));
        }

        [Theory]
        [InlineData("32T3K")]
        public void Constructor_Created_Successfully(string labels)
        {
            var hand = new Hand(labels, 0);
            Assert.Equal(5, hand.Cards.Count);
            Assert.Equal('3', hand.Cards[0].Label);
            Assert.Equal('2', hand.Cards[1].Label);
            Assert.Equal('T', hand.Cards[2].Label);
            Assert.Equal('3', hand.Cards[3].Label);
            Assert.Equal('K', hand.Cards[4].Label);
        }

        [Fact]
        public void Hand_Returns_Correct_HandType()
        {
            var hand = new Hand("KKKKK", 0);
            Assert.Equal(HandType.FiveOfAKind, hand.Type);

            hand = new Hand("K8888", 0);
            Assert.Equal(HandType.FourOfAKind, hand.Type);

            hand = new Hand("K88K8", 0);
            Assert.Equal(HandType.FullHouse, hand.Type);

            hand = new Hand("K89KK", 0);
            Assert.Equal(HandType.ThreeOfAKind, hand.Type);

            hand = new Hand("K899K", 0);
            Assert.Equal(HandType.TwoPair, hand.Type);

            hand = new Hand("K8K97", 0);
            Assert.Equal(HandType.OnePair, hand.Type);

            hand = new Hand("62345", 0);
            Assert.Equal(HandType.HighCard, hand.Type);
        }

        [Fact]
        public void Hand_Comparison_Returns_Correct_Based_On_HandType()
        {
            var hand1 = new Hand("KKKKK", 0);
            var hand2 = new Hand("K8888", 0);
            var hand3 = new Hand("K88K8", 0);
            var hand4 = new Hand("K89KK", 0);
            var hand5 = new Hand("K899K", 0);
            var hand6 = new Hand("K8K97", 0);
            var hand7 = new Hand("62345", 0);

            Assert.True(hand1.CompareTo(hand2) > 0);
            Assert.True(hand1.CompareTo(hand3) > 0);
            Assert.True(hand1.CompareTo(hand4) > 0);
            Assert.True(hand1.CompareTo(hand5) > 0);
            Assert.True(hand1.CompareTo(hand6) > 0);
            Assert.True(hand1.CompareTo(hand7) > 0);

            Assert.True(hand2.CompareTo(hand3) > 0);

            Assert.True(hand3.CompareTo(hand4) > 0);

            Assert.True(hand4.CompareTo(hand5) > 0);

            Assert.True(hand5.CompareTo(hand6) > 0);

            Assert.True(hand6.CompareTo(hand7) > 0);
        }

        [Fact]
        public void Hand_With_Same_Type_Comparison_Returns_Correct_Result()
        {
            var hand1 = new Hand("KKKKK", 0);
            var hand2 = new Hand("22222", 0);

            var hand4 = new Hand("K89KK", 0);
            var hand5 = new Hand("89KKK", 0);

            var hand6 = new Hand("62345", 0);
            var hand7 = new Hand("62347", 0);

            Assert.True(hand1.CompareTo(hand2) > 0);
            Assert.True(hand4.CompareTo(hand5) > 0);
            Assert.True(hand7.CompareTo(hand6) > 0);
        }
    }
}
