using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Model
{
    public class Driver : IParticipant
    {
        public string Name { get; set; }
        public int DrivenLaps { get; set; }
        public IEquipment Equipment { get; set; }
        public TeamColors TeamColor { get; set; }
        public string Icon { get; set; }
        public bool Finished { get; set; }
        public Section PreviousSection { get; set; }
        public int PassedSections { get; set; }
        public Stopwatch Timer { get; set; }

        public Driver(string name, IEquipment car, TeamColors teamColor, string icon)
        {
            Name = name;
            DrivenLaps = 0;
            Equipment = car;
            TeamColor = teamColor;
            Icon = icon;
            Finished = false;
            PreviousSection = null;
            PassedSections = 0;
        }

        public ConsoleColor GetTeamColorAsConsoleColor()
        {
            return TeamColor switch
            {
                TeamColors.Blue => ConsoleColor.Blue,
                TeamColors.Red => ConsoleColor.Red,
                TeamColors.Green => ConsoleColor.Green,
                TeamColors.White => ConsoleColor.White,
                TeamColors.Yellow => ConsoleColor.Yellow
            };
        }

        public string GetTeamColorAsIcon()
        {
            return TeamColor switch
            {
                TeamColors.Blue => "C:\\RaceSimImages\\TeamColors\\blue.png",
                TeamColors.Red => "C:\\RaceSimImages\\TeamColors\\red.png",
                TeamColors.Green => "C:\\RaceSimImages\\TeamColors\\green.png",
                TeamColors.White => "C:\\RaceSimImages\\TeamColors\\white.png",
                TeamColors.Yellow => "C:\\RaceSimImages\\TeamColors\\yellow.png"
            };
        }
    }
}
