using System.ComponentModel;
using System.Reflection.Emit;

namespace day_7_Camelcards.Tests
{
    public class CardTests
    {
        [Theory]
        [InlineData('1')]
        [InlineData('a')]
        [InlineData('m')]
        public void NonScoped_Characters_Throws_ArgumentException_In_Constructor(char label)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Card(label));
        }

        [Theory]
        [InlineData('A')]
        [InlineData('K')]
        [InlineData('Q')]
        [InlineData('J')]
        [InlineData('T')]
        [InlineData('9')]
        [InlineData('8')]
        [InlineData('7')]
        [InlineData('6')]
        [InlineData('5')]
        [InlineData('4')]
        [InlineData('3')]
        [InlineData('2')]
        public void Scoped_Characters_Create_Constructor_Successfully(char label)
        {
            _ = new Card(label);
        }

        [Theory]
        [InlineData('A')]
        [InlineData('K')]
        [InlineData('Q')]
        [InlineData('J')]
        [InlineData('T')]
        [InlineData('9')]
        [InlineData('8')]
        [InlineData('7')]
        [InlineData('6')]
        [InlineData('5')]
        [InlineData('4')]
        [InlineData('3')]
        [InlineData('2')]
        public void Cards_With_Same_Label_Are_Equal(char label)
        {
            Assert.Equal(0, new Card(label).CompareTo(new Card(label)));
        }

        [Theory]
        [InlineData('A', 'K')]
        [InlineData('K', 'Q')]
        [InlineData('Q', 'J')]
        [InlineData('J', 'T')]
        [InlineData('T', '9')]
        [InlineData('9', '8')]
        [InlineData('8', '7')]
        [InlineData('7', '6')]
        [InlineData('6', '5')]
        [InlineData('5', '4')]
        [InlineData('4', '3')]
        [InlineData('3', '2')]
        public void Cards_Return_Correct_Comparison_Result(char label1, char label2)
        {
            Assert.True((new Card(label1)).CompareTo(new Card(label2)) > 0);
        }

        [Fact]
        public void IsUniversalCard_Throws_NotSupportedException()
        {
            Assert.Throws<NotSupportedException>(() => new Card('A').IsUniversalCard());
        }
    }
}
