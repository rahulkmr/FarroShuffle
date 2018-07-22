using System;
using System.Collections.Generic;
using System.Linq;

namespace FaroShuffle
{
    class Program
    {
        static IEnumerable<Suit> Suits() => Enum.GetValues(typeof(Suit)) as IEnumerable<Suit>;

        static IEnumerable<Rank> Ranks() => Enum.GetValues(typeof(Rank)) as IEnumerable<Rank>;


        static void Main(string[] args)
        {
            var startingDeck = from s in Suits()
                               from r in Ranks()
                               select new { Suit = s, Rank = r };
            var times = 0;
            var shuffle = startingDeck;
            do
            {
                shuffle = shuffle.Take(26).InterleaveSequenceWith(shuffle.Skip(26));
                foreach (var card in shuffle)
                {
                    Console.WriteLine(card);
                }
                Console.WriteLine();
                times++;
            } while (!startingDeck.SequenceEquals(shuffle));

            Console.WriteLine(times);
        }
    }
}
