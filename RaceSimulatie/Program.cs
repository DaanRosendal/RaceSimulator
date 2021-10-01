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
            Console.CursorVisible = false;
            Visualizer.DrawTrack(Data.CurrentRace.Track);
            Visualizer.DrawParticipantsInStartPosition(Data.CurrentRace.Track);
            
            for (; ; )
            {
                System.Threading.Thread.Sleep(100);
                Visualizer.HideParticipants(Data.CurrentRace.Track);
                Visualizer.DrawTrack(Data.CurrentRace.Track);
                Visualizer.MoveParticipants(Data.CurrentRace.Track);
                Visualizer.RenderParticipants(Data.CurrentRace.Track);
                Data.CurrentRace.
            }
        }
    }
}
