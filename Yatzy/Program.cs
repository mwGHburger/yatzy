using System.Linq;
using System;
using System.Collections.Generic;

namespace Yatzy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Yatzy!");
            var diceRoll1 = new int[] {1,2,2,2,2};
            var dictionary = new Dictionary<int,int>();
            foreach(int die in diceRoll1)
            {
                if(dictionary.ContainsKey(die))
                {
                    dictionary[die] = dictionary[die] + 1;
                }
                else
                {
                    dictionary.Add(die,1);
                }
            }

            System.Console.WriteLine(dictionary.Keys); 
            System.Console.WriteLine(dictionary.Keys.Count);
            System.Console.WriteLine(dictionary.Values.Min()); 
        }
    }
}
