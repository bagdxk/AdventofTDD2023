// See https://aka.ms/new-console-template for more information
using day_7_Camelcards;
using day_7_Camelcards.Interfaces;

var lines = File.ReadAllLines("input1.txt").ToList();
var handList = new List<IHand>();
lines.ForEach(l =>
{
    var parsedCard = l.Split();
    handList.Add(new JHand(parsedCard[0], int.Parse(parsedCard[1])));
})
;

//foreach (var hand in handList)
//{
//    Console.WriteLine($"{hand}, {hand.Type}") ;
//}

handList.Sort();

var sum = 0;
for (var i = 0; i < handList.Count(); i++)
{
    sum += (i + 1) * handList[i].Bid;
}

Console.WriteLine(sum);
Console.ReadLine();
