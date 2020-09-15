using System;

namespace Yatzy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Yatzy!");
            var diceRoll1 = new int[5] {3,3,3,4,4};
            var ret = Array.FindAll(diceRoll1, x => x == 4);
            System.Console.WriteLine(ret.Length);
        }
    }
}
