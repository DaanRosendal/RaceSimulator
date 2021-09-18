using System;
using Controller;

namespace RaceSimulatie
{
    class Program
    {
        static void Main(string[] args)
        {
            Data.Initialize();
            Data.NextRace();
            Console.WriteLine(Data.CurrentRace.Track.Name);

            for (; ; )
            {
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
