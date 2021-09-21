using System;
using System.Linq;
using Controller;

namespace RaceSimulatie
{
    class Program
    {
        static void Main(string[] args)
        {
            Data.Initialize();
            Data.NextRace();
            Visualizer.DrawTrack(Data.CurrentRace.Track);
            
            /*Console.WriteLine(Data.CurrentRace.Track.Name);
            for (var i = 0; i < Data.CurrentRace.Track.Sections.Count; i++)
            {
                Console.WriteLine(Data.CurrentRace.Track.Sections.ElementAt(i).SectionType);
            }*/

            for (; ; )
            {
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
